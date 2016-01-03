using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Careers : UICaltureBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Database db = new Database();
            Lang lang = new Lang();
            db.AddParameter("@lang", lang.getCurrentLang());
            db.AddParameter("@key", "ContactInformation");
            DataTable dt = db.ExecuteDataTable("select * from pages where pagekey=@key and lang=@lang");
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            db.AddParameter("@lang", lang.getCurrentLang());
            db.AddParameter("@key", "Careers");
            dt = db.ExecuteDataTable("select * from pages where pagekey=@key and lang=@lang");
            Repeater2.DataSource = dt;
            Repeater2.DataBind();
        }
    }
}