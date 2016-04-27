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
using CEMIS.Model.Image;

/// <summary>
///FitMonitorDAO 的摘要说明
/// </summary>
public class FitMonitorDAO
{
    public int searchNum;
    public FitMonitorDAO()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 有SqlDataReader获得FitMonitor
    /// </summary>
    /// <param name="sdr"></param>
    /// <returns></returns>
    private FitMonitor GetFitMonitorBySdr(SqlDataReader sdr)
    {
        FitMonitor fitMonitor = new FitMonitor();

        fitMonitor.Id = sdr["ID"].ToString();
        fitMonitor.Lessee = sdr["Lessee"].ToString();
        fitMonitor.BuildingName = sdr["BuildingName"].ToString();
        fitMonitor.Room = sdr["Room"].ToString();
        fitMonitor.CheckTime = sdr["CheckTime"].ToString();
        fitMonitor.Detail = sdr["Detail"].ToString();
        fitMonitor.EmployeId = sdr["Employe"].ToString();
        fitMonitor.PicturePath = sdr["PicturePath"].ToString();
        fitMonitor.IsPassed = (Boolean)sdr["IsPassed"];
        fitMonitor.IsDeleted = (Boolean)sdr["IsDeleted"];
        fitMonitor.ApplyMaintain = sdr["ApplyMaintain"].ToString();
        return fitMonitor;
    }

    /// <summary>
    /// 获得数据列表
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public List<FitMonitor> DataTableToList(DataTable dt)
    {
        List<FitMonitor> modelList = new List<FitMonitor>();
        int rowsCount = dt.Rows.Count;
        if (rowsCount > 0)
        {
            FitMonitor model;
            for (int n = 0; n < rowsCount; n++)
            {
                model = new FitMonitor();

                if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    model.Id = dt.Rows[n]["ID"].ToString();
                if (dt.Rows[n]["Lessee"] != null && dt.Rows[n]["Lessee"].ToString() != "")
                    model.Lessee = dt.Rows[n]["Lessee"].ToString();               
                if (dt.Rows[n]["BuildingName"] != null && dt.Rows[n]["BuildingName"].ToString() != "")
                    model.BuildingName = dt.Rows[n]["BuildingName"].ToString();
                if (dt.Rows[n]["Room"] != null && dt.Rows[n]["Room"].ToString() != "")
                    model.Room = dt.Rows[n]["Room"].ToString();
                if (dt.Rows[n]["CheckTime"] != null && dt.Rows[n]["CheckTime"].ToString() != "")
                    model.CheckTime = dt.Rows[n]["CheckTime"].ToString();
                if (dt.Rows[n]["Detail"] != null && dt.Rows[n]["Detail"].ToString() != "")
                    model.Detail = dt.Rows[n]["Detail"].ToString();
                if (dt.Rows[n]["PicturePath"] != null && dt.Rows[n]["PicturePath"].ToString() != "")
                    model.PicturePath = dt.Rows[n]["PicturePath"].ToString();
                if (dt.Rows[n]["Employe"] != null && dt.Rows[n]["Employe"].ToString() != "")
                    model.EmployeId = dt.Rows[n]["Employe"].ToString();           
                if (dt.Rows[n]["IsPassed"] != null && dt.Rows[n]["IsPassed"].ToString() != "")
                    model.IsPassed = Boolean.Parse(dt.Rows[n]["IsPassed"].ToString());
                if (dt.Rows[n]["IsDeleted"] != null && dt.Rows[n]["IsDeleted"].ToString() != "")
                    model.IsDeleted = Boolean.Parse(dt.Rows[n]["IsDeleted"].ToString());
                if (dt.Rows[n]["ApplyMaintain"] != null && dt.Rows[n]["ApplyMaintain"].ToString() != "")
                    model.ApplyMaintain = dt.Rows[n]["ApplyMaintain"].ToString();

                modelList.Add(model);
            }
        }
        return modelList;
    }


    /// <summary>
    /// 增加一条装修监督管理记录
    /// </summary>
    /// <param name="department"></param>
    /// <returns></returns>
    public int AddFitMonitor(FitMonitor fitMonitor)
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@Lessee", SqlDbType.NVarChar),
                    new SqlParameter("@BuildingName", SqlDbType.NVarChar),
                    new SqlParameter("@Room", SqlDbType.NChar),
                    new SqlParameter("@CheckTime", SqlDbType.DateTime),
                    new SqlParameter("@Detail", SqlDbType.NText),
                    new SqlParameter("@Employe", SqlDbType.VarChar),
                    new SqlParameter("@IsPassed", SqlDbType.Bit),
                    new SqlParameter("@PicturePath", SqlDbType.NChar),
                    new SqlParameter("@IsDeleted", SqlDbType.Bit),
                    new SqlParameter("@ApplyMaintain", SqlDbType.DateTime)
                                    };
        parameters[0].Value = fitMonitor.Lessee;
        parameters[1].Value = fitMonitor.BuildingName;
        parameters[2].Value = fitMonitor.Room;
        parameters[3].Value = fitMonitor.CheckTime;
        parameters[4].Value = fitMonitor.Detail;
        parameters[5].Value = fitMonitor.EmployeId;
        parameters[6].Value = fitMonitor.IsPassed;
        parameters[7].Value = fitMonitor.PicturePath;
        parameters[8].Value = fitMonitor.IsDeleted;
        parameters[9].Value = fitMonitor.ApplyMaintain;

        string sql = "insert into DecorationCheck values(@Lessee,@BuildingName,@Room,@CheckTime,@Detail,@Employe,@IsPassed,@PicturePath,@IsDeleted,@ApplyMaintain);select @@IDENTITY";
        //    sql += "SELECT CAST(scope_identity() AS int)";
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
    /// 分页读取装修监督表数据
    /// </summary>
    /// <param name="pageno">页号</param>
    /// <param name="pagesize">页大小</param>
    /// <returns></returns>
    public List<FitMonitor> ListPageFitMonitor(int pageno, int pagesize)
    {
        int rowcount = this.GetTotalRecordNum();
        string sql;

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsPassed,ID) as rownum ,* from DecorationCheck) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsPassed,ID) as rownum, * from DecorationCheck)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

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
    public List<FitMonitor> ListPageFitMonitorByLesseeName(int pageno, int pagesize,string lesseeName)
    {
        int rowcount = this.GetRecordNumByLesseeName(lesseeName);
        string sql;
        SqlParameter[] parameters = {
                    new SqlParameter("@Lessee", SqlDbType.NVarChar)
                };
        parameters[0].Value = lesseeName;
        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsPassed,ID) as rownum ,* from DecorationCheck Where Lessee=@Lessee) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsPassed,ID) as rownum, * from DecorationCheck Where Lessee=@Lessee)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        DataSet ds = DBHelperSQL.Query(sql);
        return DataTableToList(ds.Tables[0]);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="lesseeName"></param>
    /// <returns></returns>
    public int GetRecordNumByLesseeName(string lesseeName)
    {
        return DBHelperSQL.countNum("DecorationCheck", " Lessee= " + lesseeName + "");
       
    }

    /// <summary>
    /// 读取装修监督表数据
    /// </summary>
    /// <returns></returns>
    public List<FitMonitor> ListFitMonitor()
    {
        string sql = "select * from DecorationCheck Order By IsPassed,ID";

        DataSet ds = DBHelperSQL.Query(sql);
        return DataTableToList(ds.Tables[0]);
    }

    /// <summary>
    /// 由ID获得FitMonitor记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public FitMonitor GetFitMonitorById(string id)
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int)
                };
        parameters[0].Value = int.Parse(id);
        string sql = "select * from DecorationCheck where ID=@ID ";

        DataSet ds = DBHelperSQL.Query(sql, parameters);
        List<FitMonitor> fit = DataTableToList(ds.Tables[0]);
        if (fit.Count > 0)
            return fit[0];
        else
            return null;
    }

    /// <summary>
    /// 更新FitMonitor表
    /// </summary>
    /// <param name="employe"></param>
    /// <returns></returns>
    public int UpdateFitMonitor(FitMonitor fitMonitor)
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@Lessee", SqlDbType.NVarChar),
                    new SqlParameter("@BuildingName", SqlDbType.NVarChar),
                    new SqlParameter("@Room", SqlDbType.NChar),
                    new SqlParameter("@CheckTime", SqlDbType.DateTime),
                    new SqlParameter("@Detail", SqlDbType.NText),
                    new SqlParameter("@Employe", SqlDbType.VarChar),
                    new SqlParameter("@IsPassed", SqlDbType.Bit),
                    new SqlParameter("@PicturePath", SqlDbType.NChar),
                    new SqlParameter("@IsDeleted", SqlDbType.Bit),
                    new SqlParameter("@ApplyMaintain", SqlDbType.DateTime),
                    new SqlParameter("@ID", SqlDbType.Int)
                                    };
        parameters[0].Value = fitMonitor.Lessee;
        parameters[1].Value = fitMonitor.BuildingName;
        parameters[2].Value = fitMonitor.Room;
        parameters[3].Value = fitMonitor.CheckTime;
        parameters[4].Value = fitMonitor.Detail;
        parameters[5].Value = fitMonitor.EmployeId;
        parameters[6].Value = fitMonitor.IsPassed;
        parameters[7].Value = fitMonitor.PicturePath;
        parameters[8].Value = fitMonitor.IsDeleted;
        parameters[9].Value = fitMonitor.ApplyMaintain;
        parameters[10].Value=int.Parse(fitMonitor.Id);
        
        string sql = "";
        sql = "update DecorationCheck set CheckTime=@CheckTime,Detail=@Detail,Employe=@Employe,PicturePath=@PicturePath,IsPassed=@IsPassed,ApplyMaintain=@ApplyMaintain where ID=@ID ";

        return DBHelperSQL.ExecuteSql(sql, parameters);
    }

    /// <summary>
    /// 删除FitMonitor记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeleteFitMonitor(string id)
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int)
                };
        parameters[0].Value = int.Parse(id);
        
        string sql = "delete from DecorationCheck where ID=@ID";
        return DBHelperSQL.ExecuteSql(sql, parameters);
    }

   
    /// <summary>
    ///获得DecorationCheck表记录总数
    /// </summary>
    /// <returns></returns>
    public int GetTotalRecordNum()
    {
        return DBHelperSQL.countNum("DecorationCheck");
        
    }

    
    
    /// <summary>
    /// 有关键字查询记录数
    /// </summary>
    /// <param name="keyword"></param>
    /// <returns></returns>
    private int GetSearchNum(Boolean keyword)
    {
        //获得查找总数
        DBConnection db1 = new DBConnection();
        db1.AddParameter("@IsPassed", keyword);
        string sql1 = "select count(*) as a from DecorationCheck where IsPassed = @IsPassed";
        SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
        while (sdr1.Read())
        {
            searchNum = int.Parse(sdr1["a"].ToString());
        }
        sdr1.Close();
        db1.Dispose();
        return searchNum;
    }
   

    /*
    /// <summary>
    /// 有关键字进行模糊查询，查询结果进行分页
    /// </summary>
    /// <param name="keyword"></param>
    /// <param name="pageno"></param>
    /// <param name="pagesize"></param>
    /// <returns></returns>
    public List<FitMonitor> GetFitMonitorByLessee(string keyword, int pageno, int pagesize)
    {
        List<FitMonitor> fitMonitorList = new List<FitMonitor>();
        DBConnection db = new DBConnection();
        db.AddParameter("@Lessee", "%" + keyword + "%");

        searchNum = GetSearchNum(keyword);
        int rowcount = searchNum;

        string sql = "";

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsPassed,ID) as rownum ,* from DecorationCheck where Lessee like @Lessee) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsPassed,ID) as rownum, * from DecorationCheck where Lessee like @Lessee)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        while (sdr.Read())
        {
            FitMonitor fitMonitor = GetFitMonitorBySdr(sdr);
            fitMonitorList.Add(fitMonitor);
        }
        db.Dispose();
        return fitMonitorList;
    }
    */
    
    /// <summary>
    /// 有关键字进行模糊查询，查询结果进行分页
    /// </summary>
    /// <param name="bKeyword"></param>
    /// <param name="pageno"></param>
    /// <param name="pagesize"></param>
    /// <returns></returns>
    public List<FitMonitor> GetFitMonitorByIsPassed(int bKeyword, int pageno, int pagesize)
    {
        List<FitMonitor> fitMonitorList = new List<FitMonitor>();
        DBConnection db = new DBConnection();
        Boolean b = (bKeyword == 1) ? false:true;
       
        SqlParameter[] parameters = {
                    new SqlParameter("@IsPassed", SqlDbType.Bit)
                };
        parameters[0].Value = b;
        searchNum = GetSearchNum(b);
        int rowcount = searchNum;

        string sql = "";

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsPassed,ID) as rownum ,* from DecorationCheck where IsPassed = @IsPassed) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsPassed,ID) as rownum, * from DecorationCheck where IsPassed = @IsPassed)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        DataSet ds = DBHelperSQL.Query(sql, parameters);
        return DataTableToList(ds.Tables[0]);
    }
}