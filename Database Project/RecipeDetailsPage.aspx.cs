using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class RecipeDetailsPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack)
        {
            Load_Details();
            BindIngredients();
        }
        cancelBtn.Attributes.CssStyle.Add("display", "none");
        updateBtn.Attributes.CssStyle.Add("display", "none");
        boxDesc.Attributes.CssStyle.Add("display", "none");
        boxImage.Attributes.CssStyle.Add("display", "none");
        labelImage.Attributes.CssStyle.Add("display", "none");
        yes.Attributes.CssStyle.Add("display", "none");
        no.Attributes.CssStyle.Add("display", "none");
    }

    protected void Load_Details() {
        string name = "";
        string time = "";
        string category = "";
        string portion = "";
        string cuisine = "";
        string priv = "";
        string image = "";
        string description = "";
        
        int rID = Convert.ToInt32(Application["detailsID"]);
        OracleConnection conn;
        OracleCommand comm;
        string connStr;

        connStr = ConfigurationManager.ConnectionStrings["Recipes"].ConnectionString;
        conn = new OracleConnection();
        conn.ConnectionString = connStr;

        comm = new OracleCommand("Sp_TakeRecipe", conn);
        comm.CommandType = System.Data.CommandType.StoredProcedure;

        comm.Parameters.Add("N_RECIPE_NAME", OracleDbType.Varchar2, 50);
        comm.Parameters["N_RECIPE_NAME"].Direction = ParameterDirection.Output;

        comm.Parameters.Add("N_COOKING_TIME", OracleDbType.Varchar2, 50);
        comm.Parameters["N_COOKING_TIME"].Direction = ParameterDirection.Output;

        comm.Parameters.Add("N_CATEGORY", OracleDbType.Varchar2, 50);
        comm.Parameters["N_CATEGORY"].Direction = ParameterDirection.Output;

        comm.Parameters.Add("N_PORTION", OracleDbType.Int32);
        comm.Parameters["N_PORTION"].Direction = ParameterDirection.Output;

        comm.Parameters.Add("N_DESC", OracleDbType.Varchar2, 255);
        comm.Parameters["N_DESC"].Direction = ParameterDirection.Output;

        comm.Parameters.Add("N_CUISINE", OracleDbType.Varchar2, 50);
        comm.Parameters["N_CUISINE"].Direction = ParameterDirection.Output;

        comm.Parameters.Add("N_PRIVATE", OracleDbType.Varchar2, 50);
        comm.Parameters["N_PRIVATE"].Direction = ParameterDirection.Output;

        comm.Parameters.Add("N_IMAGE", OracleDbType.Varchar2, 100);
        comm.Parameters["N_IMAGE"].Direction = ParameterDirection.Output;

        comm.Parameters.Add("N_ID", OracleDbType.Int32);
        comm.Parameters["N_ID"].Value = rID;

        try
        {
            conn.Open();
            comm.ExecuteNonQuery();
            name = comm.Parameters["N_RECIPE_NAME"].Value.ToString();
            time = comm.Parameters["N_COOKING_TIME"].Value.ToString();
            category = comm.Parameters["N_CATEGORY"].Value.ToString();
            portion = comm.Parameters["N_PORTION"].Value.ToString();
            cuisine = comm.Parameters["N_CUISINE"].Value.ToString();
            priv = comm.Parameters["N_PRIVATE"].Value.ToString();
            image = comm.Parameters["N_IMAGE"].Value.ToString();
            description = comm.Parameters["N_DESC"].Value.ToString();

        }
        finally {
            conn.Close();
        }

        lblName.Text = name;
        lblTime.Text = time;
        lblCategory.Text = category;
        lblPortion.Text = portion;
        lblCuisine.Text = cuisine;
        if (priv == "1"){
            lblPrivate.Text = "Yes";
        } else {
           lblPrivate.Text = "No";
        }
        imagePct.Attributes["src"] = image;
        lblDesc.Text = description;
}

    protected void BindIngredients()
    {
        int rID = Convert.ToInt32(Application["detailsID"]);
        OracleConnection conn;
        OracleCommand comm;
        OracleDataReader reader;
        string connStr;

        connStr = ConfigurationManager.ConnectionStrings["Recipes"].ConnectionString;
        conn = new OracleConnection();
        conn.ConnectionString = connStr;

        comm = new OracleCommand(
            "SELECT INGREDIENT_ID, INGREDIENTNAME, INGREDIENTQNT, INGREDIENTCMNT FROM AOD_INGREDIENT WHERE RECIPE_ID = :recID",conn
            );

        comm.Parameters.Add(":recID", OracleDbType.Int32);
        comm.Parameters[":recID"].Value = rID;

        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            ingridients.DataSource = reader;
            ingridients.DataBind();
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }

    protected void deleteBtn_Click(object sender, EventArgs e)
    {
        int rID = Convert.ToInt32(Application["detailsID"]);
        OracleConnection conn;
        OracleCommand comm;
        string connStr;

        connStr = ConfigurationManager.ConnectionStrings["Recipes"].ConnectionString;
        conn = new OracleConnection();
        conn.ConnectionString = connStr;

        comm = new OracleCommand(
            "DELETE FROM AOD_RECIPE WHERE RECIPE_ID = :recID", conn
        );

        comm.Parameters.Add(":recID", OracleDbType.Int32);
        comm.Parameters[":recID"].Value = rID;

        try
        {
            conn.Open();
            comm.ExecuteNonQuery();
            Response.Redirect("~/Recipes.aspx");
        }
        finally {
            conn.Close();
        }
    }
    protected void ingridients_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ingridients.EditIndex = e.NewEditIndex;
        BindIngredients();
    }

    protected void ingridients_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int rID = Convert.ToInt32(Application["detailsID"]);
        OracleConnection conn;
        OracleCommand comm;
        string connStr;

        connStr = ConfigurationManager.ConnectionStrings["Recipes"].ConnectionString;
        conn = new OracleConnection();
        conn.ConnectionString = connStr;

        Label ingID = ingridients.Rows[e.RowIndex].FindControl("labelID") as Label;
        TextBox ingName = ingridients.Rows[e.RowIndex].FindControl("editName") as TextBox;
        TextBox ingQnt = ingridients.Rows[e.RowIndex].FindControl("editQnt") as TextBox;
        TextBox ingMsr = ingridients.Rows[e.RowIndex].FindControl("editMeasure") as TextBox;

        comm = new OracleCommand(
            "UPDATE AOD_INGREDIENT SET INGREDIENTNAME = :ingName, INGREDIENTQNT = :ingQnt, INGREDIENTCMNT = :ingMsr WHERE INGREDIENT_ID = :ingID", conn
            );

        comm.Parameters.Add(":ingName", OracleDbType.Varchar2, 20);
        comm.Parameters[":ingName"].Value = ingName.Text;

        comm.Parameters.Add(":ingQnt", OracleDbType.Int32);
        comm.Parameters[":ingQnt"].Value = Int32.Parse(ingQnt.Text);

        comm.Parameters.Add(":ingMsr", OracleDbType.Varchar2, 10);
        comm.Parameters[":ingMsr"].Value = ingMsr.Text; 

        comm.Parameters.Add(":ingID", OracleDbType.Double);
        comm.Parameters[":ingID"].Value = Double.Parse(ingID.Text);

        try
        {
            conn.Open();
            comm.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();
        }
        ingridients.EditIndex = -1;
        BindIngredients();
        
    }

    protected void ingridients_RowCancelingEdit1(object sender, GridViewCancelEditEventArgs e)
    {
        ingridients.EditIndex = -1;
        BindIngredients();
    }
    protected void editBtn_Click(object sender, EventArgs e)
    {
        boxName.Attributes.CssStyle.Add("display", "block");
        boxName.Text = lblName.Text;
        lblName.Attributes.CssStyle.Add("display", "none");

        boxTime.Attributes.CssStyle.Add("display", "block");
        boxTime.Text = lblTime.Text;
        lblTime.Attributes.CssStyle.Add("display", "none");

        boxCategory.Attributes.CssStyle.Add("display", "block");
        boxCategory.Text = lblCategory.Text;
        lblCategory.Attributes.CssStyle.Add("display", "none");

        boxPortion.Attributes.CssStyle.Add("display", "block");
        boxPortion.Text = lblPortion.Text;
        lblPortion.Attributes.CssStyle.Add("display", "none");

        boxCuisine.Attributes.CssStyle.Add("display", "block");
        boxCuisine.Text = lblCuisine.Text;
        lblCuisine.Attributes.CssStyle.Add("display", "none");

        yes.Attributes.CssStyle.Add("display", "block");
        no.Attributes.CssStyle.Add("display", "block");
        if (lblPrivate.Text == "Yes")
        {
            yes.Checked = true;
        }
        else
        {
            no.Checked = true;
        }
        lblPrivate.Attributes.CssStyle.Add("display", "none");

        boxDesc.Attributes.CssStyle.Add("display", "block");
        boxDesc.Text = lblDesc.Text;
        lblDesc.Attributes.CssStyle.Add("display", "none");

        boxImage.Attributes.CssStyle.Add("display", "block");
        labelImage.Attributes.CssStyle.Add("display", "block");

        cancelBtn.Attributes.CssStyle.Add("display", "inline-block");
        updateBtn.Attributes.CssStyle.Add("display", "inline-block");
        editBtn.Attributes.CssStyle.Add("display", "none");

    }
    protected void cancelBtn_Click(object sender, EventArgs e)
    {
        boxName.Attributes.CssStyle.Add("display", "none");
        lblName.Attributes.CssStyle.Add("display", "block");

        boxTime.Attributes.CssStyle.Add("display", "none");
        lblTime.Attributes.CssStyle.Add("display", "block");

        boxCategory.Attributes.CssStyle.Add("display", "none");
        lblCategory.Attributes.CssStyle.Add("display", "block");

        boxPortion.Attributes.CssStyle.Add("display", "none");
        lblPortion.Attributes.CssStyle.Add("display", "block");

        boxCuisine.Attributes.CssStyle.Add("display", "none");
        lblCuisine.Attributes.CssStyle.Add("display", "block");

        no.Attributes.CssStyle.Add("display", "none");
        yes.Attributes.CssStyle.Add("display", "none");
        lblPrivate.Attributes.CssStyle.Add("display", "block");

        boxDesc.Attributes.CssStyle.Add("display", "none");
        boxDesc.Text = lblDesc.Text;
        lblDesc.Attributes.CssStyle.Add("display", "block");

        cancelBtn.Attributes.CssStyle.Add("display", "none");
        updateBtn.Attributes.CssStyle.Add("display", "none");
        editBtn.Attributes.CssStyle.Add("display", "inline-block");

    }
    protected void updateBtn_Click(object sender, EventArgs e)
    {
        int rID = Convert.ToInt32(Application["detailsID"]);
        OracleConnection conn;
        OracleCommand comm;
        string connStr;

        connStr = ConfigurationManager.ConnectionStrings["Recipes"].ConnectionString;
        conn = new OracleConnection();
        conn.ConnectionString = connStr;

        comm = new OracleCommand("Sp_EditRecipe", conn);
        comm.CommandType = CommandType.StoredProcedure;

        comm.Parameters.Add("N_RECIPE_ID", OracleDbType.Int32);
        comm.Parameters["N_RECIPE_ID"].Value = rID;

        comm.Parameters.Add("N_RECIPE_NAME", OracleDbType.Varchar2, 50);
        comm.Parameters["N_RECIPE_NAME"].Value = boxName.Text;

        comm.Parameters.Add("N_CATEGORY_NAME", OracleDbType.Varchar2, 50);
        comm.Parameters["N_CATEGORY_NAME"].Value = boxCategory.Text;

        comm.Parameters.Add("N_COOKING_TIME", OracleDbType.Varchar2, 50);
        comm.Parameters["N_COOKING_TIME"].Value = boxTime.Text;

        comm.Parameters.Add("N_PORTION", OracleDbType.Int32);
        comm.Parameters["N_PORTION"].Value = Int32.Parse(boxPortion.Text);

        comm.Parameters.Add("N_CUISINE_NAME", OracleDbType.Varchar2, 50);
        comm.Parameters["N_CUISINE_NAME"].Value = boxCuisine.Text;

        comm.Parameters.Add("N_DESCRIPTION", OracleDbType.Varchar2, 50);
        comm.Parameters["N_DESCRIPTION"].Value = boxDesc.Text;

        comm.Parameters.Add("N_IS_PRIVATE", OracleDbType.Int32);
        if (yes.Checked) {
            comm.Parameters["N_IS_PRIVATE"].Value = 1;
        }
        else
        {
            comm.Parameters["N_IS_PRIVATE"].Value = 0;
        }

        comm.Parameters.Add("N_IMAGE_PATH", OracleDbType.Varchar2, 100);
        if (boxImage.Text == "")
        {
            comm.Parameters["N_IMAGE_PATH"].Value = "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg";
        }
        else
        {
            comm.Parameters["N_IMAGE_PATH"].Value = boxImage.Text;
        }

        try
        {
            conn.Open();
            comm.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();
        }
        Response.Redirect("RecipeDetailsPage.aspx");
    }
}