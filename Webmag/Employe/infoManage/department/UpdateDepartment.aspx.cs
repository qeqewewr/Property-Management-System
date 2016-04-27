using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CEMIS.Model.Employe;


/// <summary>
/// 更新部门信息界面处理
/// </summary>

public partial class Webmag_Employe_infoManage_department_UpdateDepartment : System.Web.UI.Page
{
    public string id;
    public DepartmentDAO departDAO;
    public Department depart;
    public string pageno;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            departDAO = new DepartmentDAO();

            id = Request["id"];
            pageno = Request["pageno"];

            depart = departDAO.GetDepartmentByID(id);



        }
    }
}