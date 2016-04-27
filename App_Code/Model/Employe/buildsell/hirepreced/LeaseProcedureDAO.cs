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
///LeaseProcedureDAO 租赁手续
/// </summary>
public class LeaseProcedureDAO
{
	public LeaseProcedureDAO()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 辅助方法
    /// </summary>
    /// <param name="sdr"></param>
    /// <returns></returns>
    public LeaseProcedure GetLeaseProcedureBySdr(SqlDataReader sdr)
    {
        LeaseProcedure leaseProcedure = new LeaseProcedure();
        leaseProcedure.Id = sdr["ID"].ToString();
        leaseProcedure.LeaseContent = sdr["LeaseContent"].ToString();

        return leaseProcedure;
    }

    /// <summary>
    /// 获得数据列表
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public List<LeaseProcedure> DataTableToList(DataTable dt)
    {
        List<LeaseProcedure> modelList = new List<LeaseProcedure>();
        int rowsCount = dt.Rows.Count;
        if (rowsCount > 0)
        {
            LeaseProcedure model;
            for (int n = 0; n < rowsCount; n++)
            {
                model = new LeaseProcedure();

                if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    model.Id = dt.Rows[n]["ID"].ToString();
                if (dt.Rows[n]["LeaseContent"] != null && dt.Rows[n]["LeaseContent"].ToString() != "")
                    model.LeaseContent = dt.Rows[n]["LeaseContent"].ToString();
              
                modelList.Add(model);
            }
        }
        return modelList;
    }

    /// <summary>
    /// 增加一条记录
    /// </summary>
    /// <param name="LeaseProcedure"></param>
    /// <returns></returns>
    public int AddLeaseProcedure(LeaseProcedure leaseProcedure)
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@LeaseContent",SqlDbType.NVarChar)};
        parameters[0].Value = leaseProcedure.LeaseContent;

        string sql = "insert into LeaseProcedure values(@LeaseContent)";
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
    /// 分页读取表数据
    /// </summary>
    /// <param name="pageno">页号</param>
    /// <param name="pagesize">页大小</param>
    /// <returns></returns>
    public List<LeaseProcedure> ListPageLeaseProcedure(int pageno, int pagesize)
    {
        int rowcount = this.GetTotalRecordNum();
        string sql;

        DBConnection db = new DBConnection();

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by ID) as rownum ,* from LeaseProcedure) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by ID) as rownum, * from LeaseProcedure) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        DataSet ds = DBHelperSQL.Query(sql);
        return DataTableToList(ds.Tables[0]);
    }

    /// <summary>
    /// 由ID获得LeaseProcedure记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public LeaseProcedure GetLeaseProcedure( )
    {
        List<LeaseProcedure> leaseProcedure = new List<LeaseProcedure>();
        string sql = "select * from LeaseProcedure";
        DataSet ds = DBHelperSQL.Query(sql);
        leaseProcedure= DataTableToList(ds.Tables[0]);
        if (leaseProcedure.Count > 0)
            return leaseProcedure[0];
        else
            return null;
    }

    /// <summary>
    /// 更新LeaseProcedure表
    /// </summary>
    /// <param name="employe"></param>
    /// <returns></returns>
    public int UpdateLeaseProcedure(LeaseProcedure leaseProcedure)
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@ID",SqlDbType.Int),
                    new SqlParameter("@LeaseContent",SqlDbType.NVarChar) 
                    };
        parameters[0].Value = leaseProcedure.Id;
        parameters[1].Value = leaseProcedure.LeaseContent;
       
        string sql = "";
        sql = "update LeaseProcedure set LeaseContent=@LeaseContent where ID=@ID ";

        return DBHelperSQL.ExecuteSql(sql, parameters);
    }


    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeleteLeaseProcedureById(string id)
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@ID",SqlDbType.Int) 
                    };
        parameters[0].Value = id;
        string sql = "delete from LeaseProcedure where ID=@ID";

        return DBHelperSQL.ExecuteSql(sql,parameters);
    }

    /// <summary>
    ///获得表记录总数
    /// </summary>
    /// <returns></returns>
    public int GetTotalRecordNum()
    {
        return DBHelperSQL.countNum("LeaseProcedure");
    }

}