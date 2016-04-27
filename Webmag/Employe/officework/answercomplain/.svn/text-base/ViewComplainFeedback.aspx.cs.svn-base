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

public partial class Webmag_Employe_officework_answercomplain_ViewComplainFeedback : System.Web.UI.Page
{
    //租户费用
    public ComplainFeedbackDAO complainFeedbackDAO = new ComplainFeedbackDAO();
    public List<ComplainFeedback> complainFeedbackList = new List<ComplainFeedback>();

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
            if (Request["keyword"] != "" && Request["keyword"] != null)
            {
                keyword = Request["keyword"].Trim();
                condition = true;
                page.PageSize = PageBLL.pageSize;
                complainFeedbackList = complainFeedbackDAO.GetComplainFeedbacksByLeessee(keyword, int.Parse(pageno), page.PageSize);
                page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), complainFeedbackDAO.searchNum);
            }
            else
            {
                condition = false;
                //int recordNum = complainFeedbackDAO.GetTotalRecordNum();
                ////由页号和记录数获得pageForm
                //page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), recordNum);
                if (role == "property")
                {
                    //complainFeedbackList = complainFeedbackDAO.ListPageComplainFeedback(page.PageNo, page.PageSize);
                    action = (Request["action"] != null && Request["action"].ToString().Trim() != "") ? Request["action"].ToString().Trim() : "all";
                    if (action == "all")
                    {
                        int recordNum = complainFeedbackDAO.GetTotalRecordNum();
                        //由页号和记录数获得pageForm
                        page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), recordNum);
                        complainFeedbackList = complainFeedbackDAO.ListPageComplainFeedback(page.PageNo, page.PageSize);
                    }
                    else
                    {
                        int recordNum = complainFeedbackDAO.GetNotBackTotalRecordNum();
                        //由页号和记录数获得pageForm
                        page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), recordNum);
                        complainFeedbackList = complainFeedbackDAO.ListPageComplainFeedbackNot(page.PageNo, page.PageSize);
                    }
                }
                else
                {
                    string userName = Session["UserName"].ToString();
                    int num = complainFeedbackDAO.GetRecordNumByLesseeName(userName);
                    page = pageBLL.GetPageByPagenoAndRecordNum(int.Parse(pageno), num);
                    complainFeedbackList = complainFeedbackDAO.ListPageComplainFeedbackByLesseeName(page.PageNo, page.PageSize, userName);
                }
            }
        }
    }

    public string GetString(int satisfaction)
    {
        string temp = "未评";
        switch (satisfaction)
        {
            case 0: temp = "满意"; break;
            case 1: temp = "较满意"; break;
            case 2: temp = "尚可"; break;
            case 3: temp = "不满意"; break; 
        }
        return temp;
    }
}