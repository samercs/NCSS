using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Phenomenon : UICaltureBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetData();
        }
    }

    private void GetData()
    {
        Database db = new Database();
        Lang lang = new Lang();
        db.AddParameter("@lang", lang.getCurrentLang());
        DataTable dt = db.ExecuteDataTable("select * from Socialevent where lang=@lang");
        ListView1.DataSource = dt;
        ListView1.DataBind();
    }

    protected void ListView1_OnPagePropertiesChanged(object sender, EventArgs e)
    {
        GetData();
    }
}