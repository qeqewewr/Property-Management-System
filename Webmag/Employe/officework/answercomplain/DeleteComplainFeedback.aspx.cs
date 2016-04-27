using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.BLL;

public partial class Webmag_Employe_officework_answercomplain_DeleteComplainFeedback : System.Web.UI.Page
{
    public string pageName = "ViewComplainFeedback.aspx";
    public ComplainFeedback complainFeedback;
    public ComplainFeedbackDAO complainFeedbackDAO;
    public int pageno = 1;
    public string id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            complainFeedback = new ComplainFeedback();
            complainFeedbackDAO = new ComplainFeedbackDAO();

            if (Request["pageno"] != null)
                pageno = int.Parse(Request["pageno"].Trim().ToString());
            id = this.Request.QueryString["id"];

            int flag = complainFeedbackDAO.DeleteComplainFeedbackById(id);
            PageBLL pageBLL = new PageBLL();
            pageBLL.RedirectPage(this, pageName, flag, pageno, 0);
        }
    }
}