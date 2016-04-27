using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.BLL;
using CEMIS.Model.Image;

public partial class Webmag_Employe_earlypre_fitmonitor_DeletePageInfo : System.Web.UI.Page
{
    protected string pageName = "ViewFitMonitor.aspx";//-------------------
    protected FitMonitorDAO fitMonitorDAO;
    protected List<FitMonitor> fitlist;
    protected PageBLL pageBLL = new PageBLL();
    //当前页号
    protected int pageno;
    //flag
    protected int flag;

    //删除装修监督记录对应的图片
    protected ImgAttachment image = new ImgAttachment();
    protected ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();
    protected List<ImgAttachment> imageList = new List<ImgAttachment>();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            string keyword = ""; //查询
            if (Request.Form["keyword"] != "" && Request.Form["keyword"] != null)//查询
                keyword = Request.Form["keyword"].Trim();//查询

            fitMonitorDAO = new FitMonitorDAO();
            //表的总记录数
            int recordNum = recordNum = int.Parse(Request["rowcount"]);

            //进行页面跳转
            if (Request.Form["pageno"] != null)
            {
               
                string page = Request.Form["pageno"].Trim();
                pageno = int.Parse(page);
                
                Response.Redirect(pageName + "?pageno=" + pageno + "&keyword=" + keyword + "");//查询
            }
            else
            {
                string id = Request["id"];
                //删除单条记录
                if (id != null)
                {
                    int pagesize = int.Parse(Request["pagesize"]);
                    pageno = int.Parse(Request["pageno"]);

                    imageList = imageDAO.GetImgAttachmentByTypeAndID(4, id);
                    for (int i = 0; i < imageList.Count; i++)
                    {
                        flag = imageDAO.deleteImgAttachmentByID(imageList[i].ID);

                        System.IO.File.Delete(HttpContext.Current.Request.MapPath(imageList[i].AttachUrl));
                        if (flag <= 0)
                            break;
                    }

                    pageno = pageBLL.CheckBoxDeleteOneRecord(pagesize, pageno, recordNum);
                    flag = fitMonitorDAO.DeleteFitMonitor(id);//-------------

                }
                else //删除多条记录
                {
                    int size = int.Parse(Request["size"]);
                    pageno = int.Parse(Request["page"]);
                    string ids = Request["selectDel"];
                    char[] separtor = { ',' };
                    if (ids == null || ids == "")
                    {
                        Response.Redirect(pageName + "?pageno=" + pageno + "&keyword=" + keyword + "");//查询
                    }
                    string[] idArray = ids.Split(separtor);

                    pageno = pageBLL.CheckBoxDeleteRecord(size, pageno, recordNum, idArray.Length);
                    for (int i = 0; i < idArray.Length; i++)
                    {
                        flag = 1;
                        //装修监督----------444444444444444444---
                        imageList = imageDAO.GetImgAttachmentByTypeAndID(4, idArray[i]);

                        for (int j = 0; j < imageList.Count; j++)
                        {
                            flag = imageDAO.deleteImgAttachmentByID(imageList[j].ID);
                            System.IO.File.Delete(HttpContext.Current.Request.MapPath(imageList[j].AttachUrl));
                            if (flag <= 0)
                                break;
                        }

                        if (flag <= 0) break;
                        flag = fitMonitorDAO.DeleteFitMonitor(idArray[i]);
                        if (flag <= 0) break;

                    }
                }
                pageBLL.RedirectPage(this, pageName, flag, pageno, 0);
            }
        }
    }
}