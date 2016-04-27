using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.BLL;
using CEMIS.Model.Image;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_officework_answercomplain_DoUpdate : System.Web.UI.Page
{
    //要跳转到的页面
    public string pageName = "ViewComplainFeedback.aspx";
    public int pageno;
    public string id;
    //用于标志更新是否成功
    public int flagID = -1;
    //tempcomplainFeedback暂存从页面发送过来的更新的数据
    ComplainFeedback complainFeedback, temp;
    ComplainFeedbackDAO complainFeedbackDAO;

    //用于图片更新
    //  private RoomStyle roomStyle = new RoomStyle();
    // private RoomStyleDAO roomStyleDAO = new RoomStyleDAO();
    private ImgAttachment attach = new ImgAttachment();
    private ImgAttachmentDAO attachDAO = new ImgAttachmentDAO();

    public string role = "";
    private void GetComplainFeedback()
    {
        complainFeedback = complainFeedbackDAO.GetComplainFeedbackById(id);

        if (complainFeedback != null)
        {
            if (role == "lessee")
                complainFeedback.ComplainContent = Request.Form["complainContent"].Trim();
            complainFeedback.Director = Request.Form["complainDirector"].Trim();
            complainFeedback.DirectorPhone = Request.Form["complainDirectorPhone"].Trim();
            complainFeedback.ComplainDateTime = Request.Form["complainDateTime"].Trim();
            complainFeedback.PicturePath = "test";
            complainFeedback.DealDateTime = Request.Form["feedbackDateTime"].Trim();
            if (role=="property")
                complainFeedback.DealContent = Request.Form["feedbackDealContent"].Trim();

            string temp = Request.Form["complainFeedbackIsDeal"].ToString();
            int myd = -1;
            if (temp == "较满意")
                myd = 1;
            else if (temp == "尚可")
                myd = 2;
            else if (temp == "不满意")
                myd = 3;
            else if (temp == "满意")
                myd = 0;
            complainFeedback.IsDeal = myd;
            
            flagID = complainFeedbackDAO.UpdateComplainFeedback(complainFeedback);
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            role = Session["Role"].ToString();
            complainFeedback = new ComplainFeedback();
            complainFeedbackDAO = new ComplainFeedbackDAO();
            pageno = int.Parse(Request["pageno"].Trim());
            id = Request["oldid"].Trim().ToString();

            GetComplainFeedback();

            HttpFileCollection files = HttpContext.Current.Request.Files;
            if (flagID >= 0)
            {
                string lname = "";
                try
                {
                    int flag = -1;
                    //for IE
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
                        attach.AttachType = 6;
                        attach.AttachUrl = "../../../attachment/" + singlefilename;
                        attach.ModuleID = id.ToString();
                        flag = attachDAO.AddImgAttachment(attach);
                        if (flag < 0)
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('图片更新失败!');location.href=('UpdateComplainFeedback.aspx?pageno=" + pageno + "');</script>");
                    }
                                         string action = (Request["action"] != null && Request["action"].ToString().Trim() != "") ? Request["action"].ToString().Trim() : "all";
                     if (action == "all")
                     {
                         Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新成功!');location.href=('ViewComplainFeedback.aspx?pageno=" + pageno + "');</script>");
                     }
                     else
                         Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新成功!');location.href=('ViewComplainFeedback.aspx?pageno=" + pageno + "&action="+action+"');</script>");
                }

                //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新成功!');location.href=('ViewComplainFeedback.aspx?pageno=" + pageno + "');</script>");
                //}
                catch (System.Exception Ex)
                {
                    Console.Write(Ex.Message);
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保更新失败!');history.go(-1);</script>");

            }
        }
    }
}