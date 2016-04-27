using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CEMIS.Util.Authority;
using CEMIS.Util;
using System.Data.SqlClient;


/// <summary>
///AllFunctionDAO 的摘要说明
/// </summary>
public class AllFunctionDAO
{
	public AllFunctionDAO()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}


    public AllFunction GetFunction(int id)
    {
        DBConnection db = new DBConnection();
        db.AddParameter("@ID", id);
        string sql = "select * from AllFunction where ID=@ID";
        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        AllFunction fun = new AllFunction();

        if (sdr.Read())
        {
            if (sdr["ID"].ToString() != "" && sdr["ID"].ToString() != null)
                fun.ID = int.Parse(sdr["ID"].ToString());
            if (sdr["ParentID"].ToString() != "" && sdr["ParentID"].ToString() != null)
                fun.ParentID = int.Parse(sdr["ParentID"].ToString());
            fun.Code = sdr["Code"].ToString();
            fun.FullName = sdr["FullName"].ToString();
            fun.NavigateUrl = sdr["NavigateUrl"].ToString();
           
        }
        else
        {
            fun = null;
        }

        db.Dispose();
        return fun;
    }

    public List<AllFunction> GetAllFunction()
    {
        DBConnection db = new DBConnection();
       
        string sql = "select * from AllFunction ";
        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        AllFunction fun = new AllFunction();
        List<AllFunction> funList = new List<AllFunction>();
        while (sdr.Read())
        {
            fun = new AllFunction();
            if (sdr["ID"].ToString() != "" && sdr["ID"].ToString() != null)
                fun.ID = int.Parse(sdr["ID"].ToString());
            if (sdr["ParentID"].ToString() != "" && sdr["ParentID"].ToString() != null)
                fun.ParentID = int.Parse(sdr["ParentID"].ToString());
            fun.Code = sdr["Code"].ToString();
            fun.FullName = sdr["FullName"].ToString();
            fun.NavigateUrl = sdr["NavigateUrl"].ToString();

            funList.Add(fun);
        }
        

        db.Dispose();
        return funList;
    }


    public List<AllFunction> GetFatherFunction()
    {
        DBConnection db = new DBConnection();

        string sql = "select * from AllFunction where ParentID=0";
        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        AllFunction fun = new AllFunction();
        List<AllFunction> funList = new List<AllFunction>();
        while (sdr.Read())
        {
            fun = new AllFunction();
            if (sdr["ID"].ToString() != "" && sdr["ID"].ToString() != null)
                fun.ID = int.Parse(sdr["ID"].ToString());
            if (sdr["ParentID"].ToString() != "" && sdr["ParentID"].ToString() != null)
                fun.ParentID = int.Parse(sdr["ParentID"].ToString());
            fun.Code = sdr["Code"].ToString();
            fun.FullName = sdr["FullName"].ToString();
            fun.NavigateUrl = sdr["NavigateUrl"].ToString();

            funList.Add(fun);
        }


        db.Dispose();
        return funList;
    }

}