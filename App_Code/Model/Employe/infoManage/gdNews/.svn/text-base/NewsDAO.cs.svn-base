using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using CEMIS.Util;
using CEMIS.Model.Employe;


/// <summary>
///NewsDAO 的摘要说明
/// </summary>
/// 

namespace CEMIS.Model.Employe
{
    public class NewsDAO
    {
        public NewsDAO()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }


        public int searchNum = 0;

        //添加新闻信息
        public int AddNews(News news)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@Title", news.Title);
            db.AddParameter("@Body", news.Body);
            if(news.PublishTime!=null)
                db.AddParameter("@PublishTime", news.PublishTime);
            else
                db.AddParameter("@PublishTime", DBNull.Value);
            if (news.LunBo == "" || news.LunBo == "")
                db.AddParameter("@LunBo", "0");
            else
                db.AddParameter("@LunBo", news.LunBo);


            string sql = "insert into News(Title,Body,PublishTime,LunBo) values(@Title,@Body,@PublishTime,@LunBo);select @@IDENTITY";

            object obj = db.ExecuteScalar(sql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        //编辑新闻内容
        public int UpdateNews(News news)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@ID", news.ID);
            db.AddParameter("@Title", news.Title);
            db.AddParameter("@Body", news.Body);
            if (news.PublishTime != null)
                db.AddParameter("@PublishTime", news.PublishTime);
            else
                db.AddParameter("@PublishTime", DBNull.Value);
            if (news.LunBo != null)
                db.AddParameter("@LunBo", news.LunBo);
            else
                db.AddParameter("@LunBo", DBNull.Value);

            string sql = "";
            //sql = "update News set Body=@Body,PublishTime=@PublishTime where Title=@Title ";
            sql = "update News set Title=@Title,Body=@Body,PublishTime=@PublishTime,LunBo=@LunBo where ID=@ID ";

            return db.ExecuteNonQuery(sql);
        }


        //获得所有新闻列表
        public List<News> ListNews()
        {
            List<News> newsList = new List<News>();

            DBConnection db = new DBConnection();
            string sql = "select * from News order by PublishTime desc";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                News news = new News();

                news.ID = int.Parse(sdr["ID"].ToString());
                news.Title = sdr["Title"].ToString();
                news.Body = sdr["Body"].ToString();
                if (sdr["PublishTime"].ToString() != null && sdr["PublishTime"].ToString() != "")
                    news.PublishTime = DateTime.Parse(sdr["PublishTime"].ToString());
                if (sdr["LunBo"].ToString() != null && sdr["LunBo"].ToString() != "")
                    news.LunBo = sdr["LunBo"].ToString();

                newsList.Add(news);
            }
            db.Dispose();
            return newsList;
        }


        //获得当前页的新闻列表
        public List<News> ListPageNews(int pageno,int pagesize)
        {
            List<News> newsList = new List<News>();
            int rowcount = this.GetTotalRecordNum();
            string sql;


            DBConnection db = new DBConnection();

            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by PublishTime desc,id desc) as rownum ,* from News) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by PublishTime desc,id desc) as rownum, * from News )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                News news = new News();

                news.ID = int.Parse(sdr["ID"].ToString());
                news.Title = sdr["Title"].ToString();
                news.Body = sdr["Body"].ToString();
                if (sdr["PublishTime"].ToString() != null && sdr["PublishTime"].ToString() != "")
                    news.PublishTime = DateTime.Parse(sdr["PublishTime"].ToString());
                if (sdr["LunBo"].ToString() != null && sdr["LunBo"].ToString() != "")
                    news.LunBo = sdr["LunBo"].ToString();

                newsList.Add(news);
            }
            db.Dispose();
            return newsList;
        }

        //通过新闻标题删除新闻
       /* public int deleteNews(string title)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@Title", title);
            string sql = "delete from News where Title=@Title";

            return db.ExecuteNonQuery(sql);
        }*/

        //通过ID删除新闻
        public int deleteNewsByID(int id)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@ID", id);
            string sql = "delete from News where ID=@ID";

            return db.ExecuteNonQuery(sql);
        }

        //通过ID获得新闻信息
        public News GetNewsByID(int id)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@ID", id);
            string sql = "select * from News where ID=@ID ";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            News news = new News();

            if (sdr.Read())
            {
                news.ID = int.Parse(sdr["ID"].ToString());
                news.Title = sdr["Title"].ToString();
                news.Body = sdr["Body"].ToString();
                if (sdr["PublishTime"].ToString() != null && sdr["PublishTime"].ToString() != "")
                    news.PublishTime = DateTime.Parse(sdr["PublishTime"].ToString());
                if (sdr["LunBo"].ToString() != null && sdr["LunBo"].ToString() != "")
                    news.LunBo = sdr["LunBo"].ToString();
            }
            else
            {
                news = null;
            }

            db.Dispose();
            return news;
        }

        //通过标题内容进行模糊搜索新闻列表
        public List<News> GetNewsByTitle(string title,int pageno,int pagesize)
        {
            List<News> newsList = new List<News>();

            DBConnection db = new DBConnection();
            string searchTitle = "%" + title + "%";
            db.AddParameter("@Title", searchTitle);

            //获得查找总数
            DBConnection db1 = new DBConnection();
            db1.AddParameter("@Title", searchTitle);
            string sql1 = "select count(*) as a from News where Title like @Title ";

   
            SqlDataReader sdr1 = (SqlDataReader)db1.ExecuteReader(sql1);
            while (sdr1.Read())
            {
                searchNum = int.Parse(sdr1["a"].ToString());
            }

            db1.Dispose();

            int rowcount = searchNum;

            string sql = "";

            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by PublishTime desc,id desc) as rownum ,* from News where Title like @Title) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by PublishTime desc,id desc) as rownum, * from News where Title like @Title )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                News news = new News();

                news.ID = int.Parse(sdr["ID"].ToString());
                news.Title = sdr["Title"].ToString();
                news.Body = sdr["Body"].ToString();
                if (sdr["PublishTime"].ToString() != null && sdr["PublishTime"].ToString() != "")
                    news.PublishTime = DateTime.Parse(sdr["PublishTime"].ToString());
                if (sdr["LunBo"].ToString() != null && sdr["LunBo"].ToString() != "")
                    news.LunBo = sdr["LunBo"].ToString();

                newsList.Add(news);
            }
            db.Dispose();
            return newsList;
        }

        //获得所有新闻的总数
        public int GetTotalRecordNum()
        {

            DBConnection db = new DBConnection();
            string sql = "select count(*) as a from News";

            int count = 0;
            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                count = int.Parse(sdr["a"].ToString());
            }

            db.Dispose();
            return count;
        }

        public List<News> LunBoNews()
        {
            DBConnection db = new DBConnection();
            string sql = "select *  from News where LunBo=1 order by PublishTime desc";

            List<News> newsList = new List<News>();

             SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                News news = new News();

                news.ID = int.Parse(sdr["ID"].ToString());
                news.Title = sdr["Title"].ToString();
                news.Body = sdr["Body"].ToString();
                if (sdr["PublishTime"].ToString() != null && sdr["PublishTime"].ToString() != "")
                    news.PublishTime = DateTime.Parse(sdr["PublishTime"].ToString());
                if (sdr["LunBo"].ToString() != null && sdr["LunBo"].ToString() != "")
                    news.LunBo = sdr["LunBo"].ToString();

                newsList.Add(news);
            }
            db.Dispose();
            return newsList;

        }
    }
}