using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe.Survey;
using CEMIS.Util.Page;

public partial class Webmag_Employe_surveyManage_surveyAnswerView : System.Web.UI.Page
{

    public Survey survey = new Survey();
    public List<SurveyQuestion> surveyQuestionLists = new List<SurveyQuestion>();
    public List<SurveyAnswer> surveyAnswerLists = new List<SurveyAnswer>();
    public SurveyQuestionDAO surveyQuestionDAO = new SurveyQuestionDAO();
    public SurveyAnswerDAO surveyAnswerDAO = new SurveyAnswerDAO();
    public pageForm page = new pageForm();
    public string pageno;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
        else
        {
            if (Request["pid"] == null || Request["pid"].ToString().Trim() == "")
            {
                Response.Write("<script>alert('页面参数出错，请重试')</script>");
                Response.Write("<script>window.location.href='surveyView.aspx'</script>");
                Response.End();
            }
            else
            {
                string pid = Request["pid"].ToString().Trim();
                Survey sq = (new SurveyDAO()).GetSurvey(pid);
                if (sq != null)
                {
                    survey = sq;
                    pageno = Request["pageno"];
                    if (pageno == null) pageno = "1";
                    page.RowCount = surveyQuestionDAO.GetTotalRecordNum(survey.ID);
                    page.PageSize = 10;
                    page.PageNo = int.Parse(pageno);

                    //确定总的页面数
                    int a = page.RowCount % page.PageSize;
                    if (a == 0)
                    {
                        if (page.RowCount == 0)
                            page.PageCount = 1;
                        else
                            page.PageCount = page.RowCount / page.PageSize;
                    }
                    else
                        page.PageCount = page.RowCount / page.PageSize + 1;

                    //读取当前页的部门信息列表
                    surveyQuestionLists = surveyQuestionDAO.ListPageSurveyQuestion(page.PageNo, page.PageSize, survey.ID);
                    surveyAnswerLists = surveyAnswerDAO.ListPageSurveyAnswer(page.PageNo, page.PageSize, survey.ID);
                    if (surveyQuestionLists.Count != surveyAnswerLists.Count)
                    {
                        Response.Write("<script>alert('页面参数出错，请重试')</script>");
                        Response.Write("<script>window.location.href='surveyView.aspx'</script>");
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("<script>alert('页面参数出错，请重试')</script>");
                    Response.Write("<script>window.location.href='surveyView.aspx'</script>");
                    Response.End();
                }

            }
        }
    }
}