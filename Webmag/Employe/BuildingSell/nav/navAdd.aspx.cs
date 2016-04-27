using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Util;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_tabledoc_uploaddoc_DocumentAdd : System.Web.UI.Page
{
    public Nav nav = new Nav();
    public NavDAO navDAO = new NavDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            if (Request.HttpMethod == "POST")
            {
                nav.Name = Request.Form["name"].ToString().Trim();
                nav.Url = HttpUtility.UrlEncode(Request.Form["Url"].ToString().Trim());
                nav.Sort = "1";
                nav.State = "1";
                if (Request["id"] != null && Request["id"].ToString().Trim() != "")
                {
                    nav.ID = Request["id"].ToString().Trim();

                    int result = navDAO.UpdateNav(nav);
                    if (result > 0)
                    {
                        Response.Write("<script>alert('编辑成功！')</script>");
                        Response.Write("<script>window.location.href='navView.aspx'</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('编辑失败，请重试')</script>");
                    }
                }
                else
                {
                    int result = navDAO.AddNav(nav);
                    if (result > 0)
                        Response.Write("<script>alert('添加成功！')</script>");
                    else
                        Response.Write("<script>alert('添加失败！')</script>");
                    nav = new Nav();
                }
            }
            else
            {
                if (Request["id"] != null && Request["id"].ToString().Trim() != "")
                {
                    Nav d = navDAO.GetNav(Request["id"].ToString().Trim());
                    if (d != null) nav = d;
                    nav.Url = HttpUtility.UrlDecode(nav.Url);
                }
            }
        }
    }
}