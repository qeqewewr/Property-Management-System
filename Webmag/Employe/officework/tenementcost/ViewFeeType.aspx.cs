using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.BLL;

public partial class Webmag_Employe_officework_tenementcost_ViewFeeType : System.Web.UI.Page
{
    public List<FeeType> feeTypeList = new List<FeeType>();
    public FeeTypeDAO feeTypeDAO = new FeeTypeDAO();
    public pageForm page = new pageForm();
    public string pageno;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            /*
            pageno = Request["pageno"];
            if (pageno == null) pageno = "1";
            page.RowCount = feeTypeDAO.GetTotalRecordNum();
            page.PageSize = PageBLL.pageSize;
            page.PageNo = int.Parse(pageno);

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
            */
            feeTypeList = feeTypeDAO.ListFeeType();
        }
    }
}