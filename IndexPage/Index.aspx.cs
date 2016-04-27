using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using CEMIS.Model.Employe;
using CEMIS.Model.Image;
using CEMIS.BLL;

public partial class Master_Index : System.Web.UI.Page
{
    public List<News> newsImageList = new List<News>();
    public List<News> newsList = new List<News>();
    public NewsDAO newsDAO = new NewsDAO();

    //企业特色
    public List<ImgAttachment> firmImageList = new List<ImgAttachment>();
    public ImgAttachmentDAO firmImageDAO = new ImgAttachmentDAO();

    public List<ImgAttachment> imageList = new List<ImgAttachment>();
    public ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();

    public FirmAdvertiseDAO firmAdvertiseDAO = new FirmAdvertiseDAO();
    public List<FirmAdvertise> firmAdvertiseList = new List<FirmAdvertise>();

    public string path = "";
    public string pageno = "";
    public PageBLL pageBLL = new PageBLL();
    public List<string> urls = new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["pageno"] != null && Request["pageno"] != "")
            pageno = Request["pageno"].Trim();
        //动态图片
        newsImageList = newsDAO.LunBoNews();
        List<ImgAttachment> img = new List<ImgAttachment>();
        for (int i = 0; i < newsImageList.Count; i++)
        {
            img = imageDAO.GetImgAttachmentByTypeAndID(9, newsImageList[i].ID.ToString());
            if (img.Count != 0)
            {
                imageList.Add(img[0]);
            }
        }
        for (int i = 0; i < imageList.Count; i++)
        {
            string lname = "";
            char[] c = { '/' };
            string[] nameArray = imageList[i].AttachUrl.Split(c);
            for (int j = 0; j < nameArray.Length; j++)
            {
                lname = nameArray[j];
            }
            urls.Add(lname);
        }
        path = HttpContext.Current.Request.ApplicationPath;
        path = path + "webmag/attachment/";



            //动态新闻
            newsList = newsDAO.ListNews();

        //企业特色
        firmAdvertiseList = firmAdvertiseDAO.ListFirmAdvertise();
        for (int i = 0; i < firmAdvertiseList.Count; i++)
        {
            List<ImgAttachment> tempList = new List<ImgAttachment>();
            tempList = firmImageDAO.GetImgAttachmentByTypeAndID(7, firmAdvertiseList[i].Id.ToString());
            if (tempList.Count > 0)
                firmImageList.Add(tempList[0]);
            else 
                firmImageList.Add(null);
        }
         
    }
    
}
