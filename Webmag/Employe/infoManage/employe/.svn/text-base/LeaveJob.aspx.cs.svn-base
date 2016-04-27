using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_infoManage_employe_LeaveJob : System.Web.UI.Page
{
    private string id;
    private int pageno;

    private Employe employe = new Employe();
    private EmployeDAO employeDAO = new EmployeDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            id = Request["id"];
            pageno = int.Parse(Request["pageno"]);

            employe = employeDAO.GetEmployeByID(id);
            if (employe.EnterDate != null)
            {

                if (DateTime.Compare((DateTime)employe.EnterDate, (DateTime)DateTime.Now) > 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('员工还未入职，离职失败！！');location.href=('ViewEmploye.aspx?pageno=" + pageno + "');</script>");

                }
                else
                {
                    employe.Status = true;//离职状态
                    employe.LeaveDate = DateTime.Now;




                    int flag = employeDAO.UpdateEmploye(employe);

                    if (flag > 0)
                    {

                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('操作成功!');location.href=('ViewEmploye.aspx?pageno=" + pageno + "');</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('操作失败!');history.go(-1);</script>");

                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>var a=confirm('员工不存在入职时间，是否继续离职操作？？');if(!a){history.go(-1);}else{alert('操作成功!');location.href=('ViewEmploye.aspx?pageno=" + pageno + "');}</script>");
                employe.Status = true;//离职状态
                employe.EnterDate = DateTime.Now;
                employe.LeaveDate = DateTime.Now;




                int flag = employeDAO.UpdateEmploye(employe);

                if (flag > 0)
                {

                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('操作成功!');location.href=('ViewEmploye.aspx?pageno=" + pageno + "');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('操作失败!');history.go(-1);</script>");

                }
            }

        }

    }
}