using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.Linq;
using System.Web;
using CEMIS.Util;
using EQWYB.Model;
namespace EQWYB.BLL 
{
	 	//news
	public partial class NewsService
	{
   		     
		private readonly EQWYB.DAL.NewsDAL dal=new EQWYB.DAL.NewsDAL();
		public NewsService()
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
		public int  Add(EQWYB.Model.News model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EQWYB.Model.News model)
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
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EQWYB.Model.News GetModel(int id)
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EQWYB.Model.News> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EQWYB.Model.News> DataTableToList(DataTable dt)
		{
			List<EQWYB.Model.News> modelList = new List<EQWYB.Model.News>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				EQWYB.Model.News model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new EQWYB.Model.News();					
				    if(dt.Rows[n]["id"].ToString()!="")
				    {
					    model.id=int.Parse(dt.Rows[n]["id"].ToString());
				    }
																																				    model.title= dt.Rows[n]["title"].ToString();
				    model.body= dt.Rows[n]["body"].ToString();
				    if(dt.Rows[n]["publishTime"].ToString()!="")
				    {
					    model.publishTime=DateTime.Parse(dt.Rows[n]["publishTime"].ToString());
				    }
				    if(dt.Rows[n]["style"].ToString()!="")
				    {
					    model.style=int.Parse(dt.Rows[n]["style"].ToString());
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
        /// **获得某查询结果的数据列数（有类型）
        /// </summary>
        /// <param name="filed"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public int GetInqueryNum(string filed, string str,string whereStr)
        {
            int rows = dal.GetInqueryNum(filed, str,whereStr);
            return rows;
        }

        /// <summary>
        /// **获得某查询结果的数据列数
        /// </summary>
        /// <param name="filed"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public int GetInqueryNum(string filed, string str)
        {
            int rows = dal.GetInqueryNum(filed, str);
            return rows;
        }

        /// <summary>
        /// **获得当前页数据列表（关键字查询）
        /// </summary>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <param name="filed"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<News> ListLookNews(int pageno, int pagesize, string filed, string name)
        {
            DataSet ds = dal.ListLookNews(pageno, pagesize, filed, name);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// **获得当前页数据列表（关键字查询）(有类型)
        /// </summary>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <param name="filed"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<News> ListLookNews(int pageno, int pagesize, string filed, string name, string whereStr)
        {
            DataSet ds = dal.ListLookNews(pageno, pagesize, filed, name,whereStr);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// **所有数据行数
        /// </summary>
        /// <returns></returns>
        public int GetTotalRecordNum()
        {
            int rows = dal.GetTotalRecordNum();
            return rows;
        }

        /// <summary>
        /// **所有数据行数(有类型)
        /// </summary>
        /// <returns></returns>
        public int GetTotalRecordNum(string whereStr)
        {
            int rows = dal.GetTotalRecordNum(whereStr);
            return rows;
        }

        /// <summary>
        /// **当前页数据列表（未查询）
        /// </summary>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public List<News> ListPageNews(int pageno, int pagesize)
        {

            DataSet ds = dal.ListPageNews(pageno, pagesize);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// **当前页数据列表（未查询）(有类型)
        /// </summary>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public List<News> ListPageNews(int pageno, int pagesize,string whereStr)
        {

            DataSet ds = dal.ListPageNews(pageno, pagesize,whereStr);
            return DataTableToList(ds.Tables[0]);
        }

#endregion
   
	}
}