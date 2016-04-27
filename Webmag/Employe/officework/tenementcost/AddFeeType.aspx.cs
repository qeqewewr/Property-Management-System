using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Util;

public partial class Webmag_Employe_officework_tenementcost_AddFeeType : System.Web.UI.Page
{
    public FeeType feeType = new FeeType();
    public FeeTypeDAO feeTypeDAO = new FeeTypeDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            if (Request.HttpMethod == "POST")
            {
                feeType.FeeName = Request.Form["typename"].ToString().Trim();
                if (feeType.FeeName == "")
                {
                    Response.Write("<script>alert('名称不能为空！')</script>");
                }
                else
                {
                    //有ID编辑
                    if (Request["id"] != null && Request["id"].ToString().Trim() != "" && Request["id"].ToString().Trim() != "0")
                    {
                        feeType.Id = int.Parse(Request["id"].ToString().Trim());
                        int result = feeTypeDAO.UpdateFeeType(feeType);
                        if (result > 0)
                            Response.Write("<script>alert('编辑成功！')</script>");
                        else
                            Response.Write("<script>alert('编辑失败！')</script>");
                    }
                    else //无ID添加费用类型
                    {
                        int result = feeTypeDAO.AddFeeType(feeType);
                        if (result > 0)
                            Response.Write("<script>alert('添加成功！')</script>");
                        else
                            Response.Write("<script>alert('添加失败！')</script>");
                    }
                }


            }
            else
            {
                if (Request["id"] != null && Request["id"].ToString().Trim() != "")
                {
                    feeType = feeTypeDAO.GetFeeTypeById(Request["id"].ToString().Trim());
                    
                }

            }
        }
    }
}