using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEMIS.Model.Employe.Survey
{
    /// <summary>
    ///调查问卷的模型
    /// </summary>
    /// 
    public class Survey
    {
        private string _id;
        private string _name;
        private string _desc;
        private string _addtime;
        private string _deadline;
        //private List<SurveyQuestion> _surveyQustions;

        public Survey()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public string ID
        {
            set {_id = value; }
            get { return _id; }
        }

        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public string Addtime
        {
            set { _addtime = value; }
            get {return _addtime; }
        }

        public string Deadline
        {
            set { _deadline = value; }
            get { return _deadline; }
        }
        public string Desc
        {
            set { _desc = value; }
            get { return _desc; }
        }

        //public List<SurveyQuestion> SurveyQuestion
        //{
        //    set { SurveyQuestion = value; }
        //    get {return _surveyQustions; }
        //}
    }

    public class SurveyQuestion
    {
        private string _pid;
        private string _id;
        private string _question;
        private string _answerA;
        private string _answerB;
        private string _answerC;
        private string _answerD;
  
        public SurveyQuestion()
        {
 
        }

        public string PID
        {
            get { return _pid; }
            set { _pid = value; }
        }

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Question
        {
            get { return _question; }
            set { _question = value; }
        }

        public string AnswerA
        {
            get { return _answerA; }
            set { _answerA = value; }
        }
        public string AnswerB
        {
            get { return _answerB; }
            set { _answerB = value; }
        }
        public string AnswerC
        {
            get { return _answerC; }
            set { _answerC = value; }
        }
        public string AnswerD
        {
            get { return _answerD; }
            set { _answerD = value; }
        }

    }

    public class SurveyAnswer
    {
        private string _pid;
        private string _id;
		private string _answerANum;
        private string _answerBNum;
        private string _answerCNum;
        private string _answerDNum;

        public SurveyAnswer()
        {
			_answerANum = "0";
			_answerBNum = "0";
			_answerCNum = "0";
			_answerDNum = "0";
        }

        public string PID
        {
            get { return _pid; }
            set { _pid = value; }
        }

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string AnswerANum
        {
            get { return _answerANum; }
            set { _answerANum = value; }
        }

        public string AnswerBNum
        {
            get { return _answerBNum; }
            set { _answerBNum = value; }
        }

        public string AnswerCNum
        {
            get { return _answerCNum; }
            set { _answerCNum = value; }
        }

        public string AnswerDNum
        {
            get { return _answerDNum; }
            set { _answerDNum = value; }
        }
    }
}