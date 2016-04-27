using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_infoManage_building_AjaxgetEmploye : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            EmployeDAO employeDAO = new EmployeDAO();

            Response.AddHeader("P3P", "CP=CAO PSA OUR");
            XmlDocument doc = new XmlDocument();
            string name = Request["depart"].Trim();

            string returnText = "";
            Response.ContentType = "application/xml";
            Response.HeaderEncoding = System.Text.Encoding.UTF8;
            returnText += "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            List<string> InfoList = employeDAO.GetInfoByDepart(name,1);
            returnText += "<r><mess>" + InfoList.Count + "</mess>";
            for (int i = 0; i < InfoList.Count; i++)
                returnText += "<mess" + i + ">" + InfoList[i] + "</mess" + i + ">";
            returnText += "</r>";
            doc.LoadXml(returnText);
            Response.Write(returnText);
        }
    }

}