﻿using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using System.Web;
using CEMIS.Util;
namespace EQWYB.DAL  
{
	 	//PropertyDAL
		public partial class PropertyDAL
	{

        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Property");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DBHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EQWYB.Model.Property model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Property(");
            strSql.Append("orderList,propertyName,describe,block)");
            strSql.Append(" values (");
            strSql.Append("@orderList,@propertyName,@describe,@block)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@orderList", SqlDbType.Int,4),
					new SqlParameter("@propertyName", SqlDbType.VarChar),
					new SqlParameter("@describe", SqlDbType.NText),
					new SqlParameter("@block", SqlDbType.VarChar,50)};
            parameters[0].Value = model.orderList;
            parameters[1].Value = model.propertyName;
            parameters[2].Value = model.describe;
            parameters[3].Value = model.block;

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
        public bool Update(EQWYB.Model.Property model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Property set ");
            strSql.Append("orderList=@orderList,");
            strSql.Append("propertyName=@propertyName,");
            strSql.Append("describe=@describe,");
            strSql.Append("block=@block");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@orderList", SqlDbType.Int,4),
					new SqlParameter("@propertyName", SqlDbType.VarChar),
					new SqlParameter("@describe", SqlDbType.NText),
					new SqlParameter("@block", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.orderList;
            parameters[1].Value = model.propertyName;
            parameters[2].Value = model.describe;
            parameters[3].Value = model.block;
            parameters[4].Value = model.id;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Property ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Property ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public EQWYB.Model.Property GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,orderList,propertyName,describe,block from Property ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            EQWYB.Model.Property model = new EQWYB.Model.Property();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["orderList"] != null && ds.Tables[0].Rows[0]["orderList"].ToString() != "")
                {
                    model.orderList = int.Parse(ds.Tables[0].Rows[0]["orderList"].ToString());
                }
                if (ds.Tables[0].Rows[0]["propertyName"] != null && ds.Tables[0].Rows[0]["propertyName"].ToString() != "")
                {
                    model.propertyName = ds.Tables[0].Rows[0]["propertyName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["describe"] != null && ds.Tables[0].Rows[0]["describe"].ToString() != "")
                {
                    model.describe = ds.Tables[0].Rows[0]["describe"].ToString();
                }
                if (ds.Tables[0].Rows[0]["block"] != null && ds.Tables[0].Rows[0]["block"].ToString() != "")
                {
                    model.block = ds.Tables[0].Rows[0]["block"].ToString();
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
            strSql.Append("select id,orderList,propertyName,describe,block ");
            strSql.Append(" FROM Property ");
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
            strSql.Append(" id,orderList,propertyName,describe,block ");
            strSql.Append(" FROM Property ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Property ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DBHelperSQL.GetSingle(strSql.ToString());
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from Property T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DBHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Property";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DBHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

   
	}
}
