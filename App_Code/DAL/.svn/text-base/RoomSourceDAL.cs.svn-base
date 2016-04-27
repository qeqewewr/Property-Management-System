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
    /// 数据访问类:RoomSourceDAL
    /// </summary>
    public partial class RoomSourceDAL
    {
        public RoomSourceDAL()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RoomSource");
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
        public int Add(EQWYB.Model.RoomSource model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RoomSource(");
            strSql.Append("title,build,roomNum,toward,decorate,area,rent,address,block,phone)");
            strSql.Append(" values (");
            strSql.Append("@title,@build,@roomNum,@toward,@decorate,@area,@rent,@address,@block,@phone)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar),
					new SqlParameter("@build", SqlDbType.VarChar,50),
					new SqlParameter("@roomNum", SqlDbType.VarChar,50),
					new SqlParameter("@toward", SqlDbType.VarChar,50),
					new SqlParameter("@decorate", SqlDbType.VarChar,50),
					new SqlParameter("@area", SqlDbType.Float,8),
					new SqlParameter("@rent", SqlDbType.VarChar,50),
					new SqlParameter("@address", SqlDbType.VarChar),
					new SqlParameter("@block", SqlDbType.VarChar,50),
					new SqlParameter("@phone", SqlDbType.VarChar,50)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.build;
            parameters[2].Value = model.roomNum;
            parameters[3].Value = model.toward;
            parameters[4].Value = model.decorate;
            parameters[5].Value = model.area;
            parameters[6].Value = model.rent;
            parameters[7].Value = model.address;
            parameters[8].Value = model.block;
            parameters[9].Value = model.phone;

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
        public bool Update(EQWYB.Model.RoomSource model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RoomSource set ");
            strSql.Append("title=@title,");
            strSql.Append("build=@build,");
            strSql.Append("roomNum=@roomNum,");
            strSql.Append("toward=@toward,");
            strSql.Append("decorate=@decorate,");
            strSql.Append("area=@area,");
            strSql.Append("rent=@rent,");
            strSql.Append("address=@address,");
            strSql.Append("block=@block,");
            strSql.Append("phone=@phone");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar),
					new SqlParameter("@build", SqlDbType.VarChar,50),
					new SqlParameter("@roomNum", SqlDbType.VarChar,50),
					new SqlParameter("@toward", SqlDbType.VarChar,50),
					new SqlParameter("@decorate", SqlDbType.VarChar,50),
					new SqlParameter("@area", SqlDbType.Float,8),
					new SqlParameter("@rent", SqlDbType.VarChar,50),
					new SqlParameter("@address", SqlDbType.VarChar),
					new SqlParameter("@block", SqlDbType.VarChar,50),
					new SqlParameter("@phone", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.build;
            parameters[2].Value = model.roomNum;
            parameters[3].Value = model.toward;
            parameters[4].Value = model.decorate;
            parameters[5].Value = model.area;
            parameters[6].Value = model.rent;
            parameters[7].Value = model.address;
            parameters[8].Value = model.block;
            parameters[9].Value = model.phone;
            parameters[10].Value = model.id;

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
            strSql.Append("delete from RoomSource ");
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
            strSql.Append("delete from RoomSource ");
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
        public EQWYB.Model.RoomSource GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,title,build,roomNum,toward,decorate,area,rent,address,block,phone from RoomSource ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            EQWYB.Model.RoomSource model = new EQWYB.Model.RoomSource();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["title"] != null && ds.Tables[0].Rows[0]["title"].ToString() != "")
                {
                    model.title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["build"] != null && ds.Tables[0].Rows[0]["build"].ToString() != "")
                {
                    model.build = ds.Tables[0].Rows[0]["build"].ToString();
                }
                if (ds.Tables[0].Rows[0]["roomNum"] != null && ds.Tables[0].Rows[0]["roomNum"].ToString() != "")
                {
                    model.roomNum = ds.Tables[0].Rows[0]["roomNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["toward"] != null && ds.Tables[0].Rows[0]["toward"].ToString() != "")
                {
                    model.toward = ds.Tables[0].Rows[0]["toward"].ToString();
                }
                if (ds.Tables[0].Rows[0]["decorate"] != null && ds.Tables[0].Rows[0]["decorate"].ToString() != "")
                {
                    model.decorate = ds.Tables[0].Rows[0]["decorate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["area"] != null && ds.Tables[0].Rows[0]["area"].ToString() != "")
                {
                    model.area = decimal.Parse(ds.Tables[0].Rows[0]["area"].ToString());
                }
                if (ds.Tables[0].Rows[0]["rent"] != null && ds.Tables[0].Rows[0]["rent"].ToString() != "")
                {
                    model.rent = ds.Tables[0].Rows[0]["rent"].ToString();
                }
                if (ds.Tables[0].Rows[0]["address"] != null && ds.Tables[0].Rows[0]["address"].ToString() != "")
                {
                    model.address = ds.Tables[0].Rows[0]["address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["block"] != null && ds.Tables[0].Rows[0]["block"].ToString() != "")
                {
                    model.block = ds.Tables[0].Rows[0]["block"].ToString();
                }
                if (ds.Tables[0].Rows[0]["phone"] != null && ds.Tables[0].Rows[0]["phone"].ToString() != "")
                {
                    model.phone = ds.Tables[0].Rows[0]["phone"].ToString();
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
            strSql.Append("select id,title,build,roomNum,toward,decorate,area,rent,address,block,phone ");
            strSql.Append(" FROM RoomSource ");
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
            strSql.Append(" id,title,build,roomNum,toward,decorate,area,rent,address,block,phone ");
            strSql.Append(" FROM RoomSource ");
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
            strSql.Append("select count(1) FROM RoomSource ");
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
            strSql.Append(")AS Row, T.*  from RoomSource T ");
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
            parameters[0].Value = "RoomSource";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DBHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/


        /// <summary>
        /// **获得查询结果的数据行数(有类型)
        /// </summary>
        /// <param name="filed"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public int GetInqueryNum(string filed, string str, string whereStr)
        {
            int rows = DBHelperSQL.GetInqueryNum(filed, str, whereStr, "RoomSource");
            return rows;
        }

        /// <summary>
        /// **获得查询结果的数据行数
        /// </summary>
        /// <param name="filed"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public int GetInqueryNum(string filed, string str)
        {
            int rows = DBHelperSQL.GetInqueryNum(filed, str, "RoomSource");
            return rows;
        }

        /// <summary>
        /// **获得当前页数据列表（关键字查询）（有类型）
        /// </summary>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <param name="filed"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataSet ListLookRoomSource(int pageno, int pagesize, string filed, string name, string whereStr)
        {
            int rowcount = this.GetInqueryNum(filed, name, whereStr);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by publishTime DESC) as rownum ,* from RoomSource where " + filed + " like '%" + name + "%' and whereStr) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by publishTime DESC) as rownum, * from RoomSource where " + filed + " like '%" + name + "%' and whereStr)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        /// <summary>
        /// **获得当前页数据列表（关键字查询）
        /// </summary>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <param name="filed"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataSet ListLookRoomSource(int pageno, int pagesize, string filed, string name)
        {
            int rowcount = this.GetInqueryNum(filed, name);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by publishTime DESC) as rownum ,* from RoomSource where " + filed + " like '%" + name + "%') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by publishTime DESC) as rownum, * from RoomSource where " + filed + " like '%" + name + "%')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        /// <summary>
        /// **所有数据行数
        /// </summary>
        /// <returns></returns>
        public int GetTotalRecordNum()
        {
            int rows = DBHelperSQL.countNum("RoomSource");
            return rows;
        }

        /// <summary>
        /// **所有数据行数(有类型)
        /// </summary>
        /// <returns></returns>
        public int GetTotalRecordNum(string whereStr)
        {
            int rows = DBHelperSQL.countNum("RoomSource", whereStr);
            return rows;
        }

        /// <summary>
        /// **当前页数据列表（未查询）
        /// </summary>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public DataSet ListPageRoomSource(int pageno, int pagesize)
        {
            int rowcount = this.GetTotalRecordNum();
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by publishTime DESC) as rownum ,* from RoomSource ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by publishTime DESC) as rownum, * from RoomSource )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        /// <summary>
        /// **当前页数据列表（未查询）(有类型)
        /// </summary>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public DataSet ListPageRoomSource(int pageno, int pagesize, string whereStr)
        {
            int rowcount = this.GetTotalRecordNum(whereStr);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by publishTime DESC) as rownum ,* from RoomSource where " + whereStr + " ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by publishTime DESC) as rownum, * from RoomSource where " + whereStr + ")select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        #endregion  Method
    }
}

