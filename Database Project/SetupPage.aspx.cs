using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetupPage : System.Web.UI.Page

{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Theme"] == null)
        {
            chosenTheme.Text = "Theme 'Default' was selected";
        }
        else {
            chosenTheme.Text = "Theme '" + Session["Theme"] as string + "' was selected";
        }
    }
    protected void Choose_Theme(Object sender, EventArgs e)
    {
        Session["Theme"] = Theme.SelectedItem.Value;
        Response.Redirect("SetupPage.aspx");
    }
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        string theme = Session["Theme"] as string;
        if (theme != null)
        {
            Page.Theme = theme;
        }
    }
}