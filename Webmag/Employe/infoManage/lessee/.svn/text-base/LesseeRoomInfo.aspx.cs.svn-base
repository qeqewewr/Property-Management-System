using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_infoManage_lessee_LesseeRoomInfo : System.Web.UI.Page
{
    public int id;
    public LesseeDAO lesseeDAO;
    public Lessee lessee;
    public string pageno;
    public string keyword;
    public string scope;

    public RoomDAO roomDAO = new RoomDAO();

    public List<string> buildList = new List<string>();
    public List<List<string>> room = new List<List<string>>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            lesseeDAO = new LesseeDAO();

            id = int.Parse(Request["id"].ToString());
            pageno = Request["pageno"];

            if (Request["keyword"].Trim() != null)
                keyword = Request["keyword"].Trim();
            if (Request["scope"].Trim() != null)
                scope = Request["scope"].Trim();

            lessee = lesseeDAO.GetLesseeByID(id);

            buildList = roomDAO.GetBuildByLessee(lessee.Name);

            for (int i = 0; i < buildList.Count; i++)
            {
                List<string> roomList=new List<string>();
                roomList = roomDAO.GetRoomByLesseeAndBuild(buildList[i],lessee.Name);
                room.Add(roomList);
            }
          
        }
    }
}