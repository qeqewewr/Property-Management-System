using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.BLL;

public partial class Webmag_Employe_BuildingSell_replymess_ViewMessageReply : System.Web.UI.Page
{
    //发布通知
    public MessageReplyDAO messageReplyDAO = new MessageReplyDAO();
    public List<MessageReply> messageReplyList = new List<MessageReply>();
  
    //数据库数据分页辅助类
    public pageForm page = new pageForm();
    //当前页面显示的页号
    public string pageno;
    //PageBLL处理页面相关信息 
    public PageBLL pageBLL = new PageBLL();
    public bool condition;//是否查询
    public string keyword;//查询关键字
    public string endtime;
    //0:无开始无结束时间1:有开始无结束2:无开始有结束3：有开始有结束
    public int flag = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            if (Request["pageno"] != null && Request["pageno"]　!="")
            pageno = Request["pageno"].Trim();

            if (Request["keyword"] != "" && Request["keyword"] != null)
            {
                condition = true;
                //开始时间
                keyword = Request["keyword"].Trim();
                if (Request["endtime"].Trim() != null && Request["endtime"].Trim() != "")
                {
                    //结束时间
                    endtime = Request["endtime"].Trim();
                    flag = 3;
                }
                else
                {
                    endtime = "";
                    flag = 1;
                }

            }
            else
            {
                keyword = "";
                if (Request["endtime"] != null && Request["endtime"] != "")
                {
                    //结束时间
                    endtime = Request["endtime"].Trim();
                    flag = 2;
                    condition = true;
                }
                else
                {
                    endtime = "";
                    flag = 0;
                    condition = false;
                }

            }

            if (flag == 0)
            {
                //总行数
                int recordNum = messageReplyDAO.GetTotalRecordNum();
                //由页号和记录数获得pageForm
                page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), recordNum);
                messageReplyList = messageReplyDAO.ListPageMessageReply(page.PageNo, page.PageSize);
            }
            else
            {
                page.PageSize = PageBLL.pageSize;
                messageReplyList = messageReplyDAO.GetMessageReplysByTime(keyword, endtime, int.Parse(pageno), page.PageSize, flag);
                page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), messageReplyDAO.searchNum);
            }

           
        }
    }
}