using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using CEMIS.Util;
using EQWYB.Model;
namespace EQWYB.BLL
{
    /// <summary>
    /// T_Manager
    /// </summary>
    public partial class ManagerService
    {
        private readonly EQWYB.DAL.ManagerDAL dal = new EQWYB.DAL.ManagerDAL();
        public ManagerService()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EQWYB.Model.Manager model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EQWYB.Model.Manager model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EQWYB.Model.Manager GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

      

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EQWYB.Model.Manager> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EQWYB.Model.Manager> DataTableToList(DataTable dt)
        {
            List<EQWYB.Model.Manager> modelList = new List<EQWYB.Model.Manager>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EQWYB.Model.Manager model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new EQWYB.Model.Manager();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["userName"] != null && dt.Rows[n]["userName"].ToString() != "")
                    {
                        model.userName = dt.Rows[n]["userName"].ToString();
                    }
                    if (dt.Rows[n]["passWord"] != null && dt.Rows[n]["passWord"].ToString() != "")
                    {
                        model.passWord = dt.Rows[n]["passWord"].ToString();
                    }
                    if (dt.Rows[n]["state"] != null && dt.Rows[n]["state"].ToString() != "")
                    {
                        model.state = int.Parse(dt.Rows[n]["state"].ToString());
                    }
                    if (dt.Rows[n]["description"] != null && dt.Rows[n]["description"].ToString() != "")
                    {
                        model.description = dt.Rows[n]["description"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}


        public int GetTotalRecordNum()
        {
            int rows = dal.GetTotalRecordNum();
            return rows;
        }
        public int GetInqueryNum(string filed, string str)
        {
            int rows = dal.GetInqueryNum(filed, str);
            return rows;
        }
        /// <summary>
        /// 自定义分页
        /// </summary>
        public List<EQWYB.Model.Manager> ListPageManager(int pageno, int pagesize)
        {

            DataSet ds = dal.ListPageManager(pageno, pagesize);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// 
        public List<EQWYB.Model.Manager> GetManagerByName(string name)
        {


            DataSet ds = dal.GetList("userName like '%" + name + "%' order by ID");
            return DataTableToList(ds.Tables[0]);
        }

        public List<EQWYB.Model.Manager> ListLookManager(int pageno, int pagesize, string filed, string name)
        {
            DataSet ds = dal.ListLookManager(pageno, pagesize, filed, name);
            return DataTableToList(ds.Tables[0]);
        }

        public EQWYB.Model.Manager verifyLogin(string loginName, string loginPwd)
        {
            return dal.verifyLogin(loginName, loginPwd);
        }

        #endregion  Method
    }
}

