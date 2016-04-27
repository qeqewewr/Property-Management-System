using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Image;

public partial class Webmag_Employe_businadver_DeleteImage : System.Web.UI.Page
{
    private ImgAttachment image = new ImgAttachment();
    private ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();
    private int imageID;
    private string pageno,id;
    private int flag = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
        else
        {
            //FirmAdvertise 主键 标识符
            id = Request["id"];
            imageID = int.Parse(Request["imageID"].ToString());
            pageno = Request["pageno"].ToString();

            image = imageDAO.GetImgAttachmentByID(imageID);

            flag = imageDAO.deleteImgAttachmentByID(imageID);
            System.IO.File.Delete(HttpContext.Current.Request.MapPath(image.AttachUrl));

            if (flag > 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('图片删除成功!');location.href=('UpdateFirmAdvertise.aspx?pageno=" + pageno + "&id=" + id + "');</script>");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('图片删除失败!');history.go(-1);</script>");

            }
        }

    }
}