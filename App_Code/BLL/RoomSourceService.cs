using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using CEMIS.Util;
using EQWYB.Model;

/// <summary>
///RoomSourceService 的摘要说明
/// </summary>
namespace EQWYB.BLL
{
	/// <summary>
	/// RoomSource
	/// </summary>
	public partial class RoomSourceService
	{
		private readonly EQWYB.DAL.RoomSourceDAL dal=new EQWYB.DAL.RoomSourceDAL();
		public RoomSourceService()
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
		public int  Add(EQWYB.Model.RoomSource model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EQWYB.Model.RoomSource model)
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
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EQWYB.Model.RoomSource GetModel(int id)
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
		public List<EQWYB.Model.RoomSource> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EQWYB.Model.RoomSource> DataTableToList(DataTable dt)
		{
			List<EQWYB.Model.RoomSource> modelList = new List<EQWYB.Model.RoomSource>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				EQWYB.Model.RoomSource model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new EQWYB.Model.RoomSource();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["title"]!=null && dt.Rows[n]["title"].ToString()!="")
					{
					model.title=dt.Rows[n]["title"].ToString();
					}
					if(dt.Rows[n]["build"]!=null && dt.Rows[n]["build"].ToString()!="")
					{
					model.build=dt.Rows[n]["build"].ToString();
					}
					if(dt.Rows[n]["roomNum"]!=null && dt.Rows[n]["roomNum"].ToString()!="")
					{
					model.roomNum=dt.Rows[n]["roomNum"].ToString();
					}
					if(dt.Rows[n]["toward"]!=null && dt.Rows[n]["toward"].ToString()!="")
					{
					model.toward=dt.Rows[n]["toward"].ToString();
					}
					if(dt.Rows[n]["decorate"]!=null && dt.Rows[n]["decorate"].ToString()!="")
					{
					model.decorate=dt.Rows[n]["decorate"].ToString();
					}
					if(dt.Rows[n]["area"]!=null && dt.Rows[n]["area"].ToString()!="")
					{
						model.area=decimal.Parse(dt.Rows[n]["area"].ToString());
					}
					if(dt.Rows[n]["rent"]!=null && dt.Rows[n]["rent"].ToString()!="")
					{
					model.rent=dt.Rows[n]["rent"].ToString();
					}
					if(dt.Rows[n]["address"]!=null && dt.Rows[n]["address"].ToString()!="")
					{
					model.address=dt.Rows[n]["address"].ToString();
					}
					if(dt.Rows[n]["block"]!=null && dt.Rows[n]["block"].ToString()!="")
					{
					model.block=dt.Rows[n]["block"].ToString();
					}
					if(dt.Rows[n]["phone"]!=null && dt.Rows[n]["phone"].ToString()!="")
					{
					model.phone=dt.Rows[n]["phone"].ToString();
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

