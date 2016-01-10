using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Relogout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ret;
        if (Session["ReInfo"] != null)
        {
            Researchers re = Session["ReInfo"] as Researchers;
             ret = re.ID;
            Session.Remove("ReInfo");
            if (Request.Cookies["ReKeepOnline"] != null)
            {
                Response.Cookies["ReKeepOnline"].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Redirect("Researcher.aspx?id=" + ret);
        }
        else Response.Redirect("Experts.aspx");
    }
}