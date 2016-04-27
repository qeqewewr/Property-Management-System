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
/// 更新修改的信息
/// </summary>
public partial class Webmag_Employe_infoManage_department_DoUpdate : System.Web.UI.Page
{
    public Department depart;
    public DepartmentDAO departDAO;
    private string id;
    private string name;
    private string manager;
    private string address;
    private string oldid;
    public string pageno;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            pageno = Request["pageno"];
            depart = new Department();
            departDAO = new DepartmentDAO();
            id = Request.Form["departmentID"].Trim();
            name = Request.Form["departmentName"].Trim();
            manager = Request.Form["departmentManager"].Trim();
            address = Request.Form["departmentAddress"].Trim();
            oldid = Request["oldid"].Trim();
            int flag = -1;


            //修改的是部门ID
            depart = departDAO.GetDepartmentByID(id);
            if (depart == null)
            {
                departDAO.deleteDepartmentByID(oldid);
                depart = new Department();
                depart.ID = id;
                depart.Address = address;
                depart.Manager = manager;
                depart.Name = name;
                flag = departDAO.AddDepartment(depart);
            }
            else  //修改的是其他
            {
                if (oldid != id)
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('该部门ID已经存在，请重新输入!');history.go(-1);</script>");
                else
                {
                    depart.Name = name;
                    depart.Manager = manager;
                    depart.Address = address;
                    flag = departDAO.UpdateDepartment(depart);
                }
            }



            if (flag > 0)
            {

                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新成功!');location.href=('ViewDepartment.aspx?pageno=" + pageno + "');</script>");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新失败!');history.go(-1);</script>");

            }
        }
    }
}