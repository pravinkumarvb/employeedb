using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SQLHelper
/// </summary>
public class SQLHelper
{
    public static void ExecuteNonQuery(string strcmd)
    {
        try
        {
            SqlConnection con = new SqlConnection(Commons.GetConnectionString);
            SqlCommand cmd = new SqlCommand(strcmd, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static DataTable FillData(string strcmd)
    {
        try
        {
            SqlConnection con = new SqlConnection(Commons.GetConnectionString);
            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataAdapter dtadp = new SqlDataAdapter();
            dtadp.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dtadp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}