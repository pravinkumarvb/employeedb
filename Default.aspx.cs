using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            btnUpdate.Enabled = false;
            LoadDes();
            LoadData();
        }
    }
    private void LoadDes()
    {
        try
        {
            SqlConnection con = new SqlConnection(Commons.GetConnectionString);
            string strcmd = "select DesID,DesName from Designations order by DesID";
            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataAdapter dtadp = new SqlDataAdapter();
            dtadp.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dtadp.Fill(dt);
            ddlDes.DataSource = dt;
            ddlDes.DataTextField = "DesName";
            ddlDes.DataValueField = "DesID";
            ddlDes.DataBind();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    private void Clears()
    {
        btnSave.Enabled = true;
        btnUpdate.Enabled = false;
        hdfEmpID.Value = "";
        txtEmpName.Text = "";
        txtSalary.Text = "";
        LoadData();
        txtEmpName.Focus();
    }
    private void LoadData()
    {
        try
        {
            SqlConnection con = new SqlConnection(Commons.GetConnectionString);
            string strcmd = "select Employees.EmpID,Employees.EmpName,Designations.DesName,Employees.Salary "+
                            " from Employees inner join Designations "+
                            " on Designations.DesID = Employees.DesID "+
                            " order by Employees.EmpID";
            SqlCommand cmd = new SqlCommand(strcmd, con);
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
    private void SaveData()
    {
        try
        {
            SqlConnection con = new SqlConnection(Commons.GetConnectionString);
            string strcmd = "insert into Employees(EmpName,DesID,Salary) values('" + txtEmpName.Text + "'," +
                ddlDes.SelectedValue + "," + txtSalary.Text + ")";
            SqlCommand cmd = new SqlCommand(strcmd, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Clears();
            Commons.MsgBox("Employee saved successfully");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //to check emp name is already exist or not
        try
        {
            SqlConnection con = new SqlConnection(Commons.GetConnectionString);
            string strcmd = "select EmpID from Employees where EmpName='" + txtEmpName.Text + "'";
            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataAdapter dtadp = new SqlDataAdapter();
            dtadp.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dtadp.Fill(dt);
            if(dt.Rows.Count>0)
            {
                Commons.MsgBox("Employee name is already exist !!!");
                txtEmpName.Focus();
            }
            else
            {
                SaveData();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void btnClears_Click(object sender, EventArgs e)
    {
        Clears();
    }
    
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if(e.CommandName=="Ed")
        {
            hdfEmpID.Value = GridView1.Rows[index].Cells[0].Text;
            txtEmpName.Text = GridView1.Rows[index].Cells[1].Text;
            ddlDes.SelectedValue = ddlDes.Items.FindByText(GridView1.Rows[index].Cells[2].Text).Value;
            txtSalary.Text = GridView1.Rows[index].Cells[3].Text;
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
        }
        if(e.CommandName=="Del")
        {
            string strID= GridView1.Rows[index].Cells[0].Text;
            DeleteData(strID);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(Commons.GetConnectionString);
            string strcmd = "update Employees set EmpName='" + txtEmpName.Text +
                "',DesID=" + ddlDes.SelectedValue + ",Salary=" + txtSalary.Text +
                " where EmpID=" + hdfEmpID.Value;
            SqlCommand cmd = new SqlCommand(strcmd, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Clears();
            Commons.MsgBox("Employee updated successfully");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    private void DeleteData(string strID)
    {
        try
        {
            SqlConnection con = new SqlConnection(Commons.GetConnectionString);
            string strcmd = "delete from Employees where EmpID=" + strID;
            SqlCommand cmd = new SqlCommand(strcmd, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Clears();
            Commons.MsgBox("Employee deleted successfully");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType==DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundcolor='Yellow'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundcolor='White'");
        }
    }
}