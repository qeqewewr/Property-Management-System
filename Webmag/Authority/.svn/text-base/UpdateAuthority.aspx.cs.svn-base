using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Authority;
using CEMIS.Model.Image;

public partial class Webmag_Authority_UpdateAuthority : System.Web.UI.Page
{
    private string employid;
    public Employe employe;
    private EmployeDAO emService;
    private PermissionDAO perService;
    private List<Permission> permissionList;
    public List<AllFunction> functionList = new List<AllFunction>();
    public List<AllFunction> allFunctionList;
    public AllFunction function;
    public AllFunctionDAO funcService;
    public string pageno;


    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserName"] == null)
            Response.Redirect("../../IndexPage/Index.aspx");
        else
        {
            pageno = Request["pageno"];
            employid = Request["id"].Trim();
            emService = new EmployeDAO();
            perService = new PermissionDAO();
            funcService = new AllFunctionDAO();
            employe = emService.GetEmploye(employid);
            permissionList = perService.GetPermissionByRoleID(int.Parse(employid));
            allFunctionList = funcService.GetAllFunction();
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
    }
}