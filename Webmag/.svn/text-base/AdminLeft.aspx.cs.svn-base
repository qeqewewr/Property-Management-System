using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using CEMIS.Model.Employe;
using CEMIS.Util.Authority;
using CEMIS.Model.Admin;
 

public partial class AdminLeft : System.Web.UI.Page
{
    private Employe employ=new Employe();
    private List<Permission> permissionList = new List<Permission>();
    public List<AllFunction> functionList = new List<AllFunction>();
    private EmployeDAO emService=new EmployeDAO();
    private PermissionDAO perService=new PermissionDAO();
    private AllFunction function=new AllFunction();
    private AllFunctionDAO funcService=new AllFunctionDAO();
    public List<AllFunction> bigFunctionList = new List<AllFunction>();
    public AdminDAO adminDAO = new AdminDAO();
    public Admin admin = new Admin();

    public Boolean show = true;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../IndexPage/Index.aspx");
        else
        {
            if (Session["Role"] == "lessee" && Session["LesseePass"] == "true")
                show = false;
            if (Session["Role"] == "property" && Session["PropertyPass"] == "true")
            {
                string employeid = Session["PropertyID"].ToString();
                //employ = emService.GetEmployeByID(employeid);


                perService = new PermissionDAO();
                funcService = new AllFunctionDAO();
                //大模块列表
                bigFunctionList = funcService.GetFatherFunction();
                if (!adminDAO.GetAdmin(employeid))
                {
                    employ = emService.GetEmployeByID(employeid);
                    permissionList = perService.GetPermissionByRoleID(employ.ID);
                }
                else
                {
                    permissionList = perService.GetPermissionByRoleID(0);
                }

                //获得该员工的权限
                if (permissionList != null)
                {
                    for (int i = 0; i < permissionList.Count; i++)
                    {
                        function = funcService.GetFunction(permissionList[i].FunctionID);
                        functionList.Add(function);
                    }
                }
            }

            Response.AddHeader("P3P", "CP=CAO PSA OUR");

        }
    }
}
