using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Building 的摘要说明
/// </summary>
/// 
namespace CEMIS.Model.Employe
{
    public class Building
    {
        public Building()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        //楼号
        private string id;
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        //大楼名称
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //管理员ID
        private string adminID;
        public string AdminID
        {
            get { return adminID; }
            set { adminID = value; }
        }

        //位置
        private string position;
        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        //面积
        private double area;
        public double Area
        {
            get { return area; }
            set { area = value; }
        }
        //层数
        private int floor;
        public int Floor
        {
            get { return floor; }
            set { floor = value; }
        }

        //简介
        private string introduction;
        public string Introduction
        {
            get { return introduction; }
            set { introduction = value; }
        }

        //图片
        private string pic;
        public string Pic
        {
            get { return pic; }
            set { pic=value; }
        }
    }
}