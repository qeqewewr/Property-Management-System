using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Util;

public partial class Webmag_Employe_officework_tenementcost_DeleteFeeType : System.Web.UI.Page
{
    public FeeTypeDAO feeTypeDAO = new FeeTypeDAO();
    public TenementCostDAO tenementCostDAO = new TenementCostDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            if (Request["pageno"] != null && Request["pageno"].ToString() != "")
            {
                Response.Redirect("ViewFeeType.aspx?pageno=" + Request["pageno"]);
            }
            else if (Request["selectDel"] != null && Request["selectDel"] != "")
            {
                char[] separtor = { ',' };
                string[] idArray = Request["selectDel"].Split(separtor);
                int i,result = -1;
                for (i = 0; i < idArray.Length; i++)
                {
                    result = feeTypeDAO.DeleteFeeType(idArray[i]);
                    string feeName = feeTypeDAO.GetFeeNameById(idArray[i]);
                    tenementCostDAO.DeleteTenementCostByFeeName(feeName);
                }
                if (result > 0)
                {
                    Response.Write("<script>alert('删除成功');</script>");
                }
                else
                {
                    Response.Write("<script>alert('删除失败');</script>");
                }
                Response.Write("<script>window.location.href='ViewFeeType.aspx';</script>");
              
            }
            else
            {
                Response.Write("<script>alert('参数无效，请重新操作');</script>");
                Response.Write("<script>window.location.href='ViewFeeType.aspx';</script>");
            }
        }
    }
}