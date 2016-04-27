using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using System.Web;
using CEMIS.Util;
namespace EQWYB.DAL  
{
	 	//EmployementDAL
		public partial class EmployementDAL
	{
   		     
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Employement");
			strSql.Append(" where ");
			                                       strSql.Append(" id = @id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(EQWYB.Model.Employement model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Employement(");			
            strSql.Append("company,staff,title,endDate,startDate,detail,number");
			strSql.Append(") values (");
            strSql.Append("@company,@staff,@title,@endDate,@startDate,@detail,@number");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@company", SqlDbType.VarChar) ,            
                        new SqlParameter("@staff", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@title", SqlDbType.VarChar) ,            
                        new SqlParameter("@endDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@startDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@detail", SqlDbType.NText) ,            
                        new SqlParameter("@number", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.company;                        
            parameters[1].Value = model.staff;                        
            parameters[2].Value = model.title;                        
            parameters[3].Value = model.endDate;                        
            parameters[4].Value = model.startDate;                        
            parameters[5].Value = model.detail;                        
            parameters[6].Value = model.number;                        
			   
			object obj = DBHelperSQL.GetSingle(strSql.ToString(),parameters);			
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
		public bool Update(EQWYB.Model.Employement model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Employement set ");
			                                                
            strSql.Append(" company = @company , ");                                    
            strSql.Append(" staff = @staff , ");                                    
            strSql.Append(" title = @title , ");                                    
            strSql.Append(" endDate = @endDate , ");                                    
            strSql.Append(" startDate = @startDate , ");                                    
            strSql.Append(" detail = @detail , ");                                    
            strSql.Append(" number = @number  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@company", SqlDbType.VarChar) ,            
                        new SqlParameter("@staff", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@title", SqlDbType.VarChar) ,            
                        new SqlParameter("@endDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@startDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@detail", SqlDbType.NText) ,            
                        new SqlParameter("@number", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.company;                        
            parameters[2].Value = model.staff;                        
            parameters[3].Value = model.title;                        
            parameters[4].Value = model.endDate;                        
            parameters[5].Value = model.startDate;                        
            parameters[6].Value = model.detail;                        
            parameters[7].Value = model.number;                        
            int rows=DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Employement ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;


			int rows=DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Employement ");
			strSql.Append(" where ID in ("+idlist + ")  ");
			int rows=DBHelperSQL.ExecuteSql(strSql.ToString());
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
		public EQWYB.Model.Employement GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, company, staff, title, endDate, startDate, detail, number  ");			
			strSql.Append("  from Employement ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			
			EQWYB.Model.Employement model=new EQWYB.Model.Employement();
			DataSet ds=DBHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																				model.company= ds.Tables[0].Rows[0]["company"].ToString();
																																model.staff= ds.Tables[0].Rows[0]["staff"].ToString();
																																model.title= ds.Tables[0].Rows[0]["title"].ToString();
																												if(ds.Tables[0].Rows[0]["endDate"].ToString()!="")
				{
					model.endDate=DateTime.Parse(ds.Tables[0].Rows[0]["endDate"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["startDate"].ToString()!="")
				{
					model.startDate=DateTime.Parse(ds.Tables[0].Rows[0]["startDate"].ToString());
				}
																																				model.detail= ds.Tables[0].Rows[0]["detail"].ToString();
																												if(ds.Tables[0].Rows[0]["number"].ToString()!="")
				{
					model.number=int.Parse(ds.Tables[0].Rows[0]["number"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM Employement ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DBHelperSQL.Query(strSql.ToString());
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM Employement ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelperSQL.Query(strSql.ToString());
		}

   
	}
}

