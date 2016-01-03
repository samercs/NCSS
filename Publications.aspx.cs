using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Publications : UICaltureBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadData();
            Database db = new Database();
            Lang lang = new Lang();
            db.AddParameter("@lang", lang.getCurrentLang());
            DataTable dt = db.ExecuteDataTable("select top(3) * from SocialEvent where lang=@lang Order by id desc");
            Repeater2.DataSource = dt;
            Repeater2.DataBind();

            db.AddParameter("@lang", lang.getCurrentLang());
            dt = db.ExecuteDataTable("select top(3) * from news where lang=@lang Order by id desc");
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }

    private void LoadData()
    {
        Database db = new Database();
        Lang lang = new Lang();
        db.AddParameter("@lang", lang.getCurrentLang());
        DataTable dt = db.ExecuteDataTable("select  * from Publications where lang=@lang Order by id desc");
        ListView1.DataSource = dt;
        ListView1.DataBind();
    }

    protected void ListView1_OnPagePropertiesChanged(object sender, EventArgs e)
    {
        LoadData();
    }
}