using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Poll : UICaltureBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadPools("",null,null);
        }
    }

    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
        DateTime? d1=null, d2=null;
        DateTime tmp;
        if (DateTime.TryParse(txtFrom.Text, out tmp))
        {
            d1 = tmp;
        }
        if (DateTime.TryParse(txtTo.Text, out tmp))
        {
            d2 = tmp;
        }
        LoadPools(txtTitle.Text,d1,d2);


    }

    private void LoadPools(string title,DateTime? dateFrom, DateTime? dateTo)
    {
        Database db=new Database();
        Lang lang=new Lang();
        string sqlSerach = "select id,Title,AddDate from poll where (1=1) ";
        if(Page.Culture.Contains("Arabic"))
        {
            sqlSerach = "select id,TitleAr As title,AddDate from poll where (1=1) ";
        }
        string sqlOrderBy = " order by adddate desc,id desc";

        if (!string.IsNullOrWhiteSpace(title))
        {
            if (Page.Culture.Contains("Arabic"))
            {
                sqlSerach += " and TitleAr like '%' + @name + '%'";
                db.AddParameter("@name", title);
            }
            else
            {
                sqlSerach += " and Title like '%' + @name + '%'";
                db.AddParameter("@name", title);
            }
        }
        if (dateFrom.HasValue)
        {
            sqlSerach += " and AddDate>=@dateFrom";
            db.AddParameter("@dateFrom", dateFrom.Value);
        }
        if (dateTo.HasValue)
        {
            sqlSerach += " and AddDate<=@dateTo";
            db.AddParameter("@dateTo", dateTo.Value);
        }
        sqlSerach += sqlOrderBy;
        
        DataTable dt = db.ExecuteDataTable(sqlSerach);

        ListView1.DataSource = dt;
        ListView1.DataBind();
    }

    protected void ListView1_OnPagePropertiesChanged(object sender, EventArgs e)
    {
        btnSearch_OnClick(this, null);
    }

    protected void ListView1_OnItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Repeater rep = e.Item.FindControl("Repeater1") as Repeater;
            HiddenField id = e.Item.FindControl("id") as HiddenField;
            Database db = new Database();
            db.AddParameter("@PollId", id.Value);
            DataTable dt = db.ExecuteDataTable("PollResult", CommandType.StoredProcedure);
            rep.DataSource = dt;
            rep.DataBind();
        }
    }

    protected void Repeater1_OnItemCommand(object source, RepeaterCommandEventArgs e)
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
            btnSearch_OnClick(this, null);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("SiteTitle") + "','" + lang.getByKey("PollSubmitOk") + "');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this,this.GetType(), "Alert2", "alertify.alert('" + lang.getByKey("SiteTitle") + "','" + lang.getByKey("PollSubmitError") + "');", true);
        }
    }
}