using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util;
using CEMIS.BLL;

public partial class Webmag_Employe_BuildingSell_replymess_UpdateMessageReply : System.Web.UI.Page
{
    public string id;
    public MessageReply messageReply;
    public MessageReplyDAO messageReplyDAO;
    public string pageno;



    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            messageReplyDAO = new MessageReplyDAO();

            id = Request.QueryString["id"];
            pageno = Request["pageno"];
            messageReply = messageReplyDAO.GetMessageReplyById(id);
        }
    }

}