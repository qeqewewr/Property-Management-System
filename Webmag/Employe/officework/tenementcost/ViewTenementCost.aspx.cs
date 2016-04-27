using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.BLL;
using System.Web.SessionState;

public partial class Webmag_Employe_officework_tenementcost_ViewTenementCost : System.Web.UI.Page
{
    //租户费用
    public TenementCostDAO tenementCostDAO = new TenementCostDAO();
    public List<TenementCost> tenementCostList = new List<TenementCost>();
    //费用类型
    public FeeTypeDAO feeTypeDAO = new FeeTypeDAO();
    public List<FeeType> feeTypeList = new List<FeeType>();
    //数据库数据分页辅助类
    public pageForm page = new pageForm();
    //当前页面显示的页号
    public string pageno;
    //PageBLL处理页面相关信息 
    public PageBLL pageBLL = new PageBLL();
    public bool condition;//是否查询
    public string keyword, feeMonth;//查询关键字 租户和费用月份
    //是否有查询条件标志 0:无租户无费用月份;1:有租户无费用月份;2:无租户有费用月份3:有租户有费用月份
    public int cFlag = -1;
    public string role = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            role = Session["Role"].ToString();
            //从页面获取当前页号
            pageno = Request["pageno"];
            feeTypeList = feeTypeDAO.ListFeeType();
 
            //是否进行查询 keyword=租户，feeMonth=费用月份
            if (Request["keyword"] != "" && Request["keyword"] != null)
            {
                keyword = Request["keyword"].Trim();
                condition = true;
                page.PageSize = PageBLL.pageSize;
                if (Request["feeMonth"] != null && Request["feeMonth"] != "")
                {
                    feeMonth = Request["feeMonth"].Trim();
                    cFlag = 3;
                }
                else
                {
                    feeMonth = "";
                    cFlag = 1;
                }

            }
            else
            {
                //无租户有费用月份 2
                keyword = "";
                if (Request["feeMonth"] != null && Request["feeMonth"] != "")
                {
                    condition = true;
                    feeMonth = Request["feeMonth"].Trim();
                    cFlag = 2;
                    page.PageSize = PageBLL.pageSize;

                }
                else    //无租户无费用月份
                {
                    page.PageSize = PageBLL.pageSize;
                    condition = false;
                    cFlag = 0;
                }
            }

            //未进行查询
            if (cFlag == 0)
            {
                page.PageSize = PageBLL.pageSize;
                //总行数
                int recordNum = tenementCostDAO.GetTotalRecordNum();
                //由页号和记录数获得pageForm
                page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), recordNum);
                if (role == "property")
                {
                    tenementCostList = tenementCostDAO.ListPageTenementCost(page.PageNo, page.PageSize);
                }
                else
                {
                    string userName = Session["UserName"].ToString();
                    int num = tenementCostDAO.GetRecordNumByLesseeName(userName);
                    page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), num);
                    tenementCostList = tenementCostDAO.ListPageTenementCostByLesseeName(page.PageNo, page.PageSize,userName);
                }
            }
            else
            {
                page.PageSize = PageBLL.pageSize;
                //-------待修改
                tenementCostList = tenementCostDAO.GetTenementCostsByLesseeAndStartDate(keyword, feeMonth, int.Parse(pageno), page.PageSize, cFlag);
                page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), tenementCostDAO.searchNum);
            }
        }
    }
}