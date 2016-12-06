using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RecipesRepository
/// </summary>
public class RecipesRepository
{
    public RecipesRepository()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<Recipess> SelectRecipes()
    {
        HttpApplication webapp = HttpContext.Current.ApplicationInstance;
        return ((List<Recipess>)webapp.Application["recipes"]);
    }
}