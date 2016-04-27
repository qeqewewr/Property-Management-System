using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.BLL;
using CEMIS.Model.Employe;
using CEMIS.Util;
using System.Web.SessionState;

public partial class Webmag_Employe_businadver_AddFirmAdvertise : System.Web.UI.Page
{
    public LesseeDAO lesseeDAO = new LesseeDAO();
    public List<Lessee> lesseeList;
    public string username = "";
    public Lessee lessee;
    public string role;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
        else
        {
            role = Session["Role"].ToString();
            //如果是租户登陆
            if (role == "lessee")
            {
                username = Session["UserName"].ToString();
                lessee = lesseeDAO.GetLesseeByName(username);
            }

            lesseeList = lesseeDAO.ListExistLessee();
        }
    }
}