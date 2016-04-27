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
/// 保存部门信息
/// </summary>

public partial class BLL_informang_departmang_SaveDepartmentInfo : System.Web.UI.Page
{
    public Department depart;
    public DepartmentDAO departDAO;
    private string id;
    private string name;
    private string address;
    private string manager;


    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {

            //需要添加session的判断

            depart = new Department();
            departDAO = new DepartmentDAO();

            id = Request.Form["departmentID"].Trim();
            name = Request.Form["departmentName"].Trim();
            manager = Request.Form["departmentManager"].Trim();
            address = Request.Form["departmentAddress"].Trim();
            depart = departDAO.GetDepartmentByID(id);
            if (depart == null)
            {
                depart = departDAO.GetDepartmentByName(name);

                //Department名称不存在，进行保存
                if (depart == null)
                {
                    depart = new Department();
                    depart.ID = id;
                    depart.Name = name;
                    depart.Manager = manager;
                    depart.Address = address;

                    int flag = departDAO.AddDepartment(depart);
                    if (flag > 0)
                    {

                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('AddDepartment.aspx');</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");

                    }
                }

                //Department名称已经存在，就报错，重新输入
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('已存在此部门名称，请重新输入!');history.go(-1);</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('已存在此部门名称，请重新输入!');history.go(-1);</script>");
            }
        }
    }
}






