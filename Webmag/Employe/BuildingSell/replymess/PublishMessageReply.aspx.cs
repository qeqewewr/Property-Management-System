using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.BLL;
using CEMIS.Model.Employe;
using CEMIS.Util;

public partial class Webmag_Employe_BuildingSell_replymess_PublishMessageReply : System.Web.UI.Page
{
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
       
            id = this.Request.QueryString["id"];

            if (Request["pageno"] != null && Request["pageno"] != "")
            {
                pageno = int.Parse(Request["pageno"].Trim());
            }

            int flag = messageReplyDAO.UpdateMessageReplyByIsPublished(id);
            RedirectPage(flag);
        }
    }

    private void RedirectPage(int flag)
    {
        if (flag > 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('留言发布成功!');location.href=('ViewMessageReply.aspx?pageno=" + pageno + "');</script>");
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('留言发布失败!');history.go(-1);</script>");

        }
    }
}