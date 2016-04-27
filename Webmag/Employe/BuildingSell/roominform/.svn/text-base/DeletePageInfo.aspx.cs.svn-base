using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe.RoomInformation;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;

public partial class Webmag_Employe_BuildingSell_roominform_DeletePageInfo : System.Web.UI.Page
{
    protected int pageno;
    protected int size;
    protected int flag;
    protected bool isDeleteOrAdd;
    protected string scope = "";
    protected string buildName = "";
    protected string keyword = "";

    protected Room room = new Room();
    protected RoomInfoDAO roomDAO = new RoomInfoDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            if (Request["scope"].ToString() != "" && Request["scope"].ToString() != null)
                scope = Request["scope"].Trim();
            if (Request["buildName"].ToString() != "" && Request["buildName"].ToString() != null)
                buildName = Request["buildName"].Trim();
            if (Request["keyword"].ToString() != "" && Request["keyword"].ToString() != null)
                keyword = Request["keyword"].Trim();

            //进行页面跳转
            if (Request.Form["pageno"] != null)
            {
                string page = Request.Form["pageno"].Trim();
                pageno = int.Parse(page);
                Response.Redirect("ViewRoomInformation.aspx?pageno=" + pageno + "&scope=" + scope + "&keyword=" + keyword + "&buildName=" + buildName + "");
            }
            else
            {
                //更新单条记录
                if (Request["id"] != null)
                {
                    roomDAO = new RoomInfoDAO();

                    int pagesize = int.Parse(Request["pagesize"]);
                    pageno = int.Parse(Request["pageno"]);
                    string id = Request["id"];

                    //总页数的计算
                    int rowcount = int.Parse(Request["rowcount"]);

                    int a = rowcount % pagesize;
                    int pagecount;

                    if (a == 0)
                    {
                        if (rowcount == 0)
                            pagecount = 1;
                        else
                            pagecount = rowcount / pagesize;
                    }
                    else
                        pagecount = rowcount / pagesize + 1;

                    if (Request["action"].Trim() == "add")
                    {
                        flag = roomDAO.UpdateRoomById(id, true);
                        isDeleteOrAdd = true;
                    }
                    else if (Request["action"].Trim() == "delete")
                    {
                        flag = roomDAO.UpdateRoomById(id, false);
                        isDeleteOrAdd = false;
                    }
                    RedirectPage();

                }
                //更新多条记录
                else
                {

                    size = int.Parse(Request["size"]);
                    pageno = int.Parse(Request["page"]);

                    string ids = Request["selectDel"];
                    char[] separtor = { ',' };
                    //未添加房源、未删除房源
                    if (ids == null || ids == "")
                    {
                        //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('您还未选择任何项!');</script>");
                        Response.Redirect("ViewRoomInformation.aspx?pageno=" + pageno + "&scope=" + scope + "&keyword=" + keyword + "&buildName=" + buildName + "");
                    }
                    string[] idArray = ids.Split(separtor);


                    roomDAO = new RoomInfoDAO();

                    //计算总页数
                    int pagecount, a;
                    int rowcount = int.Parse(Request["rowcount"]);
                    a = rowcount % size;
                    if (a == 0)
                    {
                        if (rowcount == 0)
                            pagecount = 1;
                        else
                            pagecount = rowcount / size;
                    }
                    else
                        pagecount = rowcount / size + 1;

                    for (int i = 0; i < idArray.Length; i++)
                    {

                        if (Request["action"].Trim() == "add")
                        {
                            flag = roomDAO.UpdateRoomById(idArray[i], true);
                            isDeleteOrAdd = true;
                        }
                        else if (Request["action"].Trim() == "delete")
                        {
                            flag = roomDAO.UpdateRoomById(idArray[i], false);
                            isDeleteOrAdd = false;
                        }
                        if (flag <= 0)
                            break;

                    }

                    RedirectPage();

                }
            }
        }
    }


    private void RedirectPage()
    {
        string temp = "删除";
        if (isDeleteOrAdd)
        {
            temp = "添加";
        }
        if (flag > 0)
        {

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('"+temp+"房源新成功!');location.href=('ViewRoomInformation.aspx?pageno=" + pageno + " &scope=" + scope + "&keyword=" + keyword + "&buildName=" + buildName + "');</script>");
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('"+temp+"房源信息失败!');history.go(-1);</script>");

        }

    }
}