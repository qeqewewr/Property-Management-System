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
using System.Web.SessionState;

public partial class Webmag_Employe_businadver_ViewFirmAdvertise : System.Web.UI.Page
{    //租户费用
    public FirmAdvertiseDAO firmAdvertiseDAO = new FirmAdvertiseDAO();
    public List<FirmAdvertise> firmAdvertiseList = new List<FirmAdvertise>();
   
    //数据库数据分页辅助类
    public pageForm page = new pageForm();
    //当前页面显示的页号
    public string pageno;
    //PageBLL处理页面相关信息 
    public PageBLL pageBLL = new PageBLL();

    public bool condition;//是否查询
    public string keyword;//查询关键字

    public List<ImgAttachment> imageList = new List<ImgAttachment>();
    public ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();

    public string role = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
        else
        {
            //登陆者角色
            role = Session["Role"].ToString();
            //从页面获取当前页号
            pageno = Request["pageno"];

            //是否进行查询
            if (Request["keyword"] != "" && Request["keyword"] != null)
            {
                keyword = Request["keyword"].Trim();
                condition = true;
                page.PageSize = PageBLL.pageSize;
                firmAdvertiseList = firmAdvertiseDAO.GetFirmAdvertiseListByLesseeName(keyword, int.Parse(pageno), page.PageSize);
                page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), firmAdvertiseDAO.searchNum);
            }
            else
            {
                //如果为租户所有的数据在一页中显示
                condition = false;
                //总行数
                int recordNum = firmAdvertiseDAO.GetTotalRecordNum();
                //由页号和记录数获得pageForm
                page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), recordNum);
                //登陆者为物业（其他模块可以参考修改）
                if (role == "property")
                    firmAdvertiseList = firmAdvertiseDAO.ListPageFirmAdvertise(page.PageNo, page.PageSize);
                else  //登陆者为租户
                {
                    string userName = Session["UserName"].ToString();
                    int num = firmAdvertiseDAO.GetRecordNumByLesseeName(userName);
                    page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), num);
                    firmAdvertiseList = firmAdvertiseDAO.ListPageFirmAdvertiseByLesseeName(page.PageNo, page.PageSize,userName);
                }

            }
        }

       

        
        
    }
}