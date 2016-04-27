using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using CEMIS.Model.Employe;

public partial class RentProcedure : System.Web.UI.Page
{
    public LeaseProcedure rentPro = new LeaseProcedure();
    public LeaseProcedureDAO rentProDAO = new LeaseProcedureDAO();

    public Boolean IsExist = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        rentPro = rentProDAO.GetLeaseProcedure();
        if (rentPro != null)
            IsExist = true;

    }
}
