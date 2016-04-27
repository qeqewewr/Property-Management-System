using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe.Survey;
using CEMIS.Util.Page;

public partial class Webmag_Employe_surveyManage_surveyView : System.Web.UI.Page
{
    public List<Survey> surveys = new List<Survey>();
    public SurveyDAO surveysdao = new SurveyDAO();
    public pageForm page = new pageForm();
    public string pageno;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
        else
        {
            pageno = Request["pageno"];
            if (pageno == null) pageno = "1";
            page.RowCount = surveysdao.GetTotalRecordNum();
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
            surveys = surveysdao.ListPageSurvey(page.PageNo, page.PageSize);
        }
    }
}