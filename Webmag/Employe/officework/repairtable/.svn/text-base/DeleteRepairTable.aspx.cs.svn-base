using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.BLL;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_officework_repairtable_DeleteRepairTable : System.Web.UI.Page
{
    public string pageName = "ViewRepairTable.aspx";
    public RepairTable repairTable;
    public RepairTableDAO repairTableDAO;
    public int pageno = 1;
    public string id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            repairTable = new RepairTable();
            repairTableDAO = new RepairTableDAO();

            if (Request["pageno"] != null)
                pageno = int.Parse(Request["pageno"].Trim().ToString());
            id = this.Request.QueryString["id"];

            int flag = repairTableDAO.DeleteRepairTableById(id);
            PageBLL pageBLL = new PageBLL();
            pageBLL.RedirectPage(this, pageName, flag, pageno, 0);
        }
    }
}