using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.BLL;
using CEMIS.Model.Image;

public partial class Webmag_Employe_businadver_DeletePageInfo : System.Web.UI.Page
{
    protected string pageName = "ViewFirmAdvertise.aspx";
    protected FirmAdvertiseDAO firmAdvertiseDAO;
    protected int pageno;
    protected int flag;
    protected List<FirmAdvertise> firmAdvertiselist;
    protected PageBLL pageBLL = new PageBLL();

    protected ImgAttachment image = new ImgAttachment();
    protected ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();
    protected List<ImgAttachment> imageList = new List<ImgAttachment>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
        else
        {
            firmAdvertiseDAO = new FirmAdvertiseDAO();//---------------00
            //表的总记录数
            int recordNum = int.Parse(Request["rowcount"]);

            //进行页面跳转
            if (Request.Form["pageno"] != null)
            {
                string keyword = "";
                string page = Request.Form["pageno"].Trim();
                pageno = int.Parse(page);
                if (Request.Form["keyword"] != "" && Request.Form["keyword"] != null)//查询
                    keyword = Request.Form["keyword"].Trim();
                Response.Redirect(pageName + "?pageno=" + pageno + "&keyword=" + keyword + "");
            }
            else
            {
                string id = Request["id"];
                //删除单条记录
                if (id != null)
                {
                    int pagesize = int.Parse(Request["pagesize"]);
                    pageno = int.Parse(Request["pageno"]);
                    //删除对应的反馈单图片--7
                    imageList = imageDAO.GetImgAttachmentByTypeAndID(7, id);
                    for (int i = 0; i < imageList.Count; i++)
                    {
                        flag = imageDAO.deleteImgAttachmentByID(imageList[i].ID);
                        System.IO.File.Delete(HttpContext.Current.Request.MapPath(imageList[i].AttachUrl));
                        if (flag <= 0)
                            break;
                    }
                    pageno = pageBLL.CheckBoxDeleteOneRecord(pagesize, pageno, recordNum);
                    flag = firmAdvertiseDAO.DeleteFirmAdvertiseById(id);//------------- 11

                }
                else //删除多条记录
                {
                    int size = int.Parse(Request["size"]);
                    pageno = int.Parse(Request["page"]);
                    string ids = Request["selectDel"];
                    char[] separtor = { ',' };
                    string[] idArray = ids.Split(separtor);

                    pageno = pageBLL.CheckBoxDeleteRecord(size, pageno, recordNum, idArray.Length);
                    for (int i = 0; i < idArray.Length; i++)
                    {

                        //7777777777777
                        flag = 1;
                        imageList = imageDAO.GetImgAttachmentByTypeAndID(7, idArray[i]);
                        for (int j = 0; j < imageList.Count; j++)
                        {
                            flag = imageDAO.deleteImgAttachmentByID(imageList[j].ID);
                            System.IO.File.Delete(HttpContext.Current.Request.MapPath(imageList[j].AttachUrl));
                            if (flag <= 0)
                                break;
                        }

                        if (flag <= 0)
                            break;
                        flag = firmAdvertiseDAO.DeleteFirmAdvertiseById(idArray[i]);//------------------22
                        if (flag <= 0)
                            break;

                    }
                }
                pageBLL.RedirectPage(this, pageName, flag, pageno, 0);
            }
        }
    }
 }
