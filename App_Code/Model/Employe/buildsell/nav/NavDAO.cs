using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CEMIS.Util;

namespace CEMIS.Model.Employe
{
    /// <summary>
    ///NavDAO 的摘要说明
    /// </summary>

    public class NavDAO
    {
        public NavDAO()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<Nav> DataTableToList(DataTable dt)
        {
            List<Nav> modelList = new List<Nav>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Nav model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Nav();

                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                        model.ID = dt.Rows[n]["ID"].ToString();
                    if (dt.Rows[n]["Name"] != null && dt.Rows[n]["Name"].ToString() != "")
                        model.Name = dt.Rows[n]["Name"].ToString();
                    if (dt.Rows[n]["Sort"] != null && dt.Rows[n]["Sort"].ToString() != "")
                        model.Sort = dt.Rows[n]["Sort"].ToString();
                    if (dt.Rows[n]["Url"] != null && dt.Rows[n]["Url"].ToString() != "")
                        model.Url = dt.Rows[n]["Url"].ToString();
                    if (dt.Rows[n]["State"] != null && dt.Rows[n]["State"].ToString() != "")
                        model.State = dt.Rows[n]["State"].ToString();

                    modelList.Add(model);
                }
            }
            return modelList;
        }
        /// <summary>
        /// 通过id获得导航
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Nav GetNav(string id)
        {
            DBConnection db = new DBConnection();
            string sql = "select * from Nav where ID='" + id + "'";
            DataSet ds=DBHelperSQL.Query(sql);
            List<Nav> navList = DataTableToList(ds.Tables[0]);
            if (navList.Count > 0)
                return navList[0];
            else
                return null;
                
        }


        /// <summary>
        /// 添加导航
        /// </summary>
        /// <param name="nav"></param>
        /// <returns></returns>
        public int AddNav(Nav nav)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar),
                    new SqlParameter("@Url", SqlDbType.NVarChar),
                    new SqlParameter("@Sort", SqlDbType.NVarChar),
                    new SqlParameter("@State", SqlDbType.NVarChar)};

            parameters[0].Value = nav.Name;
            parameters[1].Value = nav.Url;
            parameters[2].Value = nav.Sort;
            parameters[3].Value = nav.State;

            string sql = "insert into Nav(Name,Url,Sort,State) values(@Name,@Url,@Sort,@State)";
            object obj = DBHelperSQL.GetSingle(sql, parameters);
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
        /// 编辑信息
        /// </summary>
        /// <param name="nav"></param>
        /// <returns></returns>
        public int UpdateNav(Nav nav)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.NVarChar),
                    new SqlParameter("@Name", SqlDbType.NVarChar),
                    new SqlParameter("@Url", SqlDbType.NVarChar),
                    new SqlParameter("@Sort", SqlDbType.NVarChar),
                    new SqlParameter("@State", SqlDbType.NVarChar)};

            parameters[0].Value = nav.ID;
            parameters[1].Value = nav.Name;
            parameters[2].Value = nav.Url;
            parameters[3].Value = nav.Sort;
            parameters[4].Value = nav.State;
            string sql = "update Nav set Name=@Name,Url=@Url,Sort=@Sort,State=@State where ID=@ID ";
            return DBHelperSQL.ExecuteSql(sql, parameters);
        }

        /// <summary>
        /// 激活导航
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int EnableNav(string id)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.NVarChar)};
            id = int.Parse(id.Trim()).ToString();
            parameters[0].Value = id;
            string sql = "update Nav set State='1' where ID=@ID ";
            return DBHelperSQL.ExecuteSql(sql, parameters);     
        }
        /// <summary>
        /// 关闭导航
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DisableNav(string id)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.NVarChar)};

            parameters[0].Value = id;
            string sql = "update Nav set State='0' where ID=@ID ";
            return DBHelperSQL.ExecuteSql(sql, parameters);       
        }

 

        /// <summary>
        /// 获得导航列表
        /// </summary>
        /// <returns></returns>
        public List<Nav> ListNav()
        {
            string sql = "select * from Nav";
            DataSet ds = DBHelperSQL.Query(sql);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得激活的导航列表
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public List<Nav> ListNav(string state)
        {
            state = int.Parse(state.Trim()).ToString();
            string sql = "select * from Nav where State='"+state+"'";
            DataSet ds = DBHelperSQL.Query(sql);
            return DataTableToList(ds.Tables[0]);
        }


        public int GetTotalRecordNum()
        {
            return DBHelperSQL.countNum("Nav");
        }

        public int GetTotalRecordNum(string state)
        {
            state = int.Parse(state.Trim()).ToString();
            return DBHelperSQL.countNum("Nav"," State ='"+state+"'");
           
        }
    } 
}
