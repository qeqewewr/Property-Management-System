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
///TenementCostDAO 的摘要说明
/// </summary>
public class TenementCostDAO
{
    public int searchNum;
	public TenementCostDAO()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    private TenementCost GetTenementCostBySdr(SqlDataReader sdr)
    {
        TenementCost tenementCost = new TenementCost();
        tenementCost.Id = sdr["ID"].ToString();
        tenementCost.BuildingName = sdr["BuildingName"].ToString();
        tenementCost.Room = sdr["Room"].ToString();
        tenementCost.Lessee = sdr["Lessee"].ToString();
        tenementCost.Fee = decimal.Parse(sdr["Fee"].ToString());
        tenementCost.FeeType = sdr["FeeType"].ToString();
        tenementCost.StartDate = sdr["StartDate"].ToString();
        tenementCost.InputEmployId = sdr["InputEmploye"].ToString();
        tenementCost.InputDateTime = sdr["InputDateTime"].ToString();
        tenementCost.Deadline = sdr["Deadline"].ToString();
        tenementCost.IsPayed = (Boolean)sdr["IsPayed"];

        return tenementCost;
    }

    /// <summary>
    /// 增加一条租户费用记录
    /// </summary>
    /// <param name="tenementCost">租户费用对象</param>
    /// <returns></returns>
    public int AddTenementCost(TenementCost tenementCost)
    {
        DBConnection db = new DBConnection();

        db.AddParameter("@Lessee", tenementCost.Lessee);
        db.AddParameter("@Fee", tenementCost.Fee);
        db.AddParameter("@FeeType", tenementCost.FeeType);
        db.AddParameter("@StartDate", tenementCost.StartDate);
        db.AddParameter("@InputEmploye", tenementCost.InputEmployId);
        db.AddParameter("@InputDatetime", tenementCost.InputDateTime);
        db.AddParameter("@Deadline", tenementCost.Deadline);
        db.AddParameter("@IsPayed", tenementCost.IsPayed);
        db.AddParameter("@BuildingName", tenementCost.BuildingName);
        db.AddParameter("@Room", tenementCost.Room);

        string sql = "insert into Fee values(@Lessee,@Fee,@FeeType,@StartDate,@InputEmploye,@InputDatetime,@Deadline,@IsPayed,@BuildingName,@Room)";
        int flag = db.ExecuteNonQuery(sql);
        db.Dispose();

        return flag;
    }

    /// <summary>
    /// 分页读取表数据
    /// </summary>
    /// <param name="pageno">页号</param>
    /// <param name="pagesize">页大小</param>
    /// <returns></returns>
    public List<TenementCost> ListPageTenementCost(int pageno, int pagesize)
    {
        List<TenementCost> tenementCostList = new List<TenementCost>();
        int rowcount = this.GetTotalRecordNum();
        string sql;

        DBConnection db = new DBConnection();

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsPayed,ID) as rownum ,* from Fee) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsPayed,ID) as rownum, * from Fee)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        while (sdr.Read())
        {
            TenementCost tenementCost = GetTenementCostBySdr(sdr);
            tenementCostList.Add(tenementCost);
        }
        db.Dispose();
        return tenementCostList;
    }

    public List<TenementCost> ListPageTenementCostByLesseeName(int pageno, int pagesize,string lesseeName)
    {
        List<TenementCost> tenementCostList = new List<TenementCost>();
        int rowcount = this.GetRecordNumByLesseeName(lesseeName);
        string sql;

        DBConnection db = new DBConnection();
        db.AddParameter("@Lessee", lesseeName);
        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsPayed,StartDate,ID) as rownum ,* from Fee Where Lessee=@Lessee) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsPayed,StartDate,ID) as rownum, * from Fee Where Lessee=@Lessee)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        while (sdr.Read())
        {
            TenementCost tenementCost = GetTenementCostBySdr(sdr);
            tenementCostList.Add(tenementCost);
        }
        db.Dispose();
        return tenementCostList;
    }

    public int GetRecordNumByLesseeName(string lesseeName)
    {

        DBConnection db = new DBConnection();
        db.AddParameter("@Lessee",lesseeName);

        string sql = "select count(*) as a from Fee Where Lessee=@Lessee";
        int count = 0;
        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        while (sdr.Read())
        {
            count = int.Parse(sdr["a"].ToString());
        }

        db.Dispose();
        return count;
    }

    /// <summary>
    /// 由ID获得tenementCost记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public TenementCost GetTenementCostById(string id)
    {

        DBConnection db = new DBConnection();

        db.AddParameter("@ID", id);
        string sql = "select * from Fee where ID=@ID ";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        TenementCost tenementCost = new TenementCost();

        if (sdr.Read())
        {
            tenementCost = GetTenementCostBySdr(sdr);
        }
        else
        {
            tenementCost = null;
        }

        db.Dispose();
        return tenementCost;
    }

    /// <summary>
    /// 更新tenementCost表
    /// </summary>
    /// <param name="tenementCost">租户费用对象</param>
    /// <returns></returns>
    public int UpdateTenementCost(TenementCost tenementCost)
    {
        DBConnection db = new DBConnection();

        int Id = int.Parse(tenementCost.Id);
        db.AddParameter("@ID", Id);
        db.AddParameter("@FeeType", tenementCost.FeeType);
        db.AddParameter("@Fee",tenementCost.Fee);
        db.AddParameter("@InputDateTime",tenementCost.InputDateTime);
        db.AddParameter("@InputEmploye",tenementCost.InputEmployId);
        db.AddParameter("@Deadline",tenementCost.Deadline);
        db.AddParameter("@StartDate",tenementCost.StartDate);
        db.AddParameter("@IsPayed",tenementCost.IsPayed);
       
        string sql = "";
        sql = "update Fee set FeeType=@FeeType,Fee = @Fee,InputDateTime = @InputDateTime,InputEmploye = @InputEmploye,Deadline = @Deadline,StartDate=@StartDate,IsPayed=@IsPayed where ID=@ID ";

        int flag = db.ExecuteNonQuery(sql);
        db.Dispose();
        return flag;
    }


    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeleteTenementCostById(string id)
    {
        DBConnection db = new DBConnection();
        int ID = int.Parse(id);
        db.AddParameter("@ID", ID);
        string sql = "delete from Fee where ID=@ID";
        int flag = db.ExecuteNonQuery(sql);
        db.Dispose();
        return flag;
    }

    /// <summary>
    /// 有费用名删除租户费用
    /// </summary>
    /// <param name="feeName"></param>
    /// <returns></returns>
    public int DeleteTenementCostByFeeName(string feeName)
    {
        DBConnection db = new DBConnection();
        
        db.AddParameter("@FeeType", feeName);
        string sql = "delete from Fee where FeeType=@FeeType";
        int flag = db.ExecuteNonQuery(sql);
        db.Dispose();
        return flag;
    }

    /// <summary>
    ///获得表记录总数
    /// </summary>
    /// <returns></returns>
    public int GetTotalRecordNum()
    {

        DBConnection db = new DBConnection();
        string sql = "select count(*) as a from Fee";

        int count = 0;
        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        while (sdr.Read())
        {
            count = int.Parse(sdr["a"].ToString());
        }

        db.Dispose();
        return count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="keyword">租户</param>
    /// <param name="feeMonth">费用月份</param>
    /// <param name="flag"> 0:无租户无费用月份;1:有租户无费用月份;2:无租户有费用月份3:有租户有费用月份</param>
    /// <returns></returns>
    public List<TenementCost> GetTenementCostsByLesseeAndStartDate(string keyword, string feeMonth, int pageno, int pagesize, int flag)
    {
        List<TenementCost> list = new List<TenementCost>();
        string sql = "";
        int rowcount = 0;
        DBConnection db = new DBConnection();

        string lessee = "%" + keyword + "%";
      //  feeMonth = "%" + feeMonth + "%";
        db.AddParameter("@Lessee", lessee);
        db.AddParameter("@StartDate", feeMonth);

        if (flag == 1)
        {
            //记录查询的总数
            DBConnection db1 = new DBConnection();
            db1.AddParameter("@Lessee", lessee);
            string sql1 = "select count(*) as a from Fee where Lessee like @Lessee";

            SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
            while (sdr1.Read())
            {
                searchNum = int.Parse(sdr1["a"].ToString());
            }
            db1.Dispose();


            rowcount = searchNum;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by IsPayed,StartDate,ID) as rownum ,* from Fee where Lessee like @Lessee ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by IsPayed,StartDate,ID) as rownum, * from Fee where Lessee like @Lessee )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
        }
        else if (flag == 2)
        {
            //记录查询的总数
            DBConnection db1 = new DBConnection();

            db1.AddParameter("@StartDate", feeMonth);
            string sql1 = "select count(*) as a from Fee where StartDate >= @StartDate";

            SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
            while (sdr1.Read())
            {
                searchNum = int.Parse(sdr1["a"].ToString());
            }
            db1.Dispose();
            rowcount = searchNum;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by IsPayed,StartDate,ID) as rownum ,* from Fee where StartDate >= @StartDate ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by IsPayed,StartDate,ID) as rownum, * from Fee where StartDate >= @StartDate )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
        }
        else if (flag == 3)
        {

            //记录查询的总数
            DBConnection db1 = new DBConnection();
            db1.AddParameter("@Lessee", lessee);
            db1.AddParameter("@StartDate", feeMonth);
            string sql1 = "select count(*) as a from Fee where Lessee like @Lessee And StartDate >= @StartDate";

            SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
            while (sdr1.Read())
            {
                searchNum = int.Parse(sdr1["a"].ToString());
            }
            db1.Dispose();


            rowcount = searchNum;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by IsPayed,StartDate,ID) as rownum ,* from Fee where Lessee like @Lessee And StartDate >= @StartDate ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by IsPayed,StartDate,ID) as rownum, * from Fee where Lessee like @Lessee And StartDate >= @StartDate )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
        }

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        while (sdr.Read())
        {
            TenementCost tenementCost = GetTenementCostBySdr(sdr);
            list.Add(tenementCost);
        }
        db.Dispose();
        return list;

    }

}