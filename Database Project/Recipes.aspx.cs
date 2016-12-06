using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

public partial class Recipes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }
    private void BindGrid()
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataReader reader;
        string connStr;

        connStr = ConfigurationManager.ConnectionStrings["Recipes"].ConnectionString;
        conn = new OracleConnection();
        conn.ConnectionString = connStr;

        comm = new OracleCommand(
           "SELECT a.RECIPE_ID, a.RECIPE_NAME, b.CUISINE_NAME, c.CATEGORY_NAME " +
           "FROM AOD_RECIPE a " + 
           "LEFT JOIN AOD_CUISINE b ON a.CUISINE_ID = b.CUISINE_ID " +
           "LEFT JOIN AOD_CATEGORY c ON a.CATEGORY_ID = c.CATEGORY_ID " + 
           "ORDER BY a.RECIPE_ID", conn
         );

        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            grid.DataSource = reader;
            grid.DataKeyNames = new string[] { "RECIPE_ID" };
            grid.DataBind();;
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }
      
    

    protected void Page_PreInit(object s, EventArgs e)
    {
        if (Session["Theme"] as string != null)
        {
            Page.Theme = Session["Theme"] as string;
        }
    }

    protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "takeAllDetails")
        {
            Application["detailsID"] = e.CommandArgument.ToString();
            Response.Redirect("RecipeDetailsPage.aspx");
        }
    }
}