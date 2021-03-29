using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class GridViewLoops : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            LoadStudents();
        }
    }
    private void LoadStudents()
    {
        try
        {
            //bind data using DataSet
            SqlConnection con = new SqlConnection(Commons.GetConnectionString);
            string strcmd = "select RollNo,SName,(S1+s2+s3) as TotalMarks," +
                            " (S1+s2+s3)/3 as Average " +
                            " from Students order by RollNo";
            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataAdapter dtadp = new SqlDataAdapter();
            dtadp.SelectCommand = cmd;
            //DataTable dt = new DataTable();
            //dtadp.Fill(dt);
            DataSet ds = new DataSet();
            dtadp.Fill(ds, "S");
            GridView1.DataSource = ds.Tables["S"];
            GridView1.DataBind();

            //to get no. of records
            int record = 0;
            record = ds.Tables["S"].Rows.Count;
            Label1.Text = record.ToString();

            //to get total avg
            float avg = 0.0F;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                avg += Convert.ToSingle(GridView1.Rows[i].Cells[3].Text);
            }
            Label2.Text = avg.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        float fltAvg = Convert.ToSingle(txtAvg.Text);
        bool found = false;
        for(int i=0;i<GridView1.Rows.Count;i++)
        {
            if(fltAvg<=Convert.ToSingle(GridView1.Rows[i].Cells[3].Text))
            {
                GridView1.Rows[i].Cells[3].BackColor = System.Drawing.Color.Yellow;
                found = true;
            }
            else
            {
                GridView1.Rows[i].Cells[3].BackColor = System.Drawing.Color.White;
            }
        }
        if(found==false)
        {
            Response.Write("<h3 style='color:red'>Record not found !!!</h3>");
        }
    }
}