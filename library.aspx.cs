using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class library : UICaltureBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Lang lang = new Lang();
            txtTitle.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {__doPostBack('" + btnSearch.UniqueID + "','');}} ");
            txtFrom.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {__doPostBack('" + btnSearch.UniqueID + "','');}} ");
            txtTo.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {__doPostBack('" + btnSearch.UniqueID + "','');}} ");


            ddlLang.Items.Add(new ListItem(lang.getByKey("All"), "-1"));
            ddlLang.Items.Add(new ListItem(lang.getByKey("English"), "1"));
            ddlLang.Items.Add(new ListItem(lang.getByKey("Arabic2"), "2"));
            
            txtTitle.Attributes.Add("placeholder", lang.getByKey("EnterResearchTitle"));

            Database db = new Database();
            if (Page.Culture.Contains("Ar"))
            {
                db.LoadDDL("ResearchType", "TitleAr", ref ddlType, lang.getByKey("Type"));
            }
            else
            {
                db.LoadDDL("ResearchType", "Title", ref ddlType, lang.getByKey("Type"));
            }

            SearchLibrary("", 0, 0, "","-1");

            db.AddParameter("@key", "LibraryBox");
            db.AddParameter("@lang", lang.getCurrentLang());
            DataTable dt = db.ExecuteDataTable("select * from pages where pageKey=@key and lang=@lang");
            Repeater2.DataSource = dt;
            Repeater2.DataBind();

        }
    }

    protected void Repeater1_OnPagePropertiesChanged(object sender, EventArgs e)
    {
        btnSearch_OnClick(null, null);
    }

    private void SearchLibrary(string title, int from, int to, string lang,string type)
    {
        string searchSql = "";
        
        Database db = new Database();
        if (Request.QueryString["id"] != null)
        {
            searchSql = "select * from Library where (type=@id) ";
            
            string canName = "";
            if (Page.Culture.Contains("Ar"))
            {
                canName = db.GetProName("ResearchType", "TitleAr", "id", Request.QueryString["id"]);
            }
            else
            {
                canName = db.GetProName("ResearchType", "Title", "id", Request.QueryString["id"]);
            }
            lblcatname.Text = canName;
            db.AddParameter("@id", Request.QueryString["id"]);
        }
        else
        {
            searchSql = "select * from Library where (1=1) ";
        }

        if (!string.IsNullOrEmpty(title) || from!=0 || to!=0 || !string.IsNullOrEmpty(lang) || !type.Equals("-1"))
        {

            if (!string.IsNullOrEmpty(title))
            {
                searchSql += " and (title like  '%' + @title + '%' or writer like  '%' + @title + '%') ";
                db.AddParameter("@title", title);
            }
            if (from!=0)
            {
                searchSql += " and PublishDate >= @from ";
                db.AddParameter("@from", from);
            }
            if (to!=0)
            {
                searchSql += " and PublishDate <= @to ";
                db.AddParameter("@to", to);
            }
            if (!string.IsNullOrEmpty(lang))
            {
                searchSql += " and lang = @lang ";
                db.AddParameter("@lang", lang);
            }
            if (!type.Equals("-1"))
            {
                searchSql += " and [type] = @type ";
                db.AddParameter("@type", type);
            }



        }
        searchSql += " order by PublishDate desc";
        DataTable dt = db.ExecuteDataTable(searchSql);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();


    }

    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
        int fromTmp = 0, toTmp = 0;
        int tmp;
        
        if (!string.IsNullOrEmpty(txtFrom.Text) && int.TryParse(txtFrom.Text,out tmp))
        {
            fromTmp = tmp;
        }
        if (!string.IsNullOrEmpty(txtTo.Text) && int.TryParse(txtTo.Text, out tmp))
        {
            toTmp = tmp;
        }
        string lang = ddlLang.SelectedValue.Equals("-1") ? "" : ddlLang.SelectedValue;
        SearchLibrary(txtTitle.Text, fromTmp, toTmp, lang,ddlType.SelectedValue);
    }



    protected void txtTitle_TextChanged(object sender, EventArgs e)
    {
        DoSearch();
        txtTitle.Focus();
    }

    protected void txtFrom_TextChanged(object sender, EventArgs e)
    {
        DoSearch();
        txtFrom.Focus();
    }

    protected void txtTo_TextChanged(object sender, EventArgs e)
    {
        DoSearch();
        txtTo.Focus();
    }

    private void DoSearch()
    {
        int fromTmp = 0, toTmp = 0;
        int tmp;

        if (!string.IsNullOrEmpty(txtFrom.Text) && int.TryParse(txtFrom.Text, out tmp))
        {
            fromTmp = tmp;
        }
        if (!string.IsNullOrEmpty(txtTo.Text) && int.TryParse(txtTo.Text, out tmp))
        {
            toTmp = tmp;
        }
        string lang = ddlLang.SelectedValue.Equals("-1") ? "" : ddlLang.SelectedValue;
        SearchLibrary(txtTitle.Text, fromTmp, toTmp, lang, ddlType.SelectedValue);
    }



    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int fromTmp = 0, toTmp = 0;
        int tmp;
        if (!string.IsNullOrEmpty(txtFrom.Text) && int.TryParse(txtFrom.Text, out tmp))
        {
            fromTmp = tmp;
        }
        if (!string.IsNullOrEmpty(txtTo.Text) && int.TryParse(txtTo.Text, out tmp))
        {
            toTmp = tmp;
        }
        string lang = ddlLang.SelectedValue.Equals("-1") ? "" : ddlLang.SelectedValue;
        SearchLibrary(txtTitle.Text, fromTmp, toTmp, lang, ddlType.SelectedValue);
    }

    protected void ddlLang_SelectedIndexChanged(object sender, EventArgs e)
    {
        int fromTmp = 0, toTmp = 0;
        int tmp;
        if (!string.IsNullOrEmpty(txtFrom.Text) && int.TryParse(txtFrom.Text, out tmp))
        {
            fromTmp = tmp;
        }
        if (!string.IsNullOrEmpty(txtTo.Text) && int.TryParse(txtTo.Text, out tmp))
        {
            toTmp = tmp;
        }
        string lang = ddlLang.SelectedValue.Equals("-1") ? "" : ddlLang.SelectedValue;
        SearchLibrary(txtTitle.Text, fromTmp, toTmp, lang, ddlType.SelectedValue);
    }
}