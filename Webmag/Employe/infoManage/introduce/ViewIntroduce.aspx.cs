using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_infoManage_introduce_ViewIntroduce : System.Web.UI.Page
{
    public Introduce intro = new Introduce();
    public IntroduceDAO introDAO = new IntroduceDAO();
 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
			Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {

            intro = introDAO.GetIntroduce(1);
            if (intro == null)
            {
                intro = new Introduce();
                intro.Introduction = "";
                intro.Telephone = "";
                intro.Address = "";
                intro.Email = "";
                intro.FeeAccount = "";
                intro.FeeAddress = "";
                intro.FeeCompany = "";
                intro.RentProcedure = "";
                intro.Sum = 0;
            }
        }
    }
}