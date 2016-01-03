using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Controls_Header : System.Web.UI.UserControl
{
    protected void Page_Init(object sender, EventArgs e)
    {

        if (Request.Cookies["NCSSCMSKeepOnline"] != null)
        {
            int id;
            if (int.TryParse(Request.Cookies["NCSSCMSKeepOnline"].Value, out id))
            {
                Database db = new Database();
                db.AddParameter("@id", id);
                System.Data.DataTable dt = db.ExecuteDataTable("Select * from adminUsers where id=@id");
                db.Dispose1();
                if (dt.Rows.Count != 0)
                {
                    AdminInfo admininfo = new AdminInfo(dt.Rows[0]["id"].ToString(), dt.Rows[0]["name"].ToString(), dt.Rows[0]["username"].ToString(), dt.Rows[0]["password"].ToString(), dt.Rows[0]["email"].ToString(), dt.Rows[0]["permition"].ToString());
                    Session["AdminInfo"] = admininfo;
                }
            }
        }

        if (Session["AdminInfo"] == null)
        {
            Response.Redirect("Login.aspx?url=" + Request.RawUrl);
        }
        if (!Page.IsPostBack)
        {
            AdminInfo admininfo = (AdminInfo)Session["AdminInfo"];
            HyperLink1.Text = "<span><i class=\"fa fa-smile-o\"></i> " + admininfo.Name + "!</span>";
            HyperLink1.NavigateUrl = "../AdminOp.aspx?id="+admininfo.Id+"&Op=Edit";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}