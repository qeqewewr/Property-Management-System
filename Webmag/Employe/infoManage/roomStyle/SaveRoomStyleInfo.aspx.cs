using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Model.Image;


public partial class Webmag_Employe_infoManage_roomStyle_SaveRoomStyleInfo : System.Web.UI.Page
{
    private RoomStyle roomStyle = new RoomStyle();
    private RoomStyleDAO roomStyleDAO = new RoomStyleDAO();

    private ImgAttachment attach=new ImgAttachment();
    private ImgAttachmentDAO attachDAO=new ImgAttachmentDAO();

    private string pageno;

    private string name;
    private string pic;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;

            name = Request.Form["roomStyleName"].Trim();
            pic = "";

            roomStyle = roomStyleDAO.GetRoomStyleByName(name);
            if (roomStyle == null)
            {
                roomStyle = new RoomStyle();
                roomStyle.Name = name;
                roomStyle.Pic = pic;

                int flag = roomStyleDAO.AddRoomStyle(roomStyle);

                if (flag >= 0)
                {
                    string lname = "";
                    try
                    {
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
                            file.SaveAs(System.Web.HttpContext.Current.Request.MapPath("../../../attachment/") + singlefilename);
                            attach = new ImgAttachment();
                            attach.AddDate = DateTime.Now;
                            attach.AttachName = file.FileName;
                            attach.AttachType = 1;
                            //attach.AttachUrl = System.Web.HttpContext.Current.Request.MapPath("../../../attachment/") + singlefilename;
                            attach.AttachUrl = "../../../attachment/" + singlefilename;
                            attach.ModuleID = flag.ToString();

                            attachDAO.AddImgAttachment(attach);
                        }
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('ViewRoomStyle.aspx?pageno=1');</script>");
                    }
                    catch (System.Exception Ex)
                    {
                        Console.Write(Ex.Message);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");

                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('该房型图名称已经存在，请重新输入!');history.go(-1);</script>");
            }


        }
    }
}