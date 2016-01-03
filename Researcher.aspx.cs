using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Researcher : UICaltureBase
{
    private Dates _dates=new Dates();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {


            int id = -1;
            if (int.TryParse(Request.QueryString["id"], out id))
            {
                Database db = new Database();
                Lang lang = new Lang();
                db.AddParameter("@id", id);
                db.AddParameter("@lang", lang.getCurrentLang());
                DataTable dt = db.ExecuteDataTable("select country.name as countryname,researcher.* from Researcher inner join Country on Researcher.Country=Country.id where researcher.lang=@lang and researcher.IsAproved=1 and researcher.id=@id");
                if(dt.Rows.Count==0)
                {
                    Response.Redirect("Experts.aspx");
                }
                Repeater1.DataSource = dt;
                Repeater1.DataBind();

                LoadResearch(id,"",null,null);

                txtTitle.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {__doPostBack('" + btnSearch.UniqueID + "','');}} ");
                txtFrom.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {__doPostBack('" + btnSearch.UniqueID + "','');}} ");
                txtTo.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {__doPostBack('" + btnSearch.UniqueID + "','');}} ");
            }
        }
    }

    private void LoadResearch(int id,string title,DateTime? from,DateTime? to)
    {
        Database db = new Database();
        Lang lang = new Lang();
        string sqlSearch = "select * from Research where ResearcherId=@id";
        db.AddParameter("@id", id);

        if (!string.IsNullOrWhiteSpace(title))
        {
            sqlSearch += " and Title like '%' + @title + '%'";
            db.AddParameter("@title", title);
        }
        if (from.HasValue)
        {
            sqlSearch += " and AddDate>=@fromDate";
            db.AddParameter("@fromDate", from);
        }
        if (to.HasValue)
        {
            sqlSearch += " and AddDate<=@toDate";
            db.AddParameter("@toDate", to);
        }

        DataTable dt = db.ExecuteDataTable(sqlSearch);
        ListView1.DataSource = dt;
        ListView1.DataBind();

        
    }

    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
        int id = -1;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            DateTime? tmp1=null, tmp2=null;
            DateTime tmp;
            if (DateTime.TryParseExact(_dates.HijriToGreg(txtFrom.Text,"dd/MM/yyyy"), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tmp))
            {
                tmp1 = tmp;
            }
            if (DateTime.TryParseExact(_dates.HijriToGreg(txtTo.Text, "dd/MM/yyyy"), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tmp))
            {
                tmp2 = tmp;
            }
            LoadResearch(id,txtTitle.Text,tmp1,tmp2);
        }

    }

    protected void ListView1_OnPagePropertiesChanged(object sender, EventArgs e)
    {
        int id = -1;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            btnSearch_OnClick(this, null);
        }
        
    }

    
}