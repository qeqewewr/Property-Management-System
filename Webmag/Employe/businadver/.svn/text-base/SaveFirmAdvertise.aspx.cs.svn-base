using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.BLL;
using CEMIS.Model.Image;

public partial class Webmag_Employe_businadver_SaveFirmAdvertise : System.Web.UI.Page
{
    //用于保存上传的图片
    private RoomStyle roomStyle = new RoomStyle();
    private RoomStyleDAO roomStyleDAO = new RoomStyleDAO();
    private ImgAttachment attach = new ImgAttachment();
    private ImgAttachmentDAO attachDAO = new ImgAttachmentDAO();

    //要跳转到的页名
    public string pageName = "ViewFirmAdvertise.aspx?pageno=1";
    public int pageno = -1;
    public FirmAdvertise firmAdvertise;
    public FirmAdvertiseDAO firmAdvertiseDAO;

    private FirmAdvertise GetFirmAdvertise()
    {
        FirmAdvertise tempFirmAdvertise = new FirmAdvertise();

        tempFirmAdvertise.Lessee = Request.Form["firmAdvertiseLessee"].Trim();
        tempFirmAdvertise.PicturePath = "test";
        tempFirmAdvertise.Describe = Request.Form["detailBody"].Trim();
        tempFirmAdvertise.IsSure = (Request.Form["firmAdvertiseIsSure"].Trim() == "是") ? true : false;
        tempFirmAdvertise.Remarks = Request.Form["firmAdvertiseRemarks"].Trim();
        return tempFirmAdvertise;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
        else
        {
            //用于图片上传
            HttpFileCollection files = HttpContext.Current.Request.Files;

            if (Request["pageno"] != null)
            {
                pageno = int.Parse(Request["pageno"].Trim().ToString());
            }

            firmAdvertiseDAO = new FirmAdvertiseDAO();
            firmAdvertise = GetFirmAdvertise();
            int flagID = firmAdvertiseDAO.AddFirmAdvertise(firmAdvertise);
            if (flagID <= 0)
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");

          //  Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('" + HttpContext.Current.Request.Files.Count + "');</script>");
            string lname = "";
            try
            {
                int flag = -1;
                for (int i = 0; i < Request.Files.Count; i++)
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
                    attach.AttachType = 7;//7企业宣传
                    attach.AttachUrl = "../../attachment/" + singlefilename;
                    attach.ModuleID = flagID.ToString();
                    flag = attachDAO.AddImgAttachment(attach);
                    if (flag < 0)
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('图片保存失败!');location.href=('ViewFirmAdvertise.aspx?pageno=1');</script>");
                }
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('ViewFirmAdvertise.aspx?pageno=1');</script>");
            }
            catch (System.Exception Ex)
            {
                Console.Write(Ex.Message);
            }
        }

    }
}