using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.BLL;
using CEMIS.Model.Image;

public partial class Webmag_Employe_officework_repairtable_DoUpdate : System.Web.UI.Page
{
    //要跳转到的页面
    public string pageName = "ViewRepairTable.aspx";
    public int pageno;
    public string id;
    //用于标志更新是否成功
    public int flagID = -1;
    //temprepairTable暂存从页面发送过来的更新的数据
    RepairTable repairTable, tempRepairTable;
    RepairTableDAO repairTableDAO;

    public string keyword = "",room="";
    //用于图片更新
    private RoomStyle roomStyle = new RoomStyle();
    private RoomStyleDAO roomStyleDAO = new RoomStyleDAO();
    private ImgAttachment attach = new ImgAttachment();
    private ImgAttachmentDAO attachDAO = new ImgAttachmentDAO();
    public string role = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            //获取上传的图片
            HttpFileCollection files = HttpContext.Current.Request.Files;
            tempRepairTable = new RepairTable();
            repairTableDAO = new RepairTableDAO();
            pageno = int.Parse(Request["pageno"].Trim().ToString());
            id = Request["oldid"].Trim().ToString();
            //租户才可修改
            if(role=="lessee")
                tempRepairTable.RepairContent = Request.Form["repairTableContent"].Trim();
            tempRepairTable.Director = Request.Form["repairTableDirector"].Trim();
            tempRepairTable.DirectorPhone = Request.Form["repairTableDirectorPhone"].Trim();
            tempRepairTable.DateTime = Request.Form["repairTableDateTime"].Trim();
            tempRepairTable.Remarks = Request.Form["repairTableRemarks"].Trim();
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

            repairTable = repairTableDAO.GetRepairTableById(id);
            if (repairTable != null)
            {
                //租户才可修改
                if (role == "lessee")
                    repairTable.RepairContent = tempRepairTable.RepairContent;
                repairTable.Director = tempRepairTable.Director;
                repairTable.DirectorPhone = tempRepairTable.DirectorPhone;
                repairTable.DateTime = tempRepairTable.DateTime;
                repairTable.Remarks = tempRepairTable.Remarks ;
                repairTable.Fee = tempRepairTable.Fee;
                repairTable.IsFinish = tempRepairTable.IsFinish;
                flagID = repairTableDAO.UpdateRepairTable(repairTable);
            }

            if (flagID >= 0)
            {
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
                        attach.AttachType = 5;
                        attach.AttachUrl = "../../../attachment/" + singlefilename;
                        attach.ModuleID = id.ToString();
                        int temp1 = attachDAO.AddImgAttachment(attach);
                        if (temp1 > 0)
                            flag = 1;
                    }
                
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新成功!');location.href=('ViewRepairTable.aspx?pageno=" + pageno + "');</script>");
                }
                catch (System.Exception Ex)
                {
                    Console.Write(Ex.Message);
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保更新失败!');history.go(-1);</script>");

            }

            /*
            //页面重定向
            PageBLL pageBLL = new PageBLL();
            pageBLL.RedirectPage(this, pageName, flag, pageno, 1);
             * */
        }
    }
}