using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.BLL;
using CEMIS.Model.Employe;
using System.Windows.Forms;
using CEMIS.Model.Image;
using CEMIS.Model.Image;

public partial class Webmag_Employe_officework_repairtable_SaveRepairTable : System.Web.UI.Page
{
    //要跳转页到的页名
    public string pageName = "ViewRepairTable.aspx?pageno=1";
    public int pageno = -1;
    public RepairTable repairTable, tempRepairTable;
    public RepairTableDAO repairTableDAO;

    //用于保存上传的图片
    private ImgAttachment attach = new ImgAttachment();
    private ImgAttachmentDAO attachDAO = new ImgAttachmentDAO();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            if (Request["pageno"] != null)
            {
                pageno = int.Parse(Request["pageno"].Trim().ToString());
            }
            repairTable = new RepairTable();
            tempRepairTable = new RepairTable();
            repairTableDAO = new RepairTableDAO();

            tempRepairTable.BuildingName = Request.Form["repairTableBuildingName"].Trim();

            tempRepairTable.Lessee = Request.Form["repairTableLessee"].Trim();
            tempRepairTable.Room = Request.Form["repairTableRoom"].Trim();
            tempRepairTable.RepairContent = Request.Form["repairTableContent"].Trim();
            tempRepairTable.Director = Request.Form["repairTableDirector"].Trim();
            tempRepairTable.DirectorPhone = Request.Form["repairTableDirectorPhone"].Trim();
            tempRepairTable.DateTime = Request.Form["repairTableDateTime"].Trim();
            tempRepairTable.Remarks = "";
            if (Request.Form["repairTableFee"] != null && Request.Form["repairTableFee"] != "")
                tempRepairTable.Fee = decimal.Parse(Request.Form["repairTableFee"].Trim().ToString());
            else
                tempRepairTable.Fee = 0;
            string temp = Request.Form["repairTableIsFinish"].ToString();
            int myd = -1;//未评
            if (temp == "较满意")
                myd = 1;
            else if (temp == "尚可")
                myd = 2;
            else if (temp == "不满意")
                myd = 3;
            else if (temp == "满意")
                myd = 0;
            tempRepairTable.IsFinish = myd;

            repairTable = tempRepairTable;
            int flagID = repairTableDAO.AddRepairTable(repairTable);
            if (flagID <= 0)
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");

            //用于图片上传
            HttpFileCollection files = HttpContext.Current.Request.Files;
            string lname = "";
            try
            {
                int flag = -1;
                //for IE
                for (int i = 1; i < Request.Files.Count; i++)
                {
                    HttpPostedFile file = Request.Files[i];
                    string type = System.IO.Path.GetExtension(file.FileName);
                    char[] c = { '\\' };
                    string[] nameArray = file.FileName.Split(c);
                    for (int j = 0; j < nameArray.Length; j++)
                    {
                        lname = nameArray[j];
                    }
                    string singlefilename = lname.Substring(0, lname.LastIndexOf('.')) + DateTime.Now.ToString("yyyy-mm-dd-yhh-mm-ss") + type;
                    file.SaveAs(System.Web.HttpContext.Current.Request.MapPath("../../../attachment/") + singlefilename);
                    attach = new ImgAttachment();
                    attach.AddDate = DateTime.Now;
                    attach.AttachName = file.FileName;
                    attach.AttachType = 5;//5维修单
                    //attach.AttachUrl = System.Web.HttpContext.Current.Request.MapPath("../../../attachment/") + singlefilename;
                    attach.AttachUrl = "../../../attachment/" + singlefilename;
                    attach.ModuleID = flagID.ToString();
                    flag = attachDAO.AddImgAttachment(attach);
                    if (flag < 0)
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');location.href='ViewRepairTable.aspx?pageno=1';</script>");
                }
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href='ViewRepairTable.aspx?pageno=1';</script>");
            }
            catch (System.Exception Ex)
            {
                Console.Write(Ex.Message);
            }

        }
    }
}