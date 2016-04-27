using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Sql;
using CEMIS.Util;
using CEMIS.Model.Employe;
using System.Data;

/// <summary>
///RoomStyleDAO 的摘要说明
/// </summary>
/// 

namespace CEMIS.Model.Employe
{
    public class RoomStyleDAO
    {
        public RoomStyleDAO()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        //房型图添加
        public int AddRoomStyle(RoomStyle roomStyle)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@Name", roomStyle.Name);
            db.AddParameter("@Pic", roomStyle.Pic);


            string sql = "insert into RoomStyle(Name,Pic) values(@Name,@Pic);select @@IDENTITY";


            object obj = db.ExecuteScalar(sql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }


           
        }

        //房型图编辑
        public int UpdateRoomStyle(RoomStyle roomStyle)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@ID", roomStyle.ID);
            db.AddParameter("@Name", roomStyle.Name);
            db.AddParameter("@Pic", roomStyle.Pic);


            string sql = "";
            sql = "update RoomStyle set Name=@Name,Pic=@Pic where ID=@ID ";


            return db.ExecuteNonQuery(sql);
        }


        //房型图列表
        public List<RoomStyle> ListRoomStyle()
        {
            List<RoomStyle> roomStyleList = new List<RoomStyle>();

            DBConnection db = new DBConnection();
            string sql = "select * from RoomStyle";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                RoomStyle roomStyle = new RoomStyle();
                roomStyle.ID = int.Parse(sdr["ID"].ToString());
                if (sdr["Name"].ToString() != "" && sdr["Name"].ToString()!=null)
                    roomStyle.Name = sdr["Name"].ToString();
                if (sdr["Pic"].ToString()!=""&&sdr["Pic"].ToString()!=null)
                    roomStyle.Pic=sdr["Pic"].ToString();
                roomStyleList.Add(roomStyle);
            }
            db.Dispose();
            return roomStyleList;
        }

        //获得当前页的房型图信息列表
        public List<RoomStyle> ListPageRoomStyle(int pageno, int pagesize)
        {
            List<RoomStyle> roomStyleList = new List<RoomStyle>();
            int rowcount = this.GetTotalRecordNum();
            string sql;


            DBConnection db = new DBConnection();

            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID) as rownum ,* from RoomStyle) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID) as rownum, * from RoomStyle )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                RoomStyle roomStyle = new RoomStyle();
                roomStyle.ID = int.Parse(sdr["ID"].ToString());
                if (sdr["Name"].ToString() != "" && sdr["Name"].ToString() != null)
                    roomStyle.Name = sdr["Name"].ToString();
                if (sdr["Pic"].ToString() != "" && sdr["Pic"].ToString() != null)
                    roomStyle.Pic = sdr["Pic"].ToString();

                roomStyleList.Add(roomStyle);
            }
            db.Dispose();
            return roomStyleList;
        }

        //通过ID删除房型图信息
        public int deleteRoomStyle(int id)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@ID", id);
            string sql = "delete from RoomStyle where ID=@ID";
            return db.ExecuteNonQuery(sql);
        }

        //通过ID获得房型图信息
        public RoomStyle GetRoomStyleByID(int id)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@ID", id);
            string sql = "select * from RoomStyle where ID=@ID ";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            RoomStyle roomStyle = new RoomStyle();

            if (sdr.Read())
            {
                roomStyle.ID = int.Parse(sdr["ID"].ToString());
                if (sdr["Name"].ToString() != "" && sdr["Name"].ToString() != null)
                    roomStyle.Name = sdr["Name"].ToString();
                if (sdr["Pic"].ToString() != "" && sdr["Pic"].ToString() != null)
                    roomStyle.Pic = sdr["Pic"].ToString();
            }
            else
            {
                roomStyle = null;
            }

            db.Dispose();
            return roomStyle;
        }


        /// <summary>
        /// 通过Name获得房型图信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        public RoomStyle GetRoomStyleByName(string name)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@Name", name);
            string sql = "select * from RoomStyle where Name=@Name ";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            RoomStyle roomStyle = new RoomStyle();

            if (sdr.Read())
            {
                roomStyle.ID = int.Parse(sdr["ID"].ToString());
                if (sdr["Name"].ToString() != "" && sdr["Name"].ToString() != null)
                    roomStyle.Name = sdr["Name"].ToString();
                if (sdr["Pic"].ToString() != "" && sdr["Pic"].ToString() != null)
                    roomStyle.Pic = sdr["Pic"].ToString();
            }
            else
            {
                roomStyle = null;
            }

            db.Dispose();
            return roomStyle;
        }


        //获得所有房型图的总数
        public int GetTotalRecordNum()
        {

            DBConnection db = new DBConnection();
            string sql = "select count(*) as a from RoomStyle";

            int count = 0;
            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                count = int.Parse(sdr["a"].ToString());
            }

            db.Dispose();
            return count;
        }
    }
}