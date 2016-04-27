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
///RepairTableDAO 的摘要说明
/// </summary>
public class RepairTableDAO
{
    public int searchNum;
	public RepairTableDAO()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    private RepairTable GetRepairTableBySdr(SqlDataReader sdr)
    {
        RepairTable repairTable = new RepairTable();
        repairTable.Id = sdr["ID"].ToString();
        repairTable.BuildingName = sdr["BuildingName"].ToString();
        repairTable.Room = sdr["Room"].ToString();
        repairTable.Lessee = sdr["Lessee"].ToString();
        repairTable.DateTime = sdr["DateTime"].ToString();
        repairTable.Director = sdr["Director"].ToString();
        repairTable.DirectorPhone = sdr["DirectorPhone"].ToString();
        repairTable.RepairContent = sdr["MaintainContent"].ToString();
        repairTable.Remarks = sdr["Remarks"].ToString();
        repairTable.Fee = decimal.Parse(sdr["Fee"].ToString());
        repairTable.IsFinish = int.Parse(sdr["IsFinish"].ToString());

        return repairTable;
    }

    public int AddRepairTable(RepairTable repairTable)
    {
        DBConnection db = new DBConnection();

        db.AddParameter("@BuildingName", repairTable.BuildingName);
        db.AddParameter("@Room", repairTable.Room);
        db.AddParameter("@Lessee", repairTable.Lessee);
        db.AddParameter("@MaintainContent", repairTable.RepairContent); 
        db.AddParameter("@Director", repairTable.Director);
        db.AddParameter("@DirectorPhone", repairTable.DirectorPhone);
        db.AddParameter("@DateTime", repairTable.DateTime);
        db.AddParameter("@Fee", repairTable.Fee);
        db.AddParameter("@IsFinish", repairTable.IsFinish);
        db.AddParameter("@Remarks", repairTable.Remarks);

        string sql = "insert into Maintain values(@BuildingName,@Room,@Lessee,@MaintainContent,@Director,@DirectorPhone,@DateTime,@Fee,@IsFinish,@Remarks);";
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
    public List<RepairTable> ListPageRepairTable(int pageno, int pagesize)
    {
        List<RepairTable> repairTableList = new List<RepairTable>();
        int rowcount = this.GetTotalRecordNum();
        string sql;

        DBConnection db = new DBConnection();

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsFinish,DateTime,ID) as rownum ,* from Maintain) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsFinish,DateTime,ID) as rownum, * from Maintain)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        while (sdr.Read())
        {
            RepairTable repairTable = GetRepairTableBySdr(sdr);
            repairTableList.Add(repairTable);
        }
        db.Dispose();
        return repairTableList;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pageno"></param>
    /// <param name="pagesize"></param>
    /// <param name="lesseeName"></param>
    /// <returns></returns>
    public List<RepairTable> ListPageRepairTableByLesseeName(int pageno, int pagesize,string lesseeName)
    {
        List<RepairTable> repairTableList = new List<RepairTable>();
        int rowcount = this.GetRecordNumByLesseeName(lesseeName);
        string sql;

        DBConnection db = new DBConnection();
        db.AddParameter("@Lessee",lesseeName);
        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsFinish,DateTime,ID) as rownum ,* from Maintain Where Lessee=@Lessee) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsFinish,DateTime,ID) as rownum, * from Maintain Where Lessee=@Lessee)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        while (sdr.Read())
        {
            RepairTable repairTable = GetRepairTableBySdr(sdr);
            repairTableList.Add(repairTable);
        }
        db.Dispose();
        return repairTableList;
    }

    public int GetRecordNumByLesseeName(string lesseeName)
    {
        DBConnection db = new DBConnection();
        db.AddParameter("@Lessee",lesseeName);
        string sql = "select count(*) as a from Maintain Where Lessee=@Lessee";

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
    public List<RepairTable> ListRepairTable()
    {
        List<RepairTable> repairTableList = new List<RepairTable>();

        DBConnection db = new DBConnection();
        string sql = "select * from Maintain";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        while (sdr.Read())
        {
            RepairTable repairTable = GetRepairTableBySdr(sdr);
            repairTableList.Add(repairTable);
        }
        db.Dispose();
        return repairTableList;
    }


    /*
    /// <summary>
    /// 由楼宇号进行模糊查询
    /// </summary>
    /// <param name="keyWord">查询的关键字</param>
    /// <returns></returns>
    public List<RepairTable> ListRepairTableByCondition(string keyword)
    {
        DBConnection db = new DBConnection();

        string searchName = "%" + keyword + "%";
        db.AddParameter("@BuildingName", searchName);
        string sql = "select * from Maintain where BuildingName like @BuildingName order by ID ";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        List<RepairTable> repairTableList = new List<RepairTable>();

        while (sdr.Read())
        {
            RepairTable repairTable = GetRepairTableBySdr(sdr);
            repairTableList.Add(repairTable);
        }

        db.Dispose();
        return repairTableList;
    }
    */
    
    /// <summary>
    /// 由ID获得RepairTable记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public RepairTable GetRepairTableById(string id)
    {

        DBConnection db = new DBConnection();

        int ID = int.Parse(id);
        db.AddParameter("@ID", ID);
        string sql = "select * from Maintain where ID=@ID ";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        RepairTable repairTable = new RepairTable();

        if (sdr.Read())
        {
            repairTable = GetRepairTableBySdr(sdr);
        }
        else
        {
            repairTable = null;
        }

        db.Dispose();
        return repairTable;
    }

    /// <summary>
    /// 更新RepairTable表
    /// </summary>
    /// <param name="employe"></param>
    /// <returns></returns>
    public int UpdateRepairTable(RepairTable repairTable)
    {
        DBConnection db = new DBConnection();

        int Id = int.Parse(repairTable.Id);
        db.AddParameter("@ID", Id);
        db.AddParameter("@MaintainContent", repairTable.RepairContent);
        db.AddParameter("@Director", repairTable.Director);
        db.AddParameter("@DirectorPhone", repairTable.DirectorPhone);
        db.AddParameter("@DateTime", repairTable.DateTime);
        db.AddParameter("@Fee", repairTable.Fee);
        db.AddParameter("@IsFinish", repairTable.IsFinish);
        db.AddParameter("@Remarks", repairTable.Remarks);
        string sql = "";
        sql = "update Maintain set MaintainContent=@MaintainContent,Director=@Director,DirectorPhone = @DirectorPhone,DateTime = @DateTime,Fee=@Fee,IsFinish = @IsFinish, Remarks=@Remarks where ID=@ID ";

        int flag = db.ExecuteNonQuery(sql);
        db.Dispose();
        return flag;
    }

    /// <summary>
    /// 删除RepairTable记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeleteRepairTableById(string id)
    {
        DBConnection db = new DBConnection();
        int ID = int.Parse(id);
        db.AddParameter("@ID", ID);
        string sql = "delete from Maintain where ID=@ID";
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
        string sql = "select count(*) as a from Maintain";

        int count = 0;
        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        while (sdr.Read())
        {
            count = int.Parse(sdr["a"].ToString());
        }

        db.Dispose();
        return count;
    }

    /*
    /// <summary>
    /// 
    /// </summary>
    /// <param name="keyword"></param>
    /// <param name="room"></param>
    /// <param name="flag">0:无楼宇无房号;1:有楼宇无房号;2:无楼宇有房号3:有楼宇有房号</param>
    /// <returns></returns>
    public List<RepairTable> GetRepairTablesByBuildingAndRoom(string keyword, string room, int pageno, int pagesize, int flag)
    {
        List<RepairTable> list = new List<RepairTable>();
        string sql = "";
        int rowcount = 0;
        DBConnection db = new DBConnection();

        string building = "%"+keyword+"%";
        room = "%" + room + "%";
        db.AddParameter("@BuildingName", building);
        db.AddParameter("@room", room);

        if (flag == 1)
        {
            //记录查询的总数
            DBConnection db1 = new DBConnection();
            db1.AddParameter("@BuildingName", building);
            string sql1 = "select count(*) as a from Maintain where BuildingName like @BuildingName";

            SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
            while (sdr1.Read())
            {
                searchNum = int.Parse(sdr1["a"].ToString());
            }
            db1.Dispose();


            rowcount = searchNum;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID) as rownum ,* from Maintain where BuildingName like @BuildingName ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID) as rownum, * from Maintain where BuildingName like @BuildingName )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
        }
        else if (flag == 2)
        {
            //记录查询的总数
            DBConnection db1 = new DBConnection();

            db1.AddParameter("@Room", room);
            string sql1 = "select count(*) as a from Maintain where Room like @Room";

            SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
            while (sdr1.Read())
            {
                searchNum = int.Parse(sdr1["a"].ToString());
            }
            db1.Dispose();


            rowcount = searchNum;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID) as rownum ,* from Maintain where Room like @Room ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID) as rownum, * from Maintain where Room like @Room )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
        }
        else if (flag == 3)
        {

            //记录查询的总数
            DBConnection db1 = new DBConnection();
            db1.AddParameter("@BuildingName", building);
            db1.AddParameter("@Room", room);
            string sql1 = "select count(*) as a from Maintain where BuildingName like @BuildingName And Room like @Room";

            SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
            while (sdr1.Read())
            {
                searchNum = int.Parse(sdr1["a"].ToString());
            }
            db1.Dispose();


            rowcount = searchNum;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID) as rownum ,* from Maintain where BuildingName like @BuildingName And Room like @Room ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID) as rownum, * from Maintain where BuildingName like @BuildingName And Room like @Room )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
        }

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        while (sdr.Read())
        {
            RepairTable repairTable = GetRepairTableBySdr(sdr);
            list.Add(repairTable);
        }
        db.Dispose();
        return list;

    }
    */
    /// <summary>
    /// 
    /// </summary>
    /// <param name="keyword"></param>
    /// <param name="endtime"></param>
    /// <param name="pageno"></param>
    /// <param name="pagesize"></param>
    /// <param name="flag">0:无开始无结束1:有开始无结束2:无开始有结束3：有开始有结束</param>
    /// <returns></returns>
    public List<RepairTable> GetRepairTablesByTime(string keyword, string endtime, int pageno, int pagesize, int flag)
    {
        List<RepairTable> list = new List<RepairTable>();
        string sql = "";
        int rowcount = 0;
        DBConnection db = new DBConnection();

        string searchstart = keyword;
        string searchend = endtime;
        db.AddParameter("@LeaveTime", searchstart);
        db.AddParameter("@EndTime", searchend);

        if (flag == 1)
        {
            //记录查询的总数
            DBConnection db1 = new DBConnection();
            db1.AddParameter("@LeaveTime", DateTime.Parse(searchstart));
            string sql1 = "select count(*) as a from Maintain where DateTime >= @LeaveTime";

            SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
            while (sdr1.Read())
            {
                searchNum = int.Parse(sdr1["a"].ToString());
            }
            db1.Dispose();


            rowcount = searchNum;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by IsFinish,DateTime,ID) as rownum ,* from Maintain where DateTime >= @LeaveTime ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by IsFinish,DateTime,ID) as rownum, * from Maintain where DateTime >= @LeaveTime )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
        }
        else if (flag == 2)
        {
            //记录查询的总数
            DBConnection db1 = new DBConnection();

            db1.AddParameter("@EndTime", DateTime.Parse(searchend));
            string sql1 = "select count(*) as a from Maintain where DateTime <= @EndTime";

            SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
            while (sdr1.Read())
            {
                searchNum = int.Parse(sdr1["a"].ToString());
            }
            db1.Dispose();


            rowcount = searchNum;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by IsFinish,DateTime,ID) as rownum ,* from Maintain where DateTime <= @EndTime ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by IsFinish,DateTime,ID) as rownum, * from Maintain where DateTime <= @EndTime )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
        }
        else if (flag == 3)
        {

            //记录查询的总数
            DBConnection db1 = new DBConnection();
            db1.AddParameter("@LeaveTime", DateTime.Parse(searchstart));
            db1.AddParameter("@EndTime", DateTime.Parse(searchend));
            string sql1 = "select count(*) as a from Maintain where DateTime <= @EndTime And DateTime >=@LeaveTime";

            SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
            while (sdr1.Read())
            {
                searchNum = int.Parse(sdr1["a"].ToString());
            }
            db1.Dispose();


            rowcount = searchNum;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by IsFinish,DateTime,ID) as rownum ,* from Maintain where DateTime <= @EndTime And DateTime >=@LeaveTime ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by IsFinish,DateTime,ID) as rownum, * from Maintain where DateTime <= @EndTime And DateTime >=@LeaveTime )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
        }

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        while (sdr.Read())
        {
            RepairTable messageReply = GetRepairTableBySdr(sdr);
            list.Add(messageReply);
        }
        db.Dispose();
        return list;

    }
}