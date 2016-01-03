using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_PagesOp : System.Web.UI.Page
{
    string tablename = "Pages";
    Database db = new Database();
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Request.QueryString["Op"] == null) Response.Redirect("Default.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["op"].ToString() == "Edit")
            {
                LoadData();

            }
        }
    }
    void LoadData()
    {
        db.AddParameter("@id", Request.QueryString["id"]);
        System.Data.DataSet ds = db.ExecuteDataSet("select * from " + tablename + " where id=@id" + ";" + "");
        txtTitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
        txtText.Text = ds.Tables[0].Rows[0]["txt"].ToString();
        txtPrv.Text = ds.Tables[0].Rows[0]["prev"].ToString();
        ddlLang.SelectedValue= ds.Tables[0].Rows[0]["lang"].ToString();
        txtPageKey.Text = ds.Tables[0].Rows[0]["pagekey"].ToString();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        AppFunctions v = new AppFunctions();

        if (string.IsNullOrEmpty(txtTitle.Text))
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء ادخال عنوان الصفحة.\")</SCRIPT>", false);
            return;
        }
        if (string.IsNullOrEmpty(txtPrv.Text))
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء ادخال ملخص.\")</SCRIPT>", false);
            return;
        }
        if (string.IsNullOrEmpty(txtText.Text))
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء ادخال التفاصيل.\")</SCRIPT>", false);
            return;
        }
        System.Data.DataTable dt = new System.Data.DataTable();
        db.AddParameter("@title", txtTitle.Text);
        db.AddParameter("@Text", txtText.Text);
        db.AddParameter("@Prv", txtPrv.Text);
        db.AddParameter("@lang", ddlLang.SelectedValue);
        
        if (Request.QueryString["Op"].ToLower().Equals("edit"))
        {
            try
            {
                db.AddParameter("@id", Request.QueryString["id"]);
                dt = db.ExecuteDataTable("Update Pages Set title=@title,txt=@Text,prev=@Prv,lang=@lang where Id=@id");
                Response.Redirect("PagesList.aspx");
            }

            catch
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Please try again.\")</SCRIPT>", false);
            }
        }
    }

}