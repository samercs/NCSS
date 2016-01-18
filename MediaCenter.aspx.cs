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
            GetReportData(); GetPressKit(); LoadPoll();
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
    private void GetPressKit()
    {
        Database db = new Database();
        Lang lang = new Lang();
        string sqlSearch = "select * from PressKit where lang=@lang Order by id desc";
        db.AddParameter("@lang", lang.getCurrentLang());
        DataTable dt = db.ExecuteDataTable(sqlSearch);
        ListView5.DataSource = dt;
        ListView5.DataBind();
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

    protected void ListView5_PagePropertiesChanged(object sender, EventArgs e)
    {
        GetPressKit();
    }
    private void LoadPoll()
    {
        string pollSql = "select top(1) Id,AddDate,Title from Poll where ShowInHome=1  Order By AddDate Desc, Id Desc";
        if (Page.Culture.Contains("Arabic"))
        {
            pollSql = "select top(1) Id,AddDate,TitleAr as title from Poll where ShowInHome=1  Order By AddDate Desc, Id Desc";
        }
        Database db = new Database();
        Lang lan = new Lang();

        DataTable dt = db.ExecuteDataTable(pollSql);
        Repeater7.DataSource = dt;
        Repeater7.DataBind();
    }

    protected void Repeater8_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rep = e.Item.FindControl("Repeater8") as Repeater;
            HiddenField id = e.Item.FindControl("id") as HiddenField;
            Database db = new Database();
            db.AddParameter("@PollId", id.Value);
            DataTable dt = db.ExecuteDataTable("PollResult", CommandType.StoredProcedure);
            rep.DataSource = dt;
            rep.DataBind();
        }
    }
    protected void Repeater8_OnItemCommand(object source, RepeaterCommandEventArgs e)
    {

        Lang lang = new Lang();
        HiddenField pollId = e.Item.FindControl("pollid") as HiddenField;
        HiddenField optionId = e.Item.FindControl("optionid") as HiddenField;

        if (Request.Cookies["Poll" + pollId.Value] == null)
        {
            Database db = new Database();
            db.AddParameter("@id", optionId.Value);
            db.ExecuteNonQuery("update PollOption set count=count+1 where id=@id");
            HttpCookie c = new HttpCookie("Poll" + pollId.Value);
            c.Value = optionId.Value;
            c.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(c);
            LoadPoll();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("SiteTitle") + "','" + lang.getByKey("PollSubmitOk") + "');", true);
        }
        else
        {

            ClientScript.RegisterStartupScript(this.GetType(), "Alert2", "alertify.alert('" + lang.getByKey("SiteTitle") + "','" + lang.getByKey("PollSubmitError") + "');", true);
        }


    }
}