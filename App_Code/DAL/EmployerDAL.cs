using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using System.Web;
using CEMIS.Util;
namespace EQWYB.DAL  
{
	 	//EmployerDAL
		public partial class EmployerDAL
	{
   		     
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Employer");
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
		public int Add(EQWYB.Model.Employer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Employer(");			
            strSql.Append("orderList,name,sex,staff,introduce");
			strSql.Append(") values (");
            strSql.Append("@orderList,@name,@sex,@staff,@introduce");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@orderList", SqlDbType.Int,4) ,            
                        new SqlParameter("@name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@sex", SqlDbType.Bit,1) ,            
                        new SqlParameter("@staff", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@introduce", SqlDbType.NText)             
              
            };
			            
            parameters[0].Value = model.orderList;                        
            parameters[1].Value = model.name;                        
            parameters[2].Value = model.sex;                        
            parameters[3].Value = model.staff;                        
            parameters[4].Value = model.introduce;                        
			   
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
		public bool Update(EQWYB.Model.Employer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Employer set ");
			                                                
            strSql.Append(" orderList = @orderList , ");                                    
            strSql.Append(" name = @name , ");                                    
            strSql.Append(" sex = @sex , ");                                    
            strSql.Append(" staff = @staff , ");                                    
            strSql.Append(" introduce = @introduce  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@orderList", SqlDbType.Int,4) ,            
                        new SqlParameter("@name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@sex", SqlDbType.Bit,1) ,            
                        new SqlParameter("@staff", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@introduce", SqlDbType.NText)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.orderList;                        
            parameters[2].Value = model.name;                        
            parameters[3].Value = model.sex;                        
            parameters[4].Value = model.staff;                        
            parameters[5].Value = model.introduce;                        
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
			strSql.Append("delete from Employer ");
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
			strSql.Append("delete from Employer ");
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
		public EQWYB.Model.Employer GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, orderList, name, sex, staff, introduce  ");			
			strSql.Append("  from Employer ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			
			EQWYB.Model.Employer model=new EQWYB.Model.Employer();
			DataSet ds=DBHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["orderList"].ToString()!="")
				{
					model.orderList=int.Parse(ds.Tables[0].Rows[0]["orderList"].ToString());
				}
																																				model.name= ds.Tables[0].Rows[0]["name"].ToString();
																																												if(ds.Tables[0].Rows[0]["sex"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["sex"].ToString()=="1")||(ds.Tables[0].Rows[0]["sex"].ToString().ToLower()=="true"))
					{
					model.sex= true;
					}
					else
					{
					model.sex= false;
					}
				}
																				model.staff= ds.Tables[0].Rows[0]["staff"].ToString();
																																model.introduce= ds.Tables[0].Rows[0]["introduce"].ToString();
																										
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
			strSql.Append(" FROM Employer ");
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
			strSql.Append(" FROM Employer ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelperSQL.Query(strSql.ToString());
		}

   
	}
}

