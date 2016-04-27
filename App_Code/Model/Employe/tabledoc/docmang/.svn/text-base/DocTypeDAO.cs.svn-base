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
    ///DocTypeTypeDAO 的摘要说明
    /// </summary>
    public class DocTypeDAO
    {
        public DocTypeDAO()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public DocType GetDocType(string id)
        {
            DocType docType = new DocType();
            DBConnection db = new DBConnection();
            string sql = "select * from DocumentType where ID='" + id + "'";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            if (sdr.Read())
            {
                docType.ID = sdr["ID"].ToString().Trim();
                docType.Name = sdr["Name"].ToString().Trim();
          //      docType.Description = sdr["Description"].ToString().Trim();

                return docType;
            }
            else
                return null;
        }

        public int AddDocType(DocType docType)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@Name", docType.Name);
          //  db.AddParameter("@Description", docType.Description);

            string sql = "insert into DocumentType(Name) values(@Name)";

            return db.ExecuteNonQuery(sql);
        }

        //编辑信息
        public int UpdateDocType(DocType docType)
        {
            DBConnection db = new DBConnection();
            db.AddParameter("@ID", docType.ID);
            db.AddParameter("@Name", docType.Name);
           // db.AddParameter("@Description", docType.Description);

            string sql = "update DocumentType set Name=@Name where ID=@ID ";
            return db.ExecuteNonQuery(sql);
        }

        //获得当前页的新闻信息列表
        public List<DocType> ListPageDocType(int pageno, int pagesize)
        {
            List<DocType> docTypeLists = new List<DocType>();
            int rowcount = this.GetTotalRecordNum();
            string sql;


            DBConnection db = new DBConnection();

            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID) as rownum ,* from DocumentType) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID) as rownum, * from DocumentType)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                DocType DocType = new DocType();
                DocType.ID = sdr["ID"].ToString().Trim();
                DocType.Name = sdr["Name"].ToString().Trim();
             //   DocType.Description = sdr["Description"].ToString().Trim();

                docTypeLists.Add(DocType);
            }
            db.Dispose();
            return docTypeLists;
        }

        public List<DocType> ListPageDocType()
        {
            List<DocType> docTypeLists = new List<DocType>();
            int rowcount = this.GetTotalRecordNum();
            string sql;


            DBConnection db = new DBConnection();

            sql = "select * from DocumentType";
            //if (pageno * pagesize > rowcount)
            //    sql = "with temp as( select row_number() over(order by ID) as rownum ,* from DocumentType) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            //else
            //    sql = "with temp as( select row_number() over(order by ID) as rownum, * from DocumentType)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                DocType DocType = new DocType();
                DocType.ID = sdr["ID"].ToString().Trim();
                DocType.Name = sdr["Name"].ToString().Trim();
             //   DocType.Description = sdr["Description"].ToString().Trim();

                docTypeLists.Add(DocType);
            }
            db.Dispose();
            return docTypeLists;
        }

        public int GetTotalRecordNum()
        {

            DBConnection db = new DBConnection();
            string sql = "select count(*) as a from DocumentType";

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