using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Model.Employe.RoomInformation;
using CEMIS.Util.Page;

public partial class RoomSource : System.Web.UI.Page
{
    public List<Room> roomList = new List<Room>();
    public RoomInfoDAO roomInfo = new RoomInfoDAO();

    public pageForm page = new pageForm();
    public string pageno;

    protected void Page_Load(object sender, EventArgs e)
    {
        pageno = Request["pageno"].ToString();

        page.PageSize=10;
        page.PageNo = int.Parse(pageno);
        page.RowCount = roomInfo.GetScopeTotalNum(1);

        //确定总的页面数
        int a = page.RowCount % page.PageSize;
        if (a == 0)
        {
            if (page.RowCount == 0)
                page.PageCount = 1;
            else
                page.PageCount = page.RowCount / page.PageSize;
        }
        else
            page.PageCount = page.RowCount / page.PageSize + 1;

        roomList = roomInfo.ListPageRoomSource(int.Parse(pageno), page.PageSize);
    }
    //protected void btnFirst_Click(object sender, EventArgs e)
    //{
    //    switch (((LinkButton)sender).CommandArgument.ToString())
    //    {
    //        case "first":
    //            gdvRoomSource.PageIndex = 0;
    //            break;
    //        case "last":
    //            gdvRoomSource.PageIndex = gdvRoomSource.PageCount - 1;
    //            break;
    //        case "prev":
    //            if (gdvRoomSource.PageIndex != 0)
    //            {
    //                gdvRoomSource.PageIndex = gdvRoomSource.PageIndex - 1;
    //            }
    //            break;
    //        case "next":
    //            if (gdvRoomSource.PageIndex != gdvRoomSource.PageCount - 1)
    //            {
    //                gdvRoomSource.PageIndex = gdvRoomSource.PageIndex + 1;
    //            }
    //            break;
    //        case "go":
    //            {
    //                GridViewRow gvr = gdvRoomSource.BottomPagerRow;
    //                TextBox temp = (TextBox)gvr.FindControl("txtNewPageIndex");
    //                int res = Convert.ToInt32(temp.Text.ToString());
    //                gdvRoomSource.PageIndex = res - 1;
    //            }
    //            break;
    //    }
    //    gdvRoomSource.DataBind();
    //}
}
