using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Util;

public partial class Webmag_Employe_surveyManage_surveyAnswerDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
        else
        {
            if (Request["pid"] != null && Request["pid"].ToString().Trim() != "")
            {
                //string pid =Int32.Parse(Request["pid"].ToString()).ToString();
                string pid = Request["pid"].ToString().Trim();
                if (Request["pageno"] != null && Request["pageno"].ToString() != "")
                {
                    Response.Redirect("surveyAnswerView.aspx?pageno=" + Request["pageno"] + "&pid=" + pid);
                }
                else
                {
                    Response.Write("<script>alert('参数无效，请重新操作');</script>");
                    Response.Write("<script>window.location.href='surveyQuestionView.aspx?pid=" + pid + "';</script>");
                }
            }
        }
    }
}