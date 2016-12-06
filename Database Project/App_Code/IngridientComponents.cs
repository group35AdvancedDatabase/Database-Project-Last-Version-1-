using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IngridientComponents
/// </summary>
public class IngridientComponents
{
    public IngridientComponents()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private string nameOfIngridient;
    public string NameOfIngridient { get; set; }

    private int quantityOfIngridient;
    public int QuantityOfIngridient { get; set; }

    private string unitOfMeasure;
    public string UnitOfMeasure { get; set; } 
}