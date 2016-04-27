using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.BLL;
using CEMIS.Model.Employe;
using CEMIS.Util;

public partial class Webmag_Employe_BuildingSell_replymess_DeletePageInfo : System.Web.UI.Page
{
    protected string pageName = "ViewMessageReply.aspx";
    protected MessageReplyDAO MessageReplyDAO;
    protected int pageno;
    protected int flag;
    protected List<MessageReply> MessageReplylist;
    protected PageBLL pageBLL = new PageBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            string keyword = "", endtime = "";
           
            if (Request.Form["keyword"] != "" && Request.Form["keyword"] != null)
                keyword = Request.Form["keyword"].Trim();
            if (Request.Form["endtime"] != "" && Request.Form["endtime"] != null)
                endtime = Request.Form["endtime"].Trim();
            MessageReplyDAO = new MessageReplyDAO();//---------------00
            //表的总记录数
            int recordNum = int.Parse(Request["rowcount"].Trim());

            //进行页面跳转
            if (Request.Form["pageno"] != null)
            {
                string page = Request.Form["pageno"].Trim();
                pageno = int.Parse(page);
                Response.Redirect(pageName + "?pageno=" + pageno + "&keyword=" + keyword + "&endtime=" + endtime + "");
            }
            else
            {
                string id = Request["id"];
                //删除单条记录
                if (id != null)
                {
                    int pagesize = int.Parse(Request["pagesize"]);
                    pageno = int.Parse(Request["pageno"]);
                    pageno = pageBLL.CheckBoxDeleteOneRecord(pagesize, pageno, recordNum);
                    flag = MessageReplyDAO.DeleteMessageReplyById(id);//------------- 11

                }
                else //删除多条记录
                {
                    int size = int.Parse(Request["size"]);
                    pageno = int.Parse(Request["page"]);
                    string ids = Request["selectDel"];
                    char[] separtor = { ',' };
                    if (ids == null || ids == "")
                    {
                        Response.Redirect(pageName + "?pageno=" + pageno + "&keyword=" + keyword + "&endtime=" + endtime + "");
                    }
                    string[] idArray = ids.Split(separtor);

                    pageno = pageBLL.CheckBoxDeleteRecord(size, pageno, recordNum, idArray.Length);
                    for (int i = 0; i < idArray.Length; i++)
                    {
                        flag = MessageReplyDAO.DeleteMessageReplyById(idArray[i]);//------------------22
                        if (flag <= 0)
                            break;

                    }
                }
                pageBLL.RedirectPage(this, pageName, flag, pageno, 0);
            }
        }
    }
}