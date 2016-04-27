using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;

public partial class Webmag_Employe_infoManage_room_DeletePageInfo : System.Web.UI.Page
{
    protected int pageno;
    protected int size;
    protected int flag;

    protected string scope = "";
    protected string buildName = "";
    protected string keyword = "";

    protected Room room = new Room();
    protected RoomDAO roomDAO = new RoomDAO();

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
                Response.Redirect("ViewRoom.aspx?pageno=" + pageno + "&scope=" + scope + "&keyword=" + keyword + "&buildName=" + buildName + "");
            }
            else
            {
                //删除单条记录
                if (Request["id"] != null)
                {
                    roomDAO = new RoomDAO();

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
                    //当删除的是最后一页，且最后一页只有一个数据
                    if (pagecount == pageno && a == 1)
                    {
                        if (pageno != 1)
                            pageno--;
                    }

                    flag = roomDAO.deleteRoom(int.Parse(id));
                    RedirectPage();

                }
                //删除多条记录
                else
                {

                    size = int.Parse(Request["size"]);
                    pageno = int.Parse(Request["page"]);

                    string ids = Request["selectDel"];
                    char[] separtor = { ',' };
                    string[] idArray = ids.Split(separtor);




                    roomDAO = new RoomDAO();

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

                    //判断是否是最后一页,且全部删除
                    if (pagecount == pageno && (idArray.Length == a || idArray.Length == size))
                    {
                        if (pageno != 1)
                            pageno--;
                    }

                    for (int i = 0; i < idArray.Length; i++)
                    {

                        flag = roomDAO.deleteRoom(int.Parse(idArray[i]));

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

        if (flag > 0)
        {

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除成功!');location.href=('ViewRoom.aspx?pageno=" + pageno + " &scope=" + scope + "&keyword=" + keyword + "&buildName="+buildName+"');</script>");
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除失败!');history.go(-1);</script>");

        }

    }


}