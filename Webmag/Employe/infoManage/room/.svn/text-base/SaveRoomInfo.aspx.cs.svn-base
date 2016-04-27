using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_infoManage_room_SaveRoomInfo : System.Web.UI.Page
{
    private Room room = new Room();
    private RoomDAO roomDAO = new RoomDAO();

    private string number;
    private string buildingName;
    private int floor=0;
    private double area;
    private Boolean style;
    private string rent;
    private string roomStyle;
    private double manageFee;
    private double taxes=0;
    private string toward;
    private double floorHeight;
    private string decoration;
    private int minLease;
    private string payMode;
    private Boolean isRent;
    private string lessee;
    private DateTime? rentStart;
    private DateTime? rentEnd;
    private string remark;
    private Boolean isShowed;

    private string buildID;
    private string admin;
    private string roomStylePath="";

    private int nflag = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {

            number = Request.Form["roomNum"].ToString();
            buildingName = Request.Form["roomBuild"].ToString();

            room = roomDAO.GetRoomByNumAndBuild(number, buildingName);
            if (room == null)
            {

                //if (Request.Form["roomFloor"].ToString() != "" && Request.Form["roomFloor"].ToString() != null)
                //    floor = int.Parse(Request.Form["roomFloor"].ToString());
                if (Request.Form["roomArea"].ToString() != "" && Request.Form["roomArea"].ToString() != null)
                    area = double.Parse(Request.Form["roomArea"].ToString());
                //Request.Form["roomStyle"].ToString();
                if (Request.Form["roomStyle"].ToString() != "" && Request.Form["roomStyle"].ToString() != null)
                    style = Boolean.Parse(Request.Form["roomStyle"].ToString());
                //if (Request.Form["roomRent"].ToString() != "" && Request.Form["roomRent"].ToString() != null)
                    rent = Request.Form["roomRent"].ToString();
                roomStyle = Request.Form["roomRoomStyle"].ToString();
                if (Request.Form["roomManFee"].ToString() != "" && Request.Form["roomManFee"].ToString() != null)
                    manageFee = double.Parse(Request.Form["roomManFee"].ToString());
                //if (Request.Form["roomTaxes"].ToString() != "" && Request.Form["roomTaxes"].ToString() != null)
                //    taxes = double.Parse(Request.Form["roomTaxes"].ToString());
                toward = Request.Form["roomToward"].ToString();
                if (Request.Form["roomHeight"].ToString() != "" && Request.Form["roomHeight"].ToString() != null)
                    floorHeight = double.Parse(Request.Form["roomHeight"].ToString());
                decoration = Request.Form["roomDecor"].ToString();
                if (Request.Form["roomMinLease"].ToString() != "" && Request.Form["roomMinLease"].ToString() != null)
                    minLease = int.Parse(Request.Form["roomMinLease"].ToString());
                payMode = Request.Form["roomPayMode"].ToString();
                if (Request.Form["roomIsRent"].ToString() != "" && Request.Form["roomIsRent"].ToString() != null)
                    isRent = Boolean.Parse(Request.Form["roomIsRent"].ToString());
                lessee = Request.Form["roomLessee"].ToString();
                if (Request.Form["roomRentStart"].ToString() != "" && Request.Form["roomRentStart"].ToString() != null)
                    rentStart = DateTime.Parse(Request.Form["roomRentStart"].ToString());
                if (Request.Form["roomRentEnd"].ToString() != "" && Request.Form["roomRentEnd"].ToString() != null)
                    rentEnd = DateTime.Parse(Request.Form["roomRentEnd"].ToString());
                remark = Request.Form["roomRemark"].ToString();
                if (Request.Form["roomIsShowed"].ToString() != "" && Request.Form["roomIsShowed"].ToString() != null)
                    isShowed = Boolean.Parse(Request.Form["roomIsShowed"].ToString());

                buildID = Request.Form["buildID"].ToString();
                admin = Request.Form["roomAdmin"].ToString();
                

                if (rentStart != null && rentEnd != null)
                {
                    if (DateTime.Compare((DateTime)rentStart, (DateTime)rentEnd) > 0)
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('入住时间应该早于搬离时间！！！');location.href=('AddRoom.aspx');</script>");
                    else
                    {
                        if (DateTime.Compare((DateTime)rentEnd, DateTime.Now) < 0)
                        {
                            isRent = false;
                            nflag = 1;
                        }
                    }
                }



                room = new Room();
                room.Number = number;
                room.BuildingName = buildingName;
                room.Floor = floor;
                room.Area = area;
                room.Style = style;
                room.Rent = rent;
                room.RoomStyle = roomStyle;
                room.ManageFee = manageFee;
                room.Taxes = taxes;
                room.Toward = toward;
                room.FloorHeight = floorHeight;
                room.Decoration = decoration;
                room.MinLease = minLease;
                room.PayMode = payMode;
                room.IsRent = isRent;
                room.Lessee = lessee;
                room.RentStart = rentStart;
                room.RentEnd = rentEnd;
                room.Remark = remark;
                room.IsShowed = isShowed;
                room.BuildID = buildID;
                room.Admin = admin;
                room.RoomStylePath = roomStylePath;



                int flag = roomDAO.AddRoom(room);
                if (flag > 0)
                {
                    if (nflag == 1)
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!警告：搬离时间已经超过，该房间状况将设为未租用！！！');location.href=('AddRoom.aspx');</script>");
                    else
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('AddRoom.aspx');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");

                }
            }
            else
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('此房间已经存在，请重新输入!');history.go(-1);</script>");

        }
    }
}