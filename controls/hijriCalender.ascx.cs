using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_hijriCalender : System.Web.UI.UserControl
{
    public string Class { get; set; }
    public string Text
    {
        get
        {
            return TextBox1.Text;
        }
        set
        {
            TextBox1.Text = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!string.IsNullOrWhiteSpace(Class))
        {
            TextBox1.CssClass = Class;
        }
    }
}