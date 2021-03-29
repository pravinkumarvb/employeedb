using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
/// Summary description for Commons
/// </summary>
public class Commons
{
    public static void MsgBox(string strMsg)
    {
        HttpContext.Current.Response.Write("<script>alert('" + strMsg + "');</script>");
    }
    public static string chng(string str)
    {
        return str.Replace("'", "''");
    }
    public static string GetConnectionString
    {
        //using System.Configuration;
        get
        {
            string strCon = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
            return strCon;
        }
    }
}