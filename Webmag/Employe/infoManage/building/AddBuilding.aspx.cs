﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_infoManage_building_AddBuilding : System.Web.UI.Page
{
    public DepartmentDAO departDAO = new DepartmentDAO();
    public List<Department> departlist = new List<Department>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            departlist = departDAO.ListDepartment();
        }
    }
}