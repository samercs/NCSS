using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MediaCenter : UICaltureBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetData();
            GetVedioData();
            GetImagesData();
            GetReportData();
        }
    }

    private void GetData()
    {
        Database db = new Database();
        Lang lang = new Lang();
        string sqlSearch = "select * from News where lang=@lang Order by id desc";
        db.AddParameter("@lang", lang.getCurrentLang());
        DataTable dt = db.ExecuteDataTable(sqlSearch);
        ListView1.DataSource = dt;
        ListView1.DataBind();
    }

    private void GetVedioData()
    {
        Database db = new Database();
        Lang lang = new Lang();
        string sqlSearch = "select * from Vedio where lang=@lang Order by id desc";
        db.AddParameter("@lang", lang.getCurrentLang());
        DataTable dt = db.ExecuteDataTable(sqlSearch);
        ListView2.DataSource = dt;
        ListView2.DataBind();
    }
    private void GetImagesData()
    {
        Database db = new Database();
        Lang lang = new Lang();
        string sqlSearch = "select * from albums where lang=@lang Order by id desc";
        db.AddParameter("@lang", lang.getCurrentLang());
        DataTable dt = db.ExecuteDataTable(sqlSearch);
        ListView3.DataSource = dt;
        ListView3.DataBind();
    }
    private void GetReportData()
    {
        Database db = new Database();
        Lang lang = new Lang();
        string sqlSearch = "select * from Report where lang=@lang Order by id desc";
        db.AddParameter("@lang", lang.getCurrentLang());
        DataTable dt = db.ExecuteDataTable(sqlSearch);
        ListView4.DataSource = dt;
        ListView4.DataBind();
    }

    protected void ListView1_OnPagePropertiesChanged(object sender, EventArgs e)
    {
        GetData();
    }

    protected void ListView2_OnPagePropertiesChanged(object sender, EventArgs e)
    {
        GetVedioData();
    }

    protected void ListView3_OnPagePropertiesChanged(object sender, EventArgs e)
    {
        GetImagesData();
    }

    protected void ListView4_OnPagePropertiesChanged(object sender, EventArgs e)
    {
        GetReportData();
    }
}