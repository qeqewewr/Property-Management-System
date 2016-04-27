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
///ComplainFeedbackDAO 的摘要说明
/// </summary>
public class ComplainFeedbackDAO
{
    public int searchNum;
	public ComplainFeedbackDAO()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}



    private ComplainFeedback GetComplainFeedbackBySdr(SqlDataReader sdr)
    {
        ComplainFeedback complainFeedback = new ComplainFeedback();
        complainFeedback.Id = sdr["ID"].ToString();
        complainFeedback.Lessee = sdr["Lessee"].ToString();
        complainFeedback.BuildingName = sdr["BuildingName"].ToString();
        complainFeedback.Room = sdr["Room"].ToString();
        complainFeedback.ComplainContent = sdr["ComplainContent"].ToString();
        complainFeedback.ComplainDateTime = sdr["ComplainDateTime"].ToString();
        complainFeedback.Director = sdr["Director"].ToString();
        complainFeedback.DirectorPhone = sdr["DirectorPhone"].ToString();
        complainFeedback.PicturePath = sdr["PicturePath"].ToString();
        complainFeedback.DealDateTime = sdr["DealDateTime"].ToString();
        complainFeedback.DealContent = sdr["DealContent"].ToString();
        complainFeedback.IsDeal = int.Parse(sdr["IsDeal"].ToString());

        return complainFeedback;
    }

    public int AddComplainFeedback(ComplainFeedback complainFeedback)
    {
        DBConnection db = new DBConnection();

        db.AddParameter("@BuildingName", complainFeedback.BuildingName);
        db.AddParameter("@Room", complainFeedback.Room);
        db.AddParameter("@Lessee", complainFeedback.Lessee);
        db.AddParameter("@ComplainContent", complainFeedback.ComplainContent);
        db.AddParameter("@Director", complainFeedback.Director);
        db.AddParameter("@DirectorPhone", complainFeedback.DirectorPhone);
        db.AddParameter("@ComplainDateTime", complainFeedback.ComplainDateTime);
        db.AddParameter("@DealDateTime", complainFeedback.DealDateTime);
        db.AddParameter("@DealContent", complainFeedback.ComplainContent);
        db.AddParameter("@IsDeal", complainFeedback.IsDeal);
        db.AddParameter("@PicturePath", complainFeedback.PicturePath);

        string sql = "insert into ComplainDeal values(@BuildingName,@Room,@Lessee,@ComplainContent,@Director,@DirectorPhone,@ComplainDateTime,@DealDateTime,@DealContent,@IsDeal,@PicturePath);";
        sql += "SELECT CAST(scope_identity() AS int)";
        Object obj = db.ExecuteScalar(sql);
        db.Dispose();
        if (obj == null)
            return 0;
        else
            return Convert.ToInt32(obj);
    }

    /// <summary>
    /// 分页读取表数据
    /// </summary>
    /// <param name="pageno">页号</param>
    /// <param name="pagesize">页大小</param>
    /// <returns></returns>
    public List<ComplainFeedback> ListPageComplainFeedback(int pageno, int pagesize)
    {
        List<ComplainFeedback> complainFeedbackList = new List<ComplainFeedback>();
        int rowcount = this.GetTotalRecordNum();
        string sql;

        DBConnection db = new DBConnection();

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsDeal,ComplainDateTime,ID) as rownum ,* from ComplainDeal) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsDeal,ComplainDateTime,ID) as rownum, * from ComplainDeal)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        while (sdr.Read())
        {       
            ComplainFeedback complainFeedback = GetComplainFeedbackBySdr(sdr);
            complainFeedbackList.Add(complainFeedback);
        }
        db.Dispose();
        return complainFeedbackList;
    }

    /// <summary>
    /// 有租户名（登录名）分页读取表数据
    /// </summary>
    /// <param name="pageno"></param>
    /// <param name="pagesize"></param>
    /// <returns></returns>
    public List<ComplainFeedback> ListPageComplainFeedbackByLesseeName(int pageno, int pagesize,string lesseeName)
    {
        List<ComplainFeedback> complainFeedbackList = new List<ComplainFeedback>();
        int rowcount = this.GetRecordNumByLesseeName(lesseeName);
        string sql;

        DBConnection db = new DBConnection();
        db.AddParameter("@Lessee",lesseeName);
        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsDeal,ComplainDateTime,ID) as rownum ,* from ComplainDeal where Lessee=@Lessee) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsDeal,ComplainDateTime,ID) as rownum, * from ComplainDeal where Lessee=@Lessee)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        while (sdr.Read())
        {
            ComplainFeedback complainFeedback = GetComplainFeedbackBySdr(sdr);
            complainFeedbackList.Add(complainFeedback);
        }
        db.Dispose();
        return complainFeedbackList;
    }

    public int GetRecordNumByLesseeName(string lesseeName)
    {
        DBConnection db = new DBConnection();
        db.AddParameter("@Lessee",lesseeName);
        string sql = "select count(*) as a from ComplainDeal where Lessee=@Lessee";

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
    /// 读取表数据
    /// </summary>
    /// <returns></returns>
    public List<ComplainFeedback> ListComplainFeedback()
    {
        List<ComplainFeedback> complainFeedbackList = new List<ComplainFeedback>();

        DBConnection db = new DBConnection();
        string sql = "select * from ComplainDeal";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        while (sdr.Read())
        {
            ComplainFeedback complainFeedback = GetComplainFeedbackBySdr(sdr);
            complainFeedbackList.Add(complainFeedback);
        }
        db.Dispose();
        return complainFeedbackList;
    }

    /// <summary>
    /// 由ID获得ComplainFeedback记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ComplainFeedback GetComplainFeedbackById(string id)
    {

        DBConnection db = new DBConnection();

        int ID = int.Parse(id);
        db.AddParameter("@ID",ID);
        string sql = "select * from ComplainDeal where ID=@ID ";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        ComplainFeedback complainFeedback = new ComplainFeedback();

        if (sdr.Read())
        {
            complainFeedback = GetComplainFeedbackBySdr(sdr);
        }
        else
        {
            complainFeedback = null;
        }

        db.Dispose();
        return complainFeedback;
    }

    /// <summary>
    /// 更新ComplainFeedback表
    /// </summary>
    /// <param name="employe"></param>
    /// <returns></returns>
    public int UpdateComplainFeedback(ComplainFeedback complainFeedback)
    {
       
        DBConnection db = new DBConnection();

        int Id = int.Parse(complainFeedback.Id);
        db.AddParameter("@ID", Id);
        db.AddParameter("@ComplainContent", complainFeedback.ComplainContent);
        db.AddParameter("@Director", complainFeedback.Director);
        db.AddParameter("@DirectorPhone", complainFeedback.DirectorPhone);
        db.AddParameter("@ComplainDateTime", complainFeedback.ComplainDateTime);
        db.AddParameter("@DealDateTime", complainFeedback.DealDateTime);
        db.AddParameter("@DealContent", complainFeedback.DealContent);
        db.AddParameter("@IsDeal", complainFeedback.IsDeal);
        
        string sql = "";
        sql = "update ComplainDeal set ComplainContent=@ComplainContent,Director=@Director,DirectorPhone = @DirectorPhone,ComplainDateTime = @ComplainDateTime,DealDateTime = @DealDateTime,DealContent = @DealContent,IsDeal = @IsDeal where ID=@ID ";

        int flag = db.ExecuteNonQuery(sql);
        db.Dispose();
        return flag;
    }

    /// <summary>
    /// 删除ComplainFeedback记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeleteComplainFeedbackById(string id)
    {
        DBConnection db = new DBConnection();
        int ID = int.Parse(id);
        db.AddParameter("@ID", ID);
        string sql = "delete from ComplainDeal where ID=@ID";
        int flag = db.ExecuteNonQuery(sql);
        return flag;
    }

    /// <summary>
    ///获得ComplainDeal表记录总数
    /// </summary>
    /// <returns></returns>
    public int GetTotalRecordNum()
    {

        DBConnection db = new DBConnection();
        string sql = "select count(*) as a from ComplainDeal";

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
    /// 有关键字查询记录数
    /// </summary>
    /// <param name="keyword"></param>
    /// <returns></returns>
    private int GetSearchNum(string keyword)
    {
        //获得查找总数
        DBConnection db1 = new DBConnection();
        db1.AddParameter("@Lessee", "%" + keyword + "%");
        string sql1 = "select count(*) as a from ComplainDeal where Lessee like @Lessee";
        SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
        while (sdr1.Read())
        {
            searchNum = int.Parse(sdr1["a"].ToString());
        }

        db1.Dispose();
        return searchNum;
    }

    public List<ComplainFeedback> GetComplainFeedbacksByLeessee(string keyword, int pageno, int pagesize)
    {
        List<ComplainFeedback> complainFeedbackList = new List<ComplainFeedback>();
        DBConnection db = new DBConnection();
        db.AddParameter("@Lessee", "%" + keyword + "%");

        searchNum = GetSearchNum(keyword);
        int rowcount = searchNum;

        string sql = "";

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsDeal,ComplainDateTime,ID) as rownum ,* from ComplainDeal where Lessee like @Lessee) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsDeal,ComplainDateTime,ID) as rownum, * from ComplainDeal where Lessee like @Lessee)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        while (sdr.Read())
        {
            ComplainFeedback complainFeedback = GetComplainFeedbackBySdr(sdr);

            complainFeedbackList.Add(complainFeedback);
        }
        db.Dispose();
        return complainFeedbackList;
    }

    /// <summary>
    /// 获得ComplainDeal表记录总数(未反馈)
    /// </summary>
    /// <returns></returns>
    public int GetNotBackTotalRecordNum()
    {

        DBConnection db = new DBConnection();
        db.AddParameter("@DealDateTime", "");
        string sql = "select count(*) as a from ComplainDeal where DealDateTime=@DealDateTime ";

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
    /// 分页读取表数据(未反馈)
    /// </summary>
    /// <param name="pageno">页号</param>
    /// <param name="pagesize">页大小</param>
    /// <returns></returns>
    public List<ComplainFeedback> ListPageComplainFeedbackNot(int pageno, int pagesize)
    {
        List<ComplainFeedback> complainFeedbackList = new List<ComplainFeedback>();
        int rowcount = this.GetTotalRecordNum();
        string sql;

        DBConnection db = new DBConnection();
        db.AddParameter("@DealDateTime", "");

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by ID desc,ComplainDateTime) as rownum ,* from ComplainDeal where DealDateTime=@DealDateTime) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by ID desc,ComplainDateTime) as rownum, * from ComplainDeal where DealDateTime=@DealDateTime )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        while (sdr.Read())
        {
            ComplainFeedback complainFeedback = GetComplainFeedbackBySdr(sdr);
            complainFeedbackList.Add(complainFeedback);
        }
        db.Dispose();
        return complainFeedbackList;
    }
}