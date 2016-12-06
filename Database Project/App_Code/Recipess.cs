using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Recipes
/// </summary>
/// beginning of the class
public class Recipess
{
    public Recipess()
    {

    }

    //instance variables
    private IngridientComponents[] ingrs = new IngridientComponents[15];

    private string nameOfRecipe;
    public string NameOfRecipe { get; set; }

    private string cuisineID;
    public string CuisineID { get; set; }

    private string categoryID;
    public string CategoryID { get; set; }

    private string cookingTime;
    public string CookingTime { get; set; }

    private int portion;
    public int Portion { get; set; }

    private int isPriv;
    public int IsPriv { get; set; }

    private string recipeDesc;
    public string RecipeDesc { get; set; }

    private int imageID;
    public int ImageID { get; set; }
    //end of instance variables

    //Method to fill ingrs
    public void InsertIngridients(IngridientComponents ingridient)
    {
        for (int i = 0; i < ingrs.Length; i++)
        {
            if (ingrs[i] == null)
            {
                ingrs[i] = ingridient;
                break;
            }
        }
    }//end of method

    public IngridientComponents[] SelectIngridients()
    {
        return ingrs;
    }

}//end of the class