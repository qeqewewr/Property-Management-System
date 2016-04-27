using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.BLL;

public partial class Webmag_Employe_officework_orderwork_ViewOrderWork : System.Web.UI.Page
{
    //加班预约
    public OrderWorkDAO orderWorkDAO = new OrderWorkDAO();
    public List<OrderWork> orderWorkList = new List<OrderWork>();

    //数据库数据分页辅助类
    public pageForm page = new pageForm();
    //当前页面显示的页号
    public string pageno;
    //PageBLL处理页面相关信息 
    public PageBLL pageBLL = new PageBLL();

    public bool condition;//是否查询
    public string keyword;//查询关键字

    public string role;
    public string action;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            role = Session["Role"].ToString();
            //从页面获取当前页号
            pageno = Request["pageno"];
            if (Request["keyword"] != "" && Request["keyword"] != null)
            {
                keyword = Request["keyword"].Trim();
                condition = true;
                page.PageSize = PageBLL.pageSize;
                orderWorkList = orderWorkDAO.GetOrderWorksByLeessee(keyword, int.Parse(pageno), page.PageSize);
                page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), orderWorkDAO.searchNum);
            }
            else
            {
                condition = false;
                //int recordNum = orderWorkDAO.GetTotalRecordNum();
                ////由页号和记录数获得pageForm
                //page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), recordNum);
                if (role == "property")
                {
                    //orderWorkList = orderWorkDAO.ListPageOrderWork(page.PageNo, page.PageSize);
                    action = (Request["action"] != null && Request["action"].ToString().Trim() != "") ? Request["action"].ToString().Trim() : "all";
                    if (action == "all")
                    {
                        int recordNum = orderWorkDAO.GetTotalRecordNum();
                        //由页号和记录数获得pageForm
                        page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), recordNum);

                        orderWorkList = orderWorkDAO.ListPageOrderWork(page.PageNo, page.PageSize);
                    }
                    else
                    {
                        int recordNum = orderWorkDAO.GetTotalRecordNumNot();
                        //由页号和记录数获得pageForm
                        page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), recordNum);

                        orderWorkList = orderWorkDAO.ListPageOrderWorkNot(page.PageNo, page.PageSize);
                    }
                }
                else
                {
                    string lesseeName = Session["UserName"].ToString();
                    int num = orderWorkDAO.GetRecordNumByLesseeName(lesseeName);
                    page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), num);
                    orderWorkList = orderWorkDAO.ListPageOrderWorkByLesseeName(page.PageNo, page.PageSize, lesseeName);
                }
            }
        }
    }
}