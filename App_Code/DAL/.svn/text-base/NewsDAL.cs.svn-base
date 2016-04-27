using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using System.Web;
using CEMIS.Util;
namespace EQWYB.DAL  
{
	 	//NewsDAL
		public partial class NewsDAL
	{
   		     
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from News");
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
		public int Add(EQWYB.Model.News model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into News(");			
            strSql.Append("title,body,publishTime,style");
			strSql.Append(") values (");
            strSql.Append("@title,@body,@publishTime,@style");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@title", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@body", SqlDbType.Text) ,            
                        new SqlParameter("@publishTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@style", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.title;                        
            parameters[1].Value = model.body;                        
            parameters[2].Value = model.publishTime;                        
            parameters[3].Value = model.style;                        
			   
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
		public bool Update(EQWYB.Model.News model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update News set ");
			                                                
            strSql.Append(" title = @title , ");                                    
            strSql.Append(" body = @body , ");                                    
            strSql.Append(" publishTime = @publishTime , ");                                    
            strSql.Append(" style = @style  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@title", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@body", SqlDbType.Text) ,            
                        new SqlParameter("@publishTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@style", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.title;                        
            parameters[2].Value = model.body;                        
            parameters[3].Value = model.publishTime;                        
            parameters[4].Value = model.style;                        
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
			strSql.Append("delete from News ");
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
			strSql.Append("delete from News ");
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
		public EQWYB.Model.News GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, title, body, publishTime, style  ");			
			strSql.Append("  from News ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			
			EQWYB.Model.News model=new EQWYB.Model.News();
			DataSet ds=DBHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																				model.title= ds.Tables[0].Rows[0]["title"].ToString();
																																model.body= ds.Tables[0].Rows[0]["body"].ToString();
																												if(ds.Tables[0].Rows[0]["publishTime"].ToString()!="")
				{
					model.publishTime=DateTime.Parse(ds.Tables[0].Rows[0]["publishTime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["style"].ToString()!="")
				{
					model.style=int.Parse(ds.Tables[0].Rows[0]["style"].ToString());
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
			strSql.Append(" FROM News ");
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
			strSql.Append(" FROM News ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// **获得查询结果的数据行数(有类型)
        /// </summary>
        /// <param name="filed"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public int GetInqueryNum(string filed, string str,string whereStr)
        {
            int rows = DBHelperSQL.GetInqueryNum(filed, str,whereStr,"News");
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
            int rows = DBHelperSQL.GetInqueryNum(filed, str, "News");
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
        public DataSet ListLookNews(int pageno, int pagesize, string filed, string name, string whereStr)
        {
            int rowcount = this.GetInqueryNum(filed, name,whereStr);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by publishTime DESC) as rownum ,* from News where " + filed + " like '%" + name + "%' and whereStr) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by publishTime DESC) as rownum, * from News where " + filed + " like '%" + name + "%' and whereStr)select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

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
        public DataSet ListLookNews(int pageno, int pagesize, string filed, string name)
        {
            int rowcount = this.GetInqueryNum(filed, name);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by publishTime DESC) as rownum ,* from News where " + filed + " like '%" + name + "%') select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by publishTime DESC) as rownum, * from News where " + filed + " like '%" + name + "%')select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }
        
        /// <summary>
        /// **所有数据行数
        /// </summary>
        /// <returns></returns>
        public int GetTotalRecordNum()
        {
            int rows = DBHelperSQL.countNum("News");
            return rows;
        }

        /// <summary>
        /// **所有数据行数(有类型)
        /// </summary>
        /// <returns></returns>
        public int GetTotalRecordNum(string whereStr)
        {
            int rows = DBHelperSQL.countNum("News",whereStr);
            return rows;
        }
        
        /// <summary>
        /// **当前页数据列表（未查询）
        /// </summary>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public DataSet ListPageNews(int pageno, int pagesize)
        {
            int rowcount = this.GetTotalRecordNum();
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by publishTime DESC) as rownum ,* from News ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by publishTime DESC) as rownum, * from News )select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }

        /// <summary>
        /// **当前页数据列表（未查询）(有类型)
        /// </summary>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public DataSet ListPageNews(int pageno, int pagesize,string whereStr)
        {
            int rowcount = this.GetTotalRecordNum(whereStr);
            String sql;
            if (pageno * pagesize > rowcount)
                sql = "with temp as( select row_number() over(order by publishTime DESC) as rownum ,* from News where "+whereStr+" ) select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (rowcount) + "";
            else
                sql = "with temp as( select row_number() over(order by publishTime DESC) as rownum, * from News where " + whereStr + ")select * from temp where rownum between " + (pagesize * (pageno - 1) + 1) + " and " + (pageno * pagesize) + "";

            return DBHelperSQL.Query(sql);
        }
   
	}
}

