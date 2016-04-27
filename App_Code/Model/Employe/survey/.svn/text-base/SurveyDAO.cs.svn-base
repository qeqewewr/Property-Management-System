using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CEMIS.Util;

namespace CEMIS.Model.Employe.Survey
{
    /// <summary>
    ///SurveyDAO 的摘要说明
    /// </summary>
    public class SurveyDAO
    {
	    public SurveyDAO()
	    {
		    //
		    //TODO: 在此处添加构造函数逻辑
		    //
	    }

        public Survey GetSurvey(string id)
        {
            Survey survey = new Survey();
            DBConnection db = new DBConnection();
            string sql = "select * from Questionnaire where ID='"+id+"'";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            if(sdr.Read())
            {
                survey.ID = sdr["ID"].ToString();
                survey.Name = sdr["Name"].ToString();
                survey.Desc = sdr["Description"].ToString();
                survey.Addtime = sdr["AddTime"].ToString();
                survey.Deadline = sdr["Deadline"].ToString();
                return survey;
            }
            else
                return null;
        }

        public int AddSurvey(Survey survey)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@Name", survey.Name);
            db.AddParameter("@Desc", survey.Desc);
            db.AddParameter("@Deadline", survey.Deadline);
            db.AddParameter("@AddTime", survey.Addtime);

            string sql = "insert into Questionnaire(Name,Description,AddTime,Deadline) values(@Name,@Desc,@AddTime,@Deadline)";

            return db.ExecuteNonQuery(sql);
        }

        //编辑信息
        public int UpdateSurvey(Survey survey)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@ID", survey.ID);
            db.AddParameter("@Name", survey.Name);
            db.AddParameter("@Desc", survey.Desc);
            db.AddParameter("@Deadline", survey.Deadline);
            db.AddParameter("@AddTime", survey.Addtime);

            string sql = "update Questionnaire set Name=@Name,Description=@Desc,AddTime=@AddTime,Deadline=@Deadline where ID=@ID ";

            return db.ExecuteNonQuery(sql);
        }

        //获得当前页的新闻信息列表
        public List<Survey> ListPageSurvey(int pageno, int pagesize)
        {
            List<Survey> SurveyList = new List<Survey>();
            int rowcount = this.GetTotalRecordNum();
            string sql;


            DBConnection db = new DBConnection();

            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID desc) as rownum ,* from Questionnaire) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID desc) as rownum, * from Questionnaire)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                Survey survey = new Survey();
                survey.ID = sdr["ID"].ToString();
                survey.Name = sdr["Name"].ToString();
                survey.Desc = sdr["Description"].ToString();
                survey.Addtime = sdr["AddTime"].ToString();
                survey.Deadline = sdr["Deadline"].ToString();

                SurveyList.Add(survey);
            }
            db.Dispose();
            return SurveyList;
        }

        public int GetTotalRecordNum()
        {

            DBConnection db = new DBConnection();
            string sql = "select count(*) as a from Questionnaire";

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