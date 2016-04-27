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
///MyNoticeDAO 的摘要说明
/// </summary>
public class MyNoticeDAO
{
	public MyNoticeDAO()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public MyNotice GetMyNotice(string id)
    {
        MyNotice notice = new MyNotice();
        DBConnection db = new DBConnection();
        string sql = "select * from MyNotice where ID='" + id + "'";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        if (sdr.Read())
        {
            notice.ID = sdr["ID"].ToString();
            notice.NoticeID = sdr["NoticeID"].ToString();
            notice.ToBuilding = sdr["ToBuilding"].ToString();
            notice.ToRoom = sdr["ToRoom"].ToString();
            notice.IsRead = sdr["IsRead"].ToString();
			notice.Lessee = sdr["Lessee"].ToString();
            return notice;
        }
        else
        {
            return null;
        }

    }

    public int AddMyNotice(MyNotice notice)
    {

        DBConnection db = new DBConnection();

        db.AddParameter("@NoticeID", notice.NoticeID);
        db.AddParameter("@ToBuilding", notice.ToBuilding);
        db.AddParameter("@ToRoom", notice.ToRoom);
        db.AddParameter("@IsRead", notice.IsRead);
		db.AddParameter("@Lessee", notice.Lessee);
        string sql = "insert into MyNotice(NoticeID,ToBuilding ,ToRoom,IsRead,Lessee) values(@NoticeID,@ToBuilding ,@ToRoom,@IsRead,@Lessee);";
        return db.ExecuteNonQuery(sql);
    }

    public int AddMyNotice(List<MyNotice> noticelist)
    {

       // DBConnection db = new DBConnection();
        MyNotice notice;
        //string sql = "";
        int result = 0;
        for (int i = 0; i < noticelist.Count; i++)
        {
            notice = noticelist[i];
            
            int result2 = AddMyNotice(notice);
            if (result2 == 0)
                return 0;
            else
                result += result2;
         //   sql += "insert into MyNotice(NoticeID,ToBuilding ,ToRoom,IsRead) values(@NoticeID,@ToBuilding ,@ToRoom,@IsRead);";
        }
        return result;
       // return db.ExecuteNonQuery(sql);
    }


    //编辑信息
    public int ReadMyNotice(string id)
    {
        int _id = int.Parse(id);
        DBConnection db = new DBConnection();
        db.AddParameter("@ID", _id.ToString());
        string sql = "update MyNotice set IsRead = '1' where ID=@ID ";
        return db.ExecuteNonQuery(sql);
    }
    /// <summary>
    /// 分页读取表数据
    /// </summary>
    /// <param name="pageno">页号</param>
    /// <param name="pagesize">页大小</param>
    /// <returns></returns>
    public List<MyNotice> ListPageMyUnReadNotice(int pageno, int pagesize, string build, string room)
    {
        List<MyNotice> noticeList = new List<MyNotice>();
        int rowcount = this.GetTotalUnReadRecordNum(build, room);
        string sql;

        DBConnection db = new DBConnection();

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by ID) as rownum ,* from MyNotice where ToBuilding = '" + build + "' and ToRoom ='" + room + "' and IsRead = '0') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by ID) as rownum, * from MyNotice where ToBuilding = '" + build + "' and ToRoom ='" + room + "'and IsRead = '0')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        while (sdr.Read())
        {
            MyNotice notice = new MyNotice();
            notice.ID = sdr["ID"].ToString();
            notice.NoticeID = sdr["NoticeID"].ToString();
            notice.ToBuilding = sdr["ToBuilding"].ToString();
            notice.ToRoom = sdr["ToRoom"].ToString();
            notice.IsRead = sdr["IsRead"].ToString();
			notice.Lessee = sdr["Lessee"].ToString();
            noticeList.Add(notice);
        }
        db.Dispose();
        return noticeList;
    }

	public List<MyNotice> ListPageMyUnReadNoticeByLessee(int pageno, int pagesize, string lessee)
	{
		List<MyNotice> noticeList = new List<MyNotice>();
		int rowcount = this.GetTotalUnReadRecordNumByLessee(lessee);
		string sql;

		DBConnection db = new DBConnection();

		if (pageno * pagesize > rowcount)
			sql = "with temp as( select row_number() over(order by ID) as rownum ,* from MyNotice where lessee = '" + lessee + "' and IsRead = '0') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
		else
			sql = "with temp as( select row_number() over(order by ID) as rownum, * from MyNotice where lessee = '" + lessee + "' and   IsRead = '0') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

		SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

		while (sdr.Read())
		{
			MyNotice notice = new MyNotice();
			notice.ID = sdr["ID"].ToString();
			notice.NoticeID = sdr["NoticeID"].ToString();
			notice.ToBuilding = sdr["ToBuilding"].ToString();
			notice.ToRoom = sdr["ToRoom"].ToString();
			notice.IsRead = sdr["IsRead"].ToString();
			notice.Lessee = sdr["Lessee"].ToString();
			noticeList.Add(notice);
		}
		db.Dispose();
		return noticeList;
	}

    //获得当前页的新闻信息列表
    public List<MyNotice> ListPageMyNotice(int pageno, int pagesize, string build, string room)
    {
        List<MyNotice> mynoticeLists = new List<MyNotice>();
        int rowcount = this.GetTotalRecordNum(build, room);
        string sql;

        DBConnection db = new DBConnection();

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by ID) as rownum ,* from MyNotice where ToBuilding = '" + build + "' and ToRoom ='" + room + "') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by ID) as rownum, * from MyNotice where ToBuilding = '" + build + "' and ToRoom ='" + room + "')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        while (sdr.Read())
        {
            MyNotice notice = new MyNotice();

            notice.ID = sdr["ID"].ToString();
            notice.NoticeID = sdr["NoticeID"].ToString();
            notice.ToBuilding = sdr["ToBuilding"].ToString();
            notice.ToRoom = sdr["ToRoom"].ToString();
            notice.IsRead = sdr["IsRead"].ToString();
			notice.Lessee = sdr["Lessee"].ToString();
            mynoticeLists.Add(notice);
        }
        db.Dispose();
        return mynoticeLists;
    }

	public List<MyNotice> ListPageMyNoticeByLessee(int pageno, int pagesize, string lessee)
	{
		List<MyNotice> mynoticeLists = new List<MyNotice>();
		int rowcount = this.GetTotalRecordNumByLessee(lessee);
		string sql;

		DBConnection db = new DBConnection();

		if (pageno * pagesize > rowcount)
			sql = "with temp as( select row_number() over(order by ID) as rownum ,* from MyNotice where lessee = '" + lessee + "') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
		else
			sql = "with temp as( select row_number() over(order by ID) as rownum, * from MyNotice where lessee = '" + lessee + "')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

		SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
		while (sdr.Read())
		{
			MyNotice notice = new MyNotice();

			notice.ID = sdr["ID"].ToString();
			notice.NoticeID = sdr["NoticeID"].ToString();
			notice.ToBuilding = sdr["ToBuilding"].ToString();
			notice.ToRoom = sdr["ToRoom"].ToString();
			notice.IsRead = sdr["IsRead"].ToString();
			notice.Lessee = sdr["Lessee"].ToString();
			mynoticeLists.Add(notice);
		}
		db.Dispose();
		return mynoticeLists;
	}

    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeleteMyNotice(string id)
    {
        DBConnection db = new DBConnection();

        db.AddParameter("@ID", id);
        string sql = "delete from MyNotice where ID=@ID";
        int flag = db.ExecuteNonQuery(sql);
        db.Dispose();
        return flag;
    }

    /// <summary>
    ///获得表记录总数
    /// </summary>
    /// <returns></returns>
    public int GetTotalRecordNum(string build,string room)
    {

        DBConnection db = new DBConnection();
        string sql = "select count(*) as a from MyNotice where ToBuilding = '"+build+"' and ToRoom ='"+room +"'";

        int count = 0;
        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        while (sdr.Read())
        {
            count = int.Parse(sdr["a"].ToString());
        }

        db.Dispose();
        return count;
    }

	public int GetTotalRecordNumByLessee(string lessee)
	{

		DBConnection db = new DBConnection();
		string sql = "select count(*) as a from MyNotice where Lessee='"+lessee+"'";

		int count = 0;
		SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
		while (sdr.Read())
		{
			count = int.Parse(sdr["a"].ToString());
		}

		db.Dispose();
		return count;
	}

    public int GetTotalUnReadRecordNum(string build, string room)
    {
        DBConnection db = new DBConnection();
        string sql = "select count(*) as a from MyNotice where ToBuilding = '" + build + "' and ToRoom ='" + room + "' and IsRead='0'";

        int count = 0;
        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        while (sdr.Read())
        {
            count = int.Parse(sdr["a"].ToString());
        }

        db.Dispose();
        return count;
    }

	public int GetTotalUnReadRecordNumByLessee(string lessee)
	{
		DBConnection db = new DBConnection();
		string sql = "select count(*) as a from MyNotice where Lessee = '" + lessee + "' and " + "IsRead='0'";

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