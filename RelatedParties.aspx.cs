using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RelatedParties : UICaltureBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            LoadData();

        }
    }

    private void LoadData()
    {
        Database db=new Database();
        DataTable dt = db.ExecuteDataTable("select * from RelatedLinks");
        ListView1.DataSource = dt;
        ListView1.DataBind();
    }


}