using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_infoManage_lessee_Leave : System.Web.UI.Page
{
    private int id;
    private string pageno;
    public LesseeDAO lesseeDAO;
    public Lessee lessee;
    private List<string> roomList = new List<string>();
    private RoomDAO roomDAO = new RoomDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            lesseeDAO = new LesseeDAO();

            id = int.Parse(Request["id"].ToString());
            pageno = Request["pageno"];

            lessee = lesseeDAO.GetLesseeByID(id);

            lessee.Status = true;//搬离
            roomList = roomDAO.GetBuildByLessee(lessee.Name);

            if (roomList.Count != 0)
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('该租户仍存在租用的房间，不能搬离！！');location.href=('ViewLessee.aspx?pageno=" + pageno + "');</script>");
            else
            {
                int flag = lesseeDAO.UpdateLessee(lessee);

                if (flag > 0)
                {

                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('操作成功!');location.href=('ViewLessee.aspx?pageno=" + pageno + "');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('操作失败!');history.go(-1);</script>");

                }
            }
        }
    }
}