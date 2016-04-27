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

public partial class Webmag_Employe_infoManage_employe_DoUpdate : System.Web.UI.Page
{
    public Employe employe=new Employe();
    public EmployeDAO employeDAO=new EmployeDAO();
    private string oldid;
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
    
    public string pageno;
    public string keyword;
    public string scope;
    private int mark = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            pageno = Request["pageno"];
            oldid = Request["oldid"];
            if (Request.Form["keyword"].Trim() != null)
                keyword = Request.Form["keyword"].Trim();
            if (Request.Form["scope"].Trim() != null)
                scope = Request.Form["scope"].Trim();

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
            if (Request.Form["employeStatus"].Trim() != "" && Request.Form["employeStatus"].Trim() != null)
                status = Boolean.Parse(Request.Form["employeStatus"].Trim());
            if (Request.Form["employeEnter"].Trim() != "" && Request.Form["employeEnter"].Trim() != null)
                enterDate = DateTime.Parse(Request.Form["employeEnter"].Trim());
            if (Request.Form["employeLeave"].Trim() != "" && Request.Form["employeLeave"].Trim() != null)
                leaveDate = DateTime.Parse(Request.Form["employeLeave"].Trim());

            if (enterDate != null && leaveDate != null)
            {
                if (DateTime.Compare((DateTime)enterDate, (DateTime)leaveDate) > 0)
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('员工入职时间应该早于离职时间！！！');history.go(-1);</script>");
                else
                {
                    if (DateTime.Compare((DateTime)leaveDate, (DateTime)DateTime.Now) < 0)
                    {
                        status = true;
                        mark = 1;
                    }
                    else
                        status = false;
                }
            }
            else
                status = false;
            password = Request.Form["employePWD"].Trim();

            int flag = -1;


            //修改的是员工id
            employe = employeDAO.GetEmployeByID(id);
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

                employeDAO.deleteEmploye(oldid);
                flag = employeDAO.AddEmploye(employe);
            }
            else  //修改其他
            {
                if (oldid != id)
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('该员工id已经存在，请重新输入!');history.go(-1);</script>");
                else
                {
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

                    flag = employeDAO.UpdateEmploye(employe);
                }
            }



            if (flag > 0)
            {
                if (mark == 0)
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新成功!');location.href=('ViewEmploye.aspx?pageno=" + pageno + "&keyword=" + keyword + "&scope=" + scope + "');</script>");
                else
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('离职时间早于当前时间，将更新为离职状态，更新成功!');location.href=('ViewEmploye.aspx?pageno=" + pageno + "&keyword=" + keyword + "&scope=" + scope + "');</script>");
               
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新失败!');history.go(-1);</script>");

            }
        }
    }
}