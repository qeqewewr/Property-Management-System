using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CEMIS.Model.Employe;
using CEMIS.Util;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

/// <summary>
///RoomInfoDAO 的摘要说明
/// </summary>
/// 
namespace CEMIS.Model.Employe.RoomInformation
{
    public class RoomInfoDAO
    {
        public int SearchNum = 0;
        public RoomInfoDAO()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<Room> DataTableToList(DataTable dt)
        {
            List<Room> modelList = new List<Room>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Room model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Room();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    if (dt.Rows[n]["Number"] != null && dt.Rows[n]["Number"].ToString() != "")
                        model.Number = dt.Rows[n]["Number"].ToString();
                    if (dt.Rows[n]["BuildingName"] != null && dt.Rows[n]["BuildingName"].ToString() != "")
                        model.BuildingName = dt.Rows[n]["BuildingName"].ToString();
                    if (dt.Rows[n]["Floor"] != null && dt.Rows[n]["Floor"].ToString() != "")
                        model.Floor = int.Parse(dt.Rows[n]["Floor"].ToString());
                    if (dt.Rows[n]["Area"] != null && dt.Rows[n]["Area"].ToString() != "")
                        model.Area = double.Parse(dt.Rows[n]["Area"].ToString());
                    if (dt.Rows[n]["Style"] != null && dt.Rows[n]["Style"].ToString() != "")
                        model.Style = Boolean.Parse(dt.Rows[n]["Style"].ToString());
                    if (dt.Rows[n]["Rent"] != null && dt.Rows[n]["Rent"].ToString() != "")
                        model.Rent = dt.Rows[n]["Rent"].ToString();
                    if (dt.Rows[n]["RoomStyle"] != null && dt.Rows[n]["RoomStyle"].ToString() != "")
                        model.RoomStyle = dt.Rows[n]["RoomStyle"].ToString();
                    if (dt.Rows[n]["Taxes"] != null && dt.Rows[n]["Taxes"].ToString() != "")
                        model.Taxes = double.Parse(dt.Rows[n]["Taxes"].ToString());
                    if (dt.Rows[n]["ManageFee"] != null && dt.Rows[n]["ManageFee"].ToString() != "")
                        model.ManageFee = double.Parse(dt.Rows[n]["ManageFee"].ToString());
                    if (dt.Rows[n]["Toward"] != null && dt.Rows[n]["Toward"].ToString() != "")
                        model.Toward = dt.Rows[n]["Toward"].ToString();
                    if (dt.Rows[n]["FloorHeight"] != null && dt.Rows[n]["FloorHeight"].ToString() != "")
                        model.FloorHeight = double.Parse(dt.Rows[n]["FloorHeight"].ToString());
                    if (dt.Rows[n]["Decoration"] != null && dt.Rows[n]["Decoration"].ToString() != "")
                        model.Decoration = dt.Rows[n]["Decoration"].ToString();
                    if (dt.Rows[n]["MinLease"] != null && dt.Rows[n]["MinLease"].ToString() != "")
                        model.MinLease = int.Parse(dt.Rows[n]["MinLease"].ToString());
                    if (dt.Rows[n]["PayMode"] != null && dt.Rows[n]["PayMode"].ToString() != "")
                        model.PayMode = dt.Rows[n]["PayMode"].ToString();
                    if (dt.Rows[n]["IsRent"] != null && dt.Rows[n]["IsRent"].ToString() != "")
                        model.IsRent = Boolean.Parse(dt.Rows[n]["IsRent"].ToString());
                    if (dt.Rows[n]["Lessee"] != null && dt.Rows[n]["Lessee"].ToString() != "")
                        model.Lessee = dt.Rows[n]["Lessee"].ToString();
                    if (dt.Rows[n]["RentStart"] != null && dt.Rows[n]["RentStart"].ToString() != "")
                        model.RentStart = DateTime.Parse(dt.Rows[n]["RentStart"].ToString());                   
                    if (dt.Rows[n]["RentEnd"] != null && dt.Rows[n]["RentEnd"].ToString() != "")
                        model.RentEnd = DateTime.Parse(dt.Rows[n]["RentEnd"].ToString());
                    if (dt.Rows[n]["Remark"] != null && dt.Rows[n]["Remark"].ToString() != "")
                        model.Remark = dt.Rows[n]["Remark"].ToString();
                    if (dt.Rows[n]["IsShowed"] != null && dt.Rows[n]["IsShowed"].ToString() != "")
                        model.IsShowed = Boolean.Parse(dt.Rows[n]["IsShowed"].ToString());
                    if (dt.Rows[n]["BuildID"] != null && dt.Rows[n]["BuildID"].ToString() != "")
                        model.BuildID = dt.Rows[n]["BuildID"].ToString();
                    if (dt.Rows[n]["Admin"] != null && dt.Rows[n]["Admin"].ToString() != "")
                        model.Admin = dt.Rows[n]["Admin"].ToString();
                    if (dt.Rows[n]["RoomStylePath"] != null && dt.Rows[n]["RoomStylePath"].ToString() != "")
                        model.RoomStylePath = dt.Rows[n]["RoomStylePath"].ToString();

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// new-----
        /// </summary>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public List<Room> ListPageRoomSource(int pageno, int pagesize)
        {
            int rowcount = this.GetScopeTotalNum(1);
            string sql = "";
            rowcount = this.GetScopeTotalNum(1);
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by BuildingName,Number) as rownum ,* from Room where IsShowed=1 ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by BuildingName,Number) as rownum, * from Room where IsShowed=1)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
            DataSet ds = DBHelperSQL.Query(sql);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 有租户和楼宇获得房间号
        /// </summary>
        /// <param name="lessee"></param>
        /// <param name="build"></param>
        /// <returns></returns>
        public List<string> ListRoomByLesseeAndBuilding(string lessee, string build)
        {
            List<string> list=new List<string>();
            SqlParameter[] parameters = {
                    new SqlParameter("@Lessee", SqlDbType.NVarChar),
                    new SqlParameter("@BuildingName", SqlDbType.NVarChar)
                };
            parameters[0].Value = lessee;
            parameters[1].Value = build;
         
            string sql = "select  distinct Number from Room where Lessee=@Lessee And BuildingName=@BuildingName";
            DataSet ds = DBHelperSQL.Query(sql, parameters);
            DataTable dt = ds.Tables[0];
            for (int n = 0; n < dt.Rows.Count; n++)
            {
                list.Add(dt.Rows[n]["ID"].ToString());
            }
            return list;
        }

        /// <summary>
        /// 有租户名称获得租户有租赁房间的大楼，一个租户可能对应多个房间
        /// </summary>
        /// <param name="lessee"></param>
        /// <returns></returns>
        public List<string> ListBuildingNameByLesseeName(string lessee)
        {
            List<string> list = new List<string>();
            DBConnection db = new DBConnection();

            db.AddParameter("@Lessee", lessee);
            string sql = "select  distinct BuildingName from Room where Lessee=@Lessee";
            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                list.Add(sdr["BuildingName"].ToString());
            }
            sdr.Close();
            db.Dispose();
            
            return list;
        }

        /// <summary>
        /// 
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
            sdr.Close();
            db.Dispose();
            return rooms;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sdr"></param>
        /// <returns></returns>
        private Room getRoomBySdr(SqlDataReader sdr)
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

            return room;
        }

        /// <summary>
        /// 添加房间信息
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public int AddRoom(Room room)
        {

            SqlParameter[] parameters = {
                    new SqlParameter("@Number", SqlDbType.VarChar),
                    new SqlParameter("@BuildingName", SqlDbType.NVarChar),
                    new SqlParameter("@Floor", SqlDbType.Int),
                    new SqlParameter("@Area", SqlDbType.Float),
                    new SqlParameter("@Style", SqlDbType.Bit),
                    new SqlParameter("@Rent", SqlDbType.VarChar),
                    new SqlParameter("@RoomStyle", SqlDbType.NVarChar),
                    new SqlParameter("@ManageFee", SqlDbType.Float),
                    new SqlParameter("@Taxes", SqlDbType.Float),
                    new SqlParameter("@Toward", SqlDbType.VarChar),
                    new SqlParameter("@FloorHeight", SqlDbType.Float),
                    new SqlParameter("@Decoration", SqlDbType.VarChar),
                    new SqlParameter("@MinLease", SqlDbType.Int),
                    new SqlParameter("@PayMode", SqlDbType.VarChar),
                    new SqlParameter("@IsRent", SqlDbType.Bit),
                    new SqlParameter("@Lessee", SqlDbType.NVarChar),
                    new SqlParameter("@RentStart", SqlDbType.DateTime),
                    new SqlParameter("@RentEnd", SqlDbType.DateTime),
                    new SqlParameter("@Remark", SqlDbType.VarChar),
                    new SqlParameter("@IsShowed", SqlDbType.Bit),
                    new SqlParameter("@BuildID", SqlDbType.VarChar),
                    new SqlParameter("@Admin", SqlDbType.VarChar),
                    new SqlParameter("@RoomStylePath", SqlDbType.VarChar)
                                        };
            parameters[0].Value = room.Number;
            parameters[1].Value = room.BuildingName;
            if (room.Floor != 0)
                parameters[2].Value = room.Floor;
            else
                parameters[2].Value = DBNull.Value;
            if (room.Area != 0)
                parameters[3].Value = room.Area;
            else
                parameters[3].Value = DBNull.Value;
            if (room.Style != null)
                parameters[4].Value = room.Style;
            else
                parameters[4].Value = DBNull.Value;
            parameters[5].Value = room.Rent;
            parameters[6].Value = room.RoomStyle;
            if (room.ManageFee != 0)
                parameters[7].Value = room.ManageFee;
            else
                parameters[7].Value = DBNull.Value;
            if (room.Taxes != 0)
                parameters[8].Value = room.Taxes;
            else
                parameters[8].Value = DBNull.Value;
            parameters[9].Value = room.Toward;
            if (room.FloorHeight != 0)
                parameters[10].Value = room.FloorHeight;
            else
                parameters[10].Value = DBNull.Value;

            parameters[11].Value = room.Decoration;
            if (room.MinLease != 0)
                parameters[12].Value = room.MinLease;
            else
                parameters[12].Value = DBNull.Value;
            parameters[13].Value = room.PayMode;
            if (room.IsRent != null)
                parameters[14].Value = room.IsRent;
            else
                parameters[14].Value = DBNull.Value;
            parameters[15].Value = room.Lessee;
            if (room.RentStart != null)
                parameters[16].Value = room.RentStart;
            else
                parameters[16].Value = DBNull.Value;
            if (room.RentEnd != null)
                parameters[17].Value = room.RentEnd;
            else
                parameters[17].Value = DBNull.Value;
            parameters[18].Value = room.Remark;
            if (room.IsShowed != null)
                parameters[19].Value = room.IsShowed;
            else
                parameters[19].Value = DBNull.Value;
            parameters[20].Value = room.BuildID;
            parameters[21].Value = room.Admin;
            parameters[22].Value = room.RoomStylePath;

            string sql = "insert into Room(Number,BuildingName,Floor,Area,Style,Rent,RoomStyle,ManageFee,Taxes,Toward,FloorHeight,Decoration,MinLease,PayMode,IsRent,Lessee,RentStart,RentEnd,Remark,IsShowed) values(@Number,@BuildingName,@Floor,@Area,@Style,@Rent,@RoomStyle,@ManageFee,@Taxes,@Toward,@FloorHeight,@Decoration,@MinLease,@PayMode,@IsRent,@Lessee,@RentStart,@RentEnd,@Remark,@IsShowed,@BuildID,@Admin,@RoomStylePath)";

            object obj = DBHelperSQL.GetSingle(sql, parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 房间信息编辑
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public int UpdateRoom(Room room)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@Number", SqlDbType.VarChar),
                    new SqlParameter("@BuildingName", SqlDbType.NVarChar),
                    new SqlParameter("@Floor", SqlDbType.Int),
                    new SqlParameter("@Area", SqlDbType.Float),
                    new SqlParameter("@Style", SqlDbType.Bit),
                    new SqlParameter("@Rent", SqlDbType.VarChar),
                    new SqlParameter("@RoomStyle", SqlDbType.NVarChar),
                    new SqlParameter("@ManageFee", SqlDbType.Float),
                    new SqlParameter("@Taxes", SqlDbType.Float),
                    new SqlParameter("@Toward", SqlDbType.VarChar),
                    new SqlParameter("@FloorHeight", SqlDbType.Float),
                    new SqlParameter("@Decoration", SqlDbType.VarChar),
                    new SqlParameter("@MinLease", SqlDbType.Int),
                    new SqlParameter("@PayMode", SqlDbType.VarChar),
                    new SqlParameter("@IsRent", SqlDbType.Bit),
                    new SqlParameter("@Lessee", SqlDbType.NVarChar),
                    new SqlParameter("@RentStart", SqlDbType.DateTime),
                    new SqlParameter("@RentEnd", SqlDbType.DateTime),
                    new SqlParameter("@Remark", SqlDbType.VarChar),
                    new SqlParameter("@IsShowed", SqlDbType.Bit),
                    new SqlParameter("@ID", SqlDbType.Int)
                                        };
            parameters[0].Value = room.Number;
            parameters[1].Value = room.BuildingName;
            if (room.Floor != 0)
                parameters[2].Value = room.Floor;
            else
                parameters[2].Value = DBNull.Value;
            if (room.Area != 0)
                parameters[3].Value = room.Area;
            else
                parameters[3].Value = DBNull.Value;
            if (room.Style != null)
                parameters[4].Value = room.Style;
            else
                parameters[4].Value = DBNull.Value;
            parameters[5].Value = room.Rent;
            parameters[6].Value = room.RoomStyle;
            if (room.ManageFee != 0)
                parameters[7].Value = room.ManageFee;
            else
                parameters[7].Value = DBNull.Value;
            if (room.Taxes != 0)
                parameters[8].Value = room.Taxes;
            else
                parameters[8].Value = DBNull.Value;
            parameters[9].Value = room.Toward;
            if (room.FloorHeight != 0)
                parameters[10].Value = room.FloorHeight;
            else
                parameters[10].Value = DBNull.Value;

            parameters[11].Value = room.Decoration;
            if (room.MinLease != 0)
                parameters[12].Value = room.MinLease;
            else
                parameters[12].Value = DBNull.Value;
            parameters[13].Value = room.PayMode;
            if (room.IsRent != null)
                parameters[14].Value = room.IsRent;
            else
                parameters[14].Value = DBNull.Value;
            parameters[15].Value = room.Lessee;
            if (room.RentStart != null)
                parameters[16].Value = room.RentStart;
            else
                parameters[16].Value = DBNull.Value;
            if (room.RentEnd != null)
                parameters[17].Value = room.RentEnd;
            else
                parameters[17].Value = DBNull.Value;
            parameters[18].Value = room.Remark;
            if (room.IsShowed != null)
                parameters[19].Value = room.IsShowed;
            else
                parameters[19].Value = DBNull.Value;

            if (room.ID != 0)
                parameters[20].Value = room.ID;
            else
                parameters[20].Value = DBNull.Value;


            string sql = "";
            sql = "update Room set Number=@Number,BuildingName=@BuildingName, Floor=@Floor,Area=@Area,Style=@Style,Rent=@Rent,RoomStyle=@RoomStyle,ManageFee=@ManageFee,Taxes=@Taxes,Toward=@Toward,FloorHeight=@FloorHeight,Decoration=@Decoration,MinLease=@MinLease,PayMode=@PayMode,IsRent=@IsRent,Lessee=@Lessee,RentStart=@RentStart,RentEnd=@RentEnd,Remark=@Remark,IsShowed=@IsShowed where ID=@ID";

            return DBHelperSQL.ExecuteSql(sql, parameters);

        }


        /// <summary>
        /// 获取房间信息列表
        /// </summary>
        /// <returns></returns>
        public List<Room> ListRoom()
        {
            string sql = "select * from Room";

            DataSet ds = DBHelperSQL.Query(sql);
            return DataTableToList(ds.Tables[0]);
            
        }
        
        /// <summary>
        /// 获得当前页房间信息，1：已租用，0：未租用，2：全部
        /// </summary>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public List<Room> ListPageRoom(int pageno, int pagesize, int scope)
        {
            DataSet ds;
            int rowcount = this.GetScopeTotalNum(2);
            string sql = "";
            Boolean IsShowed = false;

            if (scope == 2)
            {
                rowcount = this.GetScopeTotalNum(2);
                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by IsShowed,BuildingName,Number) as rownum ,* from Room ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by IsShowed,BuildingName,Number) as rownum, * from Room )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
                ds = DBHelperSQL.Query(sql);
            }
            else
            {
                if (scope == 0)
                {
                    rowcount = this.GetScopeTotalNum(0);
                    IsShowed = false;
                }
                if (scope == 1)
                {
                    rowcount = this.GetScopeTotalNum(1);
                    IsShowed = true;
                }
                SqlParameter[] parameters = {
                    new SqlParameter("@IsShowed", SqlDbType.Bit)
                    };
                parameters[0].Value = IsShowed;

                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by IsShowed,BuildingName,Number) as rownum ,* from Room where IsShowed=@IsShowed) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by IsShowed,BuildingName,Number) as rownum, * from Room where IsShowed=@IsShowed )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
                ds = DBHelperSQL.Query(sql, parameters);
            }
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 通过房间号和大楼名删除房间
        /// </summary>
        /// <param name="number"></param>
        /// <param name="buildingName"></param>
        /// <returns></returns>
        public int deleteRoom(string number,string buildingName)
        {
            DBConnection db = new DBConnection();
            SqlParameter[] parameters = {
                    new SqlParameter("@Number", SqlDbType.VarChar),
                    new SqlParameter("@BuildingName", SqlDbType.NVarChar)
                    };
            parameters[0].Value = number;
            parameters[1].Value = buildingName;
            
            string sql = "delete from Room where Number=@Number and BuildingName=@BuildingName";
            return DBHelperSQL.ExecuteSql(sql,parameters);
        }

        //通过id删除房间信息
        public int deleteRoom(int id)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@ID", id);

            string sql = "delete from Room where ID=@ID";
            return db.ExecuteNonQuery(sql);
        }

        public int UpdateRoomById(string id,Boolean flag)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int),
                    new SqlParameter("@IsShowed", SqlDbType.Bit)
                    };
            parameters[0].Value = int.Parse(id);
            parameters[1].Value=flag;
            string sql = "Update Room set  IsShowed = @IsShowed where ID=@ID";
            return DBHelperSQL.ExecuteSql(sql,parameters);
        }
      
        /// <summary>
        /// 用房间号、大楼名和租用情况进行模糊查询
        /// </summary>
        /// <param name="number"></param>
        /// <param name="buildingName"></param>
        /// <param name="scope"></param>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public List<Room> SearchRoomList(string number, string buildingName, int scope,int pageno,int pagesize)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@BuildingName", SqlDbType.NVarChar),
                    new SqlParameter("@Number", SqlDbType.VarChar)
                    };
            string searchNum = "";
            searchNum = "%" + number + "%";
            parameters[0].Value = buildingName;
            parameters[1].Value = searchNum;

            string sql = "";
            Boolean IsShowed = false;
            
            int rowcount = 0;
            DataSet ds;

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
                sdr1.Close();
                db1.Dispose();


                rowcount = SearchNum;

                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by IsShowed,BuildingName,Number) as rownum ,* from Room where Number like @Number and BuildingName=@BuildingName) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by IsShowed,BuildingName,Number) as rownum, * from Room where Number like @Number and BuildingName=@BuildingName )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
                ds = DBHelperSQL.Query(sql, parameters);
                return DataTableToList(ds.Tables[0]);
            }
            else
            {
                if (scope == 0)
                    IsShowed = false;
                if (scope == 1)
                    IsShowed = true;

                SqlParameter[] parameters1 = {
                    new SqlParameter("@BuildingName", SqlDbType.NVarChar),
                    new SqlParameter("@Number", SqlDbType.VarChar),
                    new SqlParameter("@IsShowed", SqlDbType.Bit)
                    };
                parameters1[0].Value = buildingName;
                parameters1[1].Value = searchNum;
                parameters1[2].Value = IsShowed;

                DBConnection db1 = new DBConnection();
                db1.AddParameter("@Number", searchNum);
                db1.AddParameter("@IsShowed", IsShowed);
                db1.AddParameter("@BuildingName", buildingName);
                string sql1 = "select count(*) as a from Room where Number like @Number and BuildingName=@BuildingName and IsShowed=@IsShowed";

                SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
                while (sdr1.Read())
                {
                    SearchNum = int.Parse(sdr1["a"].ToString());
                }
                sdr1.Close();
                db1.Dispose();

                rowcount = SearchNum;

                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by IsShowed,BuildingName,Number) as rownum ,* from Room where Number like @Number and BuildingName=@BuildingName and IsShowed=@IsShowed) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by IsShowed,BuildingName,Number) as rownum, * from Room where Number like @Number and BuildingName=@BuildingName and IsShowed=@IsShowed)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
                ds = DBHelperSQL.Query(sql, parameters1);
                return DataTableToList(ds.Tables[0]);
            }
        }

        /// <summary>
        /// 通过大楼名和租用情况查询房间信息
        /// </summary>
        /// <param name="buildingName"></param>
        /// <param name="scope"></param>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public List<Room> SearchRoomList(string buildingName, int scope, int pageno, int pagesize)
        {
            string sql = "";
            Boolean IsRent = false;
            DataSet ds;

            int rowcount = 0;
            SqlParameter[] parameters = {
                    new SqlParameter("@BuildingName", SqlDbType.NVarChar)
                    };
            parameters[0].Value = buildingName;
      
            if (scope == 2)
            {                
                rowcount = this.GetScopeAndBuildTotalNum(scope, buildingName);

                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by IsShowed,BuildingName,Number) as rownum ,* from Room where  BuildingName=@BuildingName) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by IsShowed,BuildingName,Number) as rownum, * from Room where  BuildingName=@BuildingName )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
                ds = DBHelperSQL.Query(sql, parameters);
                return DataTableToList(ds.Tables[0]);
            }
            else
            {
                if (scope == 0)
                    IsRent = false;
                if (scope == 1)
                    IsRent = true;
                SqlParameter[] parameters1 = {
                    new SqlParameter("@BuildingName", SqlDbType.NVarChar),
                    new SqlParameter("@IsRent", SqlDbType.Bit)
                    };
                parameters1[0].Value = buildingName;
                parameters1[1].Value = IsRent;

           
                rowcount = this.GetScopeAndBuildTotalNum(scope,buildingName);

                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by IsShowed,BuildingName,Number) as rownum ,* from Room where  BuildingName=@BuildingName and IsRent=@IsRent) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by IsShowed,BuildingName,Number) as rownum, * from Room where  BuildingName=@BuildingName and IsRent=@IsRent)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
                ds = DBHelperSQL.Query(sql, parameters1);
                return DataTableToList(ds.Tables[0]);
            }
           
        }



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 通过房间号和租用情况进行模糊查询
        /// </summary>
        /// <param name="number"></param>
        /// <param name="scope"></param>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public List<Room> SearchRoomListByName(string number,int scope, int pageno, int pagesize)
        {
            string sql = "";
            Boolean IsShowed = false;
            string searchNum = "";
            int rowcount = 0;
            SqlParameter[] parameters = {
                    new SqlParameter("@Number", SqlDbType.VarChar)
                    };
            searchNum = "%" + number + "%";
            parameters[0].Value = searchNum;

            DataSet ds;

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
                sdr1.Close();
                db1.Dispose();


                rowcount = SearchNum;

                if (pageno * pagesize > rowcount)
                    //sql = "with temp as( select row_number() over(order by ID) as rownum ,* from Room where Number like @Number ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                    sql = "with temp as( select row_number() over(order by IsShowed,BuildingName,Number) as rownum ,* from Room where Number like @Number ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    //sql = "with temp as( select row_number() over(order by ID) as rownum, * from Room where Number like @Number )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
                    sql = "with temp as( select row_number() over(order by IsShowed,BuildingName,Number) as rownum, * from Room where Number like @Number )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
                ds = DBHelperSQL.Query(sql, parameters);
                return DataTableToList(ds.Tables[0]);
            }
            else
            {
                if (scope == 0)
                    IsShowed = false;
                if (scope == 1)
                    IsShowed = true;

                SqlParameter[] parameters1 = {
                    new SqlParameter("@Number", SqlDbType.VarChar),
                    new SqlParameter("@IsShowed", SqlDbType.Bit)
                    };
                parameters1[0].Value = searchNum;
                parameters1[1].Value = IsShowed;

                DBConnection db1 = new DBConnection();
                db1.AddParameter("@Number", searchNum);
                db1.AddParameter("@IsShowed", IsShowed);

                string sql1 = "select count(*) as a from Room where Number like @Number and IsShowed=@IsShowed";

                SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
                while (sdr1.Read())
                {
                    SearchNum = int.Parse(sdr1["a"].ToString());
                }
                sdr1.Close();
                db1.Dispose();

                rowcount = SearchNum;

                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by IsShowed,BuildingName,Number) as rownum ,* from Room where Number like @Number  and IsShowed=@IsShowed) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by IsShowed,BuildingName,Number) as rownum, * from Room where Number like @Number  and IsShowed=@IsShowed)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

                ds = DBHelperSQL.Query(sql, parameters1);
                return DataTableToList(ds.Tables[0]);
            }

        }

        /// <summary>
        /// 通过ID获得房间信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Room GetRoomByID(int id)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int)
                    };
            parameters[0].Value = id;
            string sql = "select * from Room where  ID=@ID ";
            List<Room> room;
            DataSet ds = DBHelperSQL.Query(sql, parameters);
            room = DataTableToList(ds.Tables[0]);
            if (room.Count > 0)
                return room[0];
            else
                return null;
        }

        /// <summary>
        /// 通过房号和大楼名获得房间信息
        /// </summary>
        /// <param name="num"></param>
        /// <param name="build"></param>
        /// <returns></returns>
        public Room GetRoomByNumAndBuild(string num,string build)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@BuildingName", SqlDbType.NVarChar),
                    new SqlParameter("@Number", SqlDbType.VarChar)

                    };
            parameters[0].Value = build;
            parameters[1].Value = num;
           
            string sql = "select * from Room where  BuildingName=@BuildingName and Number=@Number ";

            List<Room> room;
            DataSet ds = DBHelperSQL.Query(sql, parameters);
            room = DataTableToList(ds.Tables[0]);
            if (room.Count > 0)
                return room[0];
            else
                return null;
        }

        /// <summary>
        /// 获得租用情况的总数，1为已租用，0为未租用，2为全部
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        public int GetScopeTotalNum(int scope)
        {
            if (scope == 2)
                return DBHelperSQL.countNum("Room");
            if (scope==1)
                return DBHelperSQL.countNum("Room"," IsShowed=1");
            if (scope == 0)
                return DBHelperSQL.countNum("Room", " IsShowed=0");
            else
                return 0;
        }

        /// <summary>
        /// 获得某一大楼某种租用情况的总数，1为已租用，0为未租用，2为全部
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="build"></param>
        /// <returns></returns>
        public int GetScopeAndBuildTotalNum(int scope,string build)
        {

            DBConnection db = new DBConnection();
            string sql = "";
            db.AddParameter("@BuildingName", build);
            if (scope == 2)
                sql = "select count(*) as a from Room where BuildingName=@BuildingName";
            if (scope == 1)
                sql = "select count(*) as a from Room where IsShowed=1 and BuildingName=@BuildingName";
            if (scope == 0)
                sql = "select count(*) as a from Room where IsShowed=0 and BuildingName=@BuildingName";


            int count = 0;
            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                count = int.Parse(sdr["a"].ToString());
            }
            sdr.Close();
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
    }
}