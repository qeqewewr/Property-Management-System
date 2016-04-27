using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using CEMIS.Model.Employe;
using CEMIS.Model.Image;

public partial class Webmag_Employe_infoManage_room_AjaxGetPic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            RoomStyleDAO styleDAO = new RoomStyleDAO();
            RoomStyle style = new RoomStyle();

            //ImgAttachment image = new ImgAttachment();
            ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();
            //List<ImgAttachment> imageList = new List<ImgAttachment>();

            Response.AddHeader("P3P", "CP=CAO PSA OUR");
            XmlDocument doc = new XmlDocument();

            string name = Request["roomStyle"].Trim();

            style = styleDAO.GetRoomStyleByName(name);

            string returnText = "";
            Response.ContentType = "application/xml";
            Response.HeaderEncoding = System.Text.Encoding.UTF8;
            returnText += "<?xml version=\"1.0\" encoding=\"utf-8\"?>";

            //List<ImgAttachment> imageList = imageDAO.GetImgAttachmentByTypeAndID(1, style.ID.ToString());
           //`imageList = imageDAO.GetImgAttachmentByTypeAndID(1, style.ID.ToString());
            returnText += "<r><mess>" + style.ID + "</mess>";
            //for (int i = 0; i < 2*imageList.Count; i++)
            //{
            //    returnText += "<mess" + i + ">" + imageList[i].ID + "</mess" + i + ">";
            //    i++;
            //    returnText += "<mess" + i + ">" + imageList[i].AttachUrl + "</mess" + i + ">";

            //}
            returnText += "</r>";
            doc.LoadXml(returnText);
            Response.Write(returnText);
        }
    }
}