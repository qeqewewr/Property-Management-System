using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.Linq;
using System.Web;
using CEMIS.Util;
using EQWYB.Model;
namespace EQWYB.BLL {
    //PropertyService
		public partial class PropertyService
	{
   		     
		private readonly EQWYB.DAL.PropertyDAL dal=new EQWYB.DAL.PropertyDAL();
		public PropertyService()
		{}
		
	
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EQWYB.Model.Property model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EQWYB.Model.Property model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EQWYB.Model.Property GetModel(int id)
        {

            return dal.GetModel(id);
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
        public List<EQWYB.Model.Property> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EQWYB.Model.Property> DataTableToList(DataTable dt)
        {
            List<EQWYB.Model.Property> modelList = new List<EQWYB.Model.Property>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EQWYB.Model.Property model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new EQWYB.Model.Property();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["orderList"] != null && dt.Rows[n]["orderList"].ToString() != "")
                    {
                        model.orderList = int.Parse(dt.Rows[n]["orderList"].ToString());
                    }
                    if (dt.Rows[n]["propertyName"] != null && dt.Rows[n]["propertyName"].ToString() != "")
                    {
                        model.propertyName = dt.Rows[n]["propertyName"].ToString();
                    }
                    if (dt.Rows[n]["describe"] != null && dt.Rows[n]["describe"].ToString() != "")
                    {
                        model.describe = dt.Rows[n]["describe"].ToString();
                    }
                    if (dt.Rows[n]["block"] != null && dt.Rows[n]["block"].ToString() != "")
                    {
                        model.block = dt.Rows[n]["block"].ToString();
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
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
#endregion
   
	}
}