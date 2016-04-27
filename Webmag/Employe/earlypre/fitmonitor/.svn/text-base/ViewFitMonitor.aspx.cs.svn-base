using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.BLL;
using CEMIS.Model.Image;

public partial class Webmag_Employe_earlypre_fitmonitor_ViewFitMonitor : System.Web.UI.Page
{
    //装修监督DAO
    public FitMonitorDAO fitMonitorDAO = new FitMonitorDAO();
    //装修监督表记录
    public List<FitMonitor> fitMonitorList = new List<FitMonitor>();
    //数据库数据分页辅助类
    public pageForm page = new pageForm();
    //当前页面显示的页号
    public string pageno;
    //PageBLL处理页面相关信息 
    public PageBLL pageBLL = new PageBLL();

    public List<ImgAttachment> imageList = new List<ImgAttachment>();
    public ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();
    public bool condition;//是否查询
    public string keyword;//查询关键字

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
            int bKeyword = 0;
            if (Request["keyword"] != "" && Request["keyword"] != null)
            {
                keyword = Request["keyword"].Trim();
                if (Request["keyword"].Trim() == "全部")
                    bKeyword = 0;  
                else if(Request["keyword"].Trim() == "在装修")
                    bKeyword = 1;
                else
                    bKeyword = 2;
            }

            ///查询全部
            if (bKeyword == 0)
            {
                condition = false;
                int recordNum = fitMonitorDAO.GetTotalRecordNum();
                //由页号和记录数获得pageForm
                page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), recordNum);
                //由当前页号和每页大小获得list<fitMonitor>
                if (role == "property")
                    fitMonitorList = fitMonitorDAO.ListPageFitMonitor(page.PageNo, page.PageSize);
                else
                {
                    string userName = Session["UserName"].ToString();
                    int num = fitMonitorDAO.GetRecordNumByLesseeName(userName);
                    page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), num);
                    fitMonitorList = fitMonitorDAO.ListPageFitMonitorByLesseeName(page.PageNo, page.PageSize,userName);

                }

            }
            else 
            {
                fitMonitorList = new List<FitMonitor>();
                condition = true;
                page.PageSize = PageBLL.pageSize;
                fitMonitorList = fitMonitorDAO.GetFitMonitorByIsPassed(bKeyword, int.Parse(pageno), page.PageSize);
                //fitMonitorDAO.searchNum是关键点
                page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), fitMonitorDAO.searchNum);
            }
            /*
            //是否进行查询
            if (Request["keyword"] != "" && Request["keyword"] != null)
            {
                fitMonitorList = new List<FitMonitor>();
                keyword = Request["keyword"].Trim();
                condition = true;
                page.PageSize = PageBLL.pageSize;
                fitMonitorList = fitMonitorDAO.GetFitMonitorByLessee(keyword, int.Parse(pageno), page.PageSize);
                //fitMonitorDAO.searchNum是关键点
                page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), fitMonitorDAO.searchNum);
            }
            else
            {
                condition = false;
                int recordNum = fitMonitorDAO.GetTotalRecordNum();
                //由页号和记录数获得pageForm
                page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), recordNum);
                //由当前页号和每页大小获得list<fitMonitor>
                fitMonitorList = fitMonitorDAO.ListPageFitMonitor(page.PageNo, page.PageSize);
            }
             */
        }
    }

    public string GetString(Boolean b)
    {
        return (b == true) ? "已完成" : "在装修";
    }

  
}