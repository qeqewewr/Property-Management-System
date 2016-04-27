using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.BLL;
using CEMIS.Model.Employe;
using CEMIS.Util;
using CEMIS.Model.Image;

public partial class Webmag_Employe_officework_answercomplain_facebox : System.Web.UI.Page
{
    public string detail;
    public string id,flag;
    public ComplainFeedbackDAO complainFeedbackDAO;
    public ComplainFeedback complainFeedback;

 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            id = Request["id"];
            flag = Request["flag"];
            complainFeedbackDAO = new ComplainFeedbackDAO();
            complainFeedback = complainFeedbackDAO.GetComplainFeedbackById(id);
            detail = (flag == "0") ? complainFeedback.ComplainContent : complainFeedback.DealContent;
        }
    }
}