using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SpecializedDatabases : UICaltureBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Lang lang = new Lang();
            txtTitle.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {__doPostBack('" + btnSearch.UniqueID + "','');}} ");
            SearchLibrary("","");

            if (!Page.IsPostBack)
            {
                Database db = new Database();
                string sql = "select id,title,img from DBCat Order By Id";
                if (Page.Culture.Contains("Arabic"))
                {
                    sql = "select id,titleAr as title,img from DBCat Order By Id";
                }

                DataTable dt = db.ExecuteDataTable(sql);
                Repeater2.DataSource = dt;
                Repeater2.DataBind();
            }
        }
    }

    protected void Repeater1_OnPagePropertiesChanged(object sender, EventArgs e)
    {
        btnSearch_OnClick(null, null);
    }

    private void SearchLibrary(string title,string type)
    {
        string searchSql = "select * from SpecializedDB where lang=@lang";

        Database db = new Database();
        Lang lang = new Lang();
        db.AddParameter("@lang", lang.getCurrentLang());
        if (!string.IsNullOrEmpty(title))
        {
            searchSql += " and (title like  '%' + @title + '%' or txt like  '%' + @title + '%') ";
            db.AddParameter("@title", title);
        }
        if (!string.IsNullOrEmpty(type))
        {
            searchSql += " and (typeId=@typeId) ";
            db.AddParameter("@typeId", type);
        }


        searchSql += " order by title";
        DataTable dt = db.ExecuteDataTable(searchSql);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();


    }

    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
        
        SearchLibrary(txtTitle.Text,"");
    }


    protected void LinkButton1_OnCommand(object sender, CommandEventArgs e)
    {
        SearchLibrary(txtTitle.Text,e.CommandArgument.ToString());
    }
}