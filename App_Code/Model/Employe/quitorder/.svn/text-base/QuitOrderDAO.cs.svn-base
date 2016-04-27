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
///QuitOrderDAO 的摘要说明
/// </summary>
public class QuitOrderDAO
{
    public int searchNum;
	public QuitOrderDAO()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sdr"></param>
    /// <returns></returns>
    private QuitOrder GetQuitOrderBySdr(SqlDataReader sdr)
    {
        QuitOrder quitOrder = new QuitOrder();

        quitOrder.Id = sdr["ID"].ToString();
        quitOrder.BuildingName = sdr["BuildingName"].ToString();
        quitOrder.Room = sdr["Room"].ToString();
        quitOrder.Lessee = sdr["Lessee"].ToString();
        quitOrder.DateTime = sdr["DateTime"].ToString();
        quitOrder.Director = sdr["Director"].ToString();
        quitOrder.DirectorPhone = sdr["DirectorPhone"].ToString();
        quitOrder.GoodsNum = int.Parse(sdr["GoodsNum"].ToString());
        quitOrder.IsSure = (Boolean)sdr["IsSure"];
        quitOrder.Remarks = sdr["Remarks"].ToString();
        return quitOrder;
    }

    public int AddQuitOrder(QuitOrder quitOrder)
    {
        DBConnection db = new DBConnection();

        db.AddParameter("@Lessee", quitOrder.Lessee);
        db.AddParameter("@BuildingName", quitOrder.BuildingName);
        db.AddParameter("@Room", quitOrder.Room);
        db.AddParameter("@DateTime", quitOrder.DateTime);
        //     db.AddParameter("@Time", 0);//--------------------test
        db.AddParameter("@Director", quitOrder.Director);
        db.AddParameter("@DirectorPhone", quitOrder.DirectorPhone);
        db.AddParameter("@GoodsNum", quitOrder.GoodsNum);
        db.AddParameter("@IsSure", quitOrder.IsSure);
        db.AddParameter("@Remarks", quitOrder.Remarks);

        string sql = "insert into OrderComeOut values(@BuildingName,@Room,@Lessee,@Director,@DirectorPhone,@DateTime,@GoodsNum,@IsSure,@Remarks)";
        int flag = db.ExecuteNonQuery(sql);
        db.Dispose();

        return flag;
    }

    /// <summary>
    /// 分页读取搬入预约表数据
    /// </summary>
    /// <param name="pageno">页号</param>
    /// <param name="pagesize">页大小</param>
    /// <returns></returns>
    public List<QuitOrder> ListPageQuitOrder(int pageno, int pagesize)
    {
        List<QuitOrder> quitOrderList = new List<QuitOrder>();
        int rowcount = this.GetTotalRecordNum();
        string sql;

        DBConnection db = new DBConnection();

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsSure,DateTime) as rownum ,* from OrderComeOut) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsSure,DateTime) as rownum, * from OrderComeOut)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        while (sdr.Read())
        {
            QuitOrder quitOrder = GetQuitOrderBySdr(sdr);
            quitOrderList.Add(quitOrder);
        }
        db.Dispose();
        return quitOrderList;
    }

    public List<QuitOrder> ListPageQuitOrderByLesseeName(int pageno, int pagesize,string lesseeName)
    {
        List<QuitOrder> quitOrderList = new List<QuitOrder>();
        int rowcount = this.GetRecordNumByLesseeName(lesseeName);
        string sql;

        DBConnection db = new DBConnection();
        db.AddParameter("@Lessee", lesseeName);
        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsSure,DateTime) as rownum ,* from OrderComeOut Where Lessee=@Lessee) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsSure,DateTime) as rownum, * from OrderComeOut Where Lessee=@Lessee)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        while (sdr.Read())
        {
            QuitOrder quitOrder = GetQuitOrderBySdr(sdr);
            quitOrderList.Add(quitOrder);
        }
        db.Dispose();
        return quitOrderList;
    }

    public int GetRecordNumByLesseeName(string lesseeName)
    {
        DBConnection db = new DBConnection();
        db.AddParameter("@Lessee",lesseeName);
        string sql = "select count(*) as a from OrderComeOut Where Lessee=@Lessee";

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
    /// 读取搬入预约表数据
    /// </summary>
    /// <returns></returns>
    public List<QuitOrder> ListQuitOrder()
    {
        List<QuitOrder> quitOrderList = new List<QuitOrder>();

        DBConnection db = new DBConnection();
        string sql = "select * from OrderComeOut";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        while (sdr.Read())
        {
            QuitOrder quitOrder = GetQuitOrderBySdr(sdr);
            quitOrderList.Add(quitOrder);
        }
        db.Dispose();
        return quitOrderList;
    }

    /// <summary>
    /// 由ID获得quitOrder记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public QuitOrder GetQuitOrderById(string id)
    {

        DBConnection db = new DBConnection();
        int ID = int.Parse(id);
        db.AddParameter("@ID", ID);
        string sql = "select * from OrderComeOut where ID=@ID ";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        QuitOrder quitOrder = new QuitOrder();

        if (sdr.Read())
        {
            quitOrder = GetQuitOrderBySdr(sdr);
        }
        else
        {
            quitOrder = null;
        }

        db.Dispose();
        return quitOrder;
    }

    /// <summary>
    /// 更新quitOrder表
    /// </summary>
    /// <param name="employe"></param>
    /// <returns></returns>
    public int UpdateQuitOrder(QuitOrder quitOrder)
    {
        DBConnection db = new DBConnection();

        int Id = int.Parse(quitOrder.Id);
        db.AddParameter("@ID", Id);
        db.AddParameter("@Director", quitOrder.Director);
        db.AddParameter("@DirectorPhone", quitOrder.DirectorPhone);
        db.AddParameter("@DateTime", quitOrder.DateTime);
        db.AddParameter("@GoodsNum", quitOrder.GoodsNum);
        db.AddParameter("@IsSure", quitOrder.IsSure);
        db.AddParameter("@Remarks", quitOrder.Remarks);

        string sql = "";
        sql = "update OrderComeOut set Director=@Director,DirectorPhone = @DirectorPhone,DateTime = @DateTime,GoodsNum = @GoodsNum,IsSure = @IsSure,Remarks=@Remarks where ID=@ID ";

        int flag = db.ExecuteNonQuery(sql);
        db.Dispose();
        return flag;
    }

    /// <summary>
    /// 删除quitOrder记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeleteQuitOrderById(string id)
    {
        DBConnection db = new DBConnection();

        int ID = int.Parse(id);
        db.AddParameter("@ID", ID);
        string sql = "delete from OrderComeOut where ID=@ID";
        int flag = db.ExecuteNonQuery(sql);
        return flag;
    }

    /// <summary>
    ///获得OrderComeOut表记录总数
    /// </summary>
    /// <returns></returns>
    public int GetTotalRecordNum()
    {

        DBConnection db = new DBConnection();
        string sql = "select count(*) as a from OrderComeOut";

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
        string sql1 = "select count(*) as a from OrderComeOut where Lessee like @Lessee";
        SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
        while (sdr1.Read())
        {
            searchNum = int.Parse(sdr1["a"].ToString());
        }

        db1.Dispose();
        return searchNum;
    }
    /// <summary>
    /// 有关键字进行模糊查询，查询结果进行分页
    /// </summary>
    /// <param name="keyword"></param>
    /// <param name="pageno"></param>
    /// <param name="pagesize"></param>
    /// <returns></returns>
    public List<QuitOrder> GetQuitOrderByLessee(string keyword, int pageno, int pagesize)
    {
        List<QuitOrder> QuitOrderList = new List<QuitOrder>();
        DBConnection db = new DBConnection();
        db.AddParameter("@Lessee", "%" + keyword + "%");

        searchNum = GetSearchNum(keyword);
        int rowcount = searchNum;

        string sql = "";

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsSure,DateTime) as rownum ,* from OrderComeOut where Lessee like @Lessee) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsSure,DateTime) as rownum, * from OrderComeOut where Lessee like @Lessee)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        while (sdr.Read())
        {
            QuitOrder QuitOrder = GetQuitOrderBySdr(sdr);

            QuitOrderList.Add(QuitOrder);
        }
        db.Dispose();
        return QuitOrderList;
    }

    /// <summary>
    /// 分页读取搬入预约表数据(未审核)
    /// </summary>
    /// <param name="pageno">页号</param>
    /// <param name="pagesize">页大小</param>
    /// <returns></returns>
    public List<QuitOrder> ListPageQuitOrderNot(int pageno, int pagesize)
    {
        List<QuitOrder> quitOrderList = new List<QuitOrder>();
        int rowcount = this.GetTotalRecordNum();
        string sql;

        DBConnection db = new DBConnection();

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by DateTime) as rownum ,* from OrderComeOut where IsSure=0) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by DateTime) as rownum, * from OrderComeOut where IsSure=0)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        while (sdr.Read())
        {
            QuitOrder quitOrder = GetQuitOrderBySdr(sdr);
            quitOrderList.Add(quitOrder);
        }
        db.Dispose();
        return quitOrderList;
    }

    /// <summary>
    ///获得OrderComeOut表记录总数(未审核)
    /// </summary>
    /// <returns></returns>
    public int GetTotalRecordNumNot()
    {

        DBConnection db = new DBConnection();
        string sql = "select count(*) as a from OrderComeOut where IsSure=0";

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