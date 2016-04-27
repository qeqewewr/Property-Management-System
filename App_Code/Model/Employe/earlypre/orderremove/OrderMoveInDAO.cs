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
///OrderMoveInDAO搬入预约DAO
/// </summary>
public class OrderMoveInDAO
{
    public int searchNum;
	public OrderMoveInDAO()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 获得数据列表
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public List<OrderMoveIn> DataTableToList(DataTable dt)
    {
        List<OrderMoveIn> modelList = new List<OrderMoveIn>();
        int rowsCount = dt.Rows.Count;
        if (rowsCount > 0)
        {
            OrderMoveIn model;
            for (int n = 0; n < rowsCount; n++)
            {
                model = new OrderMoveIn();

                if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    model.Id = dt.Rows[n]["ID"].ToString(); 
                if (dt.Rows[n]["BuildingName"] != null && dt.Rows[n]["BuildingName"].ToString() != "")
                    model.BuildingName = dt.Rows[n]["BuildingName"].ToString();
                if (dt.Rows[n]["Room"] != null && dt.Rows[n]["Room"].ToString() != "")
                    model.Room = dt.Rows[n]["Room"].ToString();
                if (dt.Rows[n]["Lessee"] != null && dt.Rows[n]["Lessee"].ToString() != "")
                    model.Lessee = dt.Rows[n]["Lessee"].ToString();   
                if (dt.Rows[n]["DateTime"] != null && dt.Rows[n]["DateTime"].ToString() != "")
                    model.DateTime = dt.Rows[n]["DateTime"].ToString();
                if (dt.Rows[n]["Director"] != null && dt.Rows[n]["Director"].ToString() != "")
                    model.Director = dt.Rows[n]["Director"].ToString();
                if (dt.Rows[n]["DirectorPhone"] != null && dt.Rows[n]["DirectorPhone"].ToString() != "")
                    model.DirectorPhone = dt.Rows[n]["DirectorPhone"].ToString();
                if (dt.Rows[n]["GoodsNum"] != null && dt.Rows[n]["GoodsNum"].ToString() != "")
                    model.GoodsNum = int.Parse(dt.Rows[n]["GoodsNum"].ToString()); 
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
    /// 
    /// </summary>
    /// <param name="sdr"></param>
    /// <returns></returns>
    private OrderMoveIn GetOrderMoveInBySdr(SqlDataReader sdr)
    {
        OrderMoveIn orderMoveIn = new OrderMoveIn();

        orderMoveIn.Id = sdr["ID"].ToString();
        orderMoveIn.BuildingName = sdr["BuildingName"].ToString();
        orderMoveIn.Room = sdr["Room"].ToString();
        orderMoveIn.Lessee = sdr["Lessee"].ToString();
        orderMoveIn.DateTime = sdr["DateTime"].ToString();
        orderMoveIn.Director = sdr["Director"].ToString();
        orderMoveIn.DirectorPhone = sdr["DirectorPhone"].ToString();
        orderMoveIn.GoodsNum = int.Parse(sdr["GoodsNum"].ToString());
        orderMoveIn.IsSure = (Boolean)sdr["IsSure"];
        orderMoveIn.Remarks = sdr["Remarks"].ToString();
        return orderMoveIn;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderMoveIn"></param>
    /// <returns></returns>
    public int AddOrderMoveIn(OrderMoveIn orderMoveIn) 
    {

        SqlParameter[] parameters = {
                    new SqlParameter("@Lessee", SqlDbType.NVarChar),
                    new SqlParameter("@BuildingName", SqlDbType.NVarChar),
                    new SqlParameter("@Room", SqlDbType.NChar),
                    new SqlParameter("@DateTime", SqlDbType.DateTime),
                    new SqlParameter("@Director", SqlDbType.NChar),
                    new SqlParameter("@DirectorPhone", SqlDbType.NChar),
                    new SqlParameter("@GoodsNum", SqlDbType.Int),
                    new SqlParameter("@ISure", SqlDbType.Bit),
                    new SqlParameter("@Remark", SqlDbType.NVarChar)
                                    };
        parameters[0].Value =orderMoveIn.Lessee;
        parameters[1].Value = orderMoveIn.BuildingName;
        parameters[2].Value = orderMoveIn.Room;
        parameters[3].Value = orderMoveIn.DateTime;
        parameters[4].Value = orderMoveIn.Director;
        parameters[5].Value = orderMoveIn.DirectorPhone;
        parameters[6].Value = orderMoveIn.GoodsNum;
        parameters[7].Value = orderMoveIn.IsSure;
        parameters[8].Value = orderMoveIn.Remarks;
   
        string sql = "insert into OrderComeIn values(@BuildingName,@Room,@Lessee,@Director,@DirectorPhone,@DateTime,@GoodsNum,@IsSure,@Remarks)";
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
    /// 分页读取搬入预约表数据
    /// </summary>
    /// <param name="pageno">页号</param>
    /// <param name="pagesize">页大小</param>
    /// <returns></returns>
    public List<OrderMoveIn> ListPageOrderMoveIn(int pageno, int pagesize)
    {
        int rowcount = this.GetTotalRecordNum();
        string sql;
        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsSure,DateTime) as rownum ,* from OrderComeIn) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsSure,DateTime) as rownum, * from OrderComeIn)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        DataSet ds = DBHelperSQL.Query(sql);
        return DataTableToList(ds.Tables[0]);
    }

    /// <summary>
    /// 分页读取搬入预约表数据(未确认)
    /// </summary>
    /// <param name="pageno">页号</param>
    /// <param name="pagesize">页大小</param>
    /// <returns></returns>
    public List<OrderMoveIn> ListPageOrderMoveInNotSure(int pageno, int pagesize)
    {
        int rowcount = this.GetTotalRecordNum();
        string sql;

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by DateTime) as rownum ,* from OrderComeIn where IsSure=0) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by DateTime) as rownum, * from OrderComeIn where IsSure=0)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        DataSet ds = DBHelperSQL.Query(sql);
        return DataTableToList(ds.Tables[0]);
    }

    /// <summary>
    ///获得OrderComeIn表记录总数(未确认)
    /// </summary>
    /// <returns></returns>
    public int GetNotSureRecordNum()
    {
        return DBHelperSQL.countNum("OrderComeIn", " IsSure=0");
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="pageno"></param>
    /// <param name="pagesize"></param>
    /// <param name="lesseeName"></param>
    /// <returns></returns>
    public List<OrderMoveIn> ListPageOrderMoveInByLesseeName(int pageno, int pagesize,string lesseeName)
    {
        int rowcount = this.GetRecordNumByLesseeName(lesseeName);
        string sql;

        SqlParameter[] parameters = {
                    new SqlParameter("@Lessee", SqlDbType.NVarChar)
                };
        parameters[0].Value = lesseeName;
        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsSure,DateTime) as rownum ,* from OrderComeIn Where Lessee=@Lessee) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsSure,DateTime) as rownum, * from OrderComeIn Where Lessee=@Lessee)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

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
        return DBHelperSQL.countNum("OrderComeIn", " Lessee="+lesseeName+"");
       
    }

    /// <summary>
    /// 读取搬入预约表数据
    /// </summary>
    /// <returns></returns>
    public List<OrderMoveIn> ListOrderMoveIn()
    {
        string sql = "select * from OrderComeIn";

        DataSet ds = DBHelperSQL.Query(sql);
        return DataTableToList(ds.Tables[0]);
    }


    public List<DateTime> GetDateTimeList()
    {
        List<DateTime> list = new List<DateTime>();
        DBConnection db = new DBConnection();
        string sql = "select DateTime from OrderComeIn";
        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        while (sdr.Read())
        {
            list.Add((DateTime)sdr["DateTime"]);
        }
        sdr.Close();
        db.Dispose();
        return list;

    }

    /// <summary>
    /// 由ID获得OrderMoveIn记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public OrderMoveIn GetOrderMoveInById(string id)
    {

        SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int)
                };
        parameters[0].Value =int.Parse(id);       
        string sql = "select * from OrderComeIn where ID=@ID ";
        DataSet ds = DBHelperSQL.Query(sql, parameters);
        List<OrderMoveIn>orderMoveIn= DataTableToList(ds.Tables[0]);
        if (orderMoveIn.Count > 0)
            return orderMoveIn[0];
        else
            return null;
    }

    /// <summary>
    /// 更新OrderMoveIn表
    /// </summary>
    /// <param name="employe"></param>
    /// <returns></returns>
    public int UpdateOrderMoveIn(OrderMoveIn orderMoveIn)
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@Lessee", SqlDbType.NVarChar),
                    new SqlParameter("@BuildingName", SqlDbType.NVarChar),
                    new SqlParameter("@Room", SqlDbType.NChar),
                    new SqlParameter("@DateTime", SqlDbType.DateTime),
                    new SqlParameter("@Director", SqlDbType.NChar),
                    new SqlParameter("@DirectorPhone", SqlDbType.NChar),
                    new SqlParameter("@GoodsNum", SqlDbType.Int),
                    new SqlParameter("@ISure", SqlDbType.Bit),
                    new SqlParameter("@Remark", SqlDbType.NVarChar),
                    new SqlParameter("@ID", SqlDbType.Int)
                                    };
        parameters[0].Value = orderMoveIn.Lessee;
        parameters[1].Value = orderMoveIn.BuildingName;
        parameters[2].Value = orderMoveIn.Room;
        parameters[3].Value = orderMoveIn.DateTime;
        parameters[4].Value = orderMoveIn.Director;
        parameters[5].Value = orderMoveIn.DirectorPhone;
        parameters[6].Value = orderMoveIn.GoodsNum;
        parameters[7].Value = orderMoveIn.IsSure;
        parameters[8].Value = orderMoveIn.Remarks;
        parameters[9].Value=int.Parse(orderMoveIn.Id);

      
        string sql = "";
        sql = "update OrderComeIn set Director=@Director,DirectorPhone = @DirectorPhone,DateTime = @DateTime,GoodsNum = @GoodsNum,IsSure = @IsSure,Remarks=@Remarks where ID=@ID ";

        return DBHelperSQL.ExecuteSql(sql,parameters);
    }

    /// <summary>
    /// 删除OrderMoveIn记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeleteOrderMoveInById(string id)
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int)
                };
        parameters[0].Value = int.Parse(id);   
      
        string sql = "delete from OrderComeIn where ID=@ID";
        return DBHelperSQL.ExecuteSql(sql, parameters);
    }

    /// <summary>
    ///获得OrderComeIn表记录总数
    /// </summary>
    /// <returns></returns>
    public int GetTotalRecordNum()
    {
        return DBHelperSQL.countNum("OrderComeIn");
        
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="keyword"></param>
    /// <returns></returns>
    public List<OrderMoveIn> GetOrderMoveInListByLesseeName(string keyword)
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@Lessee", SqlDbType.NVarChar)
                };
        parameters[0].Value = "%" + keyword + "%";          
        string sql = "select * from OrderComeIn where Lessee like @Lessee order by ID ";
        DataSet ds = DBHelperSQL.Query(sql, parameters);
        return DataTableToList(ds.Tables[0]);
    }

    /// <summary>
    /// 有关键字查询记录数
    /// </summary>
    /// <param name="keyword"></param>
    /// <returns></returns>
    private int GetSearchNum(string keyword)
    {
        return DBHelperSQL.countNum("OrderComeIn", "%" + keyword + "%");

    }
    /// <summary>
    /// 有关键字进行模糊查询，查询结果进行分页
    /// </summary>
    /// <param name="keyword"></param>
    /// <param name="pageno"></param>
    /// <param name="pagesize"></param>
    /// <returns></returns>
    public List<OrderMoveIn> GetOrderMoveInByLessee(string keyword, int pageno, int pagesize)
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@Lessee", SqlDbType.NVarChar)
                };
        parameters[0].Value = "%" + keyword + "%";   
     
        searchNum = GetSearchNum(keyword);
        int rowcount = searchNum;

        string sql = "";

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsSure,DateTime) as rownum ,* from OrderComeIn where Lessee like @Lessee) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsSure,DateTime) as rownum, * from OrderComeIn where Lessee like @Lessee)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        DataSet ds = DBHelperSQL.Query(sql, parameters);
        return DataTableToList(ds.Tables[0]);
    }


}