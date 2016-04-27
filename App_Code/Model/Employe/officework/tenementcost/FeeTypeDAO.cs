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
using System.Collections.Generic;
using CEMIS.Util;
using CEMIS.Model.Employe;


/// <summary>
///FeeTypeDAO 的摘要说明
/// </summary>
public class FeeTypeDAO
{
	public FeeTypeDAO()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="feeType"></param>
    /// <returns></returns>
    public int AddFeeType(FeeType feeType)
    {
        DBConnection db = new DBConnection();
        db.AddParameter("@Name", feeType.FeeName);

        string sql = "insert into FeeType(Name) values(@Name)";
        int flag = db.ExecuteNonQuery(sql);
        
        return flag;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sdr"></param>
    /// <returns></returns>
    public FeeType GetFeeTypeBySdr(SqlDataReader sdr)
    {
        FeeType feeType = new FeeType();
        feeType.Id = int.Parse(sdr["ID"].ToString());
        feeType.FeeName = sdr["Name"].ToString();

        return feeType;
    }

    public FeeType GetFeeTypeById(string id)
    {
        FeeType feeType = new FeeType();
        DBConnection db = new DBConnection();
        db.AddParameter("@ID", int.Parse(id));
        string sql = "select * from FeeType Where ID=@ID";
        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        if (sdr.Read())
        {
            feeType.Id = int.Parse(sdr["ID"].ToString());
            feeType.FeeName = sdr["Name"].ToString();
        }

        db.Dispose();
        return feeType;
    }


    /// <summary>
    /// 有ID获得费用名
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetFeeNameById(string id)
    {
        string feeName = "";
        DBConnection db = new DBConnection();
        db.AddParameter("@ID", int.Parse(id));
        string sql = "select Name from FeeType Where ID=@ID";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        if (sdr.Read())
            feeName = sdr["Name"].ToString();
        db.Dispose();
        return feeName;
    }
    /// <summary>
    /// 读取表数据
    /// </summary>
    /// <returns></returns>
    public List<FeeType> ListFeeType()
    {
        List<FeeType> feeTypeList = new List<FeeType>();

        DBConnection db = new DBConnection();
        string sql = "select * from FeeType";

        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        while (sdr.Read())
        {
            FeeType feeType = GetFeeTypeBySdr(sdr);
            feeTypeList.Add(feeType);
        }
        db.Dispose();
        return feeTypeList;
    }


    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int DeleteFeeType(string id)
    {
        DBConnection db = new DBConnection();
        int ID = int.Parse(id);
        db.AddParameter("@ID", ID);
        string sql = "delete from FeeType where ID=@ID";
        int flag = db.ExecuteNonQuery(sql);
        return flag;
    }

    public int UpdateFeeType(FeeType feeType)
    {
        DBConnection db = new DBConnection();
        db.AddParameter("@ID", feeType.Id);
        db.AddParameter("@Name", feeType.FeeName);

        string sql = "update FeeType set Name=@Name where ID=@ID ";

        int flag = db.ExecuteNonQuery(sql);
        return flag;
    }
    /// <summary>
    ///获得表记录总数
    /// </summary>
    /// <returns></returns>
    public int GetTotalRecordNum()
    {

        DBConnection db = new DBConnection();
        string sql = "select count(*) as a from FeeType";

        int count = 0;
        SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);
        while (sdr.Read())
        {
            count = int.Parse(sdr["a"].ToString());
        }

        db.Dispose();
        return count;
    }
}