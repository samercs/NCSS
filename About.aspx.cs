using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : UICaltureBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Database db=new Database();
            Lang lang=new Lang();

            string albumsSql = "select top(4) * from albums where lang=@lang order by showOrder";
            string aboutSql = "select  * from pages where pagekey=@key and lang=@lang";
            db.AddParameter("@lang", lang.getCurrentLang());
            if (Request.QueryString["page"] != null)
            {
                db.AddParameter("@key", Request.QueryString["page"]);    
            }
            else
            {
                db.AddParameter("@key", "HomeAbout");
            }
            
            DataSet ds = db.ExecuteDataSet(aboutSql+";"+albumsSql);
            Repeater1.DataSource = ds.Tables[0];
            Repeater1.DataBind();

            Repeater2.DataSource = ds.Tables[1];
            Repeater2.DataBind();

        }
    }
}