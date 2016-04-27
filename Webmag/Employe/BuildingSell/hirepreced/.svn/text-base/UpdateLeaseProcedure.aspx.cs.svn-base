using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util;
using CEMIS.BLL;

public partial class Webmag_Employe_BuildingSell_hirepreced_UpdateLeaseProcedure : System.Web.UI.Page
{
    public LeaseProcedure leaseProcedure;
    public LeaseProcedureDAO leaseProcedureDAO;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {

            leaseProcedure = new LeaseProcedure();
            leaseProcedureDAO = new LeaseProcedureDAO();
            leaseProcedure = leaseProcedureDAO.GetLeaseProcedure();
        }
    }
}