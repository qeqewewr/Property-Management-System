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

public partial class Webmag_Employe_infoManage_employe_UpdateEmploye : System.Web.UI.Page
{
    public string id;
    public EmployeDAO employeDAO;
    public Employe employe;
    public string pageno;
    public string keyword;
    public string scope;

    public DepartmentDAO departDAO;
    public List<Department> list;
  
    public List<String> education;
    public List<String> politics;


    public string birth;
    public string enterDate;
    public string leaveDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            departDAO = new DepartmentDAO();
            list = departDAO.ListDepartment();

            education = new List<string>();
            education.Add("本科");
            education.Add("硕士");
            education.Add("博士");
            education.Add("高中");
            education.Add("大专");
            education.Add("中专");
            education.Add("初中");
            education.Add("小学");

            politics = new List<string>();
            politics.Add("党员");
            politics.Add("预备党员");
            politics.Add("团员");
            politics.Add("群众");


            employeDAO = new EmployeDAO();

            id = this.Request.QueryString["id"];
            pageno = Request["pageno"];
            if (Request["keyword"].Trim() != null)
                keyword = Request["keyword"].Trim();
            if (Request["scope"].Trim() != null)
                scope = Request["scope"].Trim();




            employe = employeDAO.GetEmployeByID(id);

            for (int i = 0; i < education.Count; i++)
            {
                if (education[i] == employe.Education)
                {
                    string temp = education[i];
                    education.RemoveAt(i);
                    education.Insert(0, temp);
                }
            }


            for (int i = 0; i < politics.Count; i++)
            {
                if (politics[i] == employe.Politics)
                {
                    string temp = politics[i];
                    politics.RemoveAt(i);
                    politics.Insert(0, temp);
                }
            }


            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name.Trim() == employe.Department.Trim())
                {
                    Department tempdepart = list[i];
                    list.RemoveAt(i);
                    list.Insert(0, tempdepart);
                }
            }


            if (employe.Birth == null)
                birth = "";
            else
                birth = ((DateTime)employe.Birth).ToShortDateString();
            if (employe.EnterDate == null)
                enterDate = "";
            else
                enterDate = ((DateTime)employe.EnterDate).ToShortDateString();
            if (employe.LeaveDate == null)
                leaveDate = "";
            else
                leaveDate = ((DateTime)employe.LeaveDate).ToShortDateString();

        }
    }
}