using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_infoManage_room_DetailInfo : System.Web.UI.Page
{
    public string id;
    public string pageno;
    public string keyword;
    public string buildName;
    public string scope;

    public string rentStart;
    public string rentEnd;

    public Room room = new Room();
    public RoomDAO roomDAO = new RoomDAO();

    public RoomStyle roomStyle = new RoomStyle();
    public RoomStyleDAO roomStyleDAO = new RoomStyleDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            id = Request["id"].ToString();
            pageno = Request["pageno"].ToString();
            keyword = Request["keyword"].ToString();
            buildName = Request["buildName"].ToString();
            scope = Request["scope"].ToString();

            room = roomDAO.GetRoomByID(int.Parse(id));

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
}