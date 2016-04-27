using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;


/// <summary>
/// 删除所有部门信息
/// </summary>
public partial class Webmag_Employe_infoManage_department_DeleteAllInfo : System.Web.UI.Page
{
    protected DepartmentDAO departDAO;
    protected int pageno;
    protected int size;
    protected int flag ;

    protected Department depart;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {

            //进行页面跳转
            if (Request.Form["pageno"] != null)
            {
                string page = Request.Form["pageno"].Trim();
                pageno = int.Parse(page);
                Response.Redirect("ViewDepartment.aspx?pageno=" + pageno + "");
            }
            else
            {
                //删除单条记录
                if (Request["id"] != null)
                {
                    departDAO = new DepartmentDAO();
                    Department depart = new Department();
                    EmployeDAO employeDAO = new EmployeDAO();
                    List<string> employes = new List<string>();

                    int pagesize = int.Parse(Request["pagesize"]);
                    pageno = int.Parse(Request["pageno"]);
                    string id = Request["id"];

                    depart = departDAO.GetDepartmentByID(id);
                    employes = employeDAO.GetInfoByDepart(depart.Name, 2);


                    if (employes.Count != 0)
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('" + depart.Name + "存在员工信息，不能删除!');location.href=('ViewDepartment.aspx?pageno=" + pageno + "');</script>");
                    else
                    {

                        //总页数的计算
                        int rowcount = departDAO.GetTotalRecordNum();

                        int a = rowcount % pagesize;
                        int pagecount;

                        if (a == 0)
                        {
                            if (rowcount == 0)
                                pagecount = 1;
                            else
                                pagecount = rowcount / pagesize;
                        }
                        else
                            pagecount = rowcount / pagesize + 1;
                        //当删除的是最后一页，且最后一页只有一个数据
                        if (pagecount == pageno && a == 1)
                        {
                            if (pageno != 1)
                                pageno--;
                        }

                        flag = departDAO.deleteDepartmentByID(id);
                        RedirectPage();
                    }

                }
                //删除多条记录
                else
                {

                    size = int.Parse(Request["size"]);
                    pageno = int.Parse(Request["page"]);

                    string ids = Request["selectDel"];
                    char[] separtor = { ',' };
                    string[] idArray = ids.Split(separtor);




                    departDAO = new DepartmentDAO();


                    //计算总页数
                    int pagecount, a;
                    int rowcount = departDAO.GetTotalRecordNum();
                    a = rowcount % size;
                    if (a == 0)
                    {
                        if (rowcount == 0)
                            pagecount = 1;
                        else
                            pagecount = rowcount / size;
                    }
                    else
                        pagecount = rowcount / size + 1;

                    //判断是否是最后一页,且全部删除
                    if (pagecount == pageno && (idArray.Length == a || idArray.Length == size))
                    {
                        if (pageno != 1)
                            pageno--;
                    }

                    string info = "";
                    for (int i = 0; i < idArray.Length; i++)
                    {
                        Department depart = new Department();
                        EmployeDAO employeDAO = new EmployeDAO();
                        List<string> employes = new List<string>();

                        depart = departDAO.GetDepartmentByID(idArray[i]);
                        employes = employeDAO.GetInfoByDepart(depart.Name, 2);

                        if (employes.Count != 0)
                            info += "  " + depart.Name;
                    }
                    if (info != "")
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('" + info + "存在员工信息，不能删除!');location.href=('ViewDepartment.aspx?pageno=" + pageno + "');</script>");
                    else
                    {


                        for (int i = 0; i < idArray.Length; i++)
                        {

                            flag = departDAO.deleteDepartmentByID(idArray[i]);
                            //flag=departDAO.deleteDepartment(departlist[i].Name);
                            if (flag <= 0)
                                break;

                        }

                        RedirectPage();
                    }

                }
            }
        }
    }


    private void RedirectPage()
    {

        if (flag > 0)
        {

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除成功!');location.href=('ViewDepartment.aspx?pageno=" + pageno + "');</script>");
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除失败!');history.go(-1);</script>");

        }

    }


}