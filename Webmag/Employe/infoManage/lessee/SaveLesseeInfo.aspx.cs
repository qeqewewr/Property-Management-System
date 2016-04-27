using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Model.Image;

public partial class Webmag_Employe_infoManage_lessee_SaveLesseeInfo : System.Web.UI.Page
{
    public Lessee lessee;
    public LesseeDAO lesseeDAO;
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
    private int flag = -1;
    private int m;

    private List<ImgAttachment> img = new List<ImgAttachment>();
    private ImgAttachmentDAO imgDAO = new ImgAttachmentDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            //需要添加session的判断

            lessee = new Lessee();
            lesseeDAO = new LesseeDAO();
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
            //if (Request.Form["lesseeWarrant"].ToString() != "" && Request.Form["lesseeWarrant"].ToString() != null)
            //    warrantMon = double.Parse(Request.Form["lesseeWarrant"].Trim());

            password = "123456"; //初始密码


            //添加保存租户信息
            lessee = new Lessee();
            lessee = lesseeDAO.GetLesseeByName(name);
            if (lessee != null)
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('该公司名称已经存在！！');location.href=('AddLessee.aspx');</script>");
            else
            {
               
                lessee = new Lessee();
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

                flag = lesseeDAO.AddLessee(lessee);

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
                            imgAttach.ModuleID = flag.ToString();
                            //m = imgService.Add(imgAttach);
                            m = imgDAO.AddImgAttachment(imgAttach);
                            if (m <= 0)
                                break;

                        }
                        else
                        {
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");
                        }
                    }

                    if (m > 0)
                    {

                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('AddLessee.aspx');</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('图片保存失败!');location.href=('updateCleaner.aspx?id=flag&pageno=1');</script>");

                    }
                }
                else
                {
                    if (flag >= 0)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('AddLessee.aspx');</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");
                    }
                }


                //int flag = lesseeDAO.AddLessee(lessee);
                //if (flag > 0)
                //{

                //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('AddLessee.aspx');</script>");
                //}
                //else
                //{
                //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");
                //}
            }
        }

       
    }
}