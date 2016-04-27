using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.BLL;


public partial class Webmag_Employe_quitorder_ViewQuitOrder : System.Web.UI.Page
{    
    //搬出预约DAO
    public QuitOrderDAO quitOrderDAO = new QuitOrderDAO();
    //搬出预约表记录
    public List<QuitOrder> quitOrderList = new List<QuitOrder>();
    //数据库数据分页辅助类
    public pageForm page = new pageForm();
    //当前页面显示的页号
    public string pageno;
    //PageBLL处理页面相关信息 
    public PageBLL pageBLL = new PageBLL();

    public bool condition;//是否查询
    public string keyword;//查询关键字
    public string role = "";
    public string action;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
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
                quitOrderList = quitOrderDAO.GetQuitOrderByLessee(keyword, int.Parse(pageno), page.PageSize);
                //quitOrderDAO.searchNum是关键点
                page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), quitOrderDAO.searchNum);
            }
            else
            {
                condition = false;
                //int recordNum = quitOrderDAO.GetTotalRecordNum();
                //page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), recordNum);
                //登陆者为物业（其他模块可以参考修改）
                if (role == "property")
                {
                      action = (Request["action"] != null && Request["action"].ToString().Trim() != "") ? Request["action"].ToString().Trim() : "all";
                      if (action == "all")
                      {
                          int recordNum = quitOrderDAO.GetTotalRecordNum();
                          page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), recordNum);
                          quitOrderList = quitOrderDAO.ListPageQuitOrder(page.PageNo, page.PageSize);
                      }
                      else
                      {
                          int recordNum = quitOrderDAO.GetTotalRecordNumNot();
                          page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), recordNum);
                          quitOrderList = quitOrderDAO.ListPageQuitOrderNot(page.PageNo, page.PageSize);
                      }
                }
                    //quitOrderList = quitOrderDAO.ListPageQuitOrder(page.PageNo, page.PageSize);
                else
                {
                    string userName = Session["UserName"].ToString();
                    int num = quitOrderDAO.GetRecordNumByLesseeName(userName);
                    page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), num); 
                    quitOrderList = quitOrderDAO.ListPageQuitOrderByLesseeName(page.PageNo, page.PageSize,userName);
                }
            }
        }
    }
}