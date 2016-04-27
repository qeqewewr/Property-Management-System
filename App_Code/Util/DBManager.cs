using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using CEMIS.Util;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.OleDb;
using System.Web.Configuration;

/// <summary>
///DBManager 的摘要说明
/// </summary>
/// 
namespace CEMIS.Util
{
    public class DBManager : IDisposable
    {
        private string strConn; //数据库连接字符串


        private bool isConnected;// 数据库连接标志


        private bool isTran;// 存储过程开启标志


        //数据库连接对象
        private SqlConnection conn;
        private SqlCommand comm;
        private SqlTransaction tran;
        private SqlDataAdapter sda;


        //Encrypt encrypt = new Encrypt();
        //FileHelper helper = new FileHelper();


        public SqlConnection Conn
        {
            get { return conn; }
        }


        /// <summary>
        /// 默认构造将调用默认的连接字符串
        /// </summary>
        // public DBManager()
        // : this("Integrated Security=SSPI;Persist Security Info=False;data source= localhost;initial catalog=logistics;uid=sa")
        // {
        //    DBManager db = new  DBManager(0);
        // }

        public DBManager()
        {
            //string localhost = encrypt.dencrypt(helper.readFile(".//config/systemInformation.ini", 2));
            //string uid = encrypt.dencrypt(helper.readFile(".//config/systemInformation.ini", 0));
            //string pwd = encrypt.dencrypt(helper.readFile(".//config/systemInformation.ini", 1));

            strConn = WebConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
            // isConnected = false;



        }

        /// <summary>
        /// 实例化数据库访问对象
        /// </summary>
        /// <param name="sConnectionString">连接字符串</param>
        public DBManager(
            string sConnectionString)
        {
            if (sConnectionString != "")
            {
                strConn = sConnectionString;
                isConnected = false;
            }
            isConnected = false;
        }

        /// <summary>
        /// 连接数据库，并打开数据库连接
        /// </summary>
        /// <returns>成功返回true</returns>
        private bool ConnectDataBase()
        {
            if (!isConnected)
            {
                try
                {
                    if (conn == null)
                    {
                        conn = new SqlConnection(strConn);
                        conn.Open();
                    }

                    if (comm == null)
                    {
                        comm = new SqlCommand();
                    }
                    isConnected = true;
                    comm.Connection = conn;
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message.ToString());
                }
            }
            return true;
        }

        /// <summary>
        /// 关闭数据库，释放数据库资源
        /// </summary>
        /// <returns>成功返回true</returns>
        public bool CloseDataBase()
        {
            Dispose();
            return true;
        }
        #region IDisposable 成员
        /// <summary>
        /// 释放占用资源
        /// </summary>
        public void Dispose()
        {
            if (isConnected)
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    conn.Dispose();
                    comm = null;
                    conn = null;
                    tran = null;

                    isConnected = false;
                }
            }
            GC.SuppressFinalize(true);
        }
        #endregion

        /// <summary>
        /// 运行查询的方法,返回一个DataSet
        /// </summary>
        /// <param name="sql">要查询的SQL语句</param>
        /// <param name="sTableName">查询出来的表名</param>
        /// <param name="paramList">SqlParameter的列表</param>
        /// <returns>返回结果集</returns>
        //public DataSet Query(string sql, string sTableName, SqlParamerList paramList)
        //{

        //    //若连接数据库失败抛出错误
        //    if (!ConnectDataBase())
        //    {
        //        throw (new ApplicationException("没有建立数据库连接。"));
        //    }

        //    DataSet dataSet = new DataSet();
        //    comm.CommandType = System.Data.CommandType.Text;
        //    comm.CommandText = sql;
        //    sda = new SqlDataAdapter();
        //    sda.SelectCommand = comm;

        //    if (paramList != null)
        //    {
        //        paramList.Fill(comm);
        //    }

        //    try
        //    {
        //        sda.Fill(dataSet, sTableName);
        //    }
        //    catch (SqlException e)
        //    {
        //        //如果正在执行事务，回滚
        //        if (isTran)
        //        {
        //            tran.Rollback();
        //        }
        //        MessageBox.Show(e.Message.ToString());
        //    }
        //    return dataSet;
        //}

        /// <summary>
        /// 运行查询的方法，返回一个DataReader，适合小数据的读取
        /// </summary>
        /// <param name="sql">要查询的SQL语句</param>
        /// <param name="paramList">SqlParameter的列表</param>
        /// <returns>返回DataReader</returns>
        //public SqlDataReader Query(string sql, SqlParamerList paramList)
        //{

        //    //若连接数据库失败抛出错误
        //    if (!ConnectDataBase())
        //    {
        //        throw (new ApplicationException("没有建立数据库连接。"));
        //    }

        //    comm.CommandType = System.Data.CommandType.Text;
        //    comm.CommandText = sql;

        //    if (paramList != null)
        //    {
        //        paramList.Fill(comm);
        //    }
        //    SqlDataReader reader;
        //    try
        //    {
        //        reader = comm.ExecuteReader();
        //    }
        //    catch (SqlException e)
        //    {
        //        //如果正在执行事务，回滚
        //        if (isTran)
        //        {
        //            tran.Rollback();
        //        }
        //        throw e;
        //    }
        //    return reader;
        //}


        public IDataReader ExecuteReader()
        {
             if (!ConnectDataBase())
             {
                 throw (new ApplicationException("没有建立数据库连接。"));
             }
            IDataReader reader = null;
            try
            {
                
                reader = comm.ExecuteReader(CommandBehavior.CloseConnection);
            }
           
            catch { throw; }
            return reader;
        }

        public IDataReader ExecuteReader(string sql)
        {
            //若连接数据库失败抛出错误
            if (!ConnectDataBase())
            {
                throw (new ApplicationException("没有建立数据库连接。"));
            }          
            IDataReader reader = null;
            try
            {
                comm=new System.Data.SqlClient.SqlCommand(sql,conn);
                reader = ExecuteReader();
           
            }
            catch (SqlException e)
            {
                //如果正在执行事务，回滚
                if (isTran)
                {
                    tran.Rollback();
                }
                throw e;
            }
            return reader;
        }


        /// <summary>
        /// 执行修改数据库操作，修改、删除等无返回值的操作
        /// </summary>
        /// <param name="sql">执行的SQL语句</param>
        /// <param name="paramList">SqlParameter的列表</param>
        /// <returns>成功执行返回True</returns>
        //public bool Execute(string sql, SqlParamerList paramList)
        //{
        //    if (!ConnectDataBase())
        //    {
        //        throw (new ApplicationException("没有建立数据库连接"));
        //    }

        //    comm.CommandType = System.Data.CommandType.Text;
        //    comm.CommandText = sql;
        //    if (paramList != null)
        //    {
        //        paramList.Fill(comm);
        //    }

        //    try
        //    {
        //        comm.ExecuteNonQuery();
        //    }
        //    catch (SqlException e)
        //    {
        //        //如果正在执行事务，回滚
        //        if (isTran)
        //        {
        //            tran.Rollback();
        //        }
        //        MessageBox.Show(e.Message.ToString(), "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return true;
        //}

        /// <summary>
        /// 开始事务处理功能，之后执行的全部数据库操作语句需要调用提交函数（commit）生效
        /// </summary>
        public void StartTransation()
        {
            //若连接数据库失败抛出错误
            if (!ConnectDataBase())
            {
                throw (new ApplicationException("没有建立数据库连接。"));
            }

            isTran = true;
            tran = conn.BeginTransaction(
                IsolationLevel.ReadCommitted);
            comm.Transaction = tran;

        }

        /// <summary>
        /// 当前待处理事务提交，失败全部回滚
        /// <returns>成功提交返回true</returns>
        public bool Commit()
        {
            //如果没有开启事务处理功能，不做任何操作，直接返回成功
            if (!isTran)
            {
                return true;
            }

            try
            {
                tran.Commit();
            }
            catch (SqlException e)
            {
                tran.Rollback();
                throw e;
            }
            return true;
        }





    }
}
