using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportDetails : UICaltureBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int id;
            if (!int.TryParse(Request.QueryString["id"], out id))
            {
                Response.Redirect("~/MediaCenter.aspx");
            }
            Database db = new Database();
            Lang lang = new Lang();
            db.AddParameter("@lang", lang.getCurrentLang());
            db.AddParameter("@id", id);
            DataTable dt = db.ExecuteDataTable("select top(3) * from Report where lang=@lang and (not id=@id) Order by id desc");
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            db.AddParameter("@lang", lang.getCurrentLang());
            dt = db.ExecuteDataTable("select top(3) * from SocialEvent where lang=@lang Order by id desc");
            Repeater2.DataSource = dt;
            Repeater2.DataBind();

            db.AddParameter("@lang", lang.getCurrentLang());
            db.AddParameter("@id", id);
            dt = db.ExecuteDataTable("select * from Report where lang=@lang and id=@id");
            Repeater3.DataSource = dt;
            Repeater3.DataBind();

            if (dt.Rows.Count == 0)
            {
                Response.Redirect("~/MediaCenter.aspx");
            }
        }
    }
}