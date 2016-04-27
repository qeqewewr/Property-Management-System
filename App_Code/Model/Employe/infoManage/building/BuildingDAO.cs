using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using CEMIS.Util;
using CEMIS.Model.Employe;
using System.Data.SqlTypes;
using System.Data;

/// <summary>
///BuildingDAO 的摘要说明
/// </summary>
/// 

namespace CEMIS.Model.Employe
{
   
    public class BuildingDAO
    {

        

        public BuildingDAO()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        //添加大楼信息
        public int AddBuilding(Building building)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@ID", building.ID);
            db.AddParameter("@Name", building.Name);
            db.AddParameter("@AdminID", building.AdminID);
            db.AddParameter("@Position", building.Position);
            if (building.Area != 0)
                db.AddParameter("@Area", building.Area);
            else
                db.AddParameter("@Area", DBNull.Value);
            if (building.Floor != 0)
                db.AddParameter("@Floor", building.Floor);
            else
                db.AddParameter("@Floor", DBNull.Value);
            db.AddParameter("@Introduction", building.Introduction);
            db.AddParameter("@Pic",building.Pic);


            string sql = "insert into Building(ID,Name,AdminID,Position,Area,Floor,Introduction,Pic) values(@ID,@Name,@AdminID,@Position,@Area,@Floor,@Introduction,@Pic);select @@IDENTITY";

            object obj = db.ExecuteScalar(sql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
            //string sql = "insert into Building(ID,Name,AdminID,Position,Area,Floor,Introduction,Pic) values(@ID,@Name,@AdminID,@Position,@Area,@Floor,@Introduction,@Pic)";
            //return db.ExecuteNonQuery(sql);
        }

        //编辑大楼信息
        public int UpdateBuilding(Building building)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@ID", building.ID);
            db.AddParameter("@Name", building.Name);
            db.AddParameter("@AdminID", building.AdminID);
            db.AddParameter("@Position", building.Position);
            if (building.Area != 0)
                db.AddParameter("@Area", building.Area);
            else
                db.AddParameter("@Area", DBNull.Value);
            if (building.Floor != 0)
                db.AddParameter("@Floor", building.Floor);
            else
                db.AddParameter("@Floor", DBNull.Value);
            db.AddParameter("@Introduction", building.Introduction);
            db.AddParameter("@Pic", building.Pic);


            string sql = "";
            sql = "update Building set Name=@Name,AdminID=@AdminID,Position=@Position,Area=@Area,Floor=@Floor,Introduction=@Introduction,Pic=@Pic where ID=@ID ";


            return db.ExecuteNonQuery(sql);
        }


        //获得所有大楼信息列表
        public List<Building> ListBuilding()
        {
            List<Building> buildingList = new List<Building>();

            DBConnection db = new DBConnection();
            string sql = "select * from Building";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                Building building = new Building();
                building.ID = sdr["ID"].ToString();
                building.Name = sdr["Name"].ToString();
                building.AdminID = sdr["AdminID"].ToString();
                building.Position = sdr["Position"].ToString();
                if (sdr["Area"].ToString() != "" && sdr["Area"].ToString() != null)
                    building.Area = double.Parse(sdr["Area"].ToString());

                if (sdr["Floor"].ToString() != "" && sdr["Floor"].ToString() != null)
                    building.Floor = int.Parse(sdr["Floor"].ToString());
                building.Introduction = sdr["Introduction"].ToString();
                building.Pic = sdr["Pic"].ToString();

                buildingList.Add(building);
            }
            db.Dispose();
            return buildingList;
        }

        //获得当前页的大楼信息列表
        public List<Building> ListPageBuilding(int pageno, int pagesize)
        {
            List<Building> buildingList = new List<Building>();
            int rowcount = this.GetTotalRecordNum();
            string sql;


            DBConnection db = new DBConnection();

            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by IID,ID) as rownum ,* from Building) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by IID,ID) as rownum, * from Building )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                Building building = new Building();
                building.ID = sdr["ID"].ToString();
                building.Name = sdr["Name"].ToString();
                building.AdminID = sdr["AdminID"].ToString();
                building.Position = sdr["Position"].ToString();
                if (sdr["Area"].ToString() != "" && sdr["Area"].ToString()!=null)
                    building.Area = double.Parse(sdr["Area"].ToString());
                if (sdr["Floor"].ToString() != "" && sdr["Floor"].ToString()!=null)
                    building.Floor = int.Parse(sdr["Floor"].ToString());
                building.Introduction = sdr["Introduction"].ToString();
                building.Pic = sdr["Pic"].ToString();

                buildingList.Add(building);
            }
            db.Dispose();
            return buildingList;
        }


        //通过ID删除大楼信息
        public int deleteBuilding(string id)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@ID", id);
            string sql = "delete from Building where ID=@ID";
            return db.ExecuteNonQuery(sql);
        }



        //通过大楼名称关键字进行模糊搜索获得大楼信息列表
        public List<Building> GetBuildingByName(string name)
        {

            DBConnection db = new DBConnection();

            string searchName = "%" + name + "%";
            db.AddParameter("@Name", searchName);

            string sql = "select * from News where Name like @Name order by ID ";


            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            List<Building> buildList = new List<Building>();

            while(sdr.Read())
            {
                Building building = new Building();
                building.ID = sdr["ID"].ToString();
                building.Name = sdr["Name"].ToString();
                building.AdminID = sdr["AdminID"].ToString();
                building.Position = sdr["Position"].ToString();
                if (sdr["Area"].ToString() != "" && sdr["Area"].ToString() != null)
                    building.Area = double.Parse(sdr["Area"].ToString());
                if (sdr["Floor"].ToString() != "" && sdr["Floor"].ToString() != null)
                    building.Floor = int.Parse(sdr["Floor"].ToString());
                building.Introduction = sdr["Introduction"].ToString();
                building.Pic = sdr["Pic"].ToString();

                buildList.Add(building);
            }
           

            db.Dispose();
            return buildList;
        }

        /// <summary>
        /// 通过ID获得大楼信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public Building GetBuildingByID(string id)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@ID", id);
            string sql = "select * from Building where ID=@ID ";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            Building building = new Building();

            if (sdr.Read())
            {
                building.ID = sdr["ID"].ToString();
                building.Name = sdr["Name"].ToString();
                building.AdminID = sdr["AdminID"].ToString();
                building.Position = sdr["Position"].ToString();
                if (sdr["Area"].ToString() != "" && sdr["Area"].ToString() != null)
                    building.Area = double.Parse(sdr["Area"].ToString());
                if (sdr["Floor"].ToString() != "" && sdr["Floor"].ToString() != null)
                    building.Floor = int.Parse(sdr["Floor"].ToString());
                building.Introduction = sdr["Introduction"].ToString();
                building.Pic = sdr["Pic"].ToString();
            }
            else
            {
                building = null;
            }

            db.Dispose();
            return building;
        }


        /// <summary>
        /// 通过大楼名称查找大楼信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Building GetBuilding(string name)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@Name", name);
            string sql = "select * from Building where Name=@Name";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            Building building = new Building();

            if (sdr.Read())
            {
                building.ID = sdr["ID"].ToString();
                building.Name = sdr["Name"].ToString();
                building.AdminID = sdr["AdminID"].ToString();
                building.Position = sdr["Position"].ToString();
                if (sdr["Area"].ToString() != "" && sdr["Area"].ToString() != null)
                    building.Area = double.Parse(sdr["Area"].ToString());
                if (sdr["Floor"].ToString() != "" && sdr["Floor"].ToString() != null)
                    building.Floor = int.Parse(sdr["Floor"].ToString());
                building.Introduction = sdr["Introduction"].ToString();
                building.Pic = sdr["Pic"].ToString();
            }
            else
            {
                building = null;
            }

            db.Dispose();
            return building;
        }

        //获得所有大楼的总数
        public int GetTotalRecordNum()
        {

            DBConnection db = new DBConnection();
            string sql = "select count(*) as a from Building";

            int count = 0;
            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                count = int.Parse(sdr["a"].ToString());
            }

            db.Dispose();
            return count;
        }

        public Boolean IsExistAdmin(string id)
        {
            DBConnection db = new DBConnection();
            Boolean IsExist=false;
            db.AddParameter("@AdminID",id);
            string sql = "select ID from Building where AdminID=@AdminID";
            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

            if (sdr.Read())
                IsExist = true;
            db.Dispose();
            return IsExist;
        }
    }
}