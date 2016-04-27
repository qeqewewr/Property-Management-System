using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;
using CEMIS.Util;
using CEMIS.Model.Employe;




/// <summary>
/// DepartmentDAO 的摘要说明
/// </summary>
/// 

namespace CEMIS.Model.Employe
{

    public class DepartmentDAO
    {
        public DepartmentDAO()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        //部门信息添加
        public int AddDepartment(Department department)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@ID", department.ID);
            db.AddParameter("@Name", department.Name);
            db.AddParameter("@Manager", department.Manager);
            db.AddParameter("@Address", department.Address);


            string sql = "insert into Department(ID,Name,Manager,Address) values(@ID,@Name,@Manager,@Address)";

            return db.ExecuteNonQuery(sql);
        }

        //部门信息编辑更新
        public int UpdateDepartment(Department department)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@ID", department.ID);
            db.AddParameter("@Name", department.Name);
            db.AddParameter("@Manager", department.Manager);
            db.AddParameter("@Address", department.Address);


            string sql = "";
            //sql = "update Department set Address=@Address where Name=@Name ";
            sql = "update Department set Name=@Name ,Manager=@Manager,Address=@Address where ID=@ID ";


            return db.ExecuteNonQuery(sql);
        }

        //获得当前页面的部门信息列表
        public List<Department> ListPageDepartment(int pageno, int pagesize)
        {
            List<Department> departmentList=new List<Department>();
            int rowcount=this.GetTotalRecordNum();
            string sql;

            DBConnection db=new DBConnection();

            if(pageno*pagesize>rowcount)
                sql = "with temp as( select row_number() over(order by ID) as rownum ,* from Department) select * from temp where rownum between "+(pagesize*(pageno-1)+1)+" and "+(rowcount)+"";
            else   
                sql="with temp as( select row_number() over(order by ID) as rownum, * from Department )select * from temp where rownum between "+(pagesize*(pageno-1)+1)+" and "+(pageno*pagesize)+"";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

            while (sdr.Read())
            {
                Department department = new Department();

                department.ID = sdr["ID"].ToString();
                department.Name = sdr["Name"].ToString();
                department.Manager = sdr["Manager"].ToString();
                department.Address = sdr["Address"].ToString();
                departmentList.Add(department);
            }
            db.Dispose();
            return departmentList;
        }

        //获得所有的部门信息列表
        public List<Department> ListDepartment()
        {
            List<Department> departmentList = new List<Department>();

            DBConnection db = new DBConnection();
            string sql = "select * from Department";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                Department department = new Department();

                department.ID = sdr["ID"].ToString();
                department.Name = sdr["Name"].ToString();
                department.Manager = sdr["Manager"].ToString();
                department.Address = sdr["Address"].ToString();
                departmentList.Add(department);
            }
            db.Dispose();
            return departmentList;
        }

        /*
        //通过名称删除部门信息(当部门名称不重复的时候可以使用)
        public int deleteDepartment(string name)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@Name", name);
            string sql = "delete from Department where Name=@Name";
            return db.ExecuteNonQuery(sql);
        }*/

        //通过ID删除部门信息
        public int deleteDepartmentByID(string id)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@ID", id);
            string sql = "delete from Department where ID=@ID";
            return db.ExecuteNonQuery(sql);
        }
      
        //通过部门名称获得部门信息，可用来判断部门名称是否存在
        public Department GetDepartmentByName(string name)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@Name", name);
            string sql = "select * from Department where Name=@Name ";
         
            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            Department depart = new Department();

            if (sdr.Read())
            {
                depart.ID = sdr["ID"].ToString();
                depart.Name = sdr["Name"].ToString();
                depart.Manager = sdr["Manager"].ToString();
                depart.Address = sdr["Address"].ToString();
            }
            else
            {
                depart = null;
            }
                
            db.Dispose();
            return depart;
        }
        //通过ID获得部门信息
        public Department GetDepartmentByID (string id)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@ID", id);
            string sql = "select * from Department where ID=@ID ";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            Department depart = new Department();

            if (sdr.Read())
            {
                depart.ID = sdr["ID"].ToString();
                depart.Name = sdr["Name"].ToString();
                depart.Manager = sdr["Manager"].ToString();
                depart.Address = sdr["Address"].ToString();
            }
            else
            {
                depart = null;
            }

            db.Dispose();
            return depart;
        }

        //获得总的部门信息数
        public int GetTotalRecordNum()
        {

            DBConnection db = new DBConnection();
            string sql = "select count(*) as a from Department";

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









