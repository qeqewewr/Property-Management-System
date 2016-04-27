using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_changePSW_DoChange : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Employe employe = new Employe();
        EmployeDAO employeDAO=new EmployeDAO();

        Lessee lessee = new Lessee();
        LesseeDAO lesseeDAO = new LesseeDAO();

        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
        else
        {
            string password;
            int flag=-1;
            password = Request["newPsw"].Trim();

            if (Session["Role"] == "property")
            {
                employe = employeDAO.GetEmployeByID(Session["UserName"].ToString().Trim());
                employe.Password=password;
                flag = employeDAO.UpdateEmploye(employe);
            }
            if (Session["Role"] == "lessee")
            {
                lessee = lesseeDAO.GetLesseeByName(Session["UserName"].ToString().Trim());
                lessee.Password=password;
                flag = lesseeDAO.UpdateLessee(lessee);
            }
            if (flag > 0)
            {

                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('密码修改成功!');location.href=('ChangePassword.aspx');</script>");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('密码修改失败!');history.go(-1);</script>");

            }
        }
    }
}