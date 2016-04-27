using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.Model.Image;
using CEMIS.Model.Admin;

public partial class Webmag_Employe_infoManage_room_ViewRoom : System.Web.UI.Page
{
    public RoomDAO roomDAO = new RoomDAO();
    public List<Room> roomList = new List<Room>();

    public RoomStyle roomStyle = new RoomStyle();
    public RoomStyleDAO roomStyleDAO = new RoomStyleDAO();

    public Building build = new Building();
    public BuildingDAO buildDAO = new BuildingDAO();

    public List<ImgAttachment> imageList = new List<ImgAttachment>();
    public ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();

    public List<string> buildNameList = new List<string>();

    public AdminDAO adminDAO = new AdminDAO();

    public pageForm page = new pageForm();
    public string pageno;
    public bool condition;//是否查询
    public string keyword;//查询关键字
    public string buildName;//大楼范围
    public int status;//查询范围
    public string scope;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            this.getBuildName();
            page.PageSize = 10;

            pageno = Request["pageno"].Trim();

            if (Request["keyword"] != "" && Request["keyword"] != null) //房间号查询
            {

                keyword = Request["keyword"].Trim();
                scope = Request["scope"].Trim();

                condition = true;

                if (scope == "已租用")
                    status = 1;
                if (scope == "未租用")
                    status = 0;
                if (scope == "全部")
                    status = 2;

                if (Request["buildName"].ToString() == "请选择大楼名" || Request["buildName"].ToString() == "") //按房间号和租用情况查询
                {
                    roomList = roomDAO.SearchRoomListByName(keyword, status, int.Parse(pageno), page.PageSize);
                    this.doPage(int.Parse(pageno), roomDAO.SearchNum);
                }
                else//按房间号、大楼名和租用情况查询
                {
                    buildName = Request["buildName"].ToString();
                    this.ShowBuildName(buildName);
                    roomList = roomDAO.SearchRoomList(keyword, buildName, status, int.Parse(pageno), page.PageSize);
                    this.doPage(int.Parse(pageno), roomDAO.SearchNum);
                }
            }
            else
            {

                condition = false;

                if (Request["scope"] == null || Request["scope"] == "")
                {
                    status = 2;
                    roomList = roomDAO.ListPageRoom(int.Parse(pageno), page.PageSize, status);
                    this.doPage(int.Parse(pageno), roomDAO.GetScopeTotalNum(status));

                    //if (buildName == "请选择大楼")//显示全部
                    //{
                    //    roomList = roomDAO.ListPageRoom(int.Parse(pageno), page.PageSize, status);
                    //    this.doPage(int.Parse(pageno), roomDAO.GetScopeTotalNum(status));
                    //}
                    //else//按大楼名和租用情况查询
                    //{
                    //    this.ShowBuildName(buildName);
                    //    roomList = roomDAO.SearchRoomList(buildName, status, int.Parse(pageno), page.PageSize);
                    //    this.doPage(int.Parse(pageno), roomDAO.GetScopeAndBuildTotalNum(status, buildName));
                    //}
                }
                else
                {

                    scope = Request["scope"].Trim();

                    if (scope == "已租用")
                        status = 1;
                    if (scope == "未租用")
                        status = 0;
                    if (scope == "全部")
                        status = 2;


                    if (Request["buildName"].ToString() == "请选择大楼名" || Request["buildName"].ToString() == "")//租用情况查询
                    {
                        roomList = roomDAO.ListPageRoom(int.Parse(pageno), page.PageSize, status);
                        this.doPage(int.Parse(pageno), roomDAO.GetScopeTotalNum(status));
                    }
                    else//按大楼名和租用情况查询
                    {
                        buildName = Request["buildName"].ToString();
                        this.ShowBuildName(buildName);
                        roomList = roomDAO.SearchRoomList(buildName, status, int.Parse(pageno), page.PageSize);
                        this.doPage(int.Parse(pageno), roomDAO.GetScopeAndBuildTotalNum(status, buildName));
                    }
                }
            }
        }
    }

    //获得大楼名称列表
    public void getBuildName()
    {
        List<Building> buildList = new List<Building>();
        buildList= buildDAO.ListBuilding();

        buildNameList.Add("请选择大楼名");
        for (int i = 0; i < buildList.Count; i++)
            buildNameList.Add(buildList[i].Name);
       

    }

    //页面信息
    public void doPage(int pageno, int rowCount)
    {        
        page.RowCount = rowCount;
        page.PageNo = pageno;
        int a = rowCount % page.PageSize;
        if (a == 0)
        {
            if (rowCount == 0)
                page.PageCount = 1;
            else
                page.PageCount = rowCount / page.PageSize;
        }
        else
            page.PageCount = rowCount / page.PageSize + 1;
    }

    //更改大楼名称的显示顺序
    public void ShowBuildName(string name)
    {
        for (int i = 0; i < buildNameList.Count; i++)
        {
            if (buildNameList[i] == name)
            {
                string temp = buildNameList[i];
                buildNameList.RemoveAt(i);
                buildNameList.Insert(0, temp);
            }
        }
    }
}