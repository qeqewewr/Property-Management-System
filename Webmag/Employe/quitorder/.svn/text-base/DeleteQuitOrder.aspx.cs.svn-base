using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.BLL;


public partial class Webmag_Employe_quitorder_DeleteQuitOrder : System.Web.UI.Page
{
    public string pageName = "ViewQuitOrder.aspx";
    public string id;
    public int pageno = 1;
    public QuitOrder quitOrder;
    public QuitOrderDAO quitOrderDAO;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
        else
        {
            quitOrderDAO = new QuitOrderDAO();
            if (Request["pageno"] != null)
                pageno = int.Parse(Request["pageno"].Trim().ToString());
            id = this.Request.QueryString["id"];

            int flag = quitOrderDAO.DeleteQuitOrderById(id);
            PageBLL pageBLL = new PageBLL();
            pageBLL.RedirectPage(this, pageName, flag, pageno, 0);
        }
    }
}