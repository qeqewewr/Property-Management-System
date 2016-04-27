using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model;
using CEMIS.BLL;
using CEMIS.Model.Image;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_earlypre_fitmonitor_DoUpdate : System.Web.UI.Page
{
    public int pageno;
    public string id;
   
    //要跳转到的页面
    public string pageName = "ViewFitMonitor.aspx";

    FitMonitor fitMonitor;
    FitMonitorDAO fitMonitorDAO = new FitMonitorDAO();
    //装修检查时间
    public string checkTime;
    //检查出的主要问题
    public string detail;
    //物业员工号
    public string employeId;
    //用于储存租户违规装修的照片的路径
    public string picturePath;
    //检查是否通过
    public Boolean isPassed;

    public string keyword = "";
    //用于图片更新
    private RoomStyle roomStyle = new RoomStyle();
    private RoomStyleDAO roomStyleDAO = new RoomStyleDAO();
    private ImgAttachment attach = new ImgAttachment();
    private ImgAttachmentDAO attachDAO = new ImgAttachmentDAO();
    public int flagID = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            //获取上传的图片
            HttpFileCollection files = HttpContext.Current.Request.Files;
            //页号
            pageno = int.Parse(Request["pageno"].Trim().ToString());
            id = Request["oldid"].Trim().ToString();

            if (Request["keyword"] != null)
                keyword = Request["keyword"].Trim();

            //从页面获得相关信息   
            checkTime = Request.Form["fitMonitorCheckTime"].Trim();
            detail = Request.Form["detailBody"].Trim();
            employeId = Request.Form["fitMonitorEmployeID"].Trim();
            picturePath = "test";
            string tempIsPassed = Request.Form["fitMonitorIsPassed"].Trim();
            if (tempIsPassed.Equals("已完成"))
                isPassed = true;
            else
                isPassed = false;

            fitMonitor = fitMonitorDAO.GetFitMonitorById(id);

            if (fitMonitor != null)
            {
                fitMonitor.CheckTime = checkTime;
                fitMonitor.Detail = detail;
                fitMonitor.EmployeId = employeId;
                fitMonitor.PicturePath = picturePath;
                fitMonitor.IsPassed = isPassed;
                fitMonitor.IsDeleted = false;
                //更新fitMonitor
                flagID = fitMonitorDAO.UpdateFitMonitor(fitMonitor);
            }

            if (flagID >= 0)
            {
                string lname = "";
                try
                {
                    int flag = -1;
                    //------0：其他浏览器----------1：IE流浪器---待调试
                    for (int i = 1; i < Request.Files.Count; i++)
                    {
                        HttpPostedFile file = Request.Files[i];
                        string type = System.IO.Path.GetExtension(file.FileName);
                        char[] c = { '\\' };
                        string[] nameArray = file.FileName.Split(c);
                        for (int j = 0; j < nameArray.Length; j++)
                        {
                            lname = nameArray[j];
                        }
                        string singlefilename = lname.Substring(0, lname.LastIndexOf('.')) + DateTime.Now.ToString("yyyy-mm-dd-yhh-mm-ss") + type;
                        file.SaveAs(System.Web.HttpContext.Current.Request.MapPath("../../../attachment/") + singlefilename);
                        attach = new ImgAttachment();
                        attach.AddDate = DateTime.Now;
                        attach.AttachName = file.FileName;
                        //装修监督
                        attach.AttachType = 4;
                        attach.AttachUrl = "../../../attachment/" + singlefilename;
                        attach.ModuleID = id.ToString();

                        flag = attachDAO.AddImgAttachment(attach);
                        if (flag < 0)
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新失败!');location.href=('ViewFitMonitor.aspx?pageno=" + pageno + "');</script>");
                    }
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新成功!');location.href=('ViewFitMonitor.aspx?pageno=" + pageno + "');</script>");
                }
                catch (System.Exception Ex)
                {
                    Console.Write(Ex.Message);
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新失败!');history.go(-1);</script>");

            }
        }
    }
}