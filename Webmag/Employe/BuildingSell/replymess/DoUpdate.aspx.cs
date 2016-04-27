using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.BLL;
using CEMIS.Model.Employe;
using CEMIS.Util;

public partial class Webmag_Employe_BuildingSell_replymess_DoUpdate : System.Web.UI.Page
{
    //要跳转到的页面
    public string pageName = "ViewMessageReply.aspx";
    public int pageno;
    public string id;
    //用于标志更新是否成功
    public int flag = -1;
    MessageReply messageReply;
    MessageReplyDAO messageReplyDAO;


    private void GetMessageReply()
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {

            messageReply = messageReplyDAO.GetMessageReplyById(id);
            if (messageReply != null)
            {
                if (Request.Form["messageLeaveTime"] != null && Request.Form["messageLeaveTime"] != "")
                    messageReply.LeaveTime = DateTime.Parse(Request.Form["messageLeaveTime"].Trim());
                messageReply.LeaveMessage = Request.Form["leaveMessage"].Trim();
                messageReply.ReplyTime = DateTime.Now;
                messageReply.Reply = Request.Form["replyMessage"].Trim();
                messageReply.IsReplyed = (Request.Form["messageIsReplyed"].Trim() == "是") ? true : false;
                flag = messageReplyDAO.UpdateMessageReply(messageReply);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        messageReply = new MessageReply();
        messageReplyDAO = new MessageReplyDAO();
        pageno = int.Parse(Request["pageno"].Trim().ToString());
        id = Request["oldid"].Trim().ToString();

        GetMessageReply();

        //页面重定向
        PageBLL pageBLL = new PageBLL();
        pageBLL.RedirectPage(this, pageName, flag, pageno, 1);
    }
}