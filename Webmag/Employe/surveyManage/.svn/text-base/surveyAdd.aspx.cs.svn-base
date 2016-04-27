using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Util;
using CEMIS.Model.Employe.Survey;

public partial class Webmag_Employe_surveyManage_surveyAdd : System.Web.UI.Page
{
    private string _id;
    private string _name;
    private string _addtime;
    private string _deadline;
    private string _desc;

    public string ID
    {
        get { return _id; }
    }

    public string Name
    {
        get { return _name; }
    }

    public string Deadline
    {
        get { return _deadline; }
    }

    public string Desc
    {
        get { return _desc; }
    }

    public string AddTime
    {
        get { return _addtime; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
        else
        {
            if (Request.HttpMethod == "POST")
            {
                _name = Request.Form["title"].ToString().Trim();
                DateTime dt = DateTime.Now;
                try
                {
                    if (Request.Form["endtime"] != null && Request.Form["endtime"].ToString().Trim() != "")
                        _deadline = DateTime.Parse(Request.Form["endtime"].ToString().Trim()).ToString("yyyy-MM-dd hh:mm:ss");
                    else
                        _deadline = dt.ToString("yyyy-MM-dd hh:mm:ss");

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('请输入正确的日期格式')</script>");
                    Response.Write("<script>window.location.href='surveyAdd.aspx'</script>");
                    Response.End();
                }

                _addtime = dt.ToString("yyyy-MM-dd hh:mm:ss");

                _desc = Request.Form["desc"].ToString();

                DBConnection db = new DBConnection();
                int result;
                if (Request["id"] != null && Request["id"].ToString() != "")
                {
                    Survey survey = new Survey();
                    survey.ID = Request["id"].ToString();
                    survey.Name = _name;
                    survey.Desc = _desc;
                    survey.Addtime = _addtime;
                    survey.Deadline = _deadline;
                    result = (new SurveyDAO()).UpdateSurvey(survey);
                }
                else
                {
                    db.AddParameter("@Name", _name);
                    db.AddParameter("@Desc", _desc);
                    db.AddParameter("@Deadline", _deadline);
                    db.AddParameter("@AddTime", _addtime);
                    string sql = "insert into Questionnaire(Name,Description,AddTime,Deadline) values(@Name,@Desc,@AddTime,@Deadline)";
                    result = db.ExecuteNonQuery(sql);
                }


                if (result > 0)
                {
                    Response.Write("<script>alert('保存成功!')</script>");
                    _name = "";
                    _addtime = "";
                    _deadline = "";
                    _desc = "";
                    _id = "";

                    Response.Write("<script>window.location.href = 'surveyView.aspx';</script>");

                }

                else
				{
                    Response.Write("<script>alert('保存失败!')</script>");
				}
				
            }
            else
            {
                string id = Request["id"];
                if (id != null && id.ToString().Trim() != "")
                {
                    SurveyDAO s = new SurveyDAO();
                    Survey survey = s.GetSurvey(id);
                    if (survey != null)
                    {
                        _id = survey.ID;
                        _name = survey.Name;
                        _desc = survey.Desc;
                        _deadline = DateTime.Parse(survey.Deadline).ToString("yyyy/MM/dd"); ;
                    }

                }
            }
        }
    }
}