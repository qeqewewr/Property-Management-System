using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CEMIS.Model.Employe;
using CEMIS.Util;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Data.OleDb;


/// <summary>
///EmployeDAO 的摘要说明
/// </summary>
/// 

namespace CEMIS.Model.Employe
{
    public class EmployeDAO
    {
        
        private string key = "12345678";   //密码加密的密钥

        public int searchNum=0;  //查询得到的总数
   

        public EmployeDAO()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// new----------------
        /// </summary>
        /// <param name="id"></param>
        /// <param name="psw"></param>
        /// <returns></returns>
        public Boolean LogonJudge(string id, string psw)
        {
            DBConnection db = new DBConnection();
            db.AddParameter("@EmployeID", id);
            db.AddParameter("@Password", EncryptAndDecrypt.Encrypt(key, psw));

            string sql = "SELECT EmployeID,Password From Employe WHERE EmployeID=@EmployeID AND Password=@Password";
            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

            if (sdr.Read())
                return true;
            else
                return false;
        }

        //添加员工
        public int AddEmploye(Employe employe)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@EmployeID", employe.EmployeID);
            db.AddParameter("@Name", employe.Name);
            db.AddParameter("@IDNumber", employe.IDNumber);
            db.AddParameter("@Sex", employe.Sex);
            db.AddParameter("@Nation", employe.Nation);
            if(employe.Birth!=null)
                db.AddParameter("@Birth", employe.Birth,SqlDbType.Date);
            else
                db.AddParameter("@Birth",DBNull.Value);
            //db.AddParameter("@Birth", employe.Birth);
            db.AddParameter("@Politics", employe.Politics);
            db.AddParameter("@Education", employe.Education);
            db.AddParameter("@Department", employe.Department);
            db.AddParameter("@OfficeTel", employe.OfficeTel);
            db.AddParameter("@HomeTel", employe.HomeTel);
            db.AddParameter("@Mobile", employe.Mobile);
            db.AddParameter("@HomeAddress", employe.HomeAddress);
            db.AddParameter("@Email", employe.Email);
            if (employe.Status != null)
                db.AddParameter("@Status", employe.Status);
            else
                db.AddParameter("@Status", false);
            if (employe.EnterDate != null)
                db.AddParameter("@EnterDate", employe.EnterDate, SqlDbType.Date);
            else
                db.AddParameter("@EnterDate", DBNull.Value);
            if (employe.LeaveDate != null)
                db.AddParameter("@LeaveDate", employe.LeaveDate, SqlDbType.Date);
            else
                db.AddParameter("@LeaveDate", DBNull.Value);
            //db.AddParameter("@EnterDate", employe.EnterDate);
           // db.AddParameter("@LeaveDate", employe.LeaveDate);
            db.AddParameter("@Password", EncryptAndDecrypt.Encrypt(key,employe.Password));
            //db.AddParameter("@Password", employe.Password);


            string sql = "insert into Employe(EmployeID,Name,IDNumber,Sex,Nation,Birth,Politics,Education,Department,OfficeTel,HomeTel,Mobile,HomeAddress,Email,Status,EnterDate,LeaveDate,Password) values(@EmployeID,@Name,@IDNumber,@Sex,@Nation,@Birth,@Politics,@Education,@Department,@OfficeTel,@HomeTel,@Mobile,@HomeAddress,@Email,@Status,@EnterDate,@LeaveDate,@Password)";

            return db.ExecuteNonQuery(sql);
        }

        //编辑员工信息
        public int UpdateEmploye(Employe employe)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@EmployeID", employe.EmployeID);
            db.AddParameter("@Name", employe.Name);
            db.AddParameter("@IDNumber", employe.IDNumber);
            db.AddParameter("@Sex", employe.Sex);
            db.AddParameter("@Nation", employe.Nation);
            if (employe.Birth != null)
                db.AddParameter("@Birth", employe.Birth, SqlDbType.Date);
            else
                db.AddParameter("@Birth", DBNull.Value);
            //db.AddParameter("@Birth", employe.Birth);
            db.AddParameter("@Politics", employe.Politics);
            db.AddParameter("@Education", employe.Education);
            db.AddParameter("@Department", employe.Department);
            db.AddParameter("@OfficeTel", employe.OfficeTel);
            db.AddParameter("@HomeTel", employe.HomeTel);
            db.AddParameter("@Mobile", employe.Mobile);
            db.AddParameter("@HomeAddress", employe.HomeAddress);
            db.AddParameter("@Email", employe.Email);
            if (employe.Status != null)
                db.AddParameter("@Status", employe.Status);
            else
                db.AddParameter("@Status", false);
            if (employe.EnterDate != null)
                db.AddParameter("@EnterDate", employe.EnterDate, SqlDbType.Date);
            else
                db.AddParameter("@EnterDate", DBNull.Value);
            if (employe.LeaveDate != null)
                db.AddParameter("@LeaveDate", employe.LeaveDate, SqlDbType.Date);
            else
                db.AddParameter("@LeaveDate", DBNull.Value);
            //db.AddParameter("@EnterDate", employe.EnterDate);
            // db.AddParameter("@LeaveDate", employe.LeaveDate);
            db.AddParameter("@Password", EncryptAndDecrypt.Encrypt(key, employe.Password));
            //db.AddParameter("@Password", employe.Password);

            string sql = "";
            sql = "update Employe set Name=@Name,IDNumber=@IDNumber,Sex=@Sex,Nation=@Nation,Birth=@Birth,Politics=@Politics,Education=@Education,Department=@Department,OfficeTel=@OfficeTel,HomeTel=@HomeTel,Mobile=@Mobile,HomeAddress=@HomeAddress,Email=@Email,Status=@Status,EnterDate=@EnterDate,LeaveDate=@LeaveDate,Password=@Password where EmployeID=@EmployeID ";


            return db.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 用自增id获得员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employe GetEmploye(string id)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@ID", id);
            string sql = "select * from Employe where ID=@ID ";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            Employe employe = new Employe();

            if (sdr.Read())
            {
                employe.ID = int.Parse(sdr["ID"].ToString());
                employe.EmployeID = sdr["EmployeID"].ToString();
                employe.Name = sdr["Name"].ToString();
                employe.IDNumber = sdr["IDNumber"].ToString();
                employe.Sex = sdr["Sex"].ToString();
                employe.Nation = sdr["Nation"].ToString();
                if (sdr["Birth"].ToString() != null && sdr["Birth"].ToString() != "")
                    employe.Birth = DateTime.Parse(sdr["Birth"].ToString());
                else
                    employe.Birth = null;
                employe.Politics = sdr["Politics"].ToString();
                employe.Education = sdr["Education"].ToString();
                employe.Department = sdr["Department"].ToString();
                employe.OfficeTel = sdr["OfficeTel"].ToString();
                employe.HomeTel = sdr["HomeTel"].ToString();
                employe.HomeAddress = sdr["HomeAddress"].ToString();
                employe.Mobile = sdr["Mobile"].ToString();
                employe.Email = sdr["Email"].ToString();
                if (sdr["Status"].ToString() != null && sdr["Status"].ToString() != "")
                    employe.Status = Boolean.Parse(sdr["Status"].ToString());
                else
                    employe.Status = false;
                employe.Email = sdr["Email"].ToString();
                if (sdr["EnterDate"].ToString() != null && sdr["EnterDate"].ToString() != "")
                    employe.EnterDate = DateTime.Parse(sdr["EnterDate"].ToString());
                else
                    employe.EnterDate = null;
                if (sdr["LeaveDate"].ToString() != null && sdr["LeaveDate"].ToString() != "")
                    employe.LeaveDate = DateTime.Parse(sdr["LeaveDate"].ToString());
                else
                    employe.LeaveDate = null;
                employe.Password = EncryptAndDecrypt.Decrypt(key, sdr["Password"].ToString());
                //employe.Password = sdr["Password"].ToString();
            }
            else
            {
                employe = null;
            }

            db.Dispose();
            return employe;
        }

        //获得员工总列表
        public List<Employe> ListEmploye()
        {
            List<Employe> employeList = new List<Employe>();

            DBConnection db = new DBConnection();
            string sql = "select * from Employe";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                Employe employe = new Employe();
                employe.ID = int.Parse(sdr["ID"].ToString());
                employe.EmployeID = sdr["EmployeID"].ToString();
                employe.Name = sdr["Name"].ToString();
                employe.IDNumber = sdr["IDNumber"].ToString();
                employe.Sex = sdr["Sex"].ToString();
                employe.Nation = sdr["Nation"].ToString();
                if (sdr["Birth"].ToString() != null && sdr["Birth"].ToString() != "")
                    employe.Birth = DateTime.Parse(sdr["Birth"].ToString());
                else
                    employe.Birth = null;
                employe.Politics = sdr["Politics"].ToString();
                employe.Education = sdr["Education"].ToString();
                employe.Department = sdr["Department"].ToString();
                employe.OfficeTel = sdr["OfficeTel"].ToString();
                employe.HomeTel = sdr["HomeTel"].ToString();
                employe.HomeAddress = sdr["HomeAddress"].ToString();
                employe.Mobile = sdr["Mobile"].ToString();
                if (sdr["Status"].ToString() != null && sdr["Status"].ToString() != "")
                    employe.Status = Boolean.Parse(sdr["Status"].ToString());
                else
                    employe.Status = false;
                employe.Email = sdr["Email"].ToString();
                if (sdr["EnterDate"].ToString() != null && sdr["EnterDate"].ToString() != "")
                    employe.EnterDate = DateTime.Parse(sdr["EnterDate"].ToString());
                else
                    employe.EnterDate = null;
                if (sdr["LeaveDate"].ToString() != null && sdr["LeaveDate"].ToString() != "")
                    employe.LeaveDate = DateTime.Parse(sdr["LeaveDate"].ToString());
                else
                    employe.LeaveDate = null;
                employe.Password =EncryptAndDecrypt.Decrypt(key, sdr["Password"].ToString());
                //employe.Password = sdr["Password"].ToString();
                employeList.Add(employe);
            }
            db.Dispose();
            return employeList;
        }

        //获得当前页的员工信息
        public List<Employe> ListPageEmploye(int pageno,int pagesize,int scope)
        {
            List<Employe> employeList=new List<Employe>();
            int rowcount=this.GetTotalRecordNum();;
            string sql="";
            DBConnection db = new DBConnection();

            Boolean status = false;

            if (scope == 2)
            {
                rowcount = this.GetTotalRecordNum();
                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by Department,EmployeID) as rownum ,* from Employe ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by Department,EmployeID) as rownum, * from Employe )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
            }
            else
            {
                if (scope == 1)
                {
                    rowcount = this.GetWorkRecordNum();
                    status = false;
                }
                if (scope == 0)
                {
                    rowcount = this.GetLeaveRecordNum();
                    status = true;
                }
                db.AddParameter("@Status", status);
                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by Department,EmployeID) as rownum ,* from Employe where Status=@Status) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by Department,EmployeID) as rownum, * from Employe where Status=@Status )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
            }
           

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                Employe employe = new Employe();
                employe.ID = int.Parse(sdr["ID"].ToString());
                employe.EmployeID = sdr["EmployeID"].ToString();
                employe.Name = sdr["Name"].ToString();
                employe.IDNumber = sdr["IDNumber"].ToString();
                employe.Sex = sdr["Sex"].ToString();
                employe.Nation = sdr["Nation"].ToString();
                if (sdr["Birth"].ToString() != null && sdr["Birth"].ToString() != "")
                    employe.Birth = DateTime.Parse(sdr["Birth"].ToString());
                else
                    employe.Birth = null;
                employe.Politics = sdr["Politics"].ToString();
                employe.Education = sdr["Education"].ToString();
                employe.Department = sdr["Department"].ToString();
                employe.OfficeTel = sdr["OfficeTel"].ToString();
                employe.HomeTel = sdr["HomeTel"].ToString();
                employe.HomeAddress = sdr["HomeAddress"].ToString();
                employe.Mobile = sdr["Mobile"].ToString();
                employe.Email = sdr["Email"].ToString();
                if (sdr["Status"].ToString() != null && sdr["Status"].ToString() != "")
                    employe.Status = Boolean.Parse(sdr["Status"].ToString());
                else
                    employe.Status = false;
                employe.Email = sdr["Email"].ToString();
                if (sdr["EnterDate"].ToString() != null && sdr["EnterDate"].ToString() != "")
                    employe.EnterDate = DateTime.Parse(sdr["EnterDate"].ToString());
                else
                    employe.EnterDate = null;
                if (sdr["LeaveDate"].ToString() != null && sdr["LeaveDate"].ToString() != "")
                    employe.LeaveDate = DateTime.Parse(sdr["LeaveDate"].ToString());
                else
                    employe.LeaveDate = null;
                employe.Password = EncryptAndDecrypt.Decrypt(key, sdr["Password"].ToString());
                //employe.Password = sdr["Password"].ToString();
                employeList.Add(employe);
            }
            db.Dispose();
            return employeList;
        }

        //用员工号删除员工
        public int deleteEmploye(string id)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@EmployeID", id);
            string sql = "delete from Employe where EmployeID=@EmployeID";
            return db.ExecuteNonQuery(sql);
        }


      
        //通过员工号得到员工信息
        public Employe GetEmployeByID(string id)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@EmployeID", id);
            string sql = "select * from Employe where EmployeID=@EmployeID ";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            Employe employe = new Employe();

            if (sdr.Read())
            {
                employe.ID = int.Parse(sdr["ID"].ToString());
                employe.EmployeID = sdr["EmployeID"].ToString();
                employe.Name = sdr["Name"].ToString();
                employe.IDNumber = sdr["IDNumber"].ToString();
                employe.Sex = sdr["Sex"].ToString();
                employe.Nation = sdr["Nation"].ToString();
                if (sdr["Birth"].ToString() != null && sdr["Birth"].ToString() != "")
                    employe.Birth = DateTime.Parse(sdr["Birth"].ToString());
                else
                    employe.Birth = null;
                employe.Politics = sdr["Politics"].ToString();
                employe.Education = sdr["Education"].ToString();
                employe.Department = sdr["Department"].ToString();
                employe.OfficeTel = sdr["OfficeTel"].ToString();
                employe.HomeTel = sdr["HomeTel"].ToString();
                employe.HomeAddress = sdr["HomeAddress"].ToString();
                employe.Mobile = sdr["Mobile"].ToString();
                employe.Email = sdr["Email"].ToString();
                if (sdr["Status"].ToString() != null && sdr["Status"].ToString() != "")
                    employe.Status = Boolean.Parse(sdr["Status"].ToString());
                else
                    employe.Status = false;
                employe.Email = sdr["Email"].ToString();
                if (sdr["EnterDate"].ToString() != null && sdr["EnterDate"].ToString() != "")
                    employe.EnterDate = DateTime.Parse(sdr["EnterDate"].ToString());
                else
                    employe.EnterDate = null;
                if (sdr["LeaveDate"].ToString() != null && sdr["LeaveDate"].ToString() != "")
                    employe.LeaveDate = DateTime.Parse(sdr["LeaveDate"].ToString());
                else
                    employe.LeaveDate = null;
                employe.Password = EncryptAndDecrypt.Decrypt(key, sdr["Password"].ToString());
                //employe.Password = sdr["Password"].ToString();
            }
            else
            {
                employe = null;
            }

            db.Dispose();
            return employe;
        }

        ////通过员工部门获得员工姓名列表
        //public List<string> GetInfoByDepart(string name)
        //{
        //    string department = name;

        //    DBConnection db = new DBConnection();

        //    db.AddParameter("@Department", department);

        //    string sql = "select EmployeID,Name from Employe where Department=@Department";
        //    SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        //    List<string> nameList = new List<string>();

        //    while (sdr.Read())
        //    {
        //        string id = sdr["EmployeID"].ToString();
        //        nameList.Add(id);
        //        string employename = sdr["Name"].ToString();
        //        nameList.Add(employename);
        //    }
        //    db.Dispose();
        //    return nameList;

        //}

        /// <summary>
        /// 通过员工部门获得员工姓名列表  1:在职，0：离职  2：全部 new   
        /// </summary>
        /// <param name="name"></param>
        /// <param name="scope"></param>
        /// <returns></returns>

        public List<string> GetInfoByDepart(string name, int scope)
        {
            string department = name;
            Boolean status = false;
            string sql = "";

            DBConnection db = new DBConnection();

            db.AddParameter("@Department", department);

            if (scope == 2)
            {
                sql = "select EmployeID,Name from Employe where Department=@Department";
            }
            else
            {
                if (scope == 1)
                    status = false;
                if (scope == 0)
                    status = true;
                db.AddParameter("@Status", status);
                sql = "select EmployeID,Name from Employe where Department=@Department and Status=@Status";
            }

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

            List<string> nameList = new List<string>();

            while (sdr.Read())
            {
                string id = sdr["EmployeID"].ToString();
                nameList.Add(id);
                string employename = sdr["Name"].ToString();
                nameList.Add(employename);
            }
            db.Dispose();
            return nameList;

        }

        //通过员工姓名和在职情况模糊查找获得员工列表 1:在职，0：离职  2：全部
        public List<Employe> GetEmployeByName(string name,int scope,int pageno,int pagesize)
        {
            Boolean status = false;
            string sql = "";
            int rowcount = 0;

            DBConnection db = new DBConnection();
  
            string searchName = "%" + name + "%";
            db.AddParameter("@Name", searchName);
            if (scope == 2)
            {
                //记录查询的总数
                DBConnection db1 = new DBConnection();
                db1.AddParameter("@Name", searchName);
                string sql1 = "select count(*) as a from Employe where Name like @Name";

                SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
                while (sdr1.Read())
                {
                    searchNum = int.Parse(sdr1["a"].ToString());
                }
                db1.Dispose();


                rowcount = searchNum;
                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by Department,EmployeID) as rownum ,* from Employe where Name like @Name ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by Department,EmployeID) as rownum, * from Employe where Name like @Name )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
            }
            else
            {
                if (scope == 1)
                {
                    rowcount = this.GetWorkRecordNum();
                    status = false;
                }
                if (scope == 0)
                {
                    rowcount = this.GetLeaveRecordNum();
                    status = true;
                }


                db.AddParameter("@Status", status);


                //记录查询获得的总数
                DBConnection db1 = new DBConnection();
                db1.AddParameter("@Name", searchName);
                db1.AddParameter("@Status", status);
                string sql1 = "select count(*) as a from Employe where Name like @Name and Status=@Status";

                SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
                while (sdr1.Read())
                {
                    searchNum = int.Parse(sdr1["a"].ToString());
                }
                db1.Dispose();

                rowcount = searchNum;
                if (pageno * pagesize > rowcount)
                    sql = "with temp as( select row_number() over(order by Department,EmployeID) as rownum ,* from Employe where Name like @Name and Status=@Status) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
                else
                    sql = "with temp as( select row_number() over(order by Department,EmployeID) as rownum, * from Employe where Name like @Name and Status=@Status)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
              
            }
           

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            Employe employe ;
            List<Employe> list = new List<Employe>();

            while (sdr.Read())
            {
                employe = new Employe();
                employe.ID = int.Parse(sdr["ID"].ToString());
                employe.EmployeID = sdr["EmployeID"].ToString();
                employe.Name = sdr["Name"].ToString();
                employe.IDNumber = sdr["IDNumber"].ToString();
                employe.Sex = sdr["Sex"].ToString();
                employe.Nation = sdr["Nation"].ToString();
                if (sdr["Birth"].ToString() != null && sdr["Birth"].ToString() != "")
                    employe.Birth = DateTime.Parse(sdr["Birth"].ToString());
                else
                    employe.Birth = null;
                employe.Politics = sdr["Politics"].ToString();
                employe.Education = sdr["Education"].ToString();
                employe.Department = sdr["Department"].ToString();
                employe.OfficeTel = sdr["OfficeTel"].ToString();
                employe.HomeTel = sdr["HomeTel"].ToString();
                employe.HomeAddress = sdr["HomeAddress"].ToString();
                employe.Mobile = sdr["Mobile"].ToString();
                employe.Email = sdr["Email"].ToString();
                if (sdr["Status"].ToString() != null && sdr["Status"].ToString() != "")
                    employe.Status = Boolean.Parse(sdr["Status"].ToString());
                else
                    employe.Status = false;
                employe.Email = sdr["Email"].ToString();
                if (sdr["EnterDate"].ToString() != null && sdr["EnterDate"].ToString() != "")
                    employe.EnterDate = DateTime.Parse(sdr["EnterDate"].ToString());
                else
                    employe.EnterDate =null;
                if (sdr["LeaveDate"].ToString() != null && sdr["LeaveDate"].ToString() != "")
                    employe.LeaveDate = DateTime.Parse(sdr["LeaveDate"].ToString());
                else
                    employe.LeaveDate = null;
                employe.Password = EncryptAndDecrypt.Decrypt(key, sdr["Password"].ToString());
                //employe.Password = sdr["Password"].ToString();

                list.Add(employe);
            }
            
            db.Dispose();
            return list;
        }



        //获得总的员工数
        public int GetTotalRecordNum()
        {

            DBConnection db = new DBConnection();
            string sql = "select count(*) as a from Employe";

            int count = 0;
            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                count = int.Parse(sdr["a"].ToString());
            }

            db.Dispose();
            return count;
        }

        //获得在职员工数
        public int GetWorkRecordNum()
        {

            DBConnection db = new DBConnection();
            string sql = "select count(*) as a from Employe where Status=0";

            int count = 0;
            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                count = int.Parse(sdr["a"].ToString());
            }

            db.Dispose();
            return count;
        }

        //获得离职员工数
        public int GetLeaveRecordNum()
        {

            DBConnection db = new DBConnection();
            string sql = "select count(*) as a from Employe where Status=1";

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