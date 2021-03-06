﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Model.Image;

public partial class Webmag_Employe_infoManage_building_DoUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;

            string pageno;
            string oldid;

            string id;
            string name;
            string adminID;
            string position;
            double area = 0;
            int floor = 0;
            string introduction;
            string pic;

            int flag = -1;

            Building build = new Building();
            BuildingDAO buildDAO = new BuildingDAO();

            ImgAttachment image = new ImgAttachment();
            ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();


            pageno = Request["pageno"];
            oldid = Request["oldid"];

            id = Request.Form["buildingID"].Trim();
            name = Request.Form["buildingName"].Trim();
            adminID = Request.Form["buildingAdmin"].Trim();
            position = Request.Form["buildingPos"].Trim();
            if (Request.Form["buildingArea"].Trim() != null && Request.Form["buildingArea"].Trim() != "")
                area = double.Parse(Request.Form["buildingArea"].Trim());
            if (Request.Form["buildingFloor"].Trim() != null && Request.Form["buildingFloor"].Trim() != "")
                floor = int.Parse(Request.Form["buildingFloor"].Trim());
            introduction = Request.Form["buildingIntro"].Trim();
            pic = "";


            build = buildDAO.GetBuildingByID(id);
            if (build != null)
            {
                if (oldid != id)
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('该大楼ID已经存在，请重新输入!');history.go(-1);</script>");
                else
                {

                    build.Name = name;
                    build.AdminID = adminID;
                    build.Position = position;
                    build.Area = area;
                    build.Floor = floor;
                    build.Introduction = introduction;
                    build.Pic = pic;
                    flag = buildDAO.UpdateBuilding(build);

                    if (flag >= 0)
                    {
                        string lname = "";
                        try
                        {
                            for (int i = 0; i < Request.Files.Count; i++)
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
                                image = new ImgAttachment();
                                image.AddDate = DateTime.Now;
                                image.AttachName = file.FileName;
                                image.AttachType = 2;
                                //image.AttachUrl = System.Web.HttpContext.Current.Request.MapPath("../../../attachment/") + singlefilename;
                                image.AttachUrl = "../../../attachment/" + singlefilename;
                                image.ModuleID = build.ID;

                                imageDAO.AddImgAttachment(image);
                            }
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新成功!');location.href=('ViewBuilding.aspx?pageno=" + pageno + "');</script>");
                        }
                        catch (System.Exception Ex)
                        {
                            Console.Write(Ex.Message);
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新失败!');history.go(-1);</script>");

                    }


                }
            }
            else
            {
                buildDAO.deleteBuilding(oldid);
                build = new Building();
                build.ID = id;
                build.Name = name;
                build.AdminID = adminID;
                build.Position = position;
                build.Area = area;
                build.Floor = floor;
                build.Introduction = introduction;
                build.Pic = pic;
                flag = buildDAO.AddBuilding(build);

                if (flag >= 0)
                {
                    string lname = "";
                    try
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
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
                            image = new ImgAttachment();
                            image.AddDate = DateTime.Now;
                            image.AttachName = file.FileName;
                            image.AttachType = 2;
                            //image.AttachUrl = System.Web.HttpContext.Current.Request.MapPath("../../../attachment/") + singlefilename;
                            image.AttachUrl = "../../../attachment/" + singlefilename;
                            image.ModuleID = build.ID;

                            imageDAO.AddImgAttachment(image);
                        }
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新成功!');location.href=('ViewBuilding.aspx?pageno=" + pageno + "');</script>");
                    }
                    catch (System.Exception Ex)
                    {
                        Console.Write(Ex.Message);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('更新失败!');history.go(-1);</script>");

                }
            }

        }
    }
}