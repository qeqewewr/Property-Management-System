using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_infoManage_room_AjaxGetAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            BuildingDAO buildDAO = new BuildingDAO();

            Response.AddHeader("P3P", "CP=CAO PSA OUR");
            XmlDocument doc = new XmlDocument();
            string name = Request["build"].Trim();

            string returnText = "";
            Response.ContentType = "application/xml";
            Response.HeaderEncoding = System.Text.Encoding.UTF8;
            returnText += "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            Building build = buildDAO.GetBuilding(name);
            EmployeDAO employeDAO=new EmployeDAO();
            Employe employe=new Employe();
            employe=employeDAO.GetEmployeByID(build.AdminID);
            returnText += "<r><mess>" + build.ID + "</mess>";
            
            returnText += "<mess1>" + employe.Name+ "</mess1>";

            returnText += "</r>";
            doc.LoadXml(returnText);
            Response.Write(returnText);
        }
    }
}