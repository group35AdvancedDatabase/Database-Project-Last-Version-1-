using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ContactUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Page_PreInit(object s, EventArgs e)
    {
        if (Session["Theme"] as string != null)
        {
            Page.Theme = Session["Theme"] as string;
        }
    }
}