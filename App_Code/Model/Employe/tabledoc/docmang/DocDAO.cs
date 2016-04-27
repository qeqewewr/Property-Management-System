using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CEMIS.Util;

namespace CEMIS.Model.Employe.tabledoc.docmang
{
    /// <summary>
    ///DocDAO 的摘要说明
    /// </summary>

    public class DocDAO
    {
        public DocDAO()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public Doc GetDoc(string id)
        {
            Doc doc = new Doc();
            DBConnection db = new DBConnection();
            string sql = "select * from Document where ID='" + id + "'";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            if (sdr.Read())
            {
                doc.ID = sdr["ID"].ToString();
                doc.Title = sdr["Title"].ToString();
                doc.FileName = sdr["FileName"].ToString();
                doc.FileUrl = sdr["FileUrl"].ToString();
                doc.FileDesc = sdr["FileDesc"].ToString();
                doc.FileUpDate = sdr["FileUpDate"].ToString();
                doc.TypeID = sdr["TypeID"].ToString();
                doc.TypeName = sdr["TypeName"].ToString();
                doc.UploadName = sdr["UploadName"].ToString();
                return doc;
            }
            else
            {
                return null;
            }
                
        }

        public int AddDoc(Doc doc)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@Title",doc.Title);
            db.AddParameter("@FileName",doc.FileName);
            db.AddParameter("@FileUrl", doc.FileUrl);
            db.AddParameter("@FileDesc", doc.FileDesc);
            db.AddParameter("@FileUpDate",doc.FileUpDate);
            db.AddParameter("@TypeID", doc.TypeID);
            db.AddParameter("@TypeName", doc.TypeName);
            db.AddParameter("@UploadName", doc.UploadName);
            string sql = "insert into Document(Title,FileName,FileUrl,FileDesc,FileUpDate,TypeID,TypeName,UploadName) values(@Title,@FileName,@FileUrl,@FileDesc,@FileUpDate,@TypeID,@TypeName,@UploadName)";

            return db.ExecuteNonQuery(sql);
        }

        //编辑信息
        public int UpdateDoc(Doc doc)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@ID", doc.ID);
            db.AddParameter("@Title", doc.Title);
            db.AddParameter("@FileName", doc.FileName);
            db.AddParameter("@FileUrl", doc.FileUrl);
            db.AddParameter("@FileDesc", doc.FileDesc);
            db.AddParameter("@FileUpDate", doc.FileUpDate);
            db.AddParameter("@TypeID", doc.TypeID);
            db.AddParameter("@TypeName", doc.TypeName);
            db.AddParameter("@UploadName", doc.UploadName);
            string sql = "update Document set Title = @Title,FileName = @FileName ,FileUrl=@FileUrl,FileDesc= @FileDesc,FileUpDate = @FileUpDate,TypeID = @TypeID,TypeName=@TypeName,UploadName = @UploadName where ID=@ID ";
            return db.ExecuteNonQuery(sql);
        }

        //获得当前页的新闻信息列表
        public List<Doc> ListPageDoc(int pageno, int pagesize)
        {
            List<Doc> docLists = new List<Doc>();
            int rowcount = this.GetTotalRecordNum();
            string sql;


            DBConnection db = new DBConnection();

            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID desc) as rownum ,* from Document) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID desc) as rownum, * from Document) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                Doc doc = new Doc();

                doc.ID = sdr["ID"].ToString();
                doc.Title = sdr["Title"].ToString();
                doc.FileName = sdr["FileName"].ToString();
                doc.FileUrl = sdr["FileUrl"].ToString();
                doc.FileDesc = sdr["FileDesc"].ToString();
                doc.FileUpDate = sdr["FileUpDate"].ToString();
                doc.TypeID = sdr["TypeID"].ToString();
                doc.TypeName = sdr["TypeName"].ToString();
                doc.UploadName = sdr["UploadName"].ToString();
                docLists.Add(doc);
            }
            db.Dispose();
            return docLists;
        }

        //获得当前页的新闻信息列表
        public List<Doc> ListPageDoc(int pageno, int pagesize,string typeid)
        {
            List<Doc> docLists = new List<Doc>();
            int rowcount = this.GetTotalRecordNum();
            string sql;
            int tid = int.Parse(typeid);

            DBConnection db = new DBConnection();

            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID) as rownum ,* from Document where TypeID='"+tid+"') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID) as rownum, * from Document where TypeID='" + tid + "')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                Doc doc = new Doc();

                doc.ID = sdr["ID"].ToString();
                doc.Title = sdr["Title"].ToString();
                doc.FileName = sdr["FileName"].ToString();
                doc.FileUrl = sdr["FileUrl"].ToString();
                doc.FileDesc = sdr["FileDesc"].ToString();
                doc.FileUpDate = sdr["FileUpDate"].ToString();
                doc.TypeID = sdr["TypeID"].ToString();
                doc.TypeName = sdr["TypeName"].ToString();
                doc.UploadName = sdr["UploadName"].ToString();
                docLists.Add(doc);
            }
            db.Dispose();
            return docLists;
        }

        public int GetTotalRecordNum()
        {

            DBConnection db = new DBConnection();
            string sql = "select count(*) as a from Document";

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
}
