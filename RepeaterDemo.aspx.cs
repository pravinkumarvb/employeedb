using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class RepeaterDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            try
            {
                //bind data using DataSet
                SqlConnection con = new SqlConnection(Commons.GetConnectionString);
                string strcmd = "select RollNo,SName,S1,S2,S3,(S1+s2+s3) as TotalMarks,"+
                                " (S1+s2+s3)/3 as Average "+
                                " from Students order by RollNo";
                SqlCommand cmd = new SqlCommand(strcmd, con);
                SqlDataAdapter dtadp = new SqlDataAdapter();
                dtadp.SelectCommand = cmd;
                //DataTable dt = new DataTable();
                //dtadp.Fill(dt);
                DataSet ds = new DataSet();
                dtadp.Fill(ds, "S");
                Repeater1.DataSource = ds.Tables["S"];
                //Repeater1.DataSource = ds.Tables[0];
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}