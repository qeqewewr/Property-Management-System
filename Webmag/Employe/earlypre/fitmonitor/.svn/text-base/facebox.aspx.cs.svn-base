using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.BLL;
using CEMIS.Model.Employe;
using CEMIS.Util;

public partial class Webmag_Employe_earlypre_fitmonitor_facebox : System.Web.UI.Page
{
    public string detail = "";
    public string id;
    public FitMonitorDAO fitMonitorDAO;
    public FitMonitor fitMonitor;
 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {

            id = Request["id"];
            fitMonitorDAO = new FitMonitorDAO();
            fitMonitor = fitMonitorDAO.GetFitMonitorById(id);
            detail = fitMonitor.Detail;
        }
     
    }
}