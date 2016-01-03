using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

   

    protected void Button1_OnClick(object sender, EventArgs e)
    {
        Dates dates=new Dates();
        
        Response.Write(dates.GregToHijri("14/9/2015","d/M/yyyy"));
    }
}