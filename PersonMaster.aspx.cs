using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class PersonMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            btnUpdate.Enabled = false;
            LoadPersons();
        }
    }
    private void LoadPersons()
    {
        try
        {
            SqlConnection con = new SqlConnection(Commons.GetConnectionString);
            SqlCommand cmd = new SqlCommand("spGetPersons",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dtadp = new SqlDataAdapter();
            dtadp.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dtadp.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void Clears()
    {
        hdfID.Value = "";
        btnSave.Enabled = true;
        btnUpdate.Enabled = false;
        txtPersonAge.Text = "";
        txtPersonName.Text = "";
        LoadPersons();
        txtPersonName.Focus();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(Commons.GetConnectionString);
            SqlCommand cmd = new SqlCommand("spSavePerson", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonName", txtPersonName.Text);
            cmd.Parameters.AddWithValue("@PersonAge", txtPersonAge.Text);
            cmd.Parameters.Add("@Result", SqlDbType.VarChar, 100);
            cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
            con.Open();
            cmd.ExecuteNonQuery();
            string strMsg = cmd.Parameters["@Result"].Value.ToString();
            con.Close();
            Commons.MsgBox(strMsg);
            if (strMsg.Contains("already")==false)
            {
                Clears();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    private void UpdateData()
    {
        SqlConnection con = new SqlConnection(Commons.GetConnectionString);
        SqlCommand cmd = new SqlCommand("spUpdatePerson", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PersonID", hdfID.Value);
        cmd.Parameters.AddWithValue("@PersonName", txtPersonName.Text);
        cmd.Parameters.AddWithValue("@PersonAge", txtPersonAge.Text);
        cmd.Parameters.Add("@Result", SqlDbType.VarChar, 100);
        cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
        con.Open();
        cmd.ExecuteNonQuery();
        string strMsg = cmd.Parameters["@Result"].Value.ToString();
        con.Close();
        Commons.MsgBox(strMsg);
        if (strMsg.Contains("already") == false)
        {
            Clears();
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if(e.CommandName=="Ed")
        {
            hdfID.Value = GridView1.Rows[index].Cells[0].Text;
            txtPersonName.Text= GridView1.Rows[index].Cells[1].Text;
            txtPersonAge.Text= GridView1.Rows[index].Cells[2].Text;
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        UpdateData();
    }
}