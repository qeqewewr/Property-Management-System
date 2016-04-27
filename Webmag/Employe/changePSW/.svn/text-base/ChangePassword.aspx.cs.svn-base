using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;


public partial class Webmag_Employe_changePSW_ChangePassword : System.Web.UI.Page
{
    public Employe employe = new Employe();
    public EmployeDAO employeDAO = new EmployeDAO();

    public Lessee lessee = new Lessee();
    public LesseeDAO lesseeDAO = new LesseeDAO();

    public string role;
    public string password;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
        else
        {
            if (Session["Role"] == "property")
            {
                role="property";
                employe = employeDAO.GetEmployeByID(Session["UserName"].ToString().Trim());
                password = employe.Password;
            }
            if (Session["Role"] == "lessee")
            {
                role = "lessee";
                lessee = lesseeDAO.GetLesseeByName(Session["UserName"].ToString().Trim());
                password = lessee.Password;
            }
        }
    }
}