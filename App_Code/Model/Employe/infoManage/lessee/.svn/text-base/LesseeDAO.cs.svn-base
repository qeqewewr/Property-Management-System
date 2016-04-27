using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using CEMIS.Util;
using CEMIS.Model.Employe;

/// <summary>
///LesseeDAO 的摘要说明
/// </summary>
/// 

namespace CEMIS.Model.Employe
{
    public class LesseeDAO
    {
        private string key = "12345678";   //密码加密的密钥
        public int searchNum = 0;

        public LesseeDAO()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// new-------
        /// </summary>
        /// <param name="username"></param>
        /// <param name="psw"></param>
        /// <returns></returns>
        public Boolean LogonJudge(string username, string psw)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@Name", username);
            db.AddParameter("@Password", EncryptAndDecrypt.Encrypt(key, psw));

            string sql = "select RoomNum,Password from Lessee where Name=@Name and Password=@Password";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

            if (sdr.Read())
                return true;
            else
                return false;
        }

        //添加租户信息
        public int AddLessee(Lessee lessee)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@Name", lessee.Name);
            db.AddParameter("@Address", lessee.Address);
            db.AddParameter("@RoomNum", lessee.RoomNum);
            db.AddParameter("@OperationScope", lessee.OperationScope);
            db.AddParameter("@OfficePhone", lessee.OfficePhone);
            db.AddParameter("@Director", lessee.Director);
            db.AddParameter("@DirectorPhone", lessee.DirectorPhone);
            db.AddParameter("@Emergency", lessee.Emergency);
            db.AddParameter("@EmergencyPhone", lessee.EmergencyPhone);
            db.AddParameter("@Remark", lessee.Remark);
            db.AddParameter("@Password", EncryptAndDecrypt.Encrypt(key, lessee.Password));
            if (lessee.Status != null)
                db.AddParameter("@Status", lessee.Status);
            else
                db.AddParameter("@Status", false);
            if (lessee.WarrantMon != 0)
                db.AddParameter("@WarrantMon", lessee.WarrantMon);
			else
				db.AddParameter("@WarrantMon",  DBNull.Value);

            string sql = "insert into Lessee(Name,Address,OperationScope,OfficePhone,Director,DirectorPhone,Emergency,EmergencyPhone,Remark,Password,RoomNum,Status,WarrantMon) values(@Name,@Address,@OperationScope,@OfficePhone,@Director,@DirectorPhone,@Emergency,@EmergencyPhone,@Remark,@Password,@RoomNum,@Status,@WarrantMon);select @@IDENTITY";

            //return db.ExecuteNonQuery(sql);
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


        //编辑租户信息
        public int UpdateLessee(Lessee lessee)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@ID", lessee.ID);
            db.AddParameter("@Name", lessee.Name);
            db.AddParameter("@RoomNum", lessee.RoomNum);
            db.AddParameter("@Address", lessee.Address);
            db.AddParameter("@OperationScope", lessee.OperationScope);
            db.AddParameter("@OfficePhone", lessee.OfficePhone);
            db.AddParameter("@Director", lessee.Director);
            db.AddParameter("@DirectorPhone", lessee.DirectorPhone);
            db.AddParameter("@Emergency", lessee.Emergency);
            db.AddParameter("@EmergencyPhone", lessee.EmergencyPhone);
            db.AddParameter("@Remark", lessee.Remark);
            db.AddParameter("@Password", EncryptAndDecrypt.Encrypt(key, lessee.Password));
            if (lessee.Status != null)
                db.AddParameter("@Status", lessee.Status);
            else
                db.AddParameter("@Status", false);
            if (lessee.WarrantMon != 0)
                db.AddParameter("@WarrantMon", lessee.WarrantMon);
			else
				db.AddParameter("@WarrantMon",  DBNull.Value);

            string sql = "";
            //sql = "update Lessee set Address=@Address,OperationScope=@OperationScope,OfficePhone=@OfficePhone,Director=@Director,DirectorPhone=@DirectorPhone,Emergency=@Emergency,EmergencyPhone=@EmergencyPhone,Remark=@Remark,Password=@Password ,RoomNum=@RoomNum where Name=@Name ";
            sql = "update Lessee set Name=@Name,Address=@Address,OperationScope=@OperationScope,OfficePhone=@OfficePhone,Director=@Director,DirectorPhone=@DirectorPhone,Emergency=@Emergency,EmergencyPhone=@EmergencyPhone,Remark=@Remark,Password=@Password ,RoomNum=@RoomNum,Status=@Status,WarrantMon=@WarrantMon where ID=@ID ";

            return db.ExecuteNonQuery(sql);
        }


        //获得所有租户信息列表
        public List<Lessee> ListLessee()
        {
            List<Lessee> lesseeList = new List<Lessee>();

            DBConnection db = new DBConnection();
            string sql = "select * from Lessee";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                Lessee lessee = new Lessee();
                lessee.ID = int.Parse(sdr["ID"].ToString());
                lessee.Name = sdr["Name"].ToString();
                lessee.RoomNum = sdr["RoomNum"].ToString().Trim();
                lessee.Address = sdr["Address"].ToString();
                lessee.OperationScope = sdr["OperationScope"].ToString();
                lessee.OfficePhone = sdr["OfficePhone"].ToString();
                lessee.Director = sdr["Director"].ToString();
                lessee.DirectorPhone = sdr["DirectorPhone"].ToString();
                lessee.Emergency = sdr["Emergency"].ToString();
                lessee.EmergencyPhone = sdr["EmergencyPhone"].ToString();
                lessee.Remark = sdr["Remark"].ToString();
                lessee.Password = EncryptAndDecrypt.Decrypt(key, sdr["Password"].ToString());
                if (sdr["Status"].ToString() != null && sdr["Status"].ToString() != "")
                    lessee.Status = Boolean.Parse(sdr["Status"].ToString());
                if (sdr["WarrantMon"].ToString() != null && sdr["WarrantMon"].ToString() != "")
                    lessee.WarrantMon = double.Parse(sdr["WarrantMon"].ToString());

                lesseeList.Add(lessee);
            }
            db.Dispose();
            return lesseeList;
        }

        //获得所有租户信息列表
        public List<Lessee> ListExistLessee()
        {
            List<Lessee> lesseeList = new List<Lessee>();

            DBConnection db = new DBConnection();
            string sql = "select * from Lessee where Status=0";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                Lessee lessee = new Lessee();
                lessee.ID = int.Parse(sdr["ID"].ToString());
                lessee.Name = sdr["Name"].ToString();
                lessee.RoomNum = sdr["RoomNum"].ToString().Trim();
                lessee.Address = sdr["Address"].ToString();
                lessee.OperationScope = sdr["OperationScope"].ToString();
                lessee.OfficePhone = sdr["OfficePhone"].ToString();
                lessee.Director = sdr["Director"].ToString();
                lessee.DirectorPhone = sdr["DirectorPhone"].ToString();
                lessee.Emergency = sdr["Emergency"].ToString();
                lessee.EmergencyPhone = sdr["EmergencyPhone"].ToString();
                lessee.Remark = sdr["Remark"].ToString();
                lessee.Password = EncryptAndDecrypt.Decrypt(key, sdr["Password"].ToString());
                if (sdr["Status"].ToString() != null && sdr["Status"].ToString() != "")
                    lessee.Status = Boolean.Parse(sdr["Status"].ToString());
                if (sdr["WarrantMon"].ToString() != null && sdr["WarrantMon"].ToString() != "")
                    lessee.WarrantMon = double.Parse(sdr["WarrantMon"].ToString());

                lesseeList.Add(lessee);
            }
            db.Dispose();
            return lesseeList;
        }

        //获得当前页的租户信息列表
        public List<Lessee> ListPageLessee(int pageno, int pagesize,int scope)
        {
            List<Lessee> lesseeList = new List<Lessee>();
            int rowcount = this.GetTotalRecordNum();
            string sql;


            DBConnection db = new DBConnection();

            Boolean status = false;

            if (scope == 2)//所有
            {
                rowcount = this.GetTotalRecordNum();
                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by ID desc) as rownum ,* from Lessee ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by ID desc) as rownum, * from Lessee )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
            }
            else
            {
                if (scope == 1)//入住
                {
                    rowcount = this.GetInRecordNum();
                    status = false;
                }
                if (scope == 0)//搬离
                {
                    rowcount = this.GetOutRecordNum();
                    status = true;
                }
                db.AddParameter("@Status", status);
                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by ID desc) as rownum ,* from Lessee where Status=@Status) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by ID desc) as rownum, * from Lessee where Status=@Status )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
            }

           

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                Lessee lessee = new Lessee();
                lessee.ID = int.Parse(sdr["ID"].ToString());
                lessee.Name = sdr["Name"].ToString();
                lessee.RoomNum = sdr["RoomNum"].ToString().Trim();
                lessee.Address = sdr["Address"].ToString();
                lessee.OperationScope = sdr["OperationScope"].ToString();
                lessee.OfficePhone = sdr["OfficePhone"].ToString();
                lessee.Director = sdr["Director"].ToString();
                lessee.DirectorPhone = sdr["DirectorPhone"].ToString();
                lessee.Emergency = sdr["Emergency"].ToString();
                lessee.EmergencyPhone = sdr["EmergencyPhone"].ToString();
                lessee.Remark = sdr["Remark"].ToString();
                lessee.Password = EncryptAndDecrypt.Decrypt(key, sdr["Password"].ToString());
                if (sdr["Status"].ToString() != null && sdr["Status"].ToString() != "")
                    lessee.Status = Boolean.Parse(sdr["Status"].ToString());
                if (sdr["WarrantMon"].ToString() != null && sdr["WarrantMon"].ToString() != "")
                    lessee.WarrantMon = double.Parse(sdr["WarrantMon"].ToString());

                lesseeList.Add(lessee);
            }
            db.Dispose();
            return lesseeList;
        }


        //通过租户名称删除租户信息
        public int deleteLessee(string name)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@Name", name);
            string sql = "delete from Lessee where Name=@Name";
            return db.ExecuteNonQuery(sql);
        }

        //通过ID删除租户信息
        public int deleteLesseeByID(int id)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@ID", id);
            string sql = "delete from Lessee where ID=@ID";
            return db.ExecuteNonQuery(sql);
        }

        //通过名称获得租户信息
		public Lessee GetLesseeByName(string name)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@Name", name);
            string sql = "select * from Lessee where Name=@Name ";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            Lessee lessee = new Lessee();

            if (sdr.Read())
            {
                lessee.ID = int.Parse(sdr["ID"].ToString());
                lessee.Name = sdr["Name"].ToString();
                lessee.RoomNum = sdr["RoomNum"].ToString();
                lessee.Address = sdr["Address"].ToString();
                lessee.OperationScope = sdr["OperationScope"].ToString();
                lessee.OfficePhone = sdr["OfficePhone"].ToString();
                lessee.Director = sdr["Director"].ToString();
                lessee.DirectorPhone = sdr["DirectorPhone"].ToString();
                lessee.Emergency = sdr["Emergency"].ToString();
                lessee.EmergencyPhone = sdr["EmergencyPhone"].ToString();
                lessee.Remark = sdr["Remark"].ToString();
                lessee.Password = EncryptAndDecrypt.Decrypt(key, sdr["Password"].ToString());
            }
            else
            {
                lessee = null;
            }

            db.Dispose();
            return lessee;
        }

        //通过名称,模糊搜索，获得租户信息列表，1：入住，2：所有，0：搬离
        public List<Lessee> GetLesseeByName(string name,int scope,int pageno,int pagesize)
        {
            Boolean status = false;
            string sql = "";
            int rowcount = 0;

            List<Lessee> lesseeList = new List<Lessee>();

            DBConnection db = new DBConnection();
            /////
            string searchName = "%" + name + "%";
            db.AddParameter("@Name", searchName);
            if (scope == 2)
            {
                //记录查询的总数
                DBConnection db1 = new DBConnection();
                db1.AddParameter("@Name", searchName);
                string sql1 = "select count(*) as a from Lessee where Name like @Name";

                SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
                while (sdr1.Read())
                {
                    searchNum = int.Parse(sdr1["a"].ToString());
                }
                db1.Dispose();


                rowcount = searchNum;
                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by ID desc) as rownum ,* from Lessee where Name like @Name ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by ID desc) as rownum, * from Lessee where Name like @Name ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
            }
            else
            {
                if (scope == 1)
                {
                    rowcount = this.GetInRecordNum();
                    status = false;
                }
                if (scope == 0)
                {
                    rowcount = this.GetOutRecordNum();
                    status = true;
                }


                db.AddParameter("@Status", status);


                //记录查询获得的总数
                DBConnection db1 = new DBConnection();
                db1.AddParameter("@Name", searchName);
                db1.AddParameter("@Status", status);
                string sql1 = "select count(*) as a from Lessee where Name like @Name and Status=@Status";

                SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
                while (sdr1.Read())
                {
                    searchNum = int.Parse(sdr1["a"].ToString());
                }
                db1.Dispose();

                rowcount = searchNum;
                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by ID desc) as rownum ,* from Lessee where Name like @Name and Status=@Status) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by ID desc) as rownum, * from Lessee where Name like @Name and Status=@Status)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            }


            //////
           

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                Lessee lessee = new Lessee();
                lessee.ID = int.Parse(sdr["ID"].ToString());
                lessee.Name = sdr["Name"].ToString();
                lessee.RoomNum = sdr["RoomNum"].ToString().Trim();
                lessee.Address = sdr["Address"].ToString();
                lessee.OperationScope = sdr["OperationScope"].ToString();
                lessee.OfficePhone = sdr["OfficePhone"].ToString();
                lessee.Director = sdr["Director"].ToString();
                lessee.DirectorPhone = sdr["DirectorPhone"].ToString();
                lessee.Emergency = sdr["Emergency"].ToString();
                lessee.EmergencyPhone = sdr["EmergencyPhone"].ToString();
                lessee.Remark = sdr["Remark"].ToString();
                lessee.Password = EncryptAndDecrypt.Decrypt(key, sdr["Password"].ToString());
                if (sdr["Status"].ToString() != "" && sdr["Status"].ToString() != null)
                    lessee.Status = Boolean.Parse(sdr["Status"].ToString());
                if (sdr["WarrantMon"].ToString() != null && sdr["WarrantMon"].ToString() != "")
                    lessee.WarrantMon = double.Parse(sdr["WarrantMon"].ToString());

                lesseeList.Add(lessee);
            }
            db.Dispose();
            return lesseeList;
        }

        //通过ID获得租户信息
        public Lessee GetLesseeByID(int id)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@ID", id);
            string sql = "select * from Lessee where ID=@ID ";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            Lessee lessee = new Lessee();

            if (sdr.Read())
            {
                lessee.ID = int.Parse(sdr["ID"].ToString());
                lessee.Name = sdr["Name"].ToString();
                lessee.RoomNum = sdr["RoomNum"].ToString().Trim();
                lessee.Address = sdr["Address"].ToString();
                lessee.OperationScope = sdr["OperationScope"].ToString();
                lessee.OfficePhone = sdr["OfficePhone"].ToString();
                lessee.Director = sdr["Director"].ToString();
                lessee.DirectorPhone = sdr["DirectorPhone"].ToString();
                lessee.Emergency = sdr["Emergency"].ToString();
                lessee.EmergencyPhone = sdr["EmergencyPhone"].ToString();
                lessee.Remark = sdr["Remark"].ToString();
                lessee.Password = EncryptAndDecrypt.Decrypt(key, sdr["Password"].ToString());
                if (sdr["Status"].ToString() != "" && sdr["Status"].ToString() != null)
                    lessee.Status = Boolean.Parse(sdr["Status"].ToString());
                if (sdr["WarrantMon"].ToString() != null && sdr["WarrantMon"].ToString() != "")
                    lessee.WarrantMon = double.Parse(sdr["WarrantMon"].ToString());
            }
            else
            {
                lessee = null;
            }

            db.Dispose();
            return lessee;
        }


        //通过登录名获得租户信息
        public Lessee GetLesseeByRoomNum(string name)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@RoomNum",name );
            string sql = "select * from Lessee where RoomNum=@RoomNum ";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            Lessee lessee = new Lessee();

            if (sdr.Read())
            {
                lessee.ID = int.Parse(sdr["ID"].ToString());
                lessee.Name = sdr["Name"].ToString();
                lessee.RoomNum = sdr["RoomNum"].ToString().Trim();
                lessee.Address = sdr["Address"].ToString();
                lessee.OperationScope = sdr["OperationScope"].ToString();
                lessee.OfficePhone = sdr["OfficePhone"].ToString();
                lessee.Director = sdr["Director"].ToString();
                lessee.DirectorPhone = sdr["DirectorPhone"].ToString();
                lessee.Emergency = sdr["Emergency"].ToString();
                lessee.EmergencyPhone = sdr["EmergencyPhone"].ToString();
                lessee.Remark = sdr["Remark"].ToString();
                lessee.Password = EncryptAndDecrypt.Decrypt(key, sdr["Password"].ToString());
                if (sdr["Status"].ToString() != "" && sdr["Status"].ToString() != null)
                    lessee.Status = Boolean.Parse(sdr["Status"].ToString());
                if (sdr["WarrantMon"].ToString() != null && sdr["WarrantMon"].ToString() != "")
                    lessee.WarrantMon = double.Parse(sdr["WarrantMon"].ToString());
            }
            else
            {
                lessee = null;
            }

            db.Dispose();
            return lessee;
        }

        //获得租户信息总数
        public int GetTotalRecordNum()
        {

            DBConnection db = new DBConnection();
            string sql = "select count(*) as a from Lessee";

            int count = 0;
            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                count = int.Parse(sdr["a"].ToString());
            }

            db.Dispose();
            return count;
        }
        
        //获得入住的租户数
        public int GetInRecordNum()
        {

            DBConnection db = new DBConnection();
            string sql = "select count(*) as a from Lessee where Status=0";

            int count = 0;
            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                count = int.Parse(sdr["a"].ToString());
            }

            db.Dispose();
            return count;
        }

        //获得搬离的租户数
        public int GetOutRecordNum()
        {

            DBConnection db = new DBConnection();
            string sql = "select count(*) as a from Lessee where Status=1";

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