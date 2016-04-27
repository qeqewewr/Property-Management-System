using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
//using EMIS.DbUtility;
using System.Security.Cryptography;
using System.Text;
using CEMIS.Model.Employe;
using CEMIS.Util;
using CEMIS.Model.Admin;
public partial class IndexMaster : System.Web.UI.MasterPage
{
    private EmployeDAO employeDAO = new EmployeDAO();
    private LesseeDAO lesseeDAO=new LesseeDAO();
	public Introduce intro = new Introduce();
	public IntroduceDAO introDAO = new IntroduceDAO();

    public Admin admin = new Admin();
    public AdminDAO adminDAO = new AdminDAO();
	public string p1;

	public string p2;

    protected void Page_Load(object sender, EventArgs e)
    {
		intro = introDAO.GetIntroduce(1);
		p1 = intro.P1Url;
		p2 = intro.P2Url;
        Session["PropertyPass"] = "false";
        Session["LesseePass"] = "false";
    }
    //protected void SaveClick(object sender,EventArgs e) {
    //    string message = Message.Text;

    //    if (message != null && message != "")
    //    {
    //        DateTime dt = DateTime.Now;
    //        using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionStr))
    //        {
    //            conn.Open();
    //            SqlCommand cmd = new SqlCommand("INSERT INTO Message (LeaveTime,LeaveMessage) VALUES (@LeaveTime,@LeaveMessage);", conn);
    //            cmd.Parameters.AddWithValue("@LeaveTime", dt);
    //            cmd.Parameters.AddWithValue("@LeaveMessage", message);
    //            cmd.ExecuteNonQuery();
    //            conn.Dispose();
    //            Message.Text = "";
    //            Response.Write("<script>alert('留言成功，我们会尽快回复。');location.href='Message.aspx';</script>");
    //            Response.Write("<script>document.location=document.location;</script>"); 
    //        }
    //    }
    //    else {
    //        Response.Write("<script>alert('请重新输入留言内容。')</script>");
    //        Response.Write("<script>document.location=document.location;</script>"); 
    //    }
    //}

    protected void validateImg_Click(object sender, EventArgs e)	{
        Random rand = new Random();
         
	    validateImg.ImageUrl="~IndexPage/master/ValidateNum.aspx?t="+rand.Next();
        Response.Write("<script>alert('用户名和密码错误！')</script>");
	}	

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //实例化公共类对象
        string userName = this.txtUserName.Text.Trim();
        //string passWord = DbHelperSQL.GetMD5(this.txtPwd.Text.Trim());//对密码进行加密处理
        string passWord = this.txtPwd.Text.Trim();
        string num = this.txtValidateNum.Text.Trim();
        string type = this.ddlType.SelectedValue.ToString();
        DBConnection db = new DBConnection();
        db.AddParameter("@ID", userName);
        db.AddParameter("@Password", passWord);
        string sql = "select count(*) as a  from Admin where ID =@ID And Password=@Password";

        //验证码没及时刷新
        if (Session["ValidateNum"] == null)
        {
            Response.Redirect("../Webmag/Default.aspx");//跳转到主页
        }

        if (Session["ValidateNum"].ToString() == num.ToUpper())
        {

            if (type == "property")
            {


                if (employeDAO.LogonJudge(userName, passWord))//通过dr中是否包含行判断用户是否通过身份验证
                {
                    Session["PropertyID"] = userName;//将该用户的ID存入Session["UserID"]中
                    Session["Role"] = "property";//将该用户的权限存入Session["Role"]中
                    Session["PropertyPass"] = "true";
                    Session["UserName"] = userName;
                    Response.Redirect("../Webmag/Default.aspx");//跳转到主页
                }
                if (adminDAO.LogonJudge(userName, passWord))
                {
                    Session["PropertyID"] = userName;//将该用户的ID存入Session["UserID"]中
                    Session["Role"] = "property";//将该用户的权限存入Session["Role"]中
                    Session["PropertyPass"] = "true";
                    Session["UserName"] = userName;
                    Response.Redirect("../Webmag/Default.aspx");//跳转到主页
                }
                if (!(employeDAO.LogonJudge(userName, passWord) || adminDAO.LogonJudge(userName, passWord)))
                {
                    Session["PropertyPass"] = "false";
                    Response.Write("<script>alert('用户名和密码错误！')</script>");
                    Response.Write("<script>document.location=document.location;</script>");
                }

            }
            else
            {

                if (lesseeDAO.LogonJudge(userName, passWord))//通过dr中是否包含行判断用户是否通过身份验证
                {
                    Session["LesseeName"] = userName;//将该用户的ID存入Session["UserID"]中
                    Session["Role"] = "lessee";//将该用户的权限存入Session["Role"]中
                    Session["LesseePass"] = "true";
                    Session["UserName"] = userName;
                    Response.Redirect("../Webmag/Default.aspx");//跳转到主页
                }
                else
                {
                    Response.Write("<script>alert('用户名和密码错误！')</script>");
                    Response.Write("<script>document.location=document.location;</script>");
                }

            }


        }
        else
        {
            Response.Write("<script>alert('验证码输入错误！')</script>");
            Response.Write("<script>document.location=document.location;</script>");

        }
        
    }

   
}
