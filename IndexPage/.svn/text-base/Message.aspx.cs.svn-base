using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;

public partial class Message : System.Web.UI.Page
{
    public MessageReplyDAO messReplyDAO = new MessageReplyDAO();
    public List<MessageReply> messReplyList = new List<MessageReply>();

    public pageForm page = new pageForm();
    public string pageno;

    protected void Page_Load(object sender, EventArgs e)
    {
        pageno = Request["pageno"].ToString();

        page.PageSize = 5;
        page.PageNo = int.Parse(pageno);
      //  page.RowCount = messReplyDAO.GetTotalRecordNum();
        //已发布留言的总数
        page.RowCount = messReplyDAO.GetTotalRecordNumByIsReplyed() ;
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

  //      messReplyList = messReplyDAO.ListPageMessageReply(int.Parse(pageno), page.PageSize);
        //已发布留言列表
        messReplyList = messReplyDAO.ListPageMessageReplyByIsReplyed(int.Parse(pageno), page.PageSize);

    }

    public string GetContent(string str)
    {
        if (str.Length < 11)
            return str.Substring(0, str.Length);
        else
          //  return str.Substring(0, 10);
            return str;
    }

    protected void btnFirst_Click(object sender, EventArgs e)
    {

    }
}
