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
///MessageReplyDAO 的摘要说明
/// </summary>
public class MessageReplyDAO
{
    public int searchNum;
	public MessageReplyDAO()
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
    public List<MessageReply> DataTableToList(DataTable dt)
    {
        List<MessageReply> modelList = new List<MessageReply>();
        int rowsCount = dt.Rows.Count;
        if (rowsCount > 0)
        {
            MessageReply model;
            for (int n = 0; n < rowsCount; n++)
            {
                model = new MessageReply();

                if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    model.Id = dt.Rows[n]["ID"].ToString().ToString();
                if (dt.Rows[n]["LeaveTime"] != null && dt.Rows[n]["LeaveTime"].ToString() != "")
                    model.LeaveTime = DateTime.Parse(dt.Rows[n]["LeaveTime"].ToString());
                if (dt.Rows[n]["LeaveMessage"] != null && dt.Rows[n]["LeaveMessage"].ToString() != "")
                    model.LeaveMessage = dt.Rows[n]["LeaveMessage"].ToString();
                if (dt.Rows[n]["IsReplyed"] != null && dt.Rows[n]["IsReplyed"].ToString() != "")
                    model.IsReplyed = Boolean.Parse(dt.Rows[n]["IsReplyed"].ToString());
                if (dt.Rows[n]["ReplyTime"] != null && dt.Rows[n]["ReplyTime"].ToString() != "")
                    model.ReplyTime =DateTime.Parse( dt.Rows[n]["ReplyTime"].ToString());
                if (dt.Rows[n]["Reply"] != null && dt.Rows[n]["Reply"].ToString() != "")
                    model.Reply = dt.Rows[n]["Reply"].ToString();

                modelList.Add(model);
            }
        }
        return modelList;
    }

   /// <summary>
   /// 辅助方法
   /// </summary>
   /// <param name="sdr"></param>
   /// <returns></returns>
    public MessageReply GetMessageReplyBySdr(SqlDataReader sdr)
    {
        MessageReply MessageReply = new MessageReply();
        MessageReply.Id = sdr["ID"].ToString();
        if (sdr["LeaveTime"].ToString() != null && sdr["LeaveTime"].ToString() != "")
            MessageReply.LeaveTime =DateTime.Parse(sdr["LeaveTime"].ToString());
        MessageReply.LeaveMessage = sdr["LeaveMessage"].ToString();
        MessageReply.IsReplyed = (Boolean)sdr["IsReplyed"];
        if (sdr["ReplyTime"].ToString() != null && sdr["ReplyTime"].ToString() != "")
            MessageReply.ReplyTime = DateTime.Parse(sdr["ReplyTime"].ToString());
        MessageReply.Reply = sdr["Reply"].ToString();

        return MessageReply;
    }

    /// <summary>
    /// 增加一条记录
    /// </summary>
    /// <param name="MessageReply"></param>
    /// <returns></returns>
    public int AddMessageReply(MessageReply MessageReply)
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@LeaveTime", SqlDbType.DateTime),
                    new SqlParameter("@LeaveMessage", SqlDbType.NVarChar),
                    new SqlParameter("@IsReplyed", SqlDbType.Bit),
                    new SqlParameter("@ReplyTime", SqlDbType.DateTime),
                    new SqlParameter("@Reply", SqlDbType.VarChar)};
        parameters[0].Value = MessageReply.LeaveTime;
        parameters[1].Value = MessageReply.LeaveMessage;
        parameters[2].Value = MessageReply.IsReplyed;
        parameters[3].Value = MessageReply.ReplyTime;
        parameters[4].Value = MessageReply.Reply;

       
        string sql = "insert into Message values(@LeaveTime,@LeaveMessage,@IsReplyed,@ReplyTime,@Reply)";
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
    /// new-------------插入一条留言记录
    /// </summary>
    /// <param name="leaveMessage"></param>
    /// <param name="leaveTime"></param>
    /// <returns></returns>
    public int AddMessageReply(string leaveMessage, DateTime leaveTime)
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@LeaveTime", SqlDbType.DateTime),
                    new SqlParameter("@LeaveMessage", SqlDbType.NVarChar),
                    new SqlParameter("@IsReplyed", SqlDbType.Bit),
                    new SqlParameter("@ReplyTime", SqlDbType.DateTime),
                    new SqlParameter("@Reply", SqlDbType.VarChar)};
        parameters[0].Value = leaveTime;
        parameters[1].Value = leaveMessage;
        parameters[2].Value = false;
        parameters[3].Value = DateTime.Now;
        parameters[4].Value = "未回复";

       
   //     string sql = "insert into Message(LeaveTime,LeaveMessage,IsReplyed,ReplyTime,Reply) values(@LeaveTime,@LeaveMessage,@IsReplyed,@ReplyTime,@Reply)";
        string sql = "insert into Message values(@LeaveTime,@LeaveMessage,@IsReplyed,@ReplyTime,@Reply)";
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
    /// 分页读取表数据
    /// </summary>
    /// <param name="pageno">页号</param>
    /// <param name="pagesize">页大小</param>
    /// <returns></returns>
    public List<MessageReply> ListPageMessageReply(int pageno, int pagesize)
    {

        int rowcount = this.GetTotalRecordNum();
        string sql;

        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by IsReplyed,LeaveTime desc,ID) as rownum ,* from Message) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by IsReplyed,LeaveTime desc ,ID) as rownum, * from Message) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
        DataSet ds = DBHelperSQL.Query(sql);
        return DataTableToList(ds.Tables[0]);
    }

    /// <summary>
    /// 已回复列表
    /// </summary>
    /// <param name="pageno"></param>
    /// <param name="pagesize"></param>
    /// <returns></returns>
    public List<MessageReply> ListPageMessageReplyByIsReplyed(int pageno, int pagesize)
    {

        int rowcount = this.GetTotalRecordNumByIsReplyed();
        string sql;
        SqlParameter[] parameters = {
                    new SqlParameter("@IsReplyed", SqlDbType.Bit)
                   };
        parameters[0].Value = true;
    
        if (pageno * pagesize > rowcount)
            sql = "with temp as( select row_number() over(order by LeaveTime desc,ID) as rownum ,* from Message where IsReplyed=@IsReplyed) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
        else
            sql = "with temp as( select row_number() over(order by LeaveTime desc,ID) as rownum, * from Message where IsReplyed=@IsReplyed) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

        DataSet ds = DBHelperSQL.Query(sql, parameters);
        return DataTableToList(ds.Tables[0]);
    }

    /// <summary>
    /// 由ID获得MessageReply记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public MessageReply GetMessageReplyById(string id)
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int)
                   };
        int ID = int.Parse(id);
        parameters[0].Value =ID;
      
        string sql = "select * from Message where ID=@ID ";
        DataSet ds = DBHelperSQL.Query(sql, parameters);
        List<MessageReply> messageRely = DataTableToList(ds.Tables[0]);
        if (messageRely.Count > 0)
            return messageRely[0];
        else
            return null;    
    }

    /// <summary>
    /// 更新MessageReply表
    /// </summary>
    /// <param name="Message"></param>
    /// <returns></returns>
    public int UpdateMessageReply(MessageReply messageReply)
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@LeaveTime", SqlDbType.DateTime),
                    new SqlParameter("@LeaveMessage", SqlDbType.NVarChar),
                    new SqlParameter("@IsReplyed", SqlDbType.Bit),
                    new SqlParameter("@ReplyTime", SqlDbType.DateTime),
                    new SqlParameter("@Reply", SqlDbType.VarChar),
                    new SqlParameter("@ID", SqlDbType.Int)
                                    };
        parameters[0].Value = messageReply.LeaveTime;
        parameters[1].Value = messageReply.LeaveMessage;
        parameters[2].Value = messageReply.IsReplyed;
        parameters[3].Value = messageReply.ReplyTime;
        parameters[4].Value = messageReply.Reply;
        parameters[5].Value = messageReply.Id;
       
        string sql = "";
        sql = "update Message set LeaveTime=@LeaveTime,LeaveMessage=@LeaveMessage,IsReplyed = @IsReplyed,ReplyTime = @ReplyTime,Reply = @Reply where ID=@ID ";

        return DBHelperSQL.ExecuteSql(sql, parameters);
    }

    /// <summary>
    /// 由留言是否发布进行更新
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int UpdateMessageReplyByIsPublished(string id)
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@IsReplyed", SqlDbType.Bit),
                    new SqlParameter("@ID", SqlDbType.Int)
                                    };
        int Id = int.Parse(id);
        parameters[0].Value = true;
        parameters[1].Value = Id;
       
        string sql = "";
        sql = "update Message set IsReplyed = @IsReplyed where ID=@ID ";

        return DBHelperSQL.ExecuteSql(sql, parameters);
    }

    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeleteMessageReplyById(string id)
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int)
                                    };
        int Id = int.Parse(id);
        parameters[1].Value = Id;
        string sql = "delete from Message where ID=@ID";
        return DBHelperSQL.ExecuteSql(sql, parameters);
    }

    /// <summary>
    ///获得表记录总数
    /// </summary>
    /// <returns></returns>
    public int GetTotalRecordNum()
    {

        return DBHelperSQL.countNum("Message");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int GetTotalRecordNumByIsReplyed()
    {
        return DBHelperSQL.countNum("Message", "IsReplyed=1");
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="keyword"></param>
    /// <param name="endtime"></param>
    /// <param name="flag">0:无开始无结束1:有开始无结束2:无开始有结束3：有开始有结束</param>
    /// <returns></returns>
    public List<MessageReply> GetMessageReplysByTime(string keyword,string endtime,int pageno,int pagesize,int flag)
    {
        string sql = "";
        int rowcount = 0;
        string searchstart = keyword;
        string searchend = endtime;

        if (flag == 1)
        {
            //记录查询的总数
            DBConnection db1 = new DBConnection();
            db1.AddParameter("@LeaveTime", DateTime.Parse(searchstart));
            string sql1 = "select count(*) as a from Message where LeaveTime >= @LeaveTime";

            SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
            while (sdr1.Read())
            {
                searchNum = int.Parse(sdr1["a"].ToString());
            }
            sdr1.Close();
            db1.Dispose();


            rowcount = searchNum;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by IsReplyed,LeaveTime desc,ID) as rownum ,* from Message where LeaveTime >= @LeaveTime ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by IsReplyed,LeaveTime desc,ID) as rownum, * from Message where LeaveTime >= @LeaveTime )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
        }
        else if (flag ==2)
        {
            //记录查询的总数
            DBConnection db1 = new DBConnection();
            
            db1.AddParameter("@EndTime", DateTime.Parse(searchend));
            string sql1 = "select count(*) as a from Message where LeaveTime <= @EndTime";

            SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
            while (sdr1.Read())
            {
                searchNum = int.Parse(sdr1["a"].ToString());
            }
            sdr1.Close();
            db1.Dispose();


            rowcount = searchNum;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by IsReplyed,LeaveTime desc,ID) as rownum ,* from Message where LeaveTime <= @EndTime ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by IsReplyed,LeaveTime desc,ID) as rownum, * from Message where LeaveTime <= @EndTime )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
        }
        else if (flag == 3)
        {
            
            //记录查询的总数
            DBConnection db1 = new DBConnection();
            db1.AddParameter("@LeaveTime", DateTime.Parse(searchstart));
            db1.AddParameter("@EndTime", DateTime.Parse(searchend));
            string sql1 = "select count(*) as a from Message where LeaveTime <= @EndTime And LeaveTime >=@LeaveTime";

            SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
            while (sdr1.Read())
            {
                searchNum = int.Parse(sdr1["a"].ToString());
            }
            sdr1.Close();
            db1.Dispose();


            rowcount = searchNum;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by IsReplyed,LeaveTime desc,ID) as rownum ,* from Message where LeaveTime <= @EndTime And LeaveTime >=@LeaveTime ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by IsReplyed,LeaveTime desc,ID) as rownum, * from Message where LeaveTime <= @EndTime And LeaveTime >=@LeaveTime )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";
        }

        DataSet ds = DBHelperSQL.Query(sql);
        return DataTableToList(ds.Tables[0]);

    }

}