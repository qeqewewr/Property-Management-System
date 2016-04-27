using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Authority;

public partial class Webmag_Authority_DoUpdate : System.Web.UI.Page
{
    private string employid;
    public Employe employe;
    private EmployeDAO emService;
    private PermissionDAO perService;
    private List<Permission> permissionList;
    private Permission permission;
    private bool flag = true;
    private int nflag;

    public string pageno;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../IndexPage/Index.aspx");
        else
        {
            employid = Request["employid"].Trim();
            pageno = Request["pageno"].Trim();
            emService = new EmployeDAO();
            perService = new PermissionDAO();
            // funcService = new AllFunctionService();
            employe = emService.GetEmployeByID(employid);
            //  allFunctionList = funcService.GetModelList("");
            //获得该员工原有的权限
            permissionList = perService.GetPermissionByRoleID(int.Parse(employid));



            //删除该员工原有的所有权限
            if (permissionList != null)
            {
                for (int k = 0; k < permissionList.Count; k++)
                {
                    int f = perService.DeletePermission(permissionList[k].ID);
                    if (f <= 0)
                        flag = false;
                    if (flag == false)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('分配失败!');history.go(-1);</script>");
                    }
                }
            }

            ////重新分配权限
            char[] a = { ',' };
            string checkboxValue = Request.Form["all"];
            if (checkboxValue != null)
            {
                string[] functionsId = checkboxValue.Split(a);

                //重新分配

                for (int i = 0; i < functionsId.Length; i++)
                {
                    permission = new Permission();
                    permission.RoleID = int.Parse(employid);
                    permission.FunctionID = int.Parse(functionsId[i]);
                    permission.Description = "";
                    nflag = perService.AddPermission(permission);
                    if (nflag <= 0)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('分配失败!');history.go(-1);</script>");
                    }
                }
            }

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('分配成功!');location.href=('ViewAuthority.aspx?pageno=" + pageno + "');</script>");
        }
    }
}