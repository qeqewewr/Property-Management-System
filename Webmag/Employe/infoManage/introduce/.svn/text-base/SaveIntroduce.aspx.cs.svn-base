using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_infoManage_introduce_SaveIntroduce : System.Web.UI.Page
{
    private Introduce intro = new Introduce();
    private IntroduceDAO introDAO = new IntroduceDAO();

    private string introduction;
    private string telephone;
    private string address;
    private int sum;
    private string email;
    private string rentProcedure;
    private string feeAddress;
    private string feeCompany;
    private string feeAccount;
    private int flag = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
			Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            introduction = Request.Form["introIntroduction"].ToString();
            telephone = Request.Form["introTele"].ToString().Trim();
            address = Request.Form["introAddress"].ToString().Trim();
            email = Request.Form["introEmail"].ToString().Trim();
            sum = 0;
            rentProcedure = "";
            feeAddress = "";
            feeCompany = "";
            feeAccount = "";

            intro = introDAO.GetIntroduce(1);

			string uploadPath = "./images/";
			string extension = "";
			string filename = "";
			string serverpath = "";
			HttpPostedFile p1 = Request.Files["p1"];
			HttpPostedFile p2 = Request.Files["p2"];
			if (p1.FileName != "")
			{
				extension = System.IO.Path.GetExtension(p1.FileName);
				filename = p1.FileName;
				serverpath = Server.MapPath(uploadPath);
				intro.P1Url = filename;
				p1.SaveAs(System.IO.Path.Combine(serverpath, filename));
				//Response.Write("<script>alert('" + p1.FileName + "')</script>");
			}
			//Response.Write(System.IO.Path.Combine(serverpath, filename));
			//Response.Write("<script>alert('" + p2.FileName + "')</script>");

			if (p2.FileName != "")
			{
				extension = System.IO.Path.GetExtension(p2.FileName);
				filename = p2.FileName;
				serverpath = Server.MapPath(uploadPath);
				intro.P2Url = filename;
				p2.SaveAs(System.IO.Path.Combine(serverpath, filename));
			}
			/*
			for (int i = 0; i < Request.Files.Count; i++)
			{
				string filename = Request.Files.Keys[i];
				HttpPostedFile file = Request.Files[filename];
				bool test = file.FileName == "";
				Response.Write("<script>alert('"+filename+"')</script>");
				string uploadPath = "./images/";
				string extension = System.IO.Path.GetExtension(file.FileName);
				filename += extension;
				string serverpath = Server.MapPath(uploadPath);

				file.SaveAs(System.IO.Path.Combine(serverpath, filename));
				//	Response.Write("<script>alert('"+filename+"')</script>");
			}
			 * */
			//Response.Write(Request.Files.Keys.Count);
            if (intro == null)
            {
                intro = new Introduce();

                intro.Introduction = introduction;
                intro.Telephone = telephone;
                intro.Address = address;
                intro.Email = email;
                intro.Sum = sum;
                intro.RentProcedure = rentProcedure;
                intro.FeeAddress = feeAddress;
                intro.FeeCompany = feeCompany;
                intro.FeeAccount = feeAccount;

                flag = introDAO.AddIntroduce(intro);
            }
            else
            {
                intro.Introduction = introduction;
                intro.Telephone = telephone;
                intro.Address = address;
                intro.Email = email;
                intro.Sum = sum;
                intro.RentProcedure = rentProcedure;
                intro.FeeAddress = feeAddress;
                intro.FeeCompany = feeCompany;
                intro.FeeAccount = feeAccount;

                flag = introDAO.UpdateIntroduce(intro);
            }
			//Response.Write("<script>alert('" + Request.Files.Count + "')</script>");

				if (flag > 0)
				{

					Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新成功!');location.href=('ViewIntroduce.aspx');</script>");
				}
				else
				{
					Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新失败!');history.go(-1);</script>");

				}
        }
    }
}