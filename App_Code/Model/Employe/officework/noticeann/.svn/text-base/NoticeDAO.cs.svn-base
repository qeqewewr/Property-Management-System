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
///NoticeDAO 的摘要说明
/// </summary>
public class NoticeDAO
{
	public NoticeDAO()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public Notice GetNotice(string id)
    {
        Notice notice = new Notice();
        DBConnection db = new DBConnection();
        string sql = "select * from Notice where ID='" + id + "'";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        if (sdr.Read())
        {
            notice.ID = sdr["ID"].ToString();
            notice.Publisher = sdr["Publisher"].ToString();
            notice.PublishDate = DateTime.Parse(sdr["PublishDate"].ToString()).ToString("yyyy/MM/dd");
            notice.NoticeContent = sdr["NoticeContent"].ToString();
            notice.NoticeType = sdr["NoticeType"].ToString();
            notice.NoticeTypeID = sdr["NoticeTypeID"].ToString();
            notice.Rooms = sdr["Rooms"].ToString();
            notice.UncheckedRooms = sdr["UncheckedRooms"].ToString();
            return notice;
        }
        else
        {
            return null;
        }

    }

    public int AddNotice(Notice notice)
    {

        DBConnection db = new DBConnection();

        db.AddParameter("@PublishDate", notice.PublishDate);
        db.AddParameter("@Publisher", notice.Publisher);
        db.AddParameter("@NoticeContent", notice.NoticeContent);
        db.AddParameter("@NoticeTypeID", notice.NoticeTypeID);
        db.AddParameter("@NoticeType", notice.NoticeType);
        db.AddParameter("@Rooms", notice.Rooms);
        db.AddParameter("@UncheckedRooms", notice.UncheckedRooms);
        string sql = "insert into Notice(PublishDate ,Publisher ,NoticeContent,NoticeTypeID,NoticeType,Rooms,UncheckedRooms) values(@PublishDate ,@Publisher ,@NoticeContent,@NoticeTypeID,@NoticeType,@Rooms,@UncheckedRooms)";

        return db.ExecuteNonQuery(sql);
    }

    //编辑信息
    public int UpdateNotice(Notice notice)
    {
        DBConnection db = new DBConnection();

        db.AddParameter("@ID", notice.ID);
        db.AddParameter("@PublisDate", notice.PublishDate);
        db.AddParameter("@Publisher", notice.Publisher);
        db.AddParameter("@NoticeContent", notice.NoticeContent);
        db.AddParameter("@NoticeTypeID", notice.NoticeTypeID);
        db.AddParameter("@NoticeType", notice.NoticeType);
        db.AddParameter("@Rooms", notice.Rooms);
        db.AddParameter("@UncheckedRooms", notice.UncheckedRooms);
        string sql = "update Notice set PublishDate = @PublisDate  ,Publisher = @Publisher ,NoticeContent = @NoticeContent ,NoticeTypeID = @NoticeTypeID ,NoticeType = @NoticeType ,Rooms = @Rooms ,UncheckedRooms =  @UncheckedRooms where ID=@ID ";
        return db.ExecuteNonQuery(sql);
    }
    /// <summary>
    /// 分页读取表数据
    /// </summary>
    /// <param name="pageno">页号</param>
    /// <param name="pagesize">页大小</param>
    /// <returns></returns>
    public List<Notice> ListPageNotice(int pageno, int pagesize)
    {
        List<Notice> noticeList = new List<Notice>();
        int rowcount = this.GetTotalRecordNum();
        string sql;

        DBConnection db = new DBConnection();

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by ID) as rownum ,* from Notice) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by ID) as rownum, * from Notice)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

        while (sdr.Read())
        {
            Notice notice = new Notice();
            notice.ID = sdr["ID"].ToString();
            notice.Publisher = sdr["Publisher"].ToString();
            notice.PublishDate = DateTime.Parse(sdr["PublishDate"].ToString()).ToString("yyyy/MM/dd");
            notice.NoticeContent = sdr["NoticeContent"].ToString();
            notice.NoticeType = sdr["NoticeType"].ToString();
            notice.NoticeTypeID = sdr["NoticeTypeID"].ToString();
            notice.Rooms = sdr["Rooms"].ToString();
            notice.UncheckedRooms = sdr["UncheckedRooms"].ToString();
            noticeList.Add(notice);
        }
        db.Dispose();
        return noticeList;
    }

    //获得当前页的新闻信息列表
    public List<Notice> ListPagenotice(int pageno, int pagesize, string typeid)
    {
        List<Notice> noticeLists = new List<Notice>();
        int rowcount = this.GetTotalRecordNum();
        string sql;
        int tid = int.Parse(typeid);

        DBConnection db = new DBConnection();

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by ID) as rownum ,* from Notice where TypeID='" + tid + "') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + " ";
        else
            sql = "with temp as( select row_number() over(order by ID) as rownum, * from Notice where TypeID='" + tid + "')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + " ";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        while (sdr.Read())
        {
            Notice notice = new Notice();

            notice.ID = sdr["ID"].ToString();
            notice.Publisher = sdr["Publisher"].ToString();
            notice.PublishDate = sdr["PublishDate"].ToString();
            notice.NoticeContent = sdr["NoticeContent"].ToString();
            notice.NoticeType = sdr["NoticeType"].ToString();
            notice.NoticeTypeID = sdr["NoticeTypeID"].ToString();
            notice.Rooms = sdr["Rooms"].ToString();
            notice.UncheckedRooms = sdr["UncheckedRooms"].ToString();
            noticeLists.Add(notice);
        }
        db.Dispose();
        return noticeLists;
    }

    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeleteNotice(string id)
    {
        DBConnection db = new DBConnection();

        db.AddParameter("@ID", id);
        string sql = "delete from Notice where ID=@ID";
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
        string sql = "select count(*) as a from Notice";

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