using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.BLL;

public partial class Webmag_Employe_earlypre_orderremove_ViewOrderRemove : System.Web.UI.Page
{
    //搬入预约DAO
    public OrderMoveInDAO orderMoveInDAO = new OrderMoveInDAO();
    //搬入预约表记录
    public List<OrderMoveIn> orderMoveInList = new List<OrderMoveIn>();
    //数据库数据分页辅助类
    public pageForm page = new pageForm();
    //当前页面显示的页号
    public string pageno;
    //PageBLL处理页面相关信息 
    public PageBLL pageBLL = new PageBLL();
    public bool condition;//是否查询
    public string keyword;//查询关键字

    public string action;


    public string role = "";//用户角色

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            role = Session["Role"].ToString();
            pageno = Request["pageno"];
            //查询情况
            if (Request["keyword"] != "" && Request["keyword"] != null)
            {
                keyword = Request["keyword"].Trim();
                condition = true;
                page.PageSize = PageBLL.pageSize;
                orderMoveInList = orderMoveInDAO.GetOrderMoveInByLessee(keyword, int.Parse(pageno), page.PageSize);
                //orderMoveInDAO.searchNum是关键点
                page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), orderMoveInDAO.searchNum);
            }
            else
            {
                condition = false;

                if (role == "property")
                {

                    action = (Request["action"] != null && Request["action"].ToString().Trim() != "") ? Request["action"].ToString().Trim() : "all";
                    if (action == "all")
                    {
                        int recordNum = orderMoveInDAO.GetTotalRecordNum();
                        page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), recordNum);
                        orderMoveInList = orderMoveInDAO.ListPageOrderMoveIn(page.PageNo, page.PageSize);
                    }
                    else
                    {
                        int num = orderMoveInDAO.GetNotSureRecordNum();
                        page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), num);
                        orderMoveInList = orderMoveInDAO.ListPageOrderMoveInNotSure(page.PageNo, page.PageSize);
                    }
                }
                else
                {
                    string userName = Session["UserName"].ToString();
                    int num = orderMoveInDAO.GetRecordNumByLesseeName(userName);
                    page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), num);
                    orderMoveInList = orderMoveInDAO.ListPageOrderMoveInByLesseeName(page.PageNo, page.PageSize,userName);
                }
            }

        }
       
    }
}