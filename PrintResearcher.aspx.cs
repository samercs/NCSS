using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PrintResearcher : UICaltureBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int id;
            if (int.TryParse(Request.QueryString["id"], out id))
            {
                Database db = new Database();
                db.AddParameter("@id", id);
                DataTable dt = db.ExecuteDataTable("select * from Researcher where id=@id and IsAproved=1");
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                if (dt.Rows.Count > 0)
                {
                    Page.Title = dt.Rows[0]["name"].ToString();
                }
            }

            
        }
    }
}