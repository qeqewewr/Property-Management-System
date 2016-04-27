using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CEMIS.Model.Employe;
using CEMIS.Util;
using CEMIS.Util.Page;
using System.Data.Sql;
using System.Data.SqlClient;


/// <summary>
///IntroduceDAO 的摘要说明
/// </summary>
/// 

namespace CEMIS.Model.Employe
{
    public class IntroduceDAO
    {
        public IntroduceDAO()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public int AddIntroduce(Introduce intro)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@Introduction", intro.Introduction);
            db.AddParameter("@Telephone", intro.Telephone);
            db.AddParameter("@Address",intro.Address );
            if (intro.Sum != 0)
                db.AddParameter("@Sum", intro.Sum);
            else
                db.AddParameter("@Sum", DBNull.Value);
            db.AddParameter("@Email", intro.Email);
            db.AddParameter("@RentProcedure",intro.RentProcedure );
            db.AddParameter("@FeeAddress",intro.FeeAddress );
            db.AddParameter("@FeeCompany",intro.FeeCompany );
            db.AddParameter("@FeeAccount",intro.FeeAccount );



            string sql = "insert into Info_Property(Introduction,Telephone,Address,Sum,Email,RentProcedure,FeeAddress,FeeCompany,FeeAccount) values(@Introduction,@Telephone,@Address,@Sum,@Email,@RentProcedure,@FeeAddress,@FeeCompany,@FeeAccount)";

            return db.ExecuteNonQuery(sql);
        }



        public int UpdateIntroduce(Introduce intro)
        {
            DBConnection db = new DBConnection();

            db.AddParameter("@ID", intro.ID);
            db.AddParameter("@Introduction", intro.Introduction);
            db.AddParameter("@Telephone", intro.Telephone);
            db.AddParameter("@Address", intro.Address);
            if (intro.Sum != 0)
                db.AddParameter("@Sum", intro.Sum);
            else
                db.AddParameter("@Sum", DBNull.Value);
            db.AddParameter("@Email", intro.Email);
            db.AddParameter("@RentProcedure", intro.RentProcedure);
            db.AddParameter("@FeeAddress", intro.FeeAddress);
            db.AddParameter("@FeeCompany", intro.FeeCompany);
            db.AddParameter("@FeeAccount", intro.FeeAccount);
			db.AddParameter("@P1Url", intro.P1Url);
			db.AddParameter("@P2Url", intro.P2Url);
           // string sql = "update Info_Property set Introduction=@Introduction,Telephone=@Telephone,Address=@Address,Sum=@Sum,Email=@Email,RentProcedure=@RentProcedure,FeeAddress=@FeeAddress,FeeCompany=@FeeCompany,FeeAccount=@FeeAccount where ID=@ID";
			string sql = "update Info_Property set Introduction=@Introduction,Telephone=@Telephone,Address=@Address,Sum=@Sum,Email=@Email,RentProcedure=@RentProcedure,FeeAddress=@FeeAddress,FeeCompany=@FeeCompany,FeeAccount=@FeeAccount";
			if (intro.P1Url != "") sql += ",P1Url=@P1URL";
			if (intro.P1Url != "") sql += ",P2Url=@P2URL";
			sql += " where ID=@ID";
            return db.ExecuteNonQuery(sql);

        }

        public Introduce GetIntroduce(int id)
        {
            Introduce intro = new Introduce();

            DBConnection db = new DBConnection();

            db.AddParameter("@ID", id);

            string sql = "select * from Info_Property where ID=@ID";

            SqlDataReader sdr = (SqlDataReader)db.ExecuteReader(sql);

            if (sdr.Read())
            {
                intro.ID = int.Parse(sdr["ID"].ToString());
                intro.Introduction = sdr["Introduction"].ToString();
                intro.Telephone = sdr["Telephone"].ToString();
                intro.Address = sdr["Address"].ToString();
                if (sdr["Sum"].ToString() != "" && sdr["Sum"].ToString() != null)
                    intro.Sum = int.Parse(sdr["Sum"].ToString());
                intro.Email = sdr["Email"].ToString();
                intro.RentProcedure = sdr["RentProcedure"].ToString();
                intro.FeeAddress = sdr["FeeAddress"].ToString();
                intro.FeeCompany = sdr["FeeCompany"].ToString();
                intro.FeeAccount = sdr["FeeAccount"].ToString();
				intro.P1Url = sdr["P1Url"].ToString();
				intro.P2Url = sdr["P2Url"].ToString();
				//intro.FeeAccount = sdr["P1"].ToString();
            }
            else
                intro = null;
            return intro;

        }

        public int GetTotalRecordNum()
        {

            DBConnection db = new DBConnection();
            string sql = "select count(*) as a from Info_Property";

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

}
