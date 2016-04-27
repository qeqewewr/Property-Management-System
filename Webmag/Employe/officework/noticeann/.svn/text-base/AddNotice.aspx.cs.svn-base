using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Util;


public partial class Webmag_Employe_tabledoc_uploaddoc_DocumentAdd : System.Web.UI.Page
{
    public Notice notice = new Notice();
    public List<NoticeType> noticetypelist = new List<NoticeType>();
    public NoticeTypeDAO noticetypedao = new NoticeTypeDAO();
    public NoticeDAO noticeDAO = new NoticeDAO();
    public List<MyNotice> mynoticelist = new List<MyNotice>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            noticetypelist = noticetypedao.ListNoticeType();
            if (Request.HttpMethod == "POST")
            {
                notice.Publisher = Request["publisher"].ToString().Trim();
                notice.PublishDate = DateTime.Parse(Request["publishDate"].ToString().Trim()).ToString("yyyy-MM-dd"); ;
                notice.NoticeType = Request["noticetype"].ToString().Trim();
                notice.NoticeTypeID = Request["noticetypeid"].ToString().Trim();
                notice.NoticeContent = Request["content"].ToString().Trim();
                notice.Rooms = Request["rooms"].ToString().Trim();
                notice.UncheckedRooms = notice.Rooms;

                if (Request["id"] != null && Request["id"].ToString().Trim() != "")
                {
                    notice.ID = Request["id"].ToString().Trim();
                    int result = noticeDAO.UpdateNotice(notice);
                    if (result > 0)
                    {
                        Response.Write("<script>alert('编辑成功！')</script>");
                        notice = new Notice();
                    }
                    else
                    {
                        Response.Write("<script>alert('编辑失败！')</script>");
                    }
                }
                else
                {
                    int result = noticeDAO.AddNotice(notice);
                    string noticeid = GetLatestNoticeID();
                    string[] builds = Request.Form["builds"].ToString().Trim().Split(',');
                    for (int i = 0; i < builds.Length; i++)
                    {
						string building = builds[i];
                        string[] rooms = Request.Form[builds[i]].ToString().Trim().Split(',');
                        for (int j = 0; j < rooms.Length; j++)
                        {

							string room = rooms[j];

                            MyNotice mynotice = new MyNotice();
							mynotice.Lessee = GetLesseeByRoom(building,room);
                            mynotice.IsRead = "0";
                            mynotice.NoticeID = noticeid;
                            mynotice.ToBuilding = builds[i];
                            mynotice.ToRoom = rooms[j];
                            mynoticelist.Add(mynotice);
                        }
                    }
                    int result2 = (new MyNoticeDAO()).AddMyNotice(mynoticelist);
                    if (result > 0 && result2 > 0)
                    {
                        Response.Write("<script>alert('保存成功！')</script>");
                        notice = new Notice();
                    }
                    else
                    {
                        Response.Write("<script>alert('保存失败！')</script>");
                    }
                }



            }
            else
            {
                if (Request["id"] != null && Request["id"].ToString().Trim() != "")
                {
                    Notice d = noticeDAO.GetNotice(Request["id"].ToString().Trim());
                    if (d != null) notice = d;
                }


            }
        }
    }

    public string GetLatestNoticeID()
    {
        DBConnection db = new DBConnection();
        string sql = "select top(1) ID from Notice order by ID desc";
        string _id;
        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        if (sdr.Read())
        {
            _id = sdr["ID"].ToString();
            return _id;
        }
        else
        {
            return null;
        }
    }

	public string GetLesseeByRoom(string building,string room)
	{
		DBConnection db = new DBConnection();
		string sql = "select Lessee from Room where BuildingName='"+building+"' and Number='"+room +"'";
		DataSet ds = db.ExecuteDataSet(sql);
		return ds.Tables[0].Rows[0][0].ToString();
	}
}