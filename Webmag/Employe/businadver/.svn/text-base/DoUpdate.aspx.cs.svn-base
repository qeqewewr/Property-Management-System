using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.BLL;
using CEMIS.Model.Employe;
using CEMIS.Util;
using CEMIS.Model.Image;

public partial class Webmag_Employe_businadver_DoUpdate : System.Web.UI.Page
{    
    //要跳转到的页面
    public string pageName = "ViewFirmAdvertise.aspx";
    public int pageno;
    public string id;
    //用于标志更新是否成功
    public int flagID = -1;
    FirmAdvertise firmAdvertise;
    FirmAdvertiseDAO firmAdvertiseDAO;
    TimeUntil timeUtil = new TimeUntil();

    //用于图片更新
    private RoomStyle roomStyle = new RoomStyle();
    private RoomStyleDAO roomStyleDAO = new RoomStyleDAO();
    private ImgAttachment attach = new ImgAttachment();
    private ImgAttachmentDAO attachDAO = new ImgAttachmentDAO();

    public string role = "";
    private void GetFirmAdvertise()
    {
        firmAdvertise = firmAdvertiseDAO.GetFirmAdvertiseById(id);
        if (firmAdvertise != null)
        {
            firmAdvertise.Lessee = Request.Form["firmAdvertiseLessee"].Trim();
            firmAdvertise.PicturePath = "test";
            //租户才可修改光大动态
            if(role=="lessee")
                firmAdvertise.Describe = Request.Form["detailBody"].Trim();

            firmAdvertise.IsSure = (Request.Form["firmAdvertiseIsSure"].Trim() == "是") ? true : false;
            firmAdvertise.Remarks = Request.Form["firmAdvertiseRemarks"].Trim();
            flagID = firmAdvertiseDAO.UpdateFirmAdvertise(firmAdvertise);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
        else
        {
            role = Session["Role"].ToString();
            //获取上传的图片
            HttpFileCollection files = HttpContext.Current.Request.Files;
            firmAdvertise = new FirmAdvertise();
            firmAdvertiseDAO = new FirmAdvertiseDAO();
            pageno = int.Parse(Request["pageno"].Trim());
            id = Request["oldid"].Trim().ToString();

            GetFirmAdvertise();

            if (flagID >= 0)
            {
                string lname = "";
                try
                {
                    int flag = -1;
                    //i 0或者1
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
                        file.SaveAs(System.Web.HttpContext.Current.Request.MapPath("../../attachment/") + singlefilename);
                        attach = new ImgAttachment();
                        attach.AddDate = DateTime.Now;
                        attach.AttachName = file.FileName;
                        attach.AttachType = 7;
                        attach.AttachUrl = "../../attachment/" + singlefilename;
                        attach.ModuleID = id.ToString();

                        flag = attachDAO.AddImgAttachment(attach);
                        if (flag < 0)
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('图片更新失败!');location.href=('UpdateFirmAdvertise.aspx?pageno=" + pageno + "');</script>");
                    }

                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新成功!');location.href=('ViewFirmAdvertise.aspx?pageno=" + pageno + "');</script>");
                }
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