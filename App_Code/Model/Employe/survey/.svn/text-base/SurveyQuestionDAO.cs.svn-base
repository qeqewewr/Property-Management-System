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
    ///SurveyQuestion 的摘要说明
    /// </summary>
    public class SurveyQuestionDAO
    {
        public SurveyQuestionDAO()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public SurveyQuestion GetSurveyQuestion(string id)
        {
            SurveyQuestion sq = new SurveyQuestion();
            DBConnection db = new DBConnection();
            string sql = "select * from QuestionnaireItem where ID='" + id + "'";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            if (sdr.Read())
            {
                sq.ID = sdr["ID"].ToString();
                sq.PID = sdr["PID"].ToString();
                sq.Question = sdr["Question"].ToString();
                sq.AnswerA = sdr["A"].ToString();
                sq.AnswerB = sdr["B"].ToString();
                sq.AnswerC = sdr["C"].ToString();
                sq.AnswerD = sdr["D"].ToString();
                return sq;
            }
            else
                return null;
        }

        public List<SurveyQuestion> GetSurveyQuestions(string pid)
        {
            List<SurveyQuestion> lists = new List<SurveyQuestion>();
            SurveyQuestion sq;
            DBConnection db = new DBConnection();
            string sql = "select * from QuestionnaireItem where PID='" + pid + "'";
            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            while (sdr.Read())
            {
                sq = new SurveyQuestion();
                sq.ID = sdr["ID"].ToString();
                sq.PID = sdr["PID"].ToString();
                sq.Question = sdr["Question"].ToString();
                sq.AnswerA = sdr["A"].ToString();
                sq.AnswerB = sdr["B"].ToString();
                sq.AnswerC = sdr["C"].ToString();
                sq.AnswerD = sdr["D"].ToString();
                lists.Add(sq);
            }
            return lists;
 
        }

        public int AddSurveyQuestion(SurveyQuestion sq)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@PID", sq.PID);
            db.AddParameter("@Question", sq.Question);
            db.AddParameter("@A", sq.AnswerA);
            db.AddParameter("@B", sq.AnswerB);
            db.AddParameter("@C", sq.AnswerC);
            db.AddParameter("@D", sq.AnswerD);

            string sql = "insert into QuestionnaireItem(PID,Question,A,B,C,D) values(@PID,@Question,@A,@B,@C,@D)";

            return db.ExecuteNonQuery(sql);
        }

        public int UpdateSurveyQuestion(SurveyQuestion sq)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@ID", sq.ID);
            db.AddParameter("@PID", sq.PID);
            db.AddParameter("@Question", sq.Question);
            db.AddParameter("@A", sq.AnswerA);
            db.AddParameter("@B", sq.AnswerB);
            db.AddParameter("@C", sq.AnswerC);
            db.AddParameter("@D", sq.AnswerD);

            string sql = "update QuestionnaireItem set PID=@PID,Question=@Question,A=@A,B=@B,C=@C,D=@D where ID=@ID ";

            return db.ExecuteNonQuery(sql);
        }

        public List<SurveyQuestion> ListPageSurveyQuestion(int pageno, int pagesize,string pid)
        {
            List<SurveyQuestion> SqList = new List<SurveyQuestion>();
            int rowcount = this.GetTotalRecordNum(pid);
            string sql;


            DBConnection db = new DBConnection();

            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID) as rownum ,* from QuestionnaireItem where PID='" + pid + "') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID) as rownum, * from QuestionnaireItem where PID='" + pid + "') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            SurveyQuestion sq;
            while (sdr.Read())
            {
                sq = new SurveyQuestion();
                sq.ID = sdr["ID"].ToString();
                sq.PID = sdr["PID"].ToString();
                sq.Question = sdr["Question"].ToString();
                sq.AnswerA = sdr["A"].ToString();
                sq.AnswerB = sdr["B"].ToString();
                sq.AnswerC = sdr["C"].ToString();
                sq.AnswerD = sdr["D"].ToString();

                SqList.Add(sq);
            }
            db.Dispose();
            return SqList;
        }

        public int GetTotalRecordNum(string pid)
        {

            DBConnection db = new DBConnection();
            string sql = "select count(*) as a from QuestionnaireItem where PID='"+pid+"'";

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

