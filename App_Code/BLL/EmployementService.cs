using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.Linq;
using System.Web;
using CEMIS.Util;
using EQWYB.Model;
namespace EQWYB.BLL {
	 	//EmployementService
		public partial class EmployementService
	{
   		     
		private readonly EQWYB.DAL.EmployementDAL dal=new EQWYB.DAL.EmployementDAL();
        public EmployementService()
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
		public int  Add(EQWYB.Model.Employement model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EQWYB.Model.Employement model)
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
		public EQWYB.Model.Employement GetModel(int id)
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
		public List<EQWYB.Model.Employement> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EQWYB.Model.Employement> DataTableToList(DataTable dt)
		{
			List<EQWYB.Model.Employement> modelList = new List<EQWYB.Model.Employement>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				EQWYB.Model.Employement model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new EQWYB.Model.Employement();					
													if(dt.Rows[n]["id"].ToString()!="")
				{
					model.id=int.Parse(dt.Rows[n]["id"].ToString());
				}
																																				model.company= dt.Rows[n]["company"].ToString();
																																model.staff= dt.Rows[n]["staff"].ToString();
																																model.title= dt.Rows[n]["title"].ToString();
																												if(dt.Rows[n]["endDate"].ToString()!="")
				{
					model.endDate=DateTime.Parse(dt.Rows[n]["endDate"].ToString());
				}
																																if(dt.Rows[n]["startDate"].ToString()!="")
				{
					model.startDate=DateTime.Parse(dt.Rows[n]["startDate"].ToString());
				}
																																				model.detail= dt.Rows[n]["detail"].ToString();
																												if(dt.Rows[n]["number"].ToString()!="")
				{
					model.number=int.Parse(dt.Rows[n]["number"].ToString());
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
#endregion
   
	}
}