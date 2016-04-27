using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.BLL;
using CEMIS.Model.Image;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_earlypre_fitmonitor_SaveFitMonitorInfo : System.Web.UI.Page
{
    public int pageno;
    //要跳转页到的页名
    public string pageName = "ViewFitMonitor.aspx";
    FitMonitor fitMonitor;
    FitMonitorDAO fitMonitorDAO;
    //租户
    public string lessee;
    //楼宇号
    public string buildingName;
    //房间号
    public string room;
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
    //申请报修时间
    public string applyTime = "";
    //用于保存上传的图片
    private RoomStyle roomStyle = new RoomStyle();
    private RoomStyleDAO roomStyleDAO = new RoomStyleDAO();
    private ImgAttachment attach = new ImgAttachment();
    private ImgAttachmentDAO attachDAO = new ImgAttachmentDAO();

    public string role = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            role = Session["Role"].ToString();
            if (Request["pageno"] != null)
            {
                pageno = int.Parse(Request["pageno"].Trim());
            }
            fitMonitor = new FitMonitor();
            fitMonitorDAO = new FitMonitorDAO();

            lessee = Request.Form["fitMonitorLessee"].Trim();
            buildingName = Request.Form["fitMonitorBuildingName"].Trim();
            room = Request.Form["fitMonitorRoom"].Trim();
            if (role == "property")
            {
                checkTime = Request.Form["fitMonitorCheckTime"].Trim();
            }
            else
                checkTime = "1900/01/01 00:00:00";
            if (role == "property")
                detail = Request.Form["detailBody"].Trim();
            else
                detail = "";
            if (role == "property")
                employeId = Request.Form["fitMonitorEmployeID"].Trim();
            else
                employeId = "";
            picturePath = "ABC";//---------------临时数据
            if (role == "property")
            {
                string tempIsPassed = Request.Form["fitMonitorIsPassed"].Trim();
                isPassed = (tempIsPassed.Equals("已完成") == true) ? true : false;
            }
            else
                isPassed = false;

            applyTime = Request.Form["fitMonitorApplyTime"].Trim();
      
            fitMonitor.Lessee = lessee;
            fitMonitor.BuildingName = buildingName;
            fitMonitor.Room = room;
            fitMonitor.CheckTime = checkTime;
            fitMonitor.Detail = detail;
            fitMonitor.EmployeId = employeId;
            fitMonitor.PicturePath = picturePath;
            fitMonitor.IsPassed = isPassed;
            fitMonitor.IsDeleted = false;//false代表假删
            fitMonitor.ApplyMaintain = applyTime;
            //获得图片
            HttpFileCollection files = HttpContext.Current.Request.Files;

            //获得主键
            int flagID = fitMonitorDAO.AddFitMonitor(fitMonitor);
            if (flagID > 0)
            {
                
                string lname = "";
                try
                {
               //     int k = (Request.Files[0] == null) ? 0 : 1;
            //        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert(" + Request.Files.Count + ");</script>");
                    //上传图片
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
                        //44444444装修监督
                        attach.AttachType = 4;
                        attach.AttachUrl = "../../../attachment/" + singlefilename;
                        attach.ModuleID = flagID.ToString();

                        attachDAO.AddImgAttachment(attach);
                  
                    }
                    
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('ViewFitMonitor.aspx?pageno=1');</script>");
                }
                catch (System.Exception Ex)
                {
                    Console.Write(Ex.Message);
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");
            }
        }
    }
}
