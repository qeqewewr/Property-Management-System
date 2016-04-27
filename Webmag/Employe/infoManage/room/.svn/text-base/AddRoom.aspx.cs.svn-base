using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_infoManage_room_AddRoom : System.Web.UI.Page
{
    public List<Lessee> lesseeList = new List<Lessee>();
    public LesseeDAO lesseeDAO = new LesseeDAO();
    public List<string> lsNameList = new List<string>();
    public List<string> rStyleNameList = new List<string>();
    public List<string> buNameList = new List<string>();

    public List<Building> buildList = new List<Building>();

    public List<RoomStyle> rstyleList = new List<RoomStyle>();

    //public List<RoomStyle> rstyleList = new List<RoomStyle>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            RoomStyleDAO roomStyle = new RoomStyleDAO();
            //List<RoomStyle> rstyleList = new List<RoomStyle>();

            BuildingDAO buildDAO = new BuildingDAO();
            //List<Building> buildList = new List<Building>();
            buildList = buildDAO.ListBuilding();

            for (int i = 0; i < buildList.Count; i++)
                buNameList.Add(buildList[i].Name);

            rstyleList = roomStyle.ListRoomStyle();
            for (int i = 0; i < rstyleList.Count; i++)
            {
                rStyleNameList.Add(rstyleList[i].Name);
            }

            lesseeList = lesseeDAO.ListExistLessee();
            for (int i = 0; i < lesseeList.Count; i++)
            {
                lsNameList.Add(lesseeList[i].Name);
            }
        }
    }
}