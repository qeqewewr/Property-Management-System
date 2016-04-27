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

public partial class Webmag_Employe_businadver_facebox : System.Web.UI.Page
{
    public string detail = "";
    public string id;
    public FirmAdvertiseDAO firmAdvertiseDAO;
    public FirmAdvertise firmAdvertise;

 //   public List<ImgAttachment> imageList = new List<ImgAttachment>();
  //  public ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
        else
        {
            id = Request["id"];
            firmAdvertiseDAO = new FirmAdvertiseDAO();
            firmAdvertise = firmAdvertiseDAO.GetFirmAdvertiseById(id);
            detail = firmAdvertise.Describe;
        //    imageList = imageDAO.GetImgAttachmentByTypeAndID(7, id);
        }
    }
}