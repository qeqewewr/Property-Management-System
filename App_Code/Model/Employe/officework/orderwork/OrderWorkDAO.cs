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
///OrderWorkDAO 的摘要说明
/// </summary>
public class OrderWorkDAO
{
    public int searchNum;
	public OrderWorkDAO()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    private OrderWork GetOrderWorkBySdr(SqlDataReader sdr)
    {
        OrderWork orderWork = new OrderWork();
        orderWork.Id = sdr["ID"].ToString();
        orderWork.Lessee = sdr["Lessee"].ToString();
        orderWork.BuildingName = sdr["BuildingName"].ToString();
        orderWork.Room = sdr["Room"].ToString();
        orderWork.DayStart = sdr["DayStart"].ToString();
        orderWork.DayEnd = sdr["DayEnd"].ToString();
        orderWork.TimeStart = sdr["TimeStart"].ToString();
        orderWork.TimeEnd = sdr["TimeEnd"].ToString();
        orderWork.Num = int.Parse(sdr["Room"].ToString());
        orderWork.Service = sdr["Service"].ToString();
        orderWork.Remark = sdr["Remark"].ToString();
        string temp = sdr["Fee"].ToString();
        orderWork.Fee = (temp == null) ? 0 : decimal.Parse(temp);
        orderWork.IsSure = (Boolean)sdr["IsSure"];
        return orderWork;
    }

    public int AddOrderWork(OrderWork orderWork)
    {
         DBConnection db = new DBConnection();
     
        db.AddParameter("@BuildingName", orderWork.BuildingName);
        db.AddParameter("@Room", orderWork.Room);
        db.AddParameter("@Lessee", orderWork.Lessee);
        db.AddParameter("@DayStart", orderWork.DayStart);
        db.AddParameter("@DayEnd", orderWork.DayEnd);
        db.AddParameter("@TimeStart", orderWork.TimeStart);
        db.AddParameter("@TimeEnd", orderWork.TimeEnd);
        db.AddParameter("@Num", orderWork.Num);
        db.AddParameter("@Service", orderWork.Service);
        db.AddParameter("@Remark", orderWork.Remark);
        db.AddParameter("@Fee", orderWork.Fee);
        db.AddParameter("@IsSure", orderWork.IsSure);
        string sql = "insert into OrderOvertime values(@BuildingName,@Room,@Lessee,@DayStart,@DayEnd,@TimeStart,@TimeEnd,@Num,@Service,@Remark,@Fee,@IsSure)";
        int flag = db.ExecuteNonQuery(sql);
        return flag;
    }
    /// <summary>
    /// 分页读取表数据
    /// </summary>
    /// <param name="pageno">页号</param>
    /// <param name="pagesize">页大小</param>
    /// <returns></returns>
    public List<OrderWork> ListPageOrderWork(int pageno, int pagesize)
    {
        List<OrderWork> orderWorkList = new List<OrderWork>();
        int rowcount = this.GetTotalRecordNum();
        string sql;

        DBConnection db = new DBConnection();

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsSure,TimeStart,ID) as rownum ,* from OrderOvertime) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsSure,TimeStart,ID) as rownum, * from OrderOvertime)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        while (sdr.Read())
        {
            OrderWork orderWork = GetOrderWorkBySdr(sdr);           
            orderWorkList.Add(orderWork);
        }
        db.Dispose();
        return orderWorkList;
    }

    public List<OrderWork> ListPageOrderWorkByLesseeName(int pageno, int pagesize,string lesseeName)
    {
        List<OrderWork> orderWorkList = new List<OrderWork>();
        int rowcount = this.GetRecordNumByLesseeName(lesseeName);
        string sql;

        DBConnection db = new DBConnection();
        db.AddParameter("@Lessee",lesseeName);
        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsSure,TimeStart,ID) as rownum ,* from OrderOvertime Where Lessee=@Lessee) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsSure,TimeStart,ID) as rownum, * from OrderOvertime Where Lessee=@Lessee)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        while (sdr.Read())
        {
            OrderWork orderWork = GetOrderWorkBySdr(sdr);
            orderWorkList.Add(orderWork);
        }
        db.Dispose();
        return orderWorkList;
    }

    public int GetRecordNumByLesseeName(string lesseeName)
    {
        DBConnection db = new DBConnection();
        db.AddParameter("@Lessee",lesseeName);
        string sql = "select count(*) as a from OrderOvertime where Lessee=@Lessee";

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
    public List<OrderWork> ListOrderWork()
    {
        List<OrderWork> orderWorkList = new List<OrderWork>();

        DBConnection db = new DBConnection();
        string sql = "select * from OrderOvertime";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        while (sdr.Read())
        {
            OrderWork orderWork = GetOrderWorkBySdr(sdr);
            orderWorkList.Add(orderWork);
        }
        db.Dispose();
        return orderWorkList;
    }

    /// <summary>
    /// 由ID获得OrderWork记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public OrderWork GetOrderWorkById(string id)
    {

        DBConnection db = new DBConnection();

        db.AddParameter("@ID", id);
        string sql = "select * from OrderOvertime where ID=@ID ";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        OrderWork orderWork = new OrderWork();

        if (sdr.Read())
        {
            orderWork = GetOrderWorkBySdr(sdr);
        }
        else
        {
            orderWork = null;
        }

        db.Dispose();
        return orderWork;
    }

    /// <summary>
    /// 更新OrderWork表
    /// </summary>
    /// <param name="employe"></param>
    /// <returns></returns>
    public int UpdateOrderWork(OrderWork orderWork)
    {
        DBConnection db = new DBConnection();

        int Id = int.Parse(orderWork.Id);
        db.AddParameter("@ID", Id);
        db.AddParameter("@DayStart", orderWork.DayStart);
        db.AddParameter("@DayEnd", orderWork.DayEnd);
        db.AddParameter("@TimeStart", orderWork.TimeStart);
        db.AddParameter("@TimeEnd", orderWork.TimeEnd);
        db.AddParameter("@Num", orderWork.Num);
        db.AddParameter("@Service", orderWork.Service);
        db.AddParameter("@Remark", orderWork.Remark);
        db.AddParameter("@Fee", orderWork.Fee);
        db.AddParameter("@IsSure",orderWork.IsSure);
        string sql = "";
        sql = "update OrderOverTime set DayStart=@DayStart,DayEnd = @DayEnd,TimeStart = @TimeStart,TimeEnd = @TimeEnd,Num = @Num,Service=@Service,Remark=@Remark,Fee=@Fee,IsSure=@IsSure where ID=@ID ";

        int flag = db.ExecuteNonQuery(sql);
        db.Dispose();
        return flag;
    }

    /// <summary>
    /// 删除OrderWork记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeleteOrderWorkById(string id)
    {
        DBConnection db = new DBConnection();
        int ID = int.Parse(id);
        db.AddParameter("@ID", ID);
        string sql = "delete from OrderOvertime where ID=@ID";
        int flag = db.ExecuteNonQuery(sql);
        return flag;
    }

    /// <summary>
    ///获得OrderComeIn表记录总数
    /// </summary>
    /// <returns></returns>
    public int GetTotalRecordNum()
    {

        DBConnection db = new DBConnection();
        string sql = "select count(*) as a from OrderOvertime";

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
        string sql1 = "select count(*) as a from OrderOvertime where Lessee like @Lessee";
        SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
        while (sdr1.Read())
        {
            searchNum = int.Parse(sdr1["a"].ToString());
        }

        db1.Dispose();
        return searchNum;
    }

    public List<OrderWork> GetOrderWorksByLeessee(string keyword, int pageno, int pagesize)
    {
        List<OrderWork> orderWorkList = new List<OrderWork>();
        DBConnection db = new DBConnection();
        db.AddParameter("@Lessee", "%" + keyword + "%");

        searchNum = GetSearchNum(keyword);
        int rowcount = searchNum;

        string sql = "";

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsSure,TimeStart,ID) as rownum ,* from OrderOvertime where Lessee like @Lessee) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsSure,TimeStart,ID) as rownum, * from OrderOvertime where Lessee like @Lessee)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        while (sdr.Read())
        {
            OrderWork orderWork = GetOrderWorkBySdr(sdr);

            orderWorkList.Add(orderWork);
        }
        db.Dispose();
        return orderWorkList;
    }

    /// <summary>
    /// 分页读取表数据(未审核)
    /// </summary>
    /// <param name="pageno">页号</param>
    /// <param name="pagesize">页大小</param>
    /// <returns></returns>
    public List<OrderWork> ListPageOrderWorkNot(int pageno, int pagesize)
    {
        List<OrderWork> orderWorkList = new List<OrderWork>();
        int rowcount = this.GetTotalRecordNum();
        string sql;

        DBConnection db = new DBConnection();

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by ID desc) as rownum ,* from OrderOvertime where IsSure=0) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by ID desc) as rownum, * from OrderOvertime where IsSure=0)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        while (sdr.Read())
        {
            OrderWork orderWork = GetOrderWorkBySdr(sdr);
            orderWorkList.Add(orderWork);
        }
        db.Dispose();
        return orderWorkList;
    }

    /// <summary>
    ///获得OrderWork表记录总数(未审核)
    /// </summary>
    /// <returns></returns>
    public int GetTotalRecordNumNot()
    {

        DBConnection db = new DBConnection();
        string sql = "select count(*) as a from OrderOvertime where IsSure=0";

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