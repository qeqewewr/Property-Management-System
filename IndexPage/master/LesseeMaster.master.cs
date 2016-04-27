using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class master_LesseeMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Label1.Text = DateTime.Now.ToString(); //显示时间
        IPLabel.Text = Request.UserHostAddress.ToString();
        LoginName.Text = Session["LesseeName"].ToString();

    }
    
    
}
