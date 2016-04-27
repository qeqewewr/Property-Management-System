using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Model.Image;
using CEMIS.BLL;

public partial class IndexPage_ShowNews : System.Web.UI.Page
{
    public News news = new News();
    public NewsDAO newsDAO = new NewsDAO();

    public string id;
    public string pageno;

    //用于显示新闻图片
    public List<ImgAttachment> imagelist = new List<ImgAttachment>();
    public ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();
    public ImgAttachment image = new ImgAttachment();
    public PageBLL pageBLL = new PageBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"].ToString();
        pageno = Request["pageno"].ToString();

        news = newsDAO.GetNewsByID(int.Parse(id));

        //获得图片列表,用于主页显示--3代表广大动态
        imagelist = imageDAO.GetImgAttachmentByTypeAndID(9, id);

    }
}