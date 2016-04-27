using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;

public partial class IndexPage_SaveMessage : System.Web.UI.Page
{
    private MessageReply mesg = new MessageReply();
    private MessageReplyDAO mesgDAO = new MessageReplyDAO();

    private DateTime leaveTime;
    private string leaveMessage;

    protected void Page_Load(object sender, EventArgs e)
    {
        leaveTime = DateTime.Now;

        if (Request["Message"] != null && Request["Message"] != "")
            leaveMessage = Request["Message"].Trim();
        else
            leaveMessage = "无";

        int flag = mesgDAO.AddMessageReply(leaveMessage, leaveTime);

        if (flag > 0)
        {

            //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('恭喜您,您的留言成功!');location.href=('Message.aspx?pageno=1');</script>");
            Response.Write("success");
        }
        else
        {
           // Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('对不起,您的留言失败!');history.go(-1);</script>");
            Response.Write("error");

        }
    }
}