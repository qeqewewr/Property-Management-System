﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Image;

public partial class Webmag_Employe_infoManage_roomStyle_DeleteImage : System.Web.UI.Page
{
    private ImgAttachment image = new ImgAttachment();
    private ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();

    private int id;
    private int imageID;
    private string pageno;
    private string keyword;

    private string url;

    private int flag = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            id = int.Parse(Request["id"].ToString());
            imageID = int.Parse(Request["imageID"].ToString());
            pageno = Request["pageno"].ToString();

            if (Request["keyword"].Trim() != null)
                keyword = Request["keyword"].Trim();

            image = imageDAO.GetImgAttachmentByID(imageID);

            flag = imageDAO.deleteImgAttachmentByID(imageID);
            //System.IO.File.Delete(image.AttachUrl);
            System.IO.File.Delete(HttpContext.Current.Request.MapPath(image.AttachUrl));

            if (flag > 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('图片删除成功!');location.href=('UpdateNews.aspx?pageno=" + pageno + "&id=" + id + "&keyword="+keyword+"');</script>");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('图片删除失败!');history.go(-1);</script>");

            }
        }
    }
}