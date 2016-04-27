using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.OleDb;
using System.Web.Configuration;
using System.Windows.Forms;

/// <summary>
/// DBConnection 的摘要说明
/// </summary>

namespace CEMIS.Util
{
    public class DBConnection : IDisposable
    {
        public IDbCommand command;
        private string connstring;
        private bool handleError;
        private string lastError;
        private DBManager dbManager=new DBManager();




        private bool isConnected;// 数据库连接标志


        private bool isTran;// 存储过程开启标志


        //数据库连接对象
        //private SqlConnection conn;
        //private SqlCommand comm;
        private SqlTransaction tran;
        private SqlDataAdapter sda;
        //private bool ConnectDataBase()
        //{
        //    if (!isConnected)
        //    {
        //        try
        //        {
        //            if (conn == null)
        //            {
        //                conn = new SqlConnection(connstring);
        //                conn.Open();
        //            }

        //            if (comm == null)
        //            {
        //                comm = new SqlCommand();
        //            }
        //            isConnected = true;
        //            comm.Connection = conn;
        //        }
        //        catch (SqlException e)
        //        {
        //            MessageBox.Show(e.Message.ToString());
        //        }
        //    }
        //    return true;
        //}


        public DBConnection()
        {

            SqlConnection connection = new SqlConnection();
         //   connstring = ConfigurationManager.AppSettings["connstring"];
         
            connstring = WebConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
            connection.ConnectionString = connstring;
            handleError = false;
            lastError = "";

            command = new SqlCommand();
            command.Connection = connection;
            // command.CommandType = CommandType.Text;
        }

        public IDataReader ExecuteReader()
        {
            IDataReader reader = null;
            try
            {
                this.Open();
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                //this.Dispose();
            }
            catch (Exception ex)
            {
                if (handleError)
                    lastError = ex.Message;
                else
                    throw;
            }
            catch { throw; }
            return reader;
        }

        public IDataReader ExecuteReader(string commandText)
        {
            //if (!ConnectDataBase())
            //{
            //    throw (new ApplicationException("没有建立数据库连接。"));
            //}
            IDataReader reader = null;
            try
            {
                command.CommandText = commandText;
                reader = this.ExecuteReader();
            }
            catch (Exception ex)
            {
                if (handleError)
                    lastError = ex.Message;
                else
                    throw;
            }
            catch { throw; }

            return reader;
        }


        public object ExecuteScalar()
        {
            object obj = null;
            try
            {
                this.Open();
            //    obj = command.ExecuteReader();
                obj = command.ExecuteScalar();
                //this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                if (handleError)
                    lastError = ex.Message;
                else
                    throw;
            }
            catch
            {
                throw;
            }
            return obj;
        }

        public object ExecuteScalar(string commandText)
        {
            object obj = null;
            try
            {
                command.CommandText = commandText;
                obj = this.ExecuteScalar();
            }
            catch (Exception ex)
            {
                if (handleError)
                    lastError = ex.Message;
                else
                    throw;
            }
            catch { throw; }
            return obj;
        }

        public int ExecuteNonQuery()
        {

            int i = -1;
            try
            {
                this.Open();
                i = command.ExecuteNonQuery();
                //this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                if (handleError)
                    lastError = ex.Message;
                else
                    throw;
            }
            catch { throw; }
            return i;
        }

        public int ExecuteNonQuery(string commandText)
        {
            int i = -1;
            try
            {
                command.CommandText = commandText;
                i = this.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (handleError)
                    lastError = ex.Message;
                else
                    throw;
            }
            catch { throw; }

            return i;
        }

        public int ExecuteNonQueryRet(string commandText)
        {
            SqlParameter p = new SqlParameter("@returnValue", SqlDbType.Int);
            p.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(p);
            int i = -1;
            try
            {
                command.CommandText = commandText;
                this.ExecuteNonQuery();
                i = Int32.Parse(p.Value.ToString());
            }
            catch (Exception ex)
            {
                if (handleError)
                {
                    lastError = ex.Message;
                }
                else
                {
                    throw;
                }
            }

            return i;

        }

        public DataSet ExecuteDataSet()
        {
            SqlDataAdapter sda = null;
            DataSet ds = null;
            try
            {
                sda = new SqlDataAdapter();
                sda.SelectCommand = (SqlCommand)command;
                ds = new DataSet();
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                if (handleError)
                    lastError = ex.Message;
                else
                    throw;
            }
            catch { throw; }

            return ds;

        }


        public DataSet ExecuteDataSet(string commandText)
        {
            DataSet ds = null;
            try
            {
                command.CommandText = commandText;
                ds = this.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                if (handleError)
                    lastError = ex.Message;
                else
                    throw;
            }
            catch { throw; }
            return ds;
        }

        public void AddParameter(IDataParameter parameter)
        {
            command.Parameters.Add(parameter);
        }

        public void AddParameter(string paramName, object paramValue)
        {
            SqlParameter param = new SqlParameter(paramName, paramValue);
            command.Parameters.Add(param);

        }


        //用于不同类型的变量添加
        public void AddParameter(string paramName, object paramValue,SqlDbType type)
        {
            SqlParameter param = new SqlParameter(paramName, type);
            param.Value=paramValue;
            command.Parameters.Add(param);
        }

        public IDataParameterCollection Parameters
        {
            get { return command.Parameters; }
        }

        public string CommandText
        {
            get { return command.CommandText; }
            set
            {
                command.CommandText = value;
                command.Parameters.Clear();
            }
        }

        public string ConnString
        {
            get { return connstring; }
            set { connstring = value; }
        }

        private void Open()
        {
            command.Connection.Open();
        }

        private void Close()
        {
            command.Connection.Close();
        }

        public bool HandleExceptions
        {
            get { return handleError; }
            set { handleError = value; }
        }

        public string LastError
        {
            get { return lastError; }
            set { lastError = value; }
        }
      
        public void Dispose()
        {
           
            command.Connection.Close();
            command.Dispose();
        }


        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

    }
}


