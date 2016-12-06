using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.Collections;
using System.Web.UI.HtmlControls;
using HtmlAgilityPack;
using System.IO;

public partial class AddRecipe : System.Web.UI.Page
{
    private string check;
    OracleConnection conn;


    protected void Page_Load(object sender, EventArgs e)
    {

        checkValidPage.Text = check;
        categoryList.Items.Clear();
        cuisineList.Items.Clear();
        BindCategoryList();
        BindCuisineList();
        if (!IsPostBack)
        {
            ccategory.Attributes.CssStyle.Add("display", "none");
            removeCategory.Attributes.CssStyle.Add("display", "none");
            ccuisine.Attributes.CssStyle.Add("display", "none");
            removeCuisine.Attributes.CssStyle.Add("display", "none");
        }
        
    }
    protected void Page_PreInit(object s, EventArgs e)
    {
        if (Session["Theme"] as string != null)
        {
            Page.Theme = Session["Theme"] as string;
        }
    }


    protected void addNewCategory(object sender, EventArgs e)
    {
        categoryList.Attributes.CssStyle.Add("display", "none");
        ccategory.Attributes.CssStyle.Add("display", "inline-block");
        removeCategory.Attributes.CssStyle.Add("display", "inline-block");
        addCategory.Attributes.CssStyle.Add("display", "none");
        categoryList.SelectedValue = "%";
        categoryList.Attributes.Add("data-check", "hidden");
    }
    protected void removeNewCategory(object sender, EventArgs e)
    {
        categoryList.Attributes.CssStyle.Add("display", "inline-block");
        ccategory.Attributes.CssStyle.Add("display", "none");
        addCategory.Attributes.CssStyle.Add("display", "inline-block");
        removeCategory.Attributes.CssStyle.Add("display", "none");
        categoryList.Attributes.Add("data-check", "unhidden");
    }


    protected void addNewCuisine(object sender, EventArgs e)
    {
        cuisineList.Attributes.CssStyle.Add("display", "none");
        ccuisine.Attributes.CssStyle.Add("display", "inline-block");
        removeCuisine.Attributes.CssStyle.Add("display", "inline-block");
        addCuisine.Attributes.CssStyle.Add("display", "none");
        cuisineList.SelectedValue = "%";
        cuisineList.Attributes.Add("data-check", "hidden");
    }
    protected void removeNewCuisine(object sender, EventArgs e)
    {
        cuisineList.Attributes.CssStyle.Add("display", "inline-block");
        ccuisine.Attributes.CssStyle.Add("display", "none");
        addCuisine.Attributes.CssStyle.Add("display", "inline-block");
        removeCuisine.Attributes.CssStyle.Add("display", "none");
        cuisineList.Attributes.Add("data-check", "unhidden");
    }


    protected void Save_Recipe(object sender, EventArgs e)
    {
        

        Page.Validate();
        HttpApplication webApp = HttpContext.Current.ApplicationInstance;
        if (Page.IsValid)
        {
            check = "";
            Recipess recipe = new Recipess();
            recipe.NameOfRecipe = nnameOfRecipe.Text;
            
            /*Cuisine Choice*/
            if (cuisineList.SelectedValue == "%")
            {
                if (cuisineList.Attributes["data-check"].Contains("hidden"))
                {
                    if (ccuisine.Text != "")
                    {
                        Session["cuisine"] = ccuisine.Text;
                    }
                    else
                    {
                        Session["cuisine"] = "No Cusisine";
                    }
                }
                else
                {
                    Session["cuisine"] = "No Cuisine";
                }
            }
            else
            {
                Session["cuisine"] = cuisineList.SelectedItem;
            }
            /*End of Cuisine Choice*/

            /*********Category choice***********************/
            if (categoryList.SelectedValue == "%")
            {
                if (categoryList.Attributes["data-check"].Contains("hidden"))
                {
                    if (ccategory.Text != "")
                    {
                        Session["category"] = ccategory.Text;
                    }
                    else
                    {
                        Session["category"] = "No Category";
                    }
                }
                else
                {
                    Session["category"] = "No Category";
                }
            }
            else
            {
                Session["category"] = categoryList.SelectedItem;
            }
            /*********End of category choice*******************/

            if (isPrivate.Checked)
            {
                recipe.IsPriv = 1;
            }
            else {
                recipe.IsPriv = 0;
            }

            recipe.CookingTime = ccookingTime.Text;
            recipe.Portion = Convert.ToInt32(nnumberOfServings.Text);
            recipe.RecipeDesc = description.Text;

            foreach (Control c in Page.Controls)
            { 
                foreach ( Control control in c.Controls) {

                    if (control is ListOfIngredients)
                    {
                        ListOfIngredients list = (ListOfIngredients)control;
                        IngridientComponents ingridient = new IngridientComponents();
                        ingridient.NameOfIngridient = list.Ingridient;
                        ingridient.QuantityOfIngridient = Convert.ToInt32(list.Quantity);
                        ingridient.UnitOfMeasure = list.Unit;
                        recipe.InsertIngridients(ingridient);
                      }
                  }
             }

            ((List<Recipess>)webApp.Application["recipes"]).Add(recipe);
            insertNewRecipe(recipe);
            insertIngridientInRecipe(ingr_1);
            insertIngridientInRecipe(ingr_2);
            insertIngridientInRecipe(ingr_3);
            insertIngridientInRecipe(ingr_4);
            insertIngridientInRecipe(ingr_5);
            insertIngridientInRecipe(ingr_6);
            insertIngridientInRecipe(ingr_7);
            insertIngridientInRecipe(ingr_8);
            insertIngridientInRecipe(ingr_9);
            insertIngridientInRecipe(ingr_10);
            insertIngridientInRecipe(ingr_11);
            insertIngridientInRecipe(ingr_12);
            insertIngridientInRecipe(ingr_13);
            insertIngridientInRecipe(ingr_14);
            insertIngridientInRecipe(ingr_15);
            Response.Redirect("Recipes.aspx");

        } else
        {
            check = "Please, fix all errors";
        }
    }

    protected void BindCategoryList()
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
            categoryList.DataSource = reader;
            categoryList.DataTextField = "CATEGORY_NAME";
            categoryList.DataValueField = "CATEGORY_NAME";
            categoryList.DataBind();
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
        categoryList.Items.Insert(0, new ListItem("Please, select the category", "%"));
    }

    protected void BindCuisineList()
    {
        OracleCommand comm;
        OracleDataReader reader;
        string connStr;

        connStr = ConfigurationManager.ConnectionStrings["Recipes"].ConnectionString;
        conn = new OracleConnection();
        conn.ConnectionString = connStr;

        comm = new OracleCommand(
            "SELECT DISTINCT CUISINE_NAME FROM AOD_CUISINE", conn
            );

        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            cuisineList.DataSource = reader;
            cuisineList.DataTextField = "CUISINE_NAME";
            cuisineList.DataValueField = "CUISINE_NAME";
            cuisineList.DataBind();
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
        cuisineList.Items.Insert(0, new ListItem("Please, select the cuisine", "%"));
    }

    protected void checkTypeOfInput(Object s, ServerValidateEventArgs e)
    {
        int parsed;
        if (!int.TryParse(e.Value, out parsed)){
                e.IsValid = false;
        }
    }
    protected void Reset_Form(Object s, EventArgs e)
    {
        Response.Redirect(Request.Url.PathAndQuery, true);
    }

    protected void insertIngridientInRecipe(ListOfIngredients controlInbox) {
        OracleCommand insertIngridients;
        string connStr;
        connStr = ConfigurationManager.ConnectionStrings["Recipes"].ConnectionString;
        conn = new OracleConnection();
        conn.ConnectionString = connStr;

        insertIngridients = new OracleCommand("Sp_InsertIngredient", conn);
        insertIngridients.CommandType = System.Data.CommandType.StoredProcedure;

         

            insertIngridients.Parameters.Add("i_name", OracleDbType.Varchar2, 30);
            insertIngridients.Parameters["i_name"].Value = controlInbox.Ingridient;

            insertIngridients.Parameters.Add("i_qnt", OracleDbType.Int32);
            insertIngridients.Parameters["i_qnt"].Value = controlInbox.Quantity;

            insertIngridients.Parameters.Add("i_cmnt", OracleDbType.Varchar2, 10);
            insertIngridients.Parameters["i_cmnt"].Value = controlInbox.Unit;

            try
            {
                conn.Open();
                if (controlInbox.Ingridient != "")
                {
                    insertIngridients.ExecuteNonQuery();
                }
            }
            finally
            {
                conn.Close();
            }
    }



    protected void insertNewRecipe(Recipess rec)
    {
       
        OracleCommand insertRecipeInfo;
        string connStr;

        connStr = ConfigurationManager.ConnectionStrings["Recipes"].ConnectionString;
        conn = new OracleConnection();
        conn.ConnectionString = connStr;

        insertRecipeInfo = new OracleCommand("Sp_CreateRecipe", conn);
        insertRecipeInfo.CommandType = System.Data.CommandType.StoredProcedure;

        insertRecipeInfo.Parameters.Add("N_RECIPE_NAME", OracleDbType.Varchar2);
        insertRecipeInfo.Parameters["N_RECIPE_NAME"].Value = rec.NameOfRecipe;

        insertRecipeInfo.Parameters.Add("N_CATEGORY_NAME", OracleDbType.Varchar2);
        insertRecipeInfo.Parameters["N_CATEGORY_NAME"].Value = Session["category"].ToString();

        insertRecipeInfo.Parameters.Add("N_COOKING_TIME", OracleDbType.Varchar2);
        insertRecipeInfo.Parameters["N_COOKING_TIME"].Value = rec.CookingTime;

        insertRecipeInfo.Parameters.Add("N_PORTION", OracleDbType.Int32);
        insertRecipeInfo.Parameters["N_PORTION"].Value = rec.Portion;

        insertRecipeInfo.Parameters.Add("N_CUISINE_NAME", OracleDbType.Varchar2);
        insertRecipeInfo.Parameters["N_CUISINE_NAME"].Value = Session["cuisine"].ToString();

        insertRecipeInfo.Parameters.Add("N_DESCRIPTION", OracleDbType.Varchar2);
        insertRecipeInfo.Parameters["N_DESCRIPTION"].Value = rec.RecipeDesc;

        insertRecipeInfo.Parameters.Add("N_IS_PRIVATE", OracleDbType.Varchar2);
        insertRecipeInfo.Parameters["N_IS_PRIVATE"].Value = rec.IsPriv;

        insertRecipeInfo.Parameters.Add("N_IMAGE_PATH", OracleDbType.Varchar2);
        if (imagePath.Text != "")
        {
            insertRecipeInfo.Parameters["N_IMAGE_PATH"].Value = imagePath.Text;
        }
        else {
            insertRecipeInfo.Parameters["N_IMAGE_PATH"].Value = "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg";
        }

        try
        {
            conn.Open();
            insertRecipeInfo.ExecuteNonQuery();
        }
        finally
        {
            int counter = 0;
            foreach (Control c in Page.Controls)
            {
                foreach (Control control in c.Controls)
                {

                    if (control is ListOfIngredients)
                    {
                        ListOfIngredients list = (ListOfIngredients)control;
                        if (list.Ingridient != "")
                        {
                            counter++;
                        }
                    }
                }
            }
            if (counter == 0)
            {
                conn.Close();
            }
        }

    }

}

