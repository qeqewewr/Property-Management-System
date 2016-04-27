using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.Linq;
using System.Web;
using CEMIS.Util;
using EQWYB.Model;
namespace EQWYB.BLL {
	 	//EmployerService
		public partial class EmployerService
	{
   		     
		private readonly EQWYB.DAL.EmployerDAL dal=new EQWYB.DAL.EmployerDAL();
        public EmployerService()
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
		public int  Add(EQWYB.Model.Employer model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EQWYB.Model.Employer model)
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
		public EQWYB.Model.Employer GetModel(int id)
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
		public List<EQWYB.Model.Employer> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EQWYB.Model.Employer> DataTableToList(DataTable dt)
		{
			List<EQWYB.Model.Employer> modelList = new List<EQWYB.Model.Employer>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				EQWYB.Model.Employer model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new EQWYB.Model.Employer();					
													if(dt.Rows[n]["id"].ToString()!="")
				{
					model.id=int.Parse(dt.Rows[n]["id"].ToString());
				}
																																if(dt.Rows[n]["orderList"].ToString()!="")
				{
					model.orderList=int.Parse(dt.Rows[n]["orderList"].ToString());
				}
																																				model.name= dt.Rows[n]["name"].ToString();
																																												if(dt.Rows[n]["sex"].ToString()!="")
				{
					if((dt.Rows[n]["sex"].ToString()=="1")||(dt.Rows[n]["sex"].ToString().ToLower()=="true"))
					{
					model.sex= true;
					}
					else
					{
					model.sex= false;
					}
				}
																				model.staff= dt.Rows[n]["staff"].ToString();
																																model.introduce= dt.Rows[n]["introduce"].ToString();
																						
				
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