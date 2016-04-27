using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_infoManage_employe_SaveEmployeInfo : System.Web.UI.Page
{
    public Employe employe;
    public EmployeDAO employeDAO;
    private string id;
    private string name;
    private string idNumber;
    private string sex;
    private string nation;
    private DateTime ? birth;
    private string politics;
    private string education;
    private string department;
    private string officeTel;
    private string homeTel;
    private string mobile;
    private string homeAddress;
    private string email;
    private Boolean status;
    private DateTime ? enterDate;
    private DateTime ? leaveDate;
    private string password;
    private int mark = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
        //需要添加session的判断
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            employe = new Employe();
            employeDAO = new EmployeDAO();
            id = Request.Form["employeID"].Trim();
            name = Request.Form["employeName"].Trim();
            idNumber = Request.Form["employeIDNum"].Trim();
            sex = Request.Form["employeSex"].Trim();
            nation = Request.Form["employeNation"].Trim();
            if (Request.Form["employeBirth"].Trim() != "" && Request.Form["employeBirth"].Trim() != null)
                birth = DateTime.Parse(Request.Form["employeBirth"].Trim());
            politics = Request.Form["employePolitics"].Trim();
            education = Request.Form["employeEdu"].Trim();
            department = Request.Form["employeDepart"].Trim();
            officeTel = Request.Form["employeOTel"].Trim();
            homeTel = Request.Form["employeHTel"].Trim();
            mobile = Request.Form["employeMobile"].Trim();
            homeAddress = Request.Form["employeAddress"].Trim();
            email = Request.Form["employeEmail"].Trim();

            if (Request.Form["employeEnter"].Trim() != "" && Request.Form["employeEnter"].Trim() != null)
                enterDate = DateTime.Parse(Request.Form["employeEnter"].Trim());
            if (Request.Form["employeLeave"].Trim() != "" && Request.Form["employeLeave"].Trim() != null)
                leaveDate = DateTime.Parse(Request.Form["employeLeave"].Trim());
            if (enterDate != null && leaveDate != null)
            {
                if (DateTime.Compare((DateTime)enterDate, (DateTime)leaveDate) > 0)
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('员工入职时间应该早于离职时间！！！');location.href=('AddEmploye.aspx');</script>");
                else
                {
                    if (DateTime.Compare((DateTime)leaveDate, (DateTime)DateTime.Now) < 0)
                    {
                        mark = 1;
                        //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>var a=confirm('员工离职时间已经到达，是否改为离职状态？？');if(!a){alert('请修改离职时间!');history.go(-1);}</script>");
                        status = true;
                    }
                    else
                        status = false;
                }
            }
            else
                status = false;
            password = "123456"; //初始化的密码

            employe = employeDAO.GetEmployeByID(id);

            //EmployeID不存在，进行保存
            if (employe == null)
            {
                employe = new Employe();
                employe.EmployeID = id;
                employe.Name = name;
                employe.IDNumber = idNumber;
                employe.Sex = sex;
                employe.Nation = nation;
                employe.Birth = birth;
                employe.Politics = politics;
                employe.Education = education;
                employe.Department = department;
                employe.OfficeTel = officeTel;
                employe.HomeTel = homeTel;
                employe.Mobile = mobile;
                employe.HomeAddress = homeAddress;
                employe.Email = email;
                employe.Status = status;
                employe.EnterDate = enterDate;
                employe.LeaveDate = leaveDate;
                employe.Password = password;

                int flag = employeDAO.AddEmploye(employe);
                if (flag > 0)
                {
                   if(mark==0)
                         Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('AddEmploye.aspx');</script>");
                   else
                       Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('离职时间早于当前时间，将保存为离职状态，保存成功!');location.href=('AddEmploye.aspx');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");

                }
            }

            //EmployeID已经存在，就报错，重新输入
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('已存在此员工ID，请重新输入!');history.go(-1);</script>");
            }
        }
    }
}