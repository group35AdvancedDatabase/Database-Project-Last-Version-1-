using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

public partial class Search : System.Web.UI.Page
{
     OracleConnection conn;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCategories();
            LoadIngridients();
            categoryTxt.Items.Insert(0, new ListItem("Select All Categories", "%"));
            ingridientTxt.Items.Insert(0, new ListItem("Select All Ingridients", "%"));
        }
    }

    protected void searchFunction(object sender, EventArgs e) {
        OracleCommand comm;
        OracleDataReader reader;
        string connStr;

        connStr = ConfigurationManager.ConnectionStrings["Recipes"].ConnectionString;
        conn = new OracleConnection();
        conn.ConnectionString = connStr;

        comm = new OracleCommand(
            "SELECT b.RECIPE_NAME, b.IS_PRIVATE FROM AOD_RECIPE b " + 
            "LEFT JOIN AOD_INGREDIENT a ON b.RECIPE_ID = a.RECIPE_ID " +
            "LEFT JOIN AOD_CATEGORY c ON b.CATEGORY_ID = c.CATEGORY_ID " + 
            "WHERE c.CATEGORY_NAME LIKE :catRec AND a.INGREDIENTNAME LIKE :ingName", conn
            );
        
        comm.Parameters.Add(":catRec", OracleDbType.Varchar2, 30);
        comm.Parameters[":catRec"].Value = categoryTxt.SelectedValue;

        comm.Parameters.Add(":ingName", OracleDbType.Varchar2, 30);
        comm.Parameters[":ingName"].Value = ingridientTxt.SelectedValue;

        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            resultView.DataSource = reader;
            resultView.DataBind();
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
    
    protected void LoadCategories()
    {
        OracleCommand comm;
        OracleDataReader reader;
        string connStr;

        connStr = ConfigurationManager.ConnectionStrings["Recipes"].ConnectionString;
        conn = new OracleConnection();
        conn.ConnectionString = connStr;

        comm = new OracleCommand(
            "SELECT DISTINCT CATEGORY_NAME FROM AOD_CATEGORY", conn
            );

        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            categoryTxt.DataSource = reader;
            categoryTxt.DataTextField = "CATEGORY_NAME";
            categoryTxt.DataValueField = "CATEGORY_NAME";
            categoryTxt.DataBind();

            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }
    protected void LoadIngridients() {
        OracleCommand comm;
        OracleDataReader reader;
        string connStr;

        connStr = ConfigurationManager.ConnectionStrings["Recipes"].ConnectionString;
        conn = new OracleConnection();
        conn.ConnectionString = connStr;

        comm = new OracleCommand(
            "SELECT DISTINCT INGREDIENTNAME FROM AOD_INGREDIENT", conn
            );

        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            ingridientTxt.DataSource = reader;
            ingridientTxt.DataTextField = "INGREDIENTNAME";
            ingridientTxt.DataValueField = "INGREDIENTNAME";
            ingridientTxt.DataBind();

            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }
}