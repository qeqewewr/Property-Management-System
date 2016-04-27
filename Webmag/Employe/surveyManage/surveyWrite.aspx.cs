using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe.Survey;
using CEMIS.Util.Page;

public partial class Webmag_Employe_surveyManage_surveyWrite : System.Web.UI.Page
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
			if (Request.HttpMethod == "POST")
			{
				//List<SurveyAnswer> list = new List<SurveyAnswer>();
				SurveyAnswer sa;
				int result= 0;
				for (int i = 0; i < Request.Form.Count; i++)
				{
					if (Request.Form.Keys[i].ToString().Substring(0, 2) == "id")
					{
						sa = new SurveyAnswer();
						sa.ID = Request.Form.Keys[i].ToString().Substring(2);
						string value = Request.Form[i].ToString();
						if (value == "A")
							sa.AnswerANum = "1";
						else if (value == "B")
							sa.AnswerBNum = "1";
						else if (value == "C")
							sa.AnswerCNum = "1";
						else if (value == "D")
							sa.AnswerDNum = "1";
						result += (new SurveyAnswerDAO()).UpdateSurveyAnswer(sa);
						
					}
					//Response.Write( Request.Form.Keys[i].ToString() + " = " + Request.Form[i].ToString());
				}
				
				if(result >0 ) 
					Response.Write("<script> alert('提交成功');</script>");
				else
					Response.Write("<script> alert('提交失败，请重试');</script>");
			}

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