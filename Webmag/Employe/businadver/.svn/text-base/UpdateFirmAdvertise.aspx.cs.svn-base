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

public partial class Webmag_Employe_businadver_UpdateFirmAdvertise : System.Web.UI.Page
{
    public string id;
    public FirmAdvertise firmAdvertise;
    public FirmAdvertiseDAO firmAdvertiseDAO;
    public string pageno;

    public LesseeDAO lesseeDAO;
    public List<Lessee> lesseeList;

    public ImgAttachment image = new ImgAttachment();
    public ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();
    public List<ImgAttachment> imageList = new List<ImgAttachment>();

    public string role = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
        else
        {
            //登陆者角色
            role = Session["Role"].ToString();
            //用于在页面显示租户姓名
            lesseeDAO = new LesseeDAO();
            lesseeList = lesseeDAO.ListExistLessee();

            firmAdvertiseDAO = new FirmAdvertiseDAO();

            id = this.Request.QueryString["id"].Trim();
            pageno = Request["pageno"];

            //39行
            firmAdvertise = firmAdvertiseDAO.GetFirmAdvertiseById(id);

            imageList = imageDAO.GetImgAttachmentByTypeAndID(7, id);
        }
    }
}