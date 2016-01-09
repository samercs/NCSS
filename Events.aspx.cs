using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Events : UICaltureBase
{
    private Dates _dates=new Dates();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetData("",null);
            

            txtname.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {__doPostBack('" + btnSearch.UniqueID + "','');}} ");
            txtDate.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {__doPostBack('" + btnSearch.UniqueID + "','');}} ");
        }
    }

    private void GetData(string name,DateTime? date)
    {
        Database db = new Database();
        Lang lang = new Lang();
        string sqlSearch = "select * from Event where lang=@lang";
        db.AddParameter("@lang", lang.getCurrentLang());

        if (!string.IsNullOrWhiteSpace(name))
        {
            sqlSearch += " and title like '%' + @name + '%'";
            db.AddParameter("@name", name);
        }
        if (date.HasValue)
        {
            sqlSearch += " and (year(EventDate)=@year and  month(EventDate)=@month and day(EventDate)=@day  )";
            
            
            db.AddParameter("@year",date.Value.Year);
            db.AddParameter("@month", date.Value.Month);
            db.AddParameter("@day", date.Value.Day);
        }


        


        DataTable dt = db.ExecuteDataTable(sqlSearch);
        ListView1.DataSource = dt;
        ListView1.DataBind();
    }

    protected void ListView1_OnPagePropertiesChanged(object sender, EventArgs e)
    {
        btnSearch_OnClick(this, null);
    }

    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
        DateTime? tmpDate=null;
        DateTime tmp;
        if (DateTime.TryParseExact(_dates.HijriToGreg(txtDate.Text,"dd/MM/yyyy"), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tmp))
        {
            tmpDate = tmp;
        }


        GetData(txtname.Text, tmpDate);
    }

    protected void ListView1_OnItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Repeater r =e.Item.FindControl("Repeater1") as Repeater;
            HiddenField id = e.Item.FindControl("id") as HiddenField;
            Database db = new Database();
            db.AddParameter("@id", id.Value);
            DataTable dt = db.ExecuteDataTable("select * from EventDoc where EventId=@id");
            r.DataSource = dt;
            r.DataBind();

        }
    }
}