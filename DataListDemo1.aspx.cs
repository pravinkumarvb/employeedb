using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DataListDemo1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            LoadPersons();
        }
    }
    private void LoadPersons()
    {
        try
        {
            string strcmd = "select PersonID,PersonName,PersonAge from Persons order by PersonID";
            DataTable dt = new DataTable();
            dt = SQLHelper.FillData(strcmd);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}