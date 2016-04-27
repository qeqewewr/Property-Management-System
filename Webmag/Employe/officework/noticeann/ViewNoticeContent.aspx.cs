using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;

public partial class Webmag_Employe_officework_noticeann_ViewNotice : System.Web.UI.Page
{
    //租户费用
    public NoticeDAO noticeDAO = new NoticeDAO();

    public MyNoticeDAO mynoticeDAO = new MyNoticeDAO();

    public string content= "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            Notice n = new Notice();
            MyNotice myn = new MyNotice();
            if (Request["id"] != null && Request["id"].ToString().Trim() != "" )
            {   /*
            string read;
            if(Request["read"] != null && Request["read"].ToString().Trim() != "")
                read = Request["read"].ToString().Trim();
            else
                read = "0";
            */
                if (Request["myid"] != null && Request["myid"].ToString().Trim() != "")
                {
                    string id = int.Parse(Request["id"].ToString().Trim()).ToString();
                    string myid = int.Parse(Request["myid"].ToString().Trim()).ToString();
                    n = noticeDAO.GetNotice(id);
                    myn = mynoticeDAO.GetMyNotice(myid);
                    content = n.NoticeContent;
                    if (myn.IsRead == "0" || true)
                    {
                        mynoticeDAO.ReadMyNotice(myid);
                        string uncheckroom = myn.ToBuilding.Trim() + myn.ToRoom.Trim();

                        string[] uncheckrooms = n.UncheckedRooms.Split(',');
                        if (uncheckrooms.Length > 0)
                        {
                            int index = Array.IndexOf<string>(uncheckrooms, uncheckroom);

                            if (index != -1)
                            {
                                string newuncheckrooms = "";
                                for (int i = 0; i < uncheckrooms.Length; i++)
                                {
                                    if (i == index) continue;
                                    if (newuncheckrooms != "" && i > 0) newuncheckrooms += ",";
                                    newuncheckrooms += uncheckrooms[i];
                                }
                                n.UncheckedRooms = newuncheckrooms;
                                noticeDAO.UpdateNotice(n);
                            }
                        }
                    }
                }
                else
                {
                    string id = int.Parse(Request["id"].ToString().Trim()).ToString();
  
                    n = noticeDAO.GetNotice(id);

                    content = n.NoticeContent;
            
                }










            }
        }
    }
}