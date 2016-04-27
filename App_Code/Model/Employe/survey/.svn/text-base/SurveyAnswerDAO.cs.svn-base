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
    ///SurveyAnswerDAO 的摘要说明
    /// </summary>
    public class SurveyAnswerDAO
    {
        public SurveyAnswerDAO()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public int AddSurveyAnswer(SurveyAnswer sa)
        {

            DBConnection db = new DBConnection();

            db.AddParameter("@PID", sa.PID);
            db.AddParameter("@ID", sa.ID);
            db.AddParameter("@AnswerANum", sa.AnswerANum);
            db.AddParameter("@AnswerBNum", sa.AnswerBNum);
            db.AddParameter("@AnswerCNum", sa.AnswerCNum);
            db.AddParameter("@AnswerDNum", sa.AnswerDNum);

            string sql = "insert into QuestionnaireAnswer(ID,PID,ANum,BNum,CNum,DNum) values(@ID,@PID,@AnswerANum,@AnswerBNum,@AnswerCNum,@AnswerDNum)";

            return db.ExecuteNonQuery(sql);
        }

        public int UpdateSurveyAnswer(SurveyAnswer sa)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@ID", sa.ID);
            db.AddParameter("@AnswerANum", sa.AnswerANum);
            db.AddParameter("@AnswerBNum", sa.AnswerBNum);
            db.AddParameter("@AnswerCNum", sa.AnswerCNum);
            db.AddParameter("@AnswerDNum", sa.AnswerDNum);

            string sql = "update QuestionnaireAnswer set ANum= ANum + @AnswerANum,BNum= BNum + @AnswerBNum,CNum= CNum + @AnswerCNum,DNum= DNum + @AnswerDNum where ID=@ID ";

            return db.ExecuteNonQuery(sql);
        }

        public List<SurveyAnswer> ListPageSurveyAnswer(int pageno, int pagesize, string pid)
        {
            List<SurveyAnswer> SqList = new List<SurveyAnswer>();
            int rowcount = this.GetTotalRecordNum(pid);
            string sql;


            DBConnection db = new DBConnection();

            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID) as rownum ,* from QuestionnaireAnswer where PID='" + pid + "') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID) as rownum, * from QuestionnaireAnswer where PID='" + pid + "')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
            SurveyAnswer sa;
            while (sdr.Read())
            {
                sa = new SurveyAnswer();
                sa.ID = sdr["ID"].ToString();
                sa.PID = sdr["PID"].ToString();
                sa.AnswerANum = sdr["ANum"].ToString();
                sa.AnswerBNum = sdr["BNum"].ToString();
                sa.AnswerCNum = sdr["CNum"].ToString();
                sa.AnswerDNum = sdr["DNum"].ToString();

                SqList.Add(sa);
            }
            db.Dispose();
            return SqList;
        }

        public int GetTotalRecordNum(string pid)
        {

            DBConnection db = new DBConnection();
            string sql = "select count(*) as a from QuestionnaireAnswer where PID='" + pid + "'";

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
