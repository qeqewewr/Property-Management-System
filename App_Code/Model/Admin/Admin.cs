using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Admin 的摘要说明
/// </summary>
/// 
namespace CEMIS.Model.Admin
{
    public class Admin
    {

        private string id;
        private string password;
        private string remark;

        public Admin()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}