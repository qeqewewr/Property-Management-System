﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Model.Image;

public partial class Webmag_Employe_infoManage_lessee_DoUpdate : System.Web.UI.Page
{
    public Lessee lessee;
    public LesseeDAO lesseeDAO;

    private List<ImgAttachment> img = new List<ImgAttachment>();
    private ImgAttachmentDAO imgDAO = new ImgAttachmentDAO();

    private int id;
    private string name;
    private string roomnum="";
    private string address;
    private string operationScope;
    private string officePhone;
    private string director;
    private string directorPhone;
    private string emergency;
    private string emergencyPhone;
    private string remark;
    private string password;
    private double warrantMon;

    private string oldname;
    public string pageno;
    public string keyword;
    public string scope;

    public int m;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            pageno = Request["pageno"];
            if (Request["keyword"].Trim() != null)
                keyword = Request["keyword"].Trim();
            if (Request["scope"].Trim() != null)
                scope = Request["scope"].Trim();

            lessee = new Lessee();
            lesseeDAO = new LesseeDAO();

            id = int.Parse(Request.Form["lesseeID"].Trim());
            name = Request.Form["lesseeName"].Trim();
            //roomnum = Request.Form["lesseeRoomNum"].Trim();
            address = Request.Form["lesseeAddress"].Trim();
            operationScope = Request.Form["lesseeOS"].Trim();
            officePhone = Request.Form["lesseeOPhone"].Trim();
            director = Request.Form["lesseeDirector"].Trim();
            directorPhone = Request.Form["lesseeDPhone"].Trim();
            emergency = Request.Form["lesseeEmergency"].Trim();
            emergencyPhone = Request.Form["lesseeEPhone"].Trim();
            remark = Request.Form["lesseeRemark"].Trim();
            password = Request.Form["lesseePWD"].Trim();
            //if (Request.Form["lesseeWarrant"].ToString() != "" && Request.Form["lesseeWarrant"].ToString() != null)
            //    warrantMon = double.Parse(Request.Form["lesseeWarrant"].Trim());

            oldname = Request["oldname"];
            int flag = -1;


            lessee = lesseeDAO.GetLesseeByID(id);
            lessee.Name = name;
            lessee.RoomNum = roomnum;
            lessee.Address = address;
            lessee.OperationScope = operationScope;
            lessee.OfficePhone = officePhone;
            lessee.Director = director;
            lessee.DirectorPhone = directorPhone;
            lessee.Emergency = emergency;
            lessee.EmergencyPhone = emergencyPhone;
            lessee.Remark = remark;
            lessee.Password = password;
            lessee.WarrantMon = warrantMon;

            flag = lesseeDAO.UpdateLessee(lessee);


            string args = Request["ufile"];
            if (args != null)
            {
                char[] sep = { ',' };
                string[] fileArray = args.Split(sep);
                for (int i = 0; i < fileArray.Length; i++)
                {

                    char[] c = { '#' };
                    string fileNameArray = (fileArray[i].Split(c))[1];
                    ImgAttachment imgAttach = new ImgAttachment();
                    imgAttach.AttachName = fileNameArray;
                    imgAttach.AddDate = DateTime.Now;
                    //imgAttach.AttachUrl = uploadpath + fileArray[i].Split(c)[1];
                    imgAttach.AttachUrl = fileArray[i].Split(c)[1];
                    imgAttach.AttachType = 8; //租户附件
                    if (flag >= 0)
                    {
                        imgAttach.ModuleID = id.ToString();
                        //m = imgService.Add(imgAttach);
                        m = imgDAO.AddImgAttachment(imgAttach);
                        if (m <= 0)
                            break;

                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新失败!');history.go(-1);</script>");
                    }
                }
                if (m > 0)
                {

                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新成功!');location.href=('ViewLessee.aspx?pageno=" + pageno + "&keyword=" + keyword + "&scope=" + scope + "');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('图片更新失败!');location.href=('updateCleaner.aspx?id=flag&pageno=1');</script>");

                }
            }
            else
            {


                if (flag > 0)
                {

                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新成功!');location.href=('ViewLessee.aspx?pageno=" + pageno + "&keyword=" + keyword + "&scope=" + scope + "');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新失败!');history.go(-1);</script>");

                }
            }

            //if (flag > 0)
            //{

            //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新成功!');location.href=('ViewLessee.aspx?pageno=" + pageno + "&keyword=" + keyword + "&scope=" + scope + "');</script>");
            //}
            //else
            //{
            //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新失败!');history.go(-1);</script>");

            //}
        }

    }
    
}