using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using CEMIS.Util;
namespace EQWYB.DAL
{
    /// <summary>
    /// 数据访问类:T_Manager
    /// </summary>
    public partial class ManagerDAL
    {
        public ManagerDAL()
        { }
        #region  Method



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EQWYB.Model.Manager model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Manager(");
            strSql.Append("userName,passWord,state,description)");
            strSql.Append(" values (");
            strSql.Append("@userName,@passWord,@state,@description)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.NVarChar),
					new SqlParameter("@passWord", SqlDbType.NVarChar),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@description", SqlDbType.NVarChar)};
            parameters[0].Value = model.userName;
            parameters[1].Value = model.passWord;
            parameters[2].Value = model.state;
            parameters[3].Value = model.description;

            object obj = DBHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EQWYB.Model.Manager model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Manager set ");
            strSql.Append("userName=@userName,");
            strSql.Append("passWord=@passWord,");
            strSql.Append("state=@state,");
            strSql.Append("description=@description");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.NVarChar),
					new SqlParameter("@passWord", SqlDbType.NVarChar),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@description", SqlDbType.NVarChar),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.userName;
            parameters[1].Value = model.passWord;
            parameters[2].Value = model.state;
            parameters[3].Value = model.description;
            parameters[4].Value = model.ID;

            int rows = DBHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Manager ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            int rows = DBHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Manager ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DBHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EQWYB.Model.Manager GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,userName,passWord,state,description from T_Manager ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            EQWYB.Model.Manager model = new EQWYB.Model.Manager();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["userName"] != null && ds.Tables[0].Rows[0]["userName"].ToString() != "")
                {
                    model.userName = ds.Tables[0].Rows[0]["userName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["passWord"] != null && ds.Tables[0].Rows[0]["passWord"].ToString() != "")
                {
                    model.passWord = ds.Tables[0].Rows[0]["passWord"].ToString();
                }
                if (ds.Tables[0].Rows[0]["state"] != null && ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["description"] != null && ds.Tables[0].Rows[0]["description"].ToString() != "")
                {
                    model.description = ds.Tables[0].Rows[0]["description"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,userName,passWord,state,description ");
            strSql.Append(" FROM T_Manager ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,userName,passWord,state,description ");
            strSql.Append(" FROM T_Manager ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelperSQL.Query(strSql.ToString());
        }

        public DataSet ListPageManager(int pageno, int pagesize)
        {
            int rowcount = this.GetTotalRecordNum();
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from T_Manager) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from T_Manager)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        public DataSet ListLookManager(int pageno, int pagesize, string filed, string name)
        {
            int rowcount = this.GetInqueryNum(filed, name);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum ,* from T_Manager where " + filed + " like '%" + name + "%') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by ID DESC) as rownum, * from T_Manager where " + filed + " like '%" + name + "%')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        public int GetTotalRecordNum()
        {
            int rows = DBHelperSQL.countNum("T_Manager");
            return rows;
        }

        public int GetInqueryNum(string filed, string str)
        {
            int rows = DBHelperSQL.GetInqueryNum(filed, str, "T_Manager");
            return rows;
        }

        public EQWYB.Model.Manager verifyLogin(string userName, string passWord)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select  top 1 ID,userName,passWord,state,description from T_Manager ");
            strSql.Append(" where userName=@userName");
            strSql.Append(" and passWord=@passWord");

            SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.NVarChar),
                    new SqlParameter("@passWord", SqlDbType.NVarChar)
        };
            parameters[0].Value = userName;
            parameters[1].Value = passWord;

            EQWYB.Model.Manager model = new EQWYB.Model.Manager();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["userName"] != null && ds.Tables[0].Rows[0]["userName"].ToString() != "")
                {
                    model.userName = ds.Tables[0].Rows[0]["userName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["passWord"] != null && ds.Tables[0].Rows[0]["passWord"].ToString() != "")
                {
                    model.passWord = ds.Tables[0].Rows[0]["passWord"].ToString();
                }
                if (ds.Tables[0].Rows[0]["state"] != null && ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["description"] != null && ds.Tables[0].Rows[0]["description"].ToString() != "")
                {
                    model.description = ds.Tables[0].Rows[0]["description"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion  Method
    }
}