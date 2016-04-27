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
///NoticeTypeDAO 的摘要说明
/// </summary>
public class NoticeTypeDAO
{
	public NoticeTypeDAO()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public NoticeType GetNoticeType(string id)
    {
        NoticeType noticeType = new NoticeType();
        DBConnection db = new DBConnection();
        string sql = "select * from NoticeType where ID='" + id + "'";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        if (sdr.Read())
        {
            noticeType.ID = sdr["ID"].ToString().Trim();
            noticeType.Name = sdr["Name"].ToString().Trim();
            //      noticeType.Description = sdr["Description"].ToString().Trim();

            return noticeType;
        }
        else
            return null;
    }

    public int AddNoticeType(NoticeType noticeType)
    {

        DBConnection db = new DBConnection();

        db.AddParameter("@Name", noticeType.Name);
        //  db.AddParameter("@Description", noticeType.Description);

        string sql = "insert into NoticeType(Name) values(@Name)";

        return db.ExecuteNonQuery(sql);
    }

    //编辑信息
    public int UpdateNoticeType(NoticeType noticeType)
    {
        DBConnection db = new DBConnection();
        db.AddParameter("@ID", noticeType.ID);
        db.AddParameter("@Name", noticeType.Name);
        // db.AddParameter("@Description", noticeType.Description);

        string sql = "update NoticeType set Name=@Name where ID=@ID ";
        return db.ExecuteNonQuery(sql);
    }
    /// <summary>
    /// 读取表数据
    /// </summary>
    /// <returns></returns>
    public List<NoticeType> ListNoticeType()
    {
        List<NoticeType> noticeTypeList = new List<NoticeType>();

        DBConnection db = new DBConnection();
        string sql = "select * from NoticeType";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        while (sdr.Read())
        {
            NoticeType noticeType = new NoticeType();
            noticeType.ID = sdr["ID"].ToString();
            noticeType.Name = sdr["Name"].ToString();

            noticeTypeList.Add(noticeType);
        }
        db.Dispose();
        return noticeTypeList;
    }


    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeleteNoticeType(string id)
    {
        DBConnection db = new DBConnection();

        db.AddParameter("@ID", id);
        string sql = "delete from NoticeType where ID=@ID";
        int flag = db.ExecuteNonQuery(sql);
        return flag;
    }

    /// <summary>
    ///获得表记录总数
    /// </summary>
    /// <returns></returns>
    public int GetTotalRecordNum()
    {

        DBConnection db = new DBConnection();
        string sql = "select count(*) as a from NoticeType";

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