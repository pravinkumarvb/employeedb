using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PersonComments : System.Web.UI.Page
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
            string strcmd = "select PersonID,PersonName,PersonAge from Persons order by PersonName";
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

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if(e.CommandName== "Comment")
        {
            Panel pnl = (Panel)e.Item.FindControl("Panel1");
            //Panel pnl = e.Item.FindControl("Panel1") as Panel;
            pnl.Visible = true;
        }
        else if(e.CommandName=="CCancel")
        {
            Panel pnl = (Panel)e.Item.FindControl("Panel1");
            pnl.Visible = false;
        }
        else if(e.CommandName=="CPost")
        {
            TextBox txt = (TextBox)e.Item.FindControl("txtComment");
            HiddenField hdf = (HiddenField)e.Item.FindControl("hdfPersonID");
            //save data
            try
            {
                string strcmd = "insert into Comments(PersonID,Comment,Dated,Timed) values(" + hdf.Value + ",'" +
                txt.Text + "','" + DateTime.Now.ToString("MM-dd-yyyy") + "','"+ 
                DateTime.Now.ToString("hh:mm:ss tt") +"')";
                SQLHelper.ExecuteNonQuery(strcmd);
                txt.Text = "";
                Panel pnl = (Panel)e.Item.FindControl("Panel1");
                pnl.Visible = false;
                Response.Redirect("~//PersonComments.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if(e.Item.ItemType==ListItemType.Item || e.Item.ItemType== ListItemType.AlternatingItem)
        {
            HiddenField hdf = (HiddenField)e.Item.FindControl("hdfPersonID");
            LinkButton lnk = (LinkButton)e.Item.FindControl("lnkComment");
            //check no. of comments
            try
            {
                string strcmd = "select count(CommentID) as Cmn from Comments where PersonID=" + hdf.Value;
                DataTable dt = new DataTable();
                dt = SQLHelper.FillData(strcmd);
                lnk.Text = "Comment (" + dt.Rows[0]["Cmn"].ToString() + ")";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //binding gridview
            GridView gv = (GridView)e.Item.FindControl("GridView1");
            try
            {
                string strcmd = "select Comment,Dated,Timed from Comments where PersonID=" + hdf.Value +
                    " order by Dated desc,Timed desc";
                DataTable dt = new DataTable();
                dt = SQLHelper.FillData(strcmd);
                gv.DataSource = dt;
                gv.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}