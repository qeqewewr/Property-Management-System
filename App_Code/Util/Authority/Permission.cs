using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Permission 的摘要说明
///功能模块和用户的连接表
/// </summary>
/// 

namespace CEMIS.Util.Authority
{
    public class Permission
    {
        public Permission()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 自增id
        /// </summary>
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 用户类型 1：物业，2：租户
        /// </summary>
        //private int type;
        //public int Type
        //{
        //    get { return type; }
        //    set { type = value; }
        //}

        /// <summary>
        ///用户id
        /// </summary>
        private int roleID;
        public int RoleID
        {
            get { return roleID; }
            set { roleID = value; }
        }

        /// <summary>
        /// 功能模块的id
        /// </summary>
        private int functionID;
        public int FunctionID
        {
            get { return functionID; }
            set { functionID = value; }
        }

        /// <summary>
        /// 功能模块描述
        /// </summary>
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}