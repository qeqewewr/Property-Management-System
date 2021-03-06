﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.BLL;

public partial class Webmag_Employe_officework_orderwork_AddOrderWork : System.Web.UI.Page
{
    public LesseeDAO lesseeDAO;
    public List<Lessee> lesseeList;

    public BuildingDAO buildingDAO;
    public List<Building> buildingList;

    public RoomDAO roomDAO;
    public List<Room> roomList;

    public string role = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            role = Session["Role"].ToString();
            //用于在页面显示住户姓名
            lesseeDAO = new LesseeDAO();
            lesseeList = lesseeDAO.ListExistLessee();

            //用于在页面显示大楼名称
            buildingDAO = new BuildingDAO();
            buildingList = buildingDAO.ListBuilding();

            //用于在页面显示房间号
            roomDAO = new RoomDAO();
            roomList = roomDAO.ListRoom();
        }
    }
}