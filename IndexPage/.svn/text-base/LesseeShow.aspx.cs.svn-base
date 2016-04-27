using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Model.Image;
using CEMIS.BLL;

public partial class IndexPage_LesseeShow : System.Web.UI.Page
{
    public FirmAdvertise firm = new FirmAdvertise();
    public FirmAdvertiseDAO firmDAO = new FirmAdvertiseDAO();

    public string id;
    public string pageno;

    public List<ImgAttachment> imagelist = new List<ImgAttachment>();
    public ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();
     public PageBLL pageBLL = new PageBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"].ToString();
        if (Request["pageno"] != null && Request["pageno"] != "")
            pageno = Request["pageno"].ToString();
        else
            pageno = "1";

        firm = firmDAO.GetFirmAdvertiseById(id);
        //获得图片列表
        imagelist = imageDAO.GetImgAttachmentByTypeAndID(7,id);
    }
}