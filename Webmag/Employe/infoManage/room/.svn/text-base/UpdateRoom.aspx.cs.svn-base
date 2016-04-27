using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_infoManage_room_UpdateRoom : System.Web.UI.Page
{
    public string id;
    public string pageno;
    public string keyword;
    public string buildName;
    public string scope;


    public List<string> lsNameList = new List<string>();
    public List<string> rStyleNameList = new List<string>();
    public List<string> buNameList = new List<string>();

    public Room room = new Room();
    public RoomDAO roomDAO = new RoomDAO();

    public string rentStart;
    public string rentEnd;

    public List<string> towardList = new List<string>();
    public List<string> decorList = new List<string>();

    public List<RoomStyle> roomStyleList = new List<RoomStyle>();
    public RoomStyleDAO roomStyleDAO = new RoomStyleDAO();
    public RoomStyle roomStyle = new RoomStyle();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            id = Request["id"].ToString();
            pageno = Request["pageno"].ToString();
            if (Request["keyword"].ToString() != null)
                keyword = Request["keyword"].Trim();
            if (Request["buildName"].ToString() != null)
                buildName = Request["buildName"].Trim();
            if (Request["scope"].ToString() != null)
                scope = Request["scope"].Trim();

            room = roomDAO.GetRoomByID(int.Parse(id));


            List<Building> buildList = new List<Building>();
            BuildingDAO buildDAO = new BuildingDAO();
            buildList = buildDAO.ListBuilding();

            for (int i = 0; i < buildList.Count; i++)
                buNameList.Add(buildList[i].Name);
            this.ShowList(buNameList, room.BuildingName);

            //List<RoomStyle> roomStyleList = new List<RoomStyle>();
            //RoomStyleDAO roomStyleDAO = new RoomStyleDAO();
            roomStyleList = roomStyleDAO.ListRoomStyle();

            for (int i = 0; i < roomStyleList.Count; i++)
                rStyleNameList.Add(roomStyleList[i].Name);
            this.ShowList(rStyleNameList, room.RoomStyle);

            List<Lessee> lesseeList = new List<Lessee>();
            LesseeDAO lesseeDAO = new LesseeDAO();
            lesseeList = lesseeDAO.ListExistLessee();
            for (int i = 0; i < lesseeList.Count; i++)
                lsNameList.Add(lesseeList[i].Name);
            this.ShowList(lsNameList, room.Lessee);

            towardList.Add("东");
            towardList.Add("南");
            towardList.Add("西");
            towardList.Add("北");
            towardList.Add("东南");
            towardList.Add("西南");
            towardList.Add("东北");
            towardList.Add("西北");
            this.ShowList(towardList, room.Toward);

            decorList.Add("精装修");
            decorList.Add("普通装修");
            decorList.Add("毛坯");
            this.ShowList(decorList, room.Decoration);

            if (room.RentStart == null)
                rentStart = "";
            else
                rentStart = ((DateTime)room.RentStart).ToShortDateString();
            if (room.RentEnd == null)
                rentEnd = "";
            else
                rentEnd = ((DateTime)room.RentEnd).ToShortDateString();


        }
    }

    private void ShowList(List<string> list, string choose)
    {
        for (int j = 0; j < list.Count; j++)
        {
            if (choose == list[j])
            {
                string temp = list[j];
                list.RemoveAt(j);
                list.Insert(0, temp);
            }
        }
    }
}