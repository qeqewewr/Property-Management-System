using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.BLL;
using CEMIS.Model.Employe;
using CEMIS.Util;

public partial class Webmag_Employe_BuildingSell_replymess_DeleteMessageReply : System.Web.UI.Page
{

    public string pageName = "ViewMessageReply.aspx";
    public MessageReply messageReply;
    public MessageReplyDAO messageReplyDAO;
    public int pageno = 1;
    public string id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            messageReply = new MessageReply();
            messageReplyDAO = new MessageReplyDAO();
            /*
            if (Request["pageno"] != null && Request["pageno"] != "")
                pageno = int.Parse(Request["pageno"].ToString());
             * */
            id = this.Request.QueryString["id"];

            int flag = messageReplyDAO.DeleteMessageReplyById(id);
            PageBLL pageBLL = new PageBLL();
            pageBLL.RedirectPage(this, pageName, flag, pageno, 0);
        }
    }
}