using System;
using System.Web;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using CEMIS.Util;
using CEMIS.Model.Employe;

public partial class Webmag_SelectRoom : System.Web.UI.Page
{
  //  public Hashtable BuildingRoom = new Hashtable();
    public List<string> Builds = new List<string>();
    public List<List<string>> Rooms = new List<List<string>>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../IndexPage/Index.aspx");
        else
        {
            List<Building> buildings = getBuildings();
            for (int i = 0; i < buildings.Count; i++)
            {
                string build = buildings[i].Name.Trim();
                List<string> rooms = getRoomsByBuilding(build);
                Builds.Add(build);
                Rooms.Add(rooms);
            }
        }
        
    }

    private List<Building> getBuildings()
    {
        List<Building> builds = (new BuildingDAO()).ListBuilding();
        return builds;
    }

    private List<string> getRoomsByBuilding(string building)
    {
        List<string> rooms = (new RoomDAO()).ListRoomNumberByBuildingName(building);
        return rooms;
    }

    /// <summary>
    /// 将字符串数组转换成字符串
    /// </summary>
    /// <param name="strArray">需要转换的字符串</param>
    /// <returns>合并完成的字符串</returns>
    public string arrayToString(string[] strArray)
    {
        StringBuilder str = new StringBuilder();
        for (int i = 0; i < strArray.Length; i++)
        {

            if (i > 0)
            {
                //分割符可根据需要自行修改
                str.Append(",");
            }
            str.Append(strArray[i]);
        }
        return str.ToString();
    }
}