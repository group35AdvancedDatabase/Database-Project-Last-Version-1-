using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListOfIngredients : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    public string Ingridient
    {
        get { return ingridient.Text; }
        set { ingridient.Text = value; }
    }
    public string Quantity
    {
        set { quantity.Text = value.ToString(); }
        get { return quantity.Text; }
    }
    public string Unit
    {
        get { return unit.Text; }
        set { unit.Text = value; }
    }


    protected void nameValidate(object s, ServerValidateEventArgs e)
    {
        
        if (ingridient.Text == "")
        {
            if (unit.Text != "" || quantity.Text != "")
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }
    }
}