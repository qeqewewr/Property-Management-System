using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe.Survey;
using CEMIS.Util;

public partial class Webmag_Employe_surveyManage_surveyQuestionAdd : System.Web.UI.Page
{
    public Survey survey = new Survey();

    public SurveyQuestion surveyQuestion = new SurveyQuestion();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
        else
        {
            if (Request.HttpMethod == "POST")
            {
                int result, result2;
                surveyQuestion.PID = Request.Form["pid"].ToString();
                surveyQuestion.Question = Request.Form["question"].ToString();
                surveyQuestion.AnswerA = Request.Form["answerA"].ToString();
                surveyQuestion.AnswerB = Request.Form["answerB"].ToString();
                surveyQuestion.AnswerC = Request.Form["answerC"].ToString();
                surveyQuestion.AnswerD = Request.Form["answerD"].ToString();
                Survey s = (new SurveyDAO()).GetSurvey(surveyQuestion.PID);
                if (s != null) survey = s;
                if (Request["id"] != null && Request["id"].ToString().Trim() != "")
                {
                    surveyQuestion.ID = Request["id"].ToString().Trim();
                    DBConnection db = new DBConnection();
                    string sql = "select count(*) as a from QuestionnaireItem where PID='" + surveyQuestion.PID + "' and Question='" + surveyQuestion.Question + "' and ID !='" + surveyQuestion.ID + "'";
                    int count = 0;
                    SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

                    while (sdr.Read())
                    {
                        count = int.Parse(sdr["a"].ToString());
                    }
                    db.Dispose();
                    if (count > 0)
                    {
                        Response.Write("<script>alert('重新编辑的问题与原有问题重复')</script>");
                    }
                    else
                    {
                        result = (new SurveyQuestionDAO()).UpdateSurveyQuestion(surveyQuestion);
                        if (result > 0)
                        {
                            Response.Write("<script>alert('编辑成功')</script>");
                            Response.Write("<script>window.location.href='surveyQuestionView.aspx?pid=" + survey.ID + "'</script>");
							//Response.Write("<script>history.go(-1)</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('编辑失败')</script>");

                        }
                    }
                }
                else
                {
                    DBConnection db = new DBConnection();
                    string sql = "select count(*) as a from QuestionnaireItem where PID='" + surveyQuestion.PID + "' and Question='" + surveyQuestion.Question + "'";
                    int count = 0;
                    SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

                    while (sdr.Read())
                    {
                        count = int.Parse(sdr["a"].ToString());
                    }
                    db.Dispose();


                    if (count == 0)
                    {
                        if (Request["id"] != null && Request["id"].ToString() != "")
                        {
                            surveyQuestion.ID = Request["id"].ToString();
                            result = (new SurveyQuestionDAO()).UpdateSurveyQuestion(surveyQuestion);
                            result2 = 1;
                        }
                        else
                        {
                            result = (new SurveyQuestionDAO()).AddSurveyQuestion(surveyQuestion);
                            string sql2 = "select top 1 ID from QuestionnaireItem where Question='" + surveyQuestion.Question + "' and PID='" + surveyQuestion.PID + "' order by ID desc";
                            db = new DBConnection();
                            sdr = (SqlDataReader)db.ExecuteReader(sql2);
                            if (sdr.Read())
                            {
                                SurveyAnswer sa = new SurveyAnswer();
                                sa.ID = sdr["ID"].ToString();
                                sa.PID = surveyQuestion.PID;
                                sa.AnswerANum = "0";
                                sa.AnswerBNum = "0";
                                sa.AnswerCNum = "0";
                                sa.AnswerDNum = "0";
                                result2 = (new SurveyAnswerDAO()).AddSurveyAnswer(sa);
                            }
                            else
                            {
                                result2 = 0;
                            }
                            db.Dispose();

                        }

                        if (result > 0 && result2 > 0)
                        {
                            surveyQuestion = new SurveyQuestion();
                            surveyQuestion.PID = survey.ID;
                            Response.Write("<script>alert('编辑成功')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('编辑失败，请重试')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('问题不能重复，请重新输入')</script>");
                    }
                    db.Dispose();
                }


            }
            else if (Request["id"] != null && Request["id"].ToString() != "")
            {

                SurveyQuestion sQ = (new SurveyQuestionDAO()).GetSurveyQuestion(Request["id"].ToString().Trim());
                if (sQ != null)
                {
                    string pid = sQ.PID;
                    Survey s = (new SurveyDAO()).GetSurvey(pid);
                    if (s != null)
                    {
                        survey = s;
                        surveyQuestion = sQ;
                    }
                }
            }
            else if (Request["pid"] != null && Request["pid"].ToString() != "")
            {
                surveyQuestion.PID = Request["pid"].ToString().Trim();
                Survey s = (new SurveyDAO()).GetSurvey(surveyQuestion.PID);
                if (s != null)
                    survey = s;
            }
        }
    }
}