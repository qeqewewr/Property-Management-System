using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using CEMIS.Model.Employe;

public partial class PropertyIntroduction : System.Web.UI.Page
{
    public Introduce intro = new Introduce();
    public IntroduceDAO introDAO = new IntroduceDAO();

    public Boolean IsExist = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        intro = introDAO.GetIntroduce(1);

        if (intro != null)
        {
            IsExist = true;
        }

        //using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionStr))
        //{
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("select * from Info_Property Where ID=1", conn);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    if (reader.Read())
        //    {
        //        labelMessage.Text = reader["Introduction"].ToString();
        //        address.Text = reader["Address"].ToString();
        //        telephone.Text = reader["Telephone"].ToString();
        //        email.Text = reader["Email"].ToString();
                
        //    }
        //    conn.Dispose();
        //}
    }
}
