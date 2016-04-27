using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.BLL;

public partial class Webmag_Employe_earlypre_orderremove_DeletePageInfo : System.Web.UI.Page
{
    protected string pageName = "ViewOrderRemove.aspx";
    protected OrderMoveInDAO orderMoveInDAO;
    protected int pageno;
    protected int flag;
    protected List<OrderMoveIn> orderlist;
    protected PageBLL pageBLL = new PageBLL();

    public string action;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            string keyword = "";
            if (Request.Form["keyword"] != "" && Request.Form["keyword"] != null)
                keyword = Request.Form["keyword"].Trim();
            orderMoveInDAO = new OrderMoveInDAO();
            //表的总记录数
            //    int recordNum = orderMoveInDAO.GetTotalRecordNum();
            int recordNum = int.Parse(Request["rowcount"]);
            //进行页面跳转
            if (Request.Form["pageno"] != null)
            {
                
                string page = Request.Form["pageno"].Trim();
                pageno = int.Parse(page);
               
                action = (Request["action"] != null && Request["action"].ToString().Trim() != "") ? Request["action"].ToString().Trim() : "all";
                if (action == "all")
                {
                    Response.Redirect(pageName + "?pageno=" + pageno + "&keyword=" + keyword + "");
                }
                else
                    Response.Redirect(pageName + "?pageno=" + pageno + "&keyword=" + keyword + "&action=" + action + "");
                //Response.Redirect(pageName + "?pageno=" + pageno + "&keyword=" + keyword + "");
            }
            else
            {
                string id = Request["id"];
                //删除单条记录
                if (id != null)
                {
                    int pagesize = int.Parse(Request["pagesize"]);
                    pageno = int.Parse(Request["pageno"]);
                    pageno = pageBLL.CheckBoxDeleteOneRecord(pagesize, pageno, recordNum);
                    flag = orderMoveInDAO.DeleteOrderMoveInById(id);//------------- 11

                }
                else //删除多条记录
                {
                    int size = int.Parse(Request["size"]);
                    pageno = int.Parse(Request["page"]);
                    string ids = Request["selectDel"];
                    char[] separtor = { ',' };
                    if (ids == null || ids == "")
                    {
                        action = (Request["action"] != null && Request["action"].ToString().Trim() != "") ? Request["action"].ToString().Trim() : "all";
                        if (action == "all")
                        {
                            Response.Redirect(pageName + "?pageno=" + pageno + "&keyword=" + keyword + "");
                        }
                        else
                            Response.Redirect(pageName + "?pageno=" + pageno + "&keyword=" + keyword + "&action=" + action + "");
                    }
                    string[] idArray = ids.Split(separtor);

                    pageno = pageBLL.CheckBoxDeleteRecord(size, pageno, recordNum, idArray.Length);
                    for (int i = 0; i < idArray.Length; i++)
                    {
                        flag = orderMoveInDAO.DeleteOrderMoveInById(idArray[i]);//----------------------22
                        if (flag <= 0)
                            break;

                    }
                }
                //pageBLL.RedirectPage(this, pageName, flag, pageno, 0);
                action = (Request["action"] != null && Request["action"].ToString().Trim() != "") ? Request["action"].ToString().Trim() : "all";
                if (action == "all")
                {
                    pageBLL.RedirectPage(this, pageName, flag, pageno, 0);
                }
                else
                {
                    pageName += "?action=" + action;
                    pageBLL.RedirectPage(this, pageName, flag, pageno, 0);
                }
            }
        }
    }
}