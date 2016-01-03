using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Privacy : UICaltureBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Database db = new Database();
            Lang lang = new Lang();
            db.AddParameter("@lang", lang.getCurrentLang());
            db.AddParameter("@key", "PrivacyPolicy");
            DataTable dt = db.ExecuteDataTable("select * from pages where pagekey=@key and lang=@lang");
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            
        }
    }
}