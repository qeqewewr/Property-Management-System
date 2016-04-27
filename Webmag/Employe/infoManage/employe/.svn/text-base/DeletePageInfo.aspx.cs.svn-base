using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.Util.Authority;

public partial class Webmag_Employe_infoManage_employe_DeletePageInfo : System.Web.UI.Page
{
    protected EmployeDAO employeDAO;
    protected int pageno;
    protected int size;
    protected int flag;
    protected BuildingDAO buildDAO = new BuildingDAO();
	protected PermissionDAO perDAO=new PermissionDAO();
    protected  string scope = "";
    protected string keyword = "";
    protected Employe employe;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {

            if (Request["scope"] != "" && Request["scope"] != null)
                scope = Request["scope"].Trim();
            if (Request["keyword"] != "" && Request["keyword"] != null)
                keyword = Request["keyword"].Trim();

            //进行页面跳转
            if (Request.Form["pageno"] != null)
            {

                string page = Request.Form["pageno"].Trim();


                pageno = int.Parse(page);
                Response.Redirect("ViewEmploye.aspx?pageno=" + pageno + "&scope=" + scope + "&keyword=" + keyword + "");
            }
            else
            {
                //删除单条记录
                if (Request["id"] != null)
                {
                    employeDAO = new EmployeDAO();

                    int pagesize = int.Parse(Request["pagesize"]);
                    pageno = int.Parse(Request["pageno"]);
                    string id = Request["id"];
                    employe = employeDAO.GetEmployeByID(id);
                    if (buildDAO.IsExistAdmin(employe.EmployeID))
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('" + employe.Name + "仍是大楼管理员，不能删除!');history.go(-1);</script>");
                    else
                    {
                        //总页数的计算
                        int rowcount = int.Parse(Request["rowcount"]);

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
                        Employe em = employeDAO.GetEmployeByID(id);
                        flag = perDAO.DeletePermissionByRoleID(em.ID);
                        if (flag < 0)
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('用户权限删除失败!');history.go(-1);</script>");
                        flag = employeDAO.deleteEmploye(id);
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




                    employeDAO = new EmployeDAO();


                    //计算总页数
                    int pagecount, a;
                    int rowcount = int.Parse(Request["rowcount"]);
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
                        employe = employeDAO.GetEmployeByID(idArray[i]);
                        if (buildDAO.IsExistAdmin(employe.EmployeID))
                            info += " " + employe.Name;
                    }
                    if (info != "")
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('" + info + "仍是大楼管理员，不能删除！！');history.go(-1);</script>");
                    else
                    {
                        for (int i = 0; i < idArray.Length; i++)
                        {
                            Employe em = employeDAO.GetEmployeByID(idArray[i]);
                            flag = perDAO.DeletePermissionByRoleID(em.ID);
                            if (flag < 0)
                                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('用户权限删除失败!');history.go(-1);</script>");
                            flag = employeDAO.deleteEmploye(idArray[i]);
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

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除成功!');location.href=('ViewEmploye.aspx?pageno=" + pageno + " &scope="+scope+"&keyword="+keyword+"');</script>");
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除失败!');history.go(-1);</script>");

        }

    }


}