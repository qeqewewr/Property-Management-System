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

public partial class Webmag_Employe_officework_orderwork_ViewRepairTable : System.Web.UI.Page
{
    //搬入预约DAO
    public RepairTableDAO repairTableDAO = new RepairTableDAO();
    //搬入预约表记录
    public List<RepairTable> repairTableList = new List<RepairTable>();
    //数据库数据分页辅助类
    public pageForm page = new pageForm();
    //当前页面显示的页号
    public string pageno;
    //PageBLL处理页面相关信息 
    public PageBLL pageBLL = new PageBLL();
    public bool condition;//是否查询
    public string keyword,endtime;//查询关键字
    //是否有查询条件标志 0:无楼宇无房号;1:有楼宇无房号;2:无楼宇有房号3:有楼宇有房号
    public int cFlag = -1;
    public string role;

    public List<ImgAttachment> imageList = new List<ImgAttachment>();
    public ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            role = Session["Role"].ToString();
            //从页面获取当前页号
            pageno = Request["pageno"];
            //是否进行查询 keyword=楼宇，room=房号
            if (Request["keyword"] != "" && Request["keyword"] != null)
            {
                keyword = Request["keyword"].Trim();
                condition = true;
                page.PageSize = PageBLL.pageSize;
                if (Request["endtime"] != null && Request["endtime"] != "")
                {
                    endtime = Request["endtime"].Trim();
                    cFlag = 3;
                }
                else
                {
                    endtime = "";
                    cFlag = 1;
                }

            }
            else
            {
                //无楼宇有房间号 2
                keyword = "";
                if (Request["endtime"] != null && Request["endtime"] != "")
                {
                    condition = true;
                    endtime = Request["endtime"].Trim();
                    cFlag = 2;
                    page.PageSize = PageBLL.pageSize;

                }
                else    //无楼宇无房间号
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
                //获得表总行数
                int recordNum = repairTableDAO.GetTotalRecordNum();
                //由页号和记录数获得pageForm
                page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), recordNum);
                if (role == "property")
                {
                    repairTableList = repairTableDAO.ListPageRepairTable(page.PageNo, page.PageSize);
                }
                else
                {
                    string userName = Session["UserName"].ToString();
                    int num = repairTableDAO.GetRecordNumByLesseeName(userName);
                    page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), num);
                    repairTableList = repairTableDAO.ListPageRepairTableByLesseeName(page.PageNo, page.PageSize,userName);
                }
            }
            else
            {
                page.PageSize = PageBLL.pageSize;
                //repairTableList = repairTableDAO.GetRepairTablesByBuildingAndRoom(keyword, room, int.Parse(pageno), page.PageSize, cFlag);
                repairTableList = repairTableDAO.GetRepairTablesByTime(keyword, endtime, int.Parse(pageno), page.PageSize, cFlag);
                page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), repairTableDAO.searchNum);
            }
        }
    }

    public string GetString(int repairSatisfaction)
    {
        string temp = "未评";
        switch (repairSatisfaction)
        {
            case 0: temp = "满意"; break;
            case 1: temp = "较满意"; break;
            case 2: temp = "尚可"; break;
            case 3: temp = "不满意"; break;
        }
        return temp;
    }
}