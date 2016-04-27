using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.Model.Image;
using CEMIS.BLL;

public partial class LesseeAD : System.Web.UI.Page
{
    public List<FirmAdvertise> firmList = new List<FirmAdvertise>();
    public FirmAdvertiseDAO firmDAO = new FirmAdvertiseDAO();

    public string pageno;
    public pageForm page = new pageForm();

    public List<ImgAttachment> imagelist = new List<ImgAttachment>(), templist = new List<ImgAttachment>();
    public ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();
    public ImgAttachment image = new ImgAttachment();
    public PageBLL pageBLL = new PageBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        pageno = Request["pageno"].ToString();

        page.PageSize = 8;
        page.PageNo = int.Parse(pageno);
        //page.RowCount = firmDAO.GetTotalRecordNum();
        page.RowCount = firmDAO.GetRecordNumByIsSure();
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

     //   firmList = firmDAO.ListPageFirmAdvertise(int.Parse(pageno), page.PageSize);
        firmList = firmDAO.ListPageFirmAdvertiseByIsSure(int.Parse(pageno), page.PageSize);
        for (int i = 0; i < firmList.Count; i++)
        {
            //获得图片列表,用于主页显示
            templist = imageDAO.GetImgAttachmentByTypeAndID(7,firmList[i].Id);
            //若有临时数据
            if (templist.Count >= 1)
                imagelist.Add(templist[0]);
            else
                imagelist.Add(null);
           
        }
        
    }
    //protected void btnFirst_Click(object sender, DataPagerCommandEventArgs e)
    //{
    //    int newIndex;
    //    switch(e.CommandName)
    //    {
    //        case "first":
    //            e.NewStartRowIndex = 0;
    //            e.NewMaximumRows = e.Item.Pager.MaximumRows;
    //            break;
    //        case "last":
    //            e.NewStartRowIndex = e.Item.Pager.TotalRowCount / e.Item.Pager.PageSize*e.Item.Pager.PageSize;
    //            e.NewMaximumRows = e.Item.Pager.MaximumRows;
    //            break;
    //        case "prev":
    //            newIndex = e.Item.Pager.StartRowIndex - e.Item.Pager.PageSize;
    //            if (newIndex >=0)
    //            {
    //                e.NewStartRowIndex = newIndex;
    //                e.NewMaximumRows = e.Item.Pager.MaximumRows;
    //            }
    //            break;
    //        case "next":
    //            newIndex = e.Item.Pager.StartRowIndex + e.Item.Pager.PageSize;
    //            if (newIndex <= e.TotalRowCount)
    //            {
    //                e.NewStartRowIndex = newIndex;
    //                e.NewMaximumRows = e.Item.Pager.MaximumRows;
    //            }
    //            break;
           
    //    }
    //}

    //protected void ShowLesseeAD_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
}
