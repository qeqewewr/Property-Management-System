using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CEMIS.Util;
using CEMIS.Util.Authority;
using System.Data.SqlClient;

/// <summary>
///PermissionDAO 的摘要说明
/// </summary>
public class PermissionDAO
{
	public PermissionDAO()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public int AddPermission(Permission per)
    {
        DBConnection db = new DBConnection();


        if (per.RoleID != 0)
            db.AddParameter("@RoleID", per.RoleID);
        else
            db.AddParameter("@RoleID", DBNull.Value);
        if (per.FunctionID != 0)
            db.AddParameter("@FunctionID", per.FunctionID);
        else
            db.AddParameter("@FunctionID", DBNull.Value);

        db.AddParameter("@Description", per.Description);



        string sql = "insert into Permission(RoleID,FunctionID,Description) values(@RoleID,@FunctionID,@Description);select @@IDENTITY";
        //string sql = "insert into Permission(RoleID,FunctionID) values(@RoleID,@FunctionID);select @@IDENTITY";

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

    public Permission GetPermission(int id)
    {
        DBConnection db = new DBConnection();
        db.AddParameter("@ID", id);
        string sql = "select * from Permission where ID=@ID";
        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        Permission per = new Permission();

        if (sdr.Read())
        {
            if (sdr["ID"].ToString() != "" && sdr["ID"].ToString() != null)
                per.ID = int.Parse(sdr["ID"].ToString());
            //if (sdr["Type"].ToString() != "" && sdr["Type"].ToString() != null)
            //    per.Type = int.Parse(sdr["Type"].ToString());
            if (sdr["RoleID"].ToString() != "" && sdr["RoleID"].ToString() != null)
                per.RoleID = int.Parse(sdr["RoleID"].ToString());
            if (sdr["FunctionID"].ToString() != "" && sdr["FunctionID"].ToString() != null)
                per.FunctionID = int.Parse(sdr["FunctionID"].ToString());
            per.Description = sdr["Description"].ToString();

        }
        else
        {
            per = null;
        }

        db.Dispose();
        return per;
    }

    public List<Permission> GetPermissionByRoleID(int id)
    {
        DBConnection db = new DBConnection();
        db.AddParameter("@RoleID", id);
        string sql = "select * from Permission where RoleID=@RoleID";
        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        List<Permission> perList = new List<Permission>();
        Permission per = new Permission();

        while (sdr.Read())
        {
            per = new Permission();
            if (sdr["ID"].ToString() != "" && sdr["ID"].ToString() != null)
                per.ID = int.Parse(sdr["ID"].ToString());
            //if (sdr["Type"].ToString() != "" && sdr["Type"].ToString() != null)
            //    per.Type = int.Parse(sdr["Type"].ToString());
            if (sdr["RoleID"].ToString() != "" && sdr["RoleID"].ToString() != null)
                per.RoleID = int.Parse(sdr["RoleID"].ToString());
            if (sdr["FunctionID"].ToString() != "" && sdr["FunctionID"].ToString() != null)
                per.FunctionID = int.Parse(sdr["FunctionID"].ToString());
            per.Description = sdr["Description"].ToString();

            perList.Add(per);

        }
        
        db.Dispose();
        return perList;
    }

    public int DeletePermission(int id)
    {
        DBConnection db = new DBConnection();
        db.AddParameter("@ID", id);
        string sql = "delete from Permission where ID=@ID";

        return db.ExecuteNonQuery(sql);
        
    }
	
	 public int DeletePermissionByRoleID(int id)
    {
        DBConnection db = new DBConnection();
        db.AddParameter("@RoleID", id);
        string sql = "delete from Permission where RoleID=@RoleID";

        return db.ExecuteNonQuery(sql);
        
    }

    
}