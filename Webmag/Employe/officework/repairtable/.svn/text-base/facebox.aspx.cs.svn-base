using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Webmag_Employe_officework_repairtable_facebox : System.Web.UI.Page
{
    public string detail;
    public string id, flag;
    public RepairTableDAO repairTableDAO;
    public RepairTable repairTable;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            id = Request["id"];
            repairTableDAO = new RepairTableDAO();
            repairTable = repairTableDAO.GetRepairTableById(id);
            detail = repairTable.RepairContent;
        }
    }
}