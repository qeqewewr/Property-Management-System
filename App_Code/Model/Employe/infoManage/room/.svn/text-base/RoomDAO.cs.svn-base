using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CEMIS.Model.Employe;
using CEMIS.Util;
using System.Data.SqlClient;
using System.Data.Sql;

/// <summary>
///RoomDAO 的摘要说明
/// </summary>
/// 
namespace CEMIS.Model.Employe
{
    public class RoomDAO
    {
        public int SearchNum = 0;
        public RoomDAO()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        //添加房间信息
        public int AddRoom(Room room)
        {

            DBConnection db = new DBConnection();

           
            db.AddParameter("@Number", room.Number);
            
            db.AddParameter("@BuildingName", room.BuildingName);
            if (room.Floor != 0)
                db.AddParameter("@Floor", room.Floor);
            else
                db.AddParameter("@Floor", DBNull.Value);
            if (room.Area != 0)
                db.AddParameter("@Area", room.Area);
            else
                db.AddParameter("@Area", DBNull.Value);
            if (room.Style != null)
                db.AddParameter("@Style", room.Style);
            else
                db.AddParameter("@Style", DBNull.Value);

            db.AddParameter("@Rent", room.Rent);
         
            db.AddParameter("@RoomStyle", room.RoomStyle);
            if (room.ManageFee != 0)
                db.AddParameter("@ManageFee", room.ManageFee);
            else
                db.AddParameter("@ManageFee", DBNull.Value);
            if (room.Taxes != 0)
                db.AddParameter("@Taxes", room.Taxes);
            else
                db.AddParameter("@Taxes", DBNull.Value);
            db.AddParameter("@Toward", room.Toward);
            if (room.FloorHeight != 0)
                db.AddParameter("@FloorHeight", room.FloorHeight);
            else
                db.AddParameter("@FloorHeight", DBNull.Value);

            db.AddParameter("@Decoration", room.Decoration);
            if(room.MinLease!=0)
                db.AddParameter("@MinLease", room.MinLease);
            else
                db.AddParameter("@MinLease", DBNull.Value);   
            if (room.IsRent != null)
                db.AddParameter("@IsRent", room.IsRent);
            else
                db.AddParameter("@IsRent", DBNull.Value);

            db.AddParameter("@PayMode", room.PayMode);
            db.AddParameter("@Lessee", room.Lessee);
            if (room.RentStart != null)
                db.AddParameter("@RentStart", room.RentStart);
            else
                db.AddParameter("@RentStart", DBNull.Value);
            if (room.RentEnd != null)
                db.AddParameter("@RentEnd", room.RentEnd);
            else
                db.AddParameter("@RentEnd", DBNull.Value);
            db.AddParameter("@Remark", room.Remark);
            if (room.IsShowed != null)
                db.AddParameter("@IsShowed", room.IsShowed);
            else
                db.AddParameter("@IsShowed", DBNull.Value);

            db.AddParameter("@BuildID", room.BuildID);
            db.AddParameter("@Admin", room.Admin);
            db.AddParameter("@RoomStylePath", room.RoomStylePath);


            string sql = "insert into Room(Number,BuildingName,Floor,Area,Style,Rent,RoomStyle,ManageFee,Taxes,Toward,FloorHeight,Decoration,MinLease,PayMode,IsRent,Lessee,RentStart,RentEnd,Remark,IsShowed,BuildID,Admin,RoomStylePath) values(@Number,@BuildingName,@Floor,@Area,@Style,@Rent,@RoomStyle,@ManageFee,@Taxes,@Toward,@FloorHeight,@Decoration,@MinLease,@PayMode,@IsRent,@Lessee,@RentStart,@RentEnd,@Remark,@IsShowed,@BuildID,@Admin,@RoomStylePath)";


            return db.ExecuteNonQuery(sql);
        }

        //房间信息编辑
        public int UpdateRoom(Room room)
        {
            DBConnection db = new DBConnection();

            if (room.ID != 0)
                db.AddParameter("@ID", room.ID);
            else
                db.AddParameter("@ID", DBNull.Value);

            
            db.AddParameter("@Number", room.Number);
          
            db.AddParameter("@BuildingName", room.BuildingName);
            if (room.Floor != 0)
                db.AddParameter("@Floor", room.Floor);
            else
                db.AddParameter("@Floor", DBNull.Value);
            if (room.Area != 0)
                db.AddParameter("@Area", room.Area);
            else
                db.AddParameter("@Area", DBNull.Value);
            if (room.Style != null)
                db.AddParameter("@Style", room.Style);
            else
                db.AddParameter("@Style", DBNull.Value);
       
            db.AddParameter("@Rent", room.Rent);
       
            db.AddParameter("@RoomStyle", room.RoomStyle);
            if (room.ManageFee != 0)
                db.AddParameter("@ManageFee", room.ManageFee);
            else
                db.AddParameter("@ManageFee", DBNull.Value);
            if (room.Taxes != 0)
                db.AddParameter("@Taxes", room.Taxes);
            else
                db.AddParameter("@Taxes", DBNull.Value);
            db.AddParameter("@Toward", room.Toward);
            if (room.FloorHeight != 0)
                db.AddParameter("@FloorHeight", room.FloorHeight);
            else
                db.AddParameter("@FloorHeight", DBNull.Value);

            db.AddParameter("@Decoration", room.Decoration);
            if (room.MinLease != 0)
                db.AddParameter("@MinLease", room.MinLease);
            else
                db.AddParameter("@MinLease", DBNull.Value); 
            if (room.IsRent != null)
                db.AddParameter("@IsRent", room.IsRent);
            else
                db.AddParameter("@IsRent", DBNull.Value);

            db.AddParameter("@PayMode", room.PayMode);
            db.AddParameter("@Lessee", room.Lessee);
            if (room.RentStart != null)
                db.AddParameter("@RentStart", room.RentStart);
            else
                db.AddParameter("@RentStart", DBNull.Value);
            if (room.RentEnd != null)
                db.AddParameter("@RentEnd", room.RentEnd);
            else
                db.AddParameter("@RentEnd", DBNull.Value);
            db.AddParameter("@Remark", room.Remark);
            if (room.IsShowed != null)
                db.AddParameter("@IsShowed", room.IsShowed);
            else
                db.AddParameter("@IsShowed", DBNull.Value);

            db.AddParameter("@BuildID", room.BuildID);
            db.AddParameter("@Admin", room.Admin);
            db.AddParameter("@RoomStylePath", room.RoomStylePath);

            string sql = "";
            sql = "update Room set Number=@Number,BuildingName=@BuildingName, Floor=@Floor,Area=@Area,Style=@Style,Rent=@Rent,RoomStyle=@RoomStyle,ManageFee=@ManageFee,Taxes=@Taxes,Toward=@Toward,FloorHeight=@FloorHeight,Decoration=@Decoration,MinLease=@MinLease,PayMode=@PayMode,IsRent=@IsRent,Lessee=@Lessee,RentStart=@RentStart,RentEnd=@RentEnd,Remark=@Remark,IsShowed=@IsShowed,BuildID=@BuildID,Admin=@Admin,RoomStylePath=@RoomStylePath  where ID=@ID";


            return db.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 通过大楼名称查找房间信息
        /// </summary>
        /// <param name="build"></param>
        /// <returns></returns>
        public List<string> ListRoomNumberByBuildingName(string build)
        {
            List<string> rooms = new List<string>();
            DBConnection db = new DBConnection();

            db.AddParameter("@BuildingName", build);
            string sql = "select Number from Room where BuildingName=@BuildingName";
            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                rooms.Add(sdr["Number"].ToString());
            }
            db.Dispose();
            return rooms;
        }

        /// <summary>
        /// 获取房间信息列表
        /// </summary>
        /// <returns></returns>

        public List<Room> ListRoom()
        {
            List<Room> roomList = new List<Room>();

            DBConnection db = new DBConnection();
            string sql = "select * from Room";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                Room room = new Room();
                if (sdr["ID"].ToString() != "" && sdr["ID"].ToString() != null)
                    room.ID = int.Parse(sdr["ID"].ToString());
                if (sdr["Number"].ToString() != "" && sdr["Number"].ToString()!=null)
                    room.Number = sdr["Number"].ToString();
                if (sdr["BuildingName"].ToString() != "" && sdr["BuildingName"].ToString()!=null)
                    room.BuildingName = sdr["BuildingName"].ToString();
                if (sdr["Floor"].ToString() != "" && sdr["Floor"].ToString()!=null)
                    room.Floor = int.Parse(sdr["Floor"].ToString());
                if (sdr["Area"].ToString() != "" && sdr["Area"].ToString()!=null)
                    room.Area = double.Parse(sdr["Area"].ToString());
                if (sdr["Style"].ToString() != "" && sdr["Style"].ToString()!=null)
                    room.Style = Boolean.Parse(sdr["Style"].ToString());
                if (sdr["Rent"].ToString() != "" && sdr["Rent"].ToString()!=null)
                    room.Rent = sdr["Rent"].ToString();
                if (sdr["RoomStyle"].ToString() != "" && sdr["RoomStyle"].ToString()!=null)
                    room.RoomStyle = sdr["RoomStyle"].ToString();
                if (sdr["ManageFee"].ToString() != "" && sdr["ManageFee"].ToString()!=null)
                    room.ManageFee = double.Parse(sdr["ManageFee"].ToString());
                if (sdr["Taxes"].ToString() != "" && sdr["Taxes"].ToString()!=null)
                    room.Taxes = double.Parse(sdr["Taxes"].ToString());
                if (sdr["Toward"].ToString() != "" && sdr["Toward"].ToString()!=null)
                    room.Toward = sdr["Toward"].ToString();
                if (sdr["FloorHeight"].ToString() != "" && sdr["FloorHeight"].ToString()!=null)
                    room.FloorHeight = double.Parse(sdr["FloorHeight"].ToString());
                if (sdr["Decoration"].ToString() != "" && sdr["Decoration"].ToString()!=null)
                    room.Decoration = sdr["Decoration"].ToString();
                if (sdr["MinLease"].ToString() != "" && sdr["MinLease"].ToString()!=null)
                    room.MinLease = int.Parse(sdr["MinLease"].ToString()); 
                if (sdr["IsRent"].ToString() != "" && sdr["IsRent"].ToString()!=null)
                    room.IsRent = Boolean.Parse(sdr["IsRent"].ToString());
                if (sdr["PayMode"].ToString() != "" && sdr["PayMode"].ToString() != null)
                    room.PayMode = sdr["PayMode"].ToString();
                if (sdr["Lessee"].ToString() != "" && sdr["Lessee"].ToString() != null)
                    room.Lessee = sdr["Lessee"].ToString();
                if (sdr["RentStart"].ToString() != "" && sdr["RentStart"].ToString() != null)
                    room.RentStart = DateTime.Parse(sdr["RentStart"].ToString());
                if (sdr["RentEnd"].ToString() != "" && sdr["RentEnd"].ToString() != null)
                    room.RentEnd = DateTime.Parse(sdr["RentEnd"].ToString());
                if (sdr["Remark"].ToString() != "" && sdr["Remark"].ToString() != null)
                    room.Remark = sdr["Remark"].ToString();
                if (sdr["IsShowed"].ToString() != "" && sdr["IsShowed"].ToString()!=null)
                    room.IsShowed = Boolean.Parse(sdr["IsShowed"].ToString());

                if (sdr["BuildID"].ToString() != "" && sdr["BuildID"].ToString() != null)
                    room.BuildID = sdr["BuildID"].ToString();
                if (sdr["Admin"].ToString() != "" && sdr["Admin"].ToString() != null)
                    room.Admin = sdr["Admin"].ToString();
                if (sdr["RoomStylePath"].ToString() != "" && sdr["RoomStylePath"].ToString() != null)
                    room.RoomStylePath = sdr["RoomStylePath"].ToString();

                roomList.Add(room);
            }
            db.Dispose();
            return roomList;
        }
        
        //获得当前页房间信息，1：已租用，0：未租用，2：全部
        public List<Room> ListPageRoom(int pageno, int pagesize, int scope)
        {
            List<Room> RoomList = new List<Room>();
            int rowcount = this.GetScopeTotalNum(2);
            string sql = "";
            DBConnection db = new DBConnection();

            Boolean IsRent = false;

            if (scope == 2)
            {
                rowcount = this.GetScopeTotalNum(2);
                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by BuildingName,Number) as rownum ,* from Room ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by BuildingName,Number) as rownum, * from Room )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
            }
            else
            {
                if (scope == 0)
                {
                    rowcount = this.GetScopeTotalNum(0);
                    IsRent = false;
                }
                if (scope == 1)
                {
                    rowcount = this.GetScopeTotalNum(1);
                    IsRent = true;
                }
                db.AddParameter("@IsRent", IsRent);
                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by BuildingName,Number) as rownum ,* from Room where IsRent=@IsRent) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by BuildingName,Number) as rownum, * from Room where IsRent=@IsRent )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
            }


            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                Room room = new Room();
                if (sdr["ID"].ToString() != "" && sdr["ID"].ToString() != null)
                    room.ID = int.Parse(sdr["ID"].ToString());
                if (sdr["Number"].ToString() != "" && sdr["Number"].ToString() != null)
                    room.Number = sdr["Number"].ToString();
                if (sdr["BuildingName"].ToString() != "" && sdr["BuildingName"].ToString() != null)
                    room.BuildingName = sdr["BuildingName"].ToString();
                if (sdr["Floor"].ToString() != "" && sdr["Floor"].ToString() != null)
                    room.Floor = int.Parse(sdr["Floor"].ToString());
                if (sdr["Area"].ToString() != "" && sdr["Area"].ToString() != null)
                    room.Area = double.Parse(sdr["Area"].ToString());
                if (sdr["Style"].ToString() != "" && sdr["Style"].ToString() != null)
                    room.Style = Boolean.Parse(sdr["Style"].ToString());
                if (sdr["Rent"].ToString() != "" && sdr["Rent"].ToString() != null)
                    room.Rent = sdr["Rent"].ToString();
                if (sdr["RoomStyle"].ToString() != "" && sdr["RoomStyle"].ToString() != null)
                    room.RoomStyle = sdr["RoomStyle"].ToString();
                if (sdr["ManageFee"].ToString() != "" && sdr["ManageFee"].ToString() != null)
                    room.ManageFee = double.Parse(sdr["ManageFee"].ToString());
                if (sdr["Taxes"].ToString() != "" && sdr["Taxes"].ToString() != null)
                    room.Taxes = double.Parse(sdr["Taxes"].ToString());
                if (sdr["Toward"].ToString() != "" && sdr["Toward"].ToString() != null)
                    room.Toward = sdr["Toward"].ToString();
                if (sdr["FloorHeight"].ToString() != "" && sdr["FloorHeight"].ToString() != null)
                    room.FloorHeight = double.Parse(sdr["FloorHeight"].ToString());
                if (sdr["Decoration"].ToString() != "" && sdr["Decoration"].ToString() != null)
                    room.Decoration = sdr["Decoration"].ToString();
                if (sdr["MinLease"].ToString() != "" && sdr["MinLease"].ToString() != null)
                    room.MinLease = int.Parse(sdr["MinLease"].ToString());
                if (sdr["PayMode"].ToString() != "" && sdr["PayMode"].ToString() != null)
                    room.PayMode = sdr["PayMode"].ToString();
                if (sdr["IsRent"].ToString() != "" && sdr["IsRent"].ToString() != null)
                    room.IsRent = Boolean.Parse(sdr["IsRent"].ToString());
                if (sdr["Lessee"].ToString() != "" && sdr["Lessee"].ToString() != null)
                    room.Lessee = sdr["Lessee"].ToString();
                if (sdr["RentStart"].ToString() != "" && sdr["RentStart"].ToString() != null)
                    room.RentStart = DateTime.Parse(sdr["RentStart"].ToString());
                if (sdr["RentEnd"].ToString() != "" && sdr["RentEnd"].ToString() != null)
                    room.RentEnd = DateTime.Parse(sdr["RentEnd"].ToString());
                if (sdr["Remark"].ToString() != "" && sdr["Remark"].ToString() != null)
                    room.Remark = sdr["Remark"].ToString();
                if (sdr["IsShowed"].ToString() != "" && sdr["IsShowed"].ToString() != null)
                    room.IsShowed = Boolean.Parse(sdr["IsShowed"].ToString());

                if (sdr["BuildID"].ToString() != "" && sdr["BuildID"].ToString() != null)
                    room.BuildID = sdr["BuildID"].ToString();
                if (sdr["Admin"].ToString() != "" && sdr["Admin"].ToString() != null)
                    room.Admin = sdr["Admin"].ToString();
                if (sdr["RoomStylePath"].ToString() != "" && sdr["RoomStylePath"].ToString() != null)
                    room.RoomStylePath = sdr["RoomStylePath"].ToString();

                RoomList.Add(room);
            }
            db.Dispose();
            return RoomList;
        }

        //通过房间号和大楼名删除房间
        public int deleteRoom(string number,string buildingName)
        {
            DBConnection db = new DBConnection();

            
            db.AddParameter("@Number", number);
            
            db.AddParameter("@BuildingName",buildingName);

            string sql = "delete from Room where Number=@Number and BuildingName=@BuildingName";
            return db.ExecuteNonQuery(sql);
        }

        //通过id删除房间信息
        public int deleteRoom(int id)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@ID", id);

            string sql = "delete from Room where ID=@ID";
            return db.ExecuteNonQuery(sql);
        }

      
        //用房间号、大楼名和租用情况进行模糊查询
        public List<Room> SearchRoomList(string number, string buildingName, int scope,int pageno,int pagesize)
        {
            string sql = "";
            Boolean IsRent = false;
            string searchNum = "";
            int rowcount = 0;

            DBConnection db = new DBConnection();

            db.AddParameter("@BuildingName", buildingName);
            searchNum = "%" + number + "%";
            db.AddParameter("@Number", searchNum);
 
           

            if (scope == 2)
            {
                //记录查询的总数
                DBConnection db1 = new DBConnection();
                db1.AddParameter("@Number", searchNum);
                db1.AddParameter("@BuildingName", buildingName);
                string sql1 = "select count(*) as a from Room where Number like @Number and BuildingName=@BuildingName ";

                SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
                while (sdr1.Read())
                {
                    SearchNum = int.Parse(sdr1["a"].ToString());
                }
                db1.Dispose();


                rowcount = SearchNum;

                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by BuildingName,Number) as rownum ,* from Room where Number like @Number and BuildingName=@BuildingName) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by BuildingName,Number) as rownum, * from Room where Number like @Number and BuildingName=@BuildingName )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
            }
            else
            {
                if (scope == 0)
                    IsRent = false;
                if (scope == 1)
                    IsRent = true;

                db.AddParameter("@IsRent", IsRent);

                DBConnection db1 = new DBConnection();
                db1.AddParameter("@Number", searchNum);
                db1.AddParameter("@IsRent", IsRent);
                db1.AddParameter("@BuildingName", buildingName);
                string sql1 = "select count(*) as a from Room where Number like @Number and BuildingName=@BuildingName and IsRent=@IsRent";

                SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
                while (sdr1.Read())
                {
                    SearchNum = int.Parse(sdr1["a"].ToString());
                }
                db1.Dispose();

                rowcount = SearchNum;

                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by BuildingName,Number) as rownum ,* from Room where Number like @Number and BuildingName=@BuildingName and IsRent=@IsRent) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by BuildingName,Number) as rownum, * from Room where Number like @Number and BuildingName=@BuildingName and IsRent=@IsRent)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
                
            }
            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            Room room = new Room();
            List<Room> roomList=new List<Room>();

            while (sdr.Read())
            {
                room=new Room ();
                if (sdr["ID"].ToString() != "" && sdr["ID"].ToString() != null)
                    room.ID = int.Parse(sdr["ID"].ToString());
                if (sdr["Number"].ToString() != "" && sdr["Number"].ToString() != null)
                    room.Number = sdr["Number"].ToString();
                if (sdr["BuildingName"].ToString() != "" && sdr["BuildingName"].ToString() != null)
                    room.BuildingName = sdr["BuildingName"].ToString();
                if (sdr["Floor"].ToString() != "" && sdr["Floor"].ToString() != null)
                    room.Floor = int.Parse(sdr["Floor"].ToString());
                if (sdr["Area"].ToString() != "" && sdr["Area"].ToString() != null)
                    room.Area = double.Parse(sdr["Area"].ToString());
                if (sdr["Style"].ToString() != "" && sdr["Style"].ToString() != null)
                    room.Style = Boolean.Parse(sdr["Style"].ToString());
                if (sdr["Rent"].ToString() != "" && sdr["Rent"].ToString() != null)
                    room.Rent = sdr["Rent"].ToString();
                if (sdr["RoomStyle"].ToString() != "" && sdr["RoomStyle"].ToString() != null)
                    room.RoomStyle = sdr["RoomStyle"].ToString();
                if (sdr["ManageFee"].ToString() != "" && sdr["ManageFee"].ToString() != null)
                    room.ManageFee = double.Parse(sdr["ManageFee"].ToString());
                if (sdr["Taxes"].ToString() != "" && sdr["Taxes"].ToString() != null)
                    room.Taxes = double.Parse(sdr["Taxes"].ToString());
                if (sdr["Toward"].ToString() != "" && sdr["Toward"].ToString() != null)
                    room.Toward = sdr["Toward"].ToString();
                if (sdr["FloorHeight"].ToString() != "" && sdr["FloorHeight"].ToString() != null)
                    room.FloorHeight = double.Parse(sdr["FloorHeight"].ToString());
                if (sdr["Decoration"].ToString() != "" && sdr["Decoration"].ToString() != null)
                    room.Decoration = sdr["Decoration"].ToString();
                if (sdr["MinLease"].ToString() != "" && sdr["MinLease"].ToString() != null)
                    room.MinLease = int.Parse(sdr["MinLease"].ToString());
                if (sdr["IsRent"].ToString() != "" && sdr["IsRent"].ToString() != null)
                    room.IsRent = Boolean.Parse(sdr["IsRent"].ToString());

                if (sdr["PayMode"].ToString() != "" && sdr["PayMode"].ToString() != null)
                    room.PayMode = sdr["PayMode"].ToString();

                if (sdr["Lessee"].ToString() != "" && sdr["Lessee"].ToString() != null)
                    room.Lessee = sdr["Lessee"].ToString();
                if (sdr["RentStart"].ToString() != "" && sdr["RentStart"].ToString() != null)
                    room.RentStart = DateTime.Parse(sdr["RentStart"].ToString());
                if (sdr["RentEnd"].ToString() != "" && sdr["RentEnd"].ToString() != null)
                    room.RentEnd = DateTime.Parse(sdr["RentEnd"].ToString());
                if (sdr["Remark"].ToString() != "" && sdr["Remark"].ToString() != null)
                    room.Remark = sdr["Remark"].ToString();
                if (sdr["IsShowed"].ToString() != "" && sdr["IsShowed"].ToString() != null)
                    room.IsShowed = Boolean.Parse(sdr["IsShowed"].ToString());

                if (sdr["BuildID"].ToString() != "" && sdr["BuildID"].ToString() != null)
                    room.BuildID = sdr["BuildID"].ToString();
                if (sdr["Admin"].ToString() != "" && sdr["Admin"].ToString() != null)
                    room.Admin = sdr["Admin"].ToString();
                if (sdr["RoomStylePath"].ToString() != "" && sdr["RoomStylePath"].ToString() != null)
                    room.RoomStylePath = sdr["RoomStylePath"].ToString();

                roomList.Add(room);
            }
          
            db.Dispose();
            return roomList;
        }

        //通过大楼名和租用情况查询房间信息
        public List<Room> SearchRoomList(string buildingName, int scope, int pageno, int pagesize)
        {
            string sql = "";
            Boolean IsRent = false;

            int rowcount = 0;

            DBConnection db = new DBConnection();

            db.AddParameter("@BuildingName", buildingName);


            if (scope == 2)
            {                
                rowcount = this.GetScopeAndBuildTotalNum(scope, buildingName);

                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by BuildingName,Number) as rownum ,* from Room where  BuildingName=@BuildingName) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by BuildingName,Number) as rownum, * from Room where  BuildingName=@BuildingName )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
            }
            else
            {
                if (scope == 0)
                    IsRent = false;
                if (scope == 1)
                    IsRent = true;

                db.AddParameter("@IsRent", IsRent);

                //DBConnection db1 = new DBConnection();
         
                //db1.AddParameter("@BuildingName", buildingName);
                //string sql1 = "select count(*) as a from Room where BuildingName=@BuildingName and IsRent=@IsRent";

                //SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
                //while (sdr1.Read())
                //{
                //    SearchNum = int.Parse(sdr1["a"].ToString());
                //}
                //db1.Dispose();

                rowcount = this.GetScopeAndBuildTotalNum(scope,buildingName);

                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by BuildingName,Number) as rownum ,* from Room where  BuildingName=@BuildingName and IsRent=@IsRent) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by BuildingName,Number) as rownum, * from Room where  BuildingName=@BuildingName and IsRent=@IsRent)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            }
            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            Room room = new Room();
            List<Room> roomList = new List<Room>();

            while (sdr.Read())
            {
                room = new Room();
                if (sdr["ID"].ToString() != "" && sdr["ID"].ToString() != null)
                    room.ID = int.Parse(sdr["ID"].ToString());
                if (sdr["Number"].ToString() != "" && sdr["Number"].ToString() != null)
                    room.Number = sdr["Number"].ToString();
                if (sdr["BuildingName"].ToString() != "" && sdr["BuildingName"].ToString() != null)
                    room.BuildingName = sdr["BuildingName"].ToString();
                if (sdr["Floor"].ToString() != "" && sdr["Floor"].ToString() != null)
                    room.Floor = int.Parse(sdr["Floor"].ToString());
                if (sdr["Area"].ToString() != "" && sdr["Area"].ToString() != null)
                    room.Area = double.Parse(sdr["Area"].ToString());
                if (sdr["Style"].ToString() != "" && sdr["Style"].ToString() != null)
                    room.Style = Boolean.Parse(sdr["Style"].ToString());
                if (sdr["Rent"].ToString() != "" && sdr["Rent"].ToString() != null)
                    room.Rent = sdr["Rent"].ToString();
                if (sdr["RoomStyle"].ToString() != "" && sdr["RoomStyle"].ToString() != null)
                    room.RoomStyle = sdr["RoomStyle"].ToString();
                if (sdr["ManageFee"].ToString() != "" && sdr["ManageFee"].ToString() != null)
                    room.ManageFee = double.Parse(sdr["ManageFee"].ToString());
                if (sdr["Taxes"].ToString() != "" && sdr["Taxes"].ToString() != null)
                    room.Taxes = double.Parse(sdr["Taxes"].ToString());
                if (sdr["Toward"].ToString() != "" && sdr["Toward"].ToString() != null)
                    room.Toward = sdr["Toward"].ToString();
                if (sdr["FloorHeight"].ToString() != "" && sdr["FloorHeight"].ToString() != null)
                    room.FloorHeight = double.Parse(sdr["FloorHeight"].ToString());
                if (sdr["Decoration"].ToString() != "" && sdr["Decoration"].ToString() != null)
                    room.Decoration = sdr["Decoration"].ToString();
                if (sdr["MinLease"].ToString() != "" && sdr["MinLease"].ToString() != null)
                    room.MinLease = int.Parse(sdr["MinLease"].ToString());
                if (sdr["IsRent"].ToString() != "" && sdr["IsRent"].ToString() != null)
                    room.IsRent = Boolean.Parse(sdr["IsRent"].ToString());

                if (sdr["PayMode"].ToString() != "" && sdr["PayMode"].ToString() != null)
                    room.PayMode = sdr["PayMode"].ToString();

                if (sdr["Lessee"].ToString() != "" && sdr["Lessee"].ToString() != null)
                    room.Lessee = sdr["Lessee"].ToString();
                if (sdr["RentStart"].ToString() != "" && sdr["RentStart"].ToString() != null)
                    room.RentStart = DateTime.Parse(sdr["RentStart"].ToString());
                if (sdr["RentEnd"].ToString() != "" && sdr["RentEnd"].ToString() != null)
                    room.RentEnd = DateTime.Parse(sdr["RentEnd"].ToString());
                if (sdr["Remark"].ToString() != "" && sdr["Remark"].ToString() != null)
                    room.Remark = sdr["Remark"].ToString();
                if (sdr["IsShowed"].ToString() != "" && sdr["IsShowed"].ToString() != null)
                    room.IsShowed = Boolean.Parse(sdr["IsShowed"].ToString());

                if (sdr["BuildID"].ToString() != "" && sdr["BuildID"].ToString() != null)
                    room.BuildID = sdr["BuildID"].ToString();
                if (sdr["Admin"].ToString() != "" && sdr["Admin"].ToString() != null)
                    room.Admin = sdr["Admin"].ToString();
                if (sdr["RoomStylePath"].ToString() != "" && sdr["RoomStylePath"].ToString() != null)
                    room.RoomStylePath = sdr["RoomStylePath"].ToString();

                roomList.Add(room);
            }

            db.Dispose();
            return roomList;
        }

        //通过房间号和租用情况进行模糊查询
        public List<Room> SearchRoomListByName(string number,int scope, int pageno, int pagesize)
        {
            string sql = "";
            Boolean IsRent = false;
            string searchNum = "";
            int rowcount = 0;

            DBConnection db = new DBConnection();

        
            searchNum = "%" + number + "%";
            db.AddParameter("@Number", searchNum);



            if (scope == 2)
            {
                //记录查询的总数
                DBConnection db1 = new DBConnection();
                db1.AddParameter("@Number", searchNum);
       
                string sql1 = "select count(*) as a from Room where Number like @Number  ";

                SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
                while (sdr1.Read())
                {
                    SearchNum = int.Parse(sdr1["a"].ToString());
                }
                db1.Dispose();


                rowcount = SearchNum;

                if (pageno * pagesize > rowcount)
                    //sql = "with temp as( select row_number() over(order by ID) as rownum ,* from Room where Number like @Number ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                    sql = "with temp as( select row_number() over(order by BuildingName,Number) as rownum ,* from Room where Number like @Number ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    //sql = "with temp as( select row_number() over(order by ID) as rownum, * from Room where Number like @Number )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
                    sql = "with temp as( select row_number() over(order by BuildingName,Number) as rownum, * from Room where Number like @Number )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
            }
            else
            {
                if (scope == 0)
                    IsRent = false;
                if (scope == 1)
                    IsRent = true;

                db.AddParameter("@IsRent", IsRent);

                DBConnection db1 = new DBConnection();
                db1.AddParameter("@Number", searchNum);
                db1.AddParameter("@IsRent", IsRent);
           
                string sql1 = "select count(*) as a from Room where Number like @Number and IsRent=@IsRent";

                SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
                while (sdr1.Read())
                {
                    SearchNum = int.Parse(sdr1["a"].ToString());
                }
                db1.Dispose();

                rowcount = SearchNum;

                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by BuildingName,Number) as rownum ,* from Room where Number like @Number  and IsRent=@IsRent) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by BuildingName,Number) as rownum, * from Room where Number like @Number  and IsRent=@IsRent)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            }
            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            Room room = new Room();
            List<Room> roomList = new List<Room>();

            while (sdr.Read())
            {
                room = new Room();
                if (sdr["ID"].ToString() != "" && sdr["ID"].ToString() != null)
                    room.ID = int.Parse(sdr["ID"].ToString());
                if (sdr["Number"].ToString() != "" && sdr["Number"].ToString() != null)
                    room.Number = sdr["Number"].ToString();
                if (sdr["BuildingName"].ToString() != "" && sdr["BuildingName"].ToString() != null)
                    room.BuildingName = sdr["BuildingName"].ToString();
                if (sdr["Floor"].ToString() != "" && sdr["Floor"].ToString() != null)
                    room.Floor = int.Parse(sdr["Floor"].ToString());
                if (sdr["Area"].ToString() != "" && sdr["Area"].ToString() != null)
                    room.Area = double.Parse(sdr["Area"].ToString());
                if (sdr["Style"].ToString() != "" && sdr["Style"].ToString() != null)
                    room.Style = Boolean.Parse(sdr["Style"].ToString());
                if (sdr["Rent"].ToString() != "" && sdr["Rent"].ToString() != null)
                    room.Rent = sdr["Rent"].ToString();
                if (sdr["RoomStyle"].ToString() != "" && sdr["RoomStyle"].ToString() != null)
                    room.RoomStyle = sdr["RoomStyle"].ToString();
                if (sdr["ManageFee"].ToString() != "" && sdr["ManageFee"].ToString() != null)
                    room.ManageFee = double.Parse(sdr["ManageFee"].ToString());
                if (sdr["Taxes"].ToString() != "" && sdr["Taxes"].ToString() != null)
                    room.Taxes = double.Parse(sdr["Taxes"].ToString());
                if (sdr["Toward"].ToString() != "" && sdr["Toward"].ToString() != null)
                    room.Toward = sdr["Toward"].ToString();
                if (sdr["FloorHeight"].ToString() != "" && sdr["FloorHeight"].ToString() != null)
                    room.FloorHeight = double.Parse(sdr["FloorHeight"].ToString());
                if (sdr["Decoration"].ToString() != "" && sdr["Decoration"].ToString() != null)
                    room.Decoration = sdr["Decoration"].ToString();
                if (sdr["MinLease"].ToString() != "" && sdr["MinLease"].ToString() != null)
                    room.MinLease = int.Parse(sdr["MinLease"].ToString());
                if (sdr["IsRent"].ToString() != "" && sdr["IsRent"].ToString() != null)
                    room.IsRent = Boolean.Parse(sdr["IsRent"].ToString());

                if (sdr["PayMode"].ToString() != "" && sdr["PayMode"].ToString() != null)
                    room.PayMode = sdr["PayMode"].ToString();

                if (sdr["Lessee"].ToString() != "" && sdr["Lessee"].ToString() != null)
                    room.Lessee = sdr["Lessee"].ToString();
                if (sdr["RentStart"].ToString() != "" && sdr["RentStart"].ToString() != null)
                    room.RentStart = DateTime.Parse(sdr["RentStart"].ToString());
                if (sdr["RentEnd"].ToString() != "" && sdr["RentEnd"].ToString() != null)
                    room.RentEnd = DateTime.Parse(sdr["RentEnd"].ToString());
                if (sdr["Remark"].ToString() != "" && sdr["Remark"].ToString() != null)
                    room.Remark = sdr["Remark"].ToString();
                if (sdr["IsShowed"].ToString() != "" && sdr["IsShowed"].ToString() != null)
                    room.IsShowed = Boolean.Parse(sdr["IsShowed"].ToString());

                if (sdr["BuildID"].ToString() != "" && sdr["BuildID"].ToString() != null)
                    room.BuildID = sdr["BuildID"].ToString();
                if (sdr["Admin"].ToString() != "" && sdr["Admin"].ToString() != null)
                    room.Admin = sdr["Admin"].ToString();
                if (sdr["RoomStylePath"].ToString() != "" && sdr["RoomStylePath"].ToString() != null)
                    room.RoomStylePath = sdr["RoomStylePath"].ToString();

                roomList.Add(room);
            }

            db.Dispose();
            return roomList;
        }

        //通过ID获得房间信息
        public Room GetRoomByID(int id)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@ID", id);

            string sql = "select * from Room where  ID=@ID ";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            Room room = new Room();

            if (sdr.Read())
            {
                if (sdr["ID"].ToString() != "" && sdr["ID"].ToString() != null)
                    room.ID = int.Parse(sdr["ID"].ToString());
                if (sdr["Number"].ToString() != "" && sdr["Number"].ToString() != null)
                    room.Number = sdr["Number"].ToString();
                if (sdr["BuildingName"].ToString() != "" && sdr["BuildingName"].ToString() != null)
                    room.BuildingName = sdr["BuildingName"].ToString();
                if (sdr["Floor"].ToString() != "" && sdr["Floor"].ToString() != null)
                    room.Floor = int.Parse(sdr["Floor"].ToString());
                if (sdr["Area"].ToString() != "" && sdr["Area"].ToString() != null)
                    room.Area = double.Parse(sdr["Area"].ToString());
                if (sdr["Style"].ToString() != "" && sdr["Style"].ToString() != null)
                    room.Style = Boolean.Parse(sdr["Style"].ToString());
                if (sdr["Rent"].ToString() != "" && sdr["Rent"].ToString() != null)
                    room.Rent = sdr["Rent"].ToString();
                if (sdr["RoomStyle"].ToString() != "" && sdr["RoomStyle"].ToString() != null)
                    room.RoomStyle = sdr["RoomStyle"].ToString();
                if (sdr["ManageFee"].ToString() != "" && sdr["ManageFee"].ToString() != null)
                    room.ManageFee = double.Parse(sdr["ManageFee"].ToString());
                if (sdr["Taxes"].ToString() != "" && sdr["Taxes"].ToString() != null)
                    room.Taxes = double.Parse(sdr["Taxes"].ToString());
                if (sdr["Toward"].ToString() != "" && sdr["Toward"].ToString() != null)
                    room.Toward = sdr["Toward"].ToString();
                if (sdr["FloorHeight"].ToString() != "" && sdr["FloorHeight"].ToString() != null)
                    room.FloorHeight = double.Parse(sdr["FloorHeight"].ToString());
                if (sdr["Decoration"].ToString() != "" && sdr["Decoration"].ToString() != null)
                    room.Decoration = sdr["Decoration"].ToString();
                if (sdr["MinLease"].ToString() != "" && sdr["MinLease"].ToString() != null)
                    room.MinLease = int.Parse(sdr["MinLease"].ToString()); 
                if (sdr["IsRent"].ToString() != "" && sdr["IsRent"].ToString() != null)
                    room.IsRent = Boolean.Parse(sdr["IsRent"].ToString());
                if (sdr["PayMode"].ToString() != "" && sdr["PayMode"].ToString() != null)
                    room.PayMode = sdr["PayMode"].ToString();
                if (sdr["Lessee"].ToString() != "" && sdr["Lessee"].ToString() != null)
                    room.Lessee = sdr["Lessee"].ToString();
                if (sdr["RentStart"].ToString() != "" && sdr["RentStart"].ToString() != null)
                    room.RentStart = DateTime.Parse(sdr["RentStart"].ToString());
                if (sdr["RentEnd"].ToString() != "" && sdr["RentEnd"].ToString() != null)
                    room.RentEnd = DateTime.Parse(sdr["RentEnd"].ToString());
                if (sdr["Remark"].ToString() != "" && sdr["Remark"].ToString() != null)
                    room.Remark = sdr["Remark"].ToString();
                if (sdr["IsShowed"].ToString() != "" && sdr["IsShowed"].ToString() != null)
                    room.IsShowed = Boolean.Parse(sdr["IsShowed"].ToString());

                if (sdr["BuildID"].ToString() != "" && sdr["BuildID"].ToString() != null)
                    room.BuildID = sdr["BuildID"].ToString();
                if (sdr["Admin"].ToString() != "" && sdr["Admin"].ToString() != null)
                    room.Admin = sdr["Admin"].ToString();
                if (sdr["RoomStylePath"].ToString() != "" && sdr["RoomStylePath"].ToString() != null)
                    room.RoomStylePath = sdr["RoomStylePath"].ToString();

            }
            else
            {
                room = null;
            }

            db.Dispose();
            return room;
        }

        //通过房号和大楼名获得房间信息
        public Room GetRoomByNumAndBuild(string num,string build)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@Number", num);
            db.AddParameter("@BuildingName", build);

            string sql = "select * from Room where  BuildingName=@BuildingName and Number=@Number ";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            Room room = new Room();

            if (sdr.Read())
            {
                if (sdr["ID"].ToString() != "" && sdr["ID"].ToString() != null)
                    room.ID = int.Parse(sdr["ID"].ToString());
                if (sdr["Number"].ToString() != "" && sdr["Number"].ToString() != null)
                    room.Number = sdr["Number"].ToString();
                if (sdr["BuildingName"].ToString() != "" && sdr["BuildingName"].ToString() != null)
                    room.BuildingName = sdr["BuildingName"].ToString();
                if (sdr["Floor"].ToString() != "" && sdr["Floor"].ToString() != null)
                    room.Floor = int.Parse(sdr["Floor"].ToString());
                if (sdr["Area"].ToString() != "" && sdr["Area"].ToString() != null)
                    room.Area = double.Parse(sdr["Area"].ToString());
                if (sdr["Style"].ToString() != "" && sdr["Style"].ToString() != null)
                    room.Style = Boolean.Parse(sdr["Style"].ToString());
                if (sdr["Rent"].ToString() != "" && sdr["Rent"].ToString() != null)
                    room.Rent = sdr["Rent"].ToString();
                if (sdr["RoomStyle"].ToString() != "" && sdr["RoomStyle"].ToString() != null)
                    room.RoomStyle = sdr["RoomStyle"].ToString();
                if (sdr["ManageFee"].ToString() != "" && sdr["ManageFee"].ToString() != null)
                    room.ManageFee = double.Parse(sdr["ManageFee"].ToString());
                if (sdr["Taxes"].ToString() != "" && sdr["Taxes"].ToString() != null)
                    room.Taxes = double.Parse(sdr["Taxes"].ToString());
                if (sdr["Toward"].ToString() != "" && sdr["Toward"].ToString() != null)
                    room.Toward = sdr["Toward"].ToString();
                if (sdr["FloorHeight"].ToString() != "" && sdr["FloorHeight"].ToString() != null)
                    room.FloorHeight = double.Parse(sdr["FloorHeight"].ToString());
                if (sdr["Decoration"].ToString() != "" && sdr["Decoration"].ToString() != null)
                    room.Decoration = sdr["Decoration"].ToString();
                if (sdr["MinLease"].ToString() != "" && sdr["MinLease"].ToString() != null)
                    room.MinLease = int.Parse(sdr["MinLease"].ToString());
                if (sdr["IsRent"].ToString() != "" && sdr["IsRent"].ToString() != null)
                    room.IsRent = Boolean.Parse(sdr["IsRent"].ToString());
                if (sdr["PayMode"].ToString() != "" && sdr["PayMode"].ToString() != null)
                    room.PayMode = sdr["PayMode"].ToString();
                if (sdr["Lessee"].ToString() != "" && sdr["Lessee"].ToString() != null)
                    room.Lessee = sdr["Lessee"].ToString();
                if (sdr["RentStart"].ToString() != "" && sdr["RentStart"].ToString() != null)
                    room.RentStart = DateTime.Parse(sdr["RentStart"].ToString());
                if (sdr["RentEnd"].ToString() != "" && sdr["RentEnd"].ToString() != null)
                    room.RentEnd = DateTime.Parse(sdr["RentEnd"].ToString());
                if (sdr["Remark"].ToString() != "" && sdr["Remark"].ToString() != null)
                    room.Remark = sdr["Remark"].ToString();
                if (sdr["IsShowed"].ToString() != "" && sdr["IsShowed"].ToString() != null)
                    room.IsShowed = Boolean.Parse(sdr["IsShowed"].ToString());

                if (sdr["BuildID"].ToString() != "" && sdr["BuildID"].ToString() != null)
                    room.BuildID = sdr["BuildID"].ToString();
                if (sdr["Admin"].ToString() != "" && sdr["Admin"].ToString() != null)
                    room.Admin = sdr["Admin"].ToString();
                if (sdr["RoomStylePath"].ToString() != "" && sdr["RoomStylePath"].ToString() != null)
                    room.RoomStylePath = sdr["RoomStylePath"].ToString();
            }
            else
            {
                room = null;
            }

            db.Dispose();
            return room;
        }

        //获得租用情况的总数，1为已租用，0为未租用，2为全部
        public int GetScopeTotalNum(int scope)
        {

            DBConnection db = new DBConnection();
            string sql="";
            if(scope==2)
                sql = "select count(*) as a from Room";
            if(scope==1)
                sql = "select count(*) as a from Room where IsRent=1";
            if (scope == 0)
                sql = "select count(*) as a from Room where IsRent=0";
            

            int count = 0;
            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                count = int.Parse(sdr["a"].ToString());
            }

            db.Dispose();
            return count;
        }

        //获得某一大楼某种租用情况的总数，1为已租用，0为未租用，2为全部
        public int GetScopeAndBuildTotalNum(int scope,string build)
        {

            DBConnection db = new DBConnection();
            string sql = "";
            db.AddParameter("@BuildingName", build);
            if (scope == 2)
                sql = "select count(*) as a from Room where BuildingName=@BuildingName";
            if (scope == 1)
                sql = "select count(*) as a from Room where IsRent=1 and BuildingName=@BuildingName";
            if (scope == 0)
                sql = "select count(*) as a from Room where IsRent=0 and BuildingName=@BuildingName";


            int count = 0;
            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                count = int.Parse(sdr["a"].ToString());
            }

            db.Dispose();
            return count;
        }

        //public int GetTotalRecordNum()
        //{

        //    DBConnection db = new DBConnection();
        //    string sql = "select count(*) as a from Room";

        //    int count = 0;
        //    SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        //    while (sdr.Read())
        //    {
        //        count = int.Parse(sdr["a"].ToString());
        //    }

        //    db.Dispose();
        //    return count;
        //}
        /// <summary>
        /// 通过租户获得大楼列表
        /// </summary>
        /// <param name="lessee"></param>
        /// <returns></returns>    
        public List<string> GetBuildByLessee(string lessee)
        {
            DBConnection db = new DBConnection();

            List<string> buildList = new List<string>();

            db.AddParameter("@Lessee", lessee);

            string sql = "select distinct BuildingName from Room where  Lessee=@Lessee and IsRent=1";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

            while (sdr.Read())
            {
                buildList.Add(sdr["BuildingName"].ToString().Trim());
            }


            db.Dispose();
            return buildList;
        }

        /// <summary>
        /// 通过大楼和租户获得房间列表
        /// </summary>
        /// <param name="lessee"></param>
        /// <returns></returns>
        public List<string> GetRoomByLesseeAndBuild(string build, string lessee)
        {
            DBConnection db = new DBConnection();

            List<string> roomList = new List<string>();
            //List<List<string>> room = new List<List<string>>();

            db.AddParameter("@Lessee", lessee);
            db.AddParameter("@BuildingName", build);

            string sql = "select Number from Room where  Lessee=@Lessee and BuildingName=@BuildingName";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

            while (sdr.Read())
            {
                roomList.Add(sdr["Number"].ToString().Trim());
            }

            db.Dispose();
            return roomList;
        }
        /// <summary>
        /// 判断是否存在房型图信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Boolean IsExistRoomStyle(string name)
        {
            DBConnection db = new DBConnection();
            Boolean isExist = false;
            db.AddParameter("@RoomStyle",name);
            string sql = "select ID from Room where  RoomStyle=@RoomStyle";
            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            if (sdr.Read())
            {
                isExist = true;
            }
            db.Dispose();
            return isExist;
            
        }

     
    }
}