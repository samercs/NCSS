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

            txtTitle.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {__doPostBack('" + btnSearch.UniqueID + "','');}} ");
            txtFrom.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {__doPostBack('" + btnSearch.UniqueID + "','');}} ");
            txtTo.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {__doPostBack('" + btnSearch.UniqueID + "','');}} ");



            int id =0;
            if (Request.QueryString["id"] != null )
            {
                int.TryParse(Request.QueryString["id"], out id);
            }

            Database db=new Database();
            Lang lang=new Lang();

            string catNameSql = "select title,titleAr from ResearchType where id=@id";
            

            db.AddParameter("@id", id);

            DataSet ds = db.ExecuteDataSet(catNameSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (Page.Culture.Contains("Arabic"))
                {
                    lblcatname.Text = ds.Tables[0].Rows[0]["TitleAr"].ToString();
                }
                else
                {
                    lblcatname.Text = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                
            }

            

            ddlLang.Items.Add(new ListItem(lang.getByKey("All"),"-1"));
            ddlLang.Items.Add(new ListItem(lang.getByKey("English"),"1"));
            ddlLang.Items.Add(new ListItem(lang.getByKey("Arabic2"), "2"));

            

            SearchLibrary("",null,null,"");
        }
    }

    protected void Repeater1_OnPagePropertiesChanged(object sender, EventArgs e)
    {
        SearchLibrary("",null,null,"");
    }

    private void SearchLibrary(string title, DateTime? from, DateTime? to, string lang)
    {
        Database db=new Database();
        string searchSql = "select * from Library where (type=@id) ";
        db.AddParameter("@id", Request.QueryString["id"]);
        if (!string.IsNullOrEmpty(title) || from.HasValue || to.HasValue || !string.IsNullOrEmpty(lang))
        {
            
            if (!string.IsNullOrEmpty(title))
            {
                searchSql += " and (title like  '%' + @title + '%') ";
                db.AddParameter("@title", title);
            }
            if (from.HasValue)
            {
                searchSql += " and adddate >= @from ";
                db.AddParameter("@from", from);
            }
            if (to.HasValue)
            {
                searchSql += " and adddate <= @to ";
                db.AddParameter("@to", to);
            }
            if (!string.IsNullOrEmpty(lang))
            {
                searchSql += " and lang = @lang ";
                db.AddParameter("@lang", lang);
            }

            
        }

        DataTable dt = db.ExecuteDataTable(searchSql);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();

        
    }

    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
        DateTime? fromTmp=null, toTmp=null;
        DateTime tmp;
        CultureInfo arSA=CultureInfo.CreateSpecificCulture("ar-SA");
        if (DateTime.TryParseExact(txtFrom.Text,"d/M/yyyy",arSA,DateTimeStyles.None, out tmp))
        {
            fromTmp = tmp;
        }
        if (DateTime.TryParseExact(txtTo.Text, "d/M/yyyy", arSA, DateTimeStyles.None, out tmp))
        {
            toTmp = tmp;
        }
        string lang = ddlLang.SelectedValue.Equals("-1") ? "" : ddlLang.SelectedValue;
        SearchLibrary(txtTitle.Text,fromTmp,toTmp,lang);
    }

    
}