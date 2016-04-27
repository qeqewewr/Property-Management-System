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
///FirmAdvertiseDAO 企业宣传
/// </summary>
public class FirmAdvertiseDAO
{
    public int searchNum;
	public FirmAdvertiseDAO()
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
    public FirmAdvertise GetFirmAdvertiseBySdr(SqlDataReader sdr)
    {
        FirmAdvertise firmAdvertise = new FirmAdvertise();
        firmAdvertise.Id = sdr["ID"].ToString();
        firmAdvertise.Lessee = sdr["Lessee"].ToString();
        firmAdvertise.PicturePath = sdr["PicturePath"].ToString();
        firmAdvertise.Describe = sdr["Describe"].ToString();
        firmAdvertise.IsSure = (Boolean)sdr["IsSure"];
        firmAdvertise.Remarks = sdr["Remarks"].ToString();
        return firmAdvertise;
    }

    /// <summary>
    /// 获得数据列表
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public List<FirmAdvertise> DataTableToList(DataTable dt)
    {
        List<FirmAdvertise> modelList = new List<FirmAdvertise>();
        int rowsCount = dt.Rows.Count;
        if (rowsCount > 0)
        {
            FirmAdvertise model;
            for (int n = 0; n < rowsCount; n++)
            {
                model = new FirmAdvertise();

                if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    model.Id = dt.Rows[n]["ID"].ToString();
                if (dt.Rows[n]["Lessee"] != null && dt.Rows[n]["Lessee"].ToString() != "")
                    model.Lessee = dt.Rows[n]["Lessee"].ToString();
                if (dt.Rows[n]["PicturePath"] != null && dt.Rows[n]["PicturePath"].ToString() != "")
                    model.PicturePath = dt.Rows[n]["PicturePath"].ToString();
                if (dt.Rows[n]["Describe"] != null && dt.Rows[n]["Describe"].ToString() != "")
                    model.Describe = dt.Rows[n]["Describe"].ToString();
                if (dt.Rows[n]["IsSure"] != null && dt.Rows[n]["IsSure"].ToString() != "")
                    model.IsSure = Boolean.Parse(dt.Rows[n]["IsSure"].ToString());
                if (dt.Rows[n]["Remarks"] != null && dt.Rows[n]["Remarks"].ToString() != "")
                    model.Remarks = dt.Rows[n]["Remarks"].ToString();

                modelList.Add(model);
            }
        }
        return modelList;
    }

    /// <summary>
    /// 增加一条企业宣传记录
    /// </summary>
    /// <param name="firmAdvertise"></param>
    /// <returns></returns>
    public int AddFirmAdvertise(FirmAdvertise firmAdvertise)
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@Lessee", SqlDbType.NVarChar),
                    new SqlParameter("@PicturePath", SqlDbType.NChar),
                    new SqlParameter("@Describe", SqlDbType.NText),
                    new SqlParameter("@IsSure", SqlDbType.Bit),
                    new SqlParameter("@Remarks", SqlDbType.NVarChar)
                };
        parameters[0].Value = firmAdvertise.Lessee;
        parameters[1].Value = firmAdvertise.PicturePath;
        parameters[2].Value = firmAdvertise.Describe;
        parameters[3].Value = firmAdvertise.IsSure;
        parameters[4].Value = firmAdvertise.Remarks;

        string sql = "insert into  LesseeAD values(@Lessee,@PicturePath,@Describe,@IsSure,@Remarks)";
        sql += "SELECT CAST(scope_identity() AS int)";

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
    /// 分页读取企业宣传表记录
    /// </summary>
    /// <param name="pageno"></param>
    /// <param name="pagesize"></param>
    /// <returns></returns>
    public List<FirmAdvertise> ListPageFirmAdvertise(int pageno, int pagesize)
    {       
        int rowcount = this.GetTotalRecordNum();
        string sql;

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsSure,ID) as rownum ,* from LesseeAD) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsSure,ID) as rownum, * from LesseeAD)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        DataSet ds = DBHelperSQL.Query(sql);
        return DataTableToList(ds.Tables[0]);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="pageno"></param>
    /// <param name="pagesize"></param>
    /// <param name="lesseeName"></param>
    /// <returns></returns>
    public List<FirmAdvertise> ListPageFirmAdvertiseByLesseeName(int pageno, int pagesize,string lesseeName)
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@Lessee", SqlDbType.NVarChar)
                };
        parameters[0].Value = lesseeName;
        int rowcount = this.GetRecordNumByLesseeName(lesseeName);
        string sql;
        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsSure,ID) as rownum ,* from LesseeAD Where Lessee=@Lessee) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsSure,ID) as rownum, * from LesseeAD Where Lessee=@Lessee)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        DataSet ds = DBHelperSQL.Query(sql, parameters);
        return DataTableToList(ds.Tables[0]);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="pageno"></param>
    /// <param name="pagesize"></param>
    /// <returns></returns>
    public List<FirmAdvertise> ListPageFirmAdvertiseByIsSure(int pageno, int pagesize)
    {
        List<FirmAdvertise> firmAdvertiseList = new List<FirmAdvertise>();
        int rowcount = this.GetTotalRecordNum();
        string sql;
        SqlParameter[] parameters = {
                    new SqlParameter("@IsSure", SqlDbType.Bit)
                };
        parameters[0].Value = true;

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsSure,ID) as rownum ,* from LesseeAD where IsSure=@IsSure) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsSure,ID) as rownum, * from LesseeAD where IsSure=@IsSure)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        DataSet ds = DBHelperSQL.Query(sql, parameters);
        return DataTableToList(ds.Tables[0]);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="lesseeName"></param>
    /// <returns></returns>
    public int GetRecordNumByLesseeName(string lesseeName)
    {
        return DBHelperSQL.countNum("LesseeAD", "Lessee= " + lesseeName + "");
    }

    /// <summary>
    /// 读取表数据
    /// </summary>
    /// <returns></returns>
    public List<FirmAdvertise> ListFirmAdvertise()
    { 
        string sql = "select * from LesseeAD";

        DataSet ds = DBHelperSQL.Query(sql);
        return DataTableToList(ds.Tables[0]);
    }

    /// <summary>
    /// 由ID获得FirmAdvertise记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public FirmAdvertise GetFirmAdvertiseById(string id)
    {

        DBConnection db = new DBConnection();
        SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int)
                };
        parameters[0].Value = int.Parse(id);
        string sql = "select * from LesseeAD where ID=@ID ";

        DataSet ds = DBHelperSQL.Query(sql,parameters);
        List<FirmAdvertise> firmAd = DataTableToList(ds.Tables[0]);
        if (firmAd.Count > 0)
            return firmAd[0];
        else
            return null;
    }

    /// <summary>
    /// 更新FirmAdvertise表
    /// </summary>
    /// <param name="employe"></param>
    /// <returns></returns>
    public int UpdateFirmAdvertise(FirmAdvertise firmAdvertise)
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@Lessee", SqlDbType.NVarChar),
                    new SqlParameter("@PicturePath", SqlDbType.NChar),
                    new SqlParameter("@Describe", SqlDbType.NText),
                    new SqlParameter("@IsSure", SqlDbType.Bit),
                    new SqlParameter("@Remarks", SqlDbType.NVarChar),
                    new SqlParameter("@ID", SqlDbType.Int)
                };
        parameters[0].Value = firmAdvertise.Lessee;
        parameters[1].Value = firmAdvertise.PicturePath;
        parameters[2].Value = firmAdvertise.Describe;
        parameters[3].Value = firmAdvertise.IsSure;
        parameters[4].Value = firmAdvertise.Remarks;
        parameters[5].Value= int.Parse(firmAdvertise.Id);      
        string sql = "";
        sql = "update LesseeAD set Lessee=@Lessee,PicturePath=@PicturePath,Describe=@Describe,IsSure=@IsSure,Remarks=@Remarks where ID=@ID ";
        return DBHelperSQL.ExecuteSql(sql, parameters);

    }

    /// <summary>
    /// 删除FirmAdvertise记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeleteFirmAdvertiseById(string id)
    {
      
        string sql = "delete from  LesseeAD where ID="+id+"";
        return DBHelperSQL.ExecuteSql(sql);
    }

    /// <summary>
    ///获得LesseeAdv表记录总数
    /// </summary>
    /// <returns></returns>
    public int GetTotalRecordNum()
    {
        return DBHelperSQL.countNum("LesseeAD");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int GetRecordNumByIsSure()
    {
        return DBHelperSQL.countNum("LesseeAD", " IsSure=1");
    }


    /// <summary>
    /// 有关键字查询记录数
    /// </summary>
    /// <param name="keyword"></param>
    /// <returns></returns>
    private int GetSearchNum(string keyword)
    {
        //获得查找总数
        DBConnection db1 = new DBConnection();
        db1.AddParameter("@Lessee", "%" + keyword + "%");
        string sql1 = "select count(*) as a from LesseeAD where Lessee like @Lessee";
        SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
        while (sdr1.Read())
        {
            searchNum = int.Parse(sdr1["a"].ToString());
        }
        sdr1.Close();

        db1.Dispose();
        return searchNum;
    }
    /// <summary>
    /// 由租户名称进行模糊查询
    /// </summary>
    /// <param name="keywork">租户名称</param>
    /// <returns></returns>
    public List<FirmAdvertise> GetFirmAdvertiseListByLesseeName(string keyword,int pageno,int pagesize)
    {

        SqlParameter[] parameters = {
                    new SqlParameter("@Lessee", SqlDbType.NVarChar)
                };
        parameters[0].Value = "%" + keyword + "%";  
       
        searchNum = GetSearchNum(keyword);
        int rowcount = searchNum;

        string sql = "";

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsSure,ID) as rownum ,* from LesseeAD where Lessee like @Lessee) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsSure,ID) as rownum, * from LesseeAD where Lessee like @Lessee)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        DataSet ds = DBHelperSQL.Query(sql, parameters);
        return DataTableToList(ds.Tables[0]);

    }
}