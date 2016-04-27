using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using CEMIS.BLL;
using CEMIS.Model.Employe;
using CEMIS.Util;

public partial class Webmag_Employe_BuildingSell_hirepreced_DoUpdate : System.Web.UI.Page
{
    //要跳转到的页面
    public string pageName = "UpdateLeaseProcedure.aspx";
    public string id;
    public string leaseContent = "";
    public LeaseProcedure leaseProcedure;
    public LeaseProcedureDAO leaseProcedureDAO;
    //用于标志更新是否成功
    public int flag = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
		if(Session["UserName"]==null)
			Response.Redirect("../../../../IndexPage/Index.aspx");
		else
		{		
            leaseProcedure = new LeaseProcedure();
            leaseProcedureDAO = new LeaseProcedureDAO();
            leaseProcedure.Id = "1";
            leaseProcedure.LeaseContent = Request["leaseContent"].Trim();
            if (leaseProcedure != null)
                flag = leaseProcedureDAO.UpdateLeaseProcedure(leaseProcedure);

            //页面重定向
            PageBLL pageBLL = new PageBLL();
            pageBLL.RedirectPage(this, pageName, flag,-1, 1);
		}
        
    }
}