﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_infoManage_employe_AddEmploye : System.Web.UI.Page
{
    public DepartmentDAO departDAO;
    public List<Department> list;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            departDAO = new DepartmentDAO();
            list = departDAO.ListDepartment();
        }
    }
}