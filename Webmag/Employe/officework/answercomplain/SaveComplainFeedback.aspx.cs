using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.BLL;
using CEMIS.Model.Image;

public partial class Webmag_Employe_officework_answercomplain_SaveComplainFeedback : System.Web.UI.Page
{
    //要跳转到的页名
    public string pageName = "ViewcomplainFeedback.aspx?pageno=1";
    public int pageno = -1;
    ComplainFeedback complainFeedback;
    ComplainFeedbackDAO complainFeedbackDAO;

    //用于保存上传的图片到roomStyle-用于测试
    private RoomStyle roomStyle = new RoomStyle();
    private RoomStyleDAO roomStyleDAO = new RoomStyleDAO();
    private ImgAttachment attach = new ImgAttachment();
    private ImgAttachmentDAO attachDAO = new ImgAttachmentDAO();

    public string role = "";
    private ComplainFeedback GetComplainFeedback()
    {
        ComplainFeedback temp = new ComplainFeedback();
        temp.Lessee = Request.Form["complainFeedbackLessee"].Trim();
        temp.BuildingName = Request.Form["complainFeedbackBuildingName"].Trim();
        temp.Room = Request.Form["complainFeedbackRoom"].Trim();
        temp.ComplainContent = Request.Form["complainContent"].Trim();
        temp.Director = Request.Form["complainDirector"].Trim();
        temp.DirectorPhone = Request.Form["complainDirectorPhone"].Trim();
        temp.ComplainDateTime = Request.Form["complainDateTime"].Trim();
        temp.PicturePath = "test";
        if (role == "property")
            temp.DealDateTime = Request.Form["feedbackDateTime"].Trim();
        else
            temp.DealDateTime = "";
        temp.DealContent = Request.Form["feedbackDealContent"].Trim();
        string tempStr = Request.Form["complainFeedbackIsDeal"].Trim();
        int myd = -1;//未评
        if (tempStr == "较满意")
            myd = 1;
        else if (tempStr == "尚可")
            myd = 2;
        else if (tempStr == "不满意")
            myd = 3;
        else if (tempStr == "满意")
            myd = 0;
        temp.IsDeal = myd;
        return temp;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            role = Session["Role"].ToString();
            //用于图片上传
            HttpFileCollection files = HttpContext.Current.Request.Files;

            if (Request["pageno"] != null)
            {
                pageno = int.Parse(Request["pageno"].Trim().ToString());
            }

            complainFeedbackDAO = new ComplainFeedbackDAO();
            complainFeedback = GetComplainFeedback();

            int flagID = complainFeedbackDAO.AddComplainFeedback(complainFeedback);
            if (flagID <= 0)
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");

            string lname = "";
            try
            {
                int flag = -1;
                //for IE
                for (int i = 1; i < Request.Files.Count; i++)
                {
                    HttpPostedFile file = Request.Files[i];
                 //   if (file == null) continue;
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
                    attach.AttachType = 6;//6反馈单
                    attach.AttachUrl = "../../../attachment/" + singlefilename;
                    attach.ModuleID = flagID.ToString();
                    flag = attachDAO.AddImgAttachment(attach);
                    if (flag < 0)
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存图片失败!');location.href=('ViewComplainFeedback.aspx?pageno=1');</script>");

                }
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('ViewComplainFeedback.aspx?pageno=1');</script>");
            }
            catch (System.Exception Ex)
            {
                Console.Write(Ex.Message);
            }

        }
    }
}