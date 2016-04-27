using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using CEMIS.Util;
using System.Data.Sql;
using System.Data.SqlClient;

/// <summary>
///AdminDAO 的摘要说明
/// </summary>
/// 
namespace CEMIS.Model.Admin
{
    public class AdminDAO
    {
        public AdminDAO()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }


        /// <summary>
        /// 更新超级管理员信息
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public int UpdateAdmin(Admin admin)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int),
                    new SqlParameter("@Password", SqlDbType.NVarChar),
                    new SqlParameter("@Remark", SqlDbType.NVarChar)
                    };
            parameters[0].Value= admin.ID;
            parameters[1].Value= admin.Password;
            parameters[2].Value= admin.Remark;

            string sql = "update Admin set Password=@Password,Remark=@Remark where ID=@ID ";

            return DBHelperSQL.ExecuteSql(sql, parameters);          
        }

        /// <summary>
        /// 超级管理员的登陆判断
        /// </summary>
        /// <param name="id"></param>
        /// <param name="psw"></param>
        /// <returns></returns>
        public Boolean LogonJudge(string id, string psw)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.NChar),
                    new SqlParameter("@Password", SqlDbType.NVarChar)
                    };
            parameters[0].Value = id;
            parameters[1].Value = psw;

            string sql = "SELECT ID,Password From Admin WHERE ID=@ID AND Password=@Password";
            return DBHelperSQL.Exists(sql, parameters);
           
        }


        /// <summary>
        /// 获取超级管理员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean GetAdmin(string id)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int) 
                    };
            parameters[0].Value = id;
            string sql = "select * from Admin where ID=@ID ";
            object obj=DBHelperSQL.GetSingle(sql, parameters);
            if (obj == null)
                return false;
            else
                return true;           
        }
    }
}