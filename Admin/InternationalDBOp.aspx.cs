using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_InternationalDBOp : System.Web.UI.Page
{
    string tablename = "InternationalDB";
    string listpage = "InternationDBList.aspx";
    public string name = "قواعد البيانات العالمية";
    Database db = new Database();
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Request.QueryString["Op"] == null) Response.Redirect("Default.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            HyperLink2.NavigateUrl = listpage;
            if (Request.QueryString["Op"].Equals("Edit"))
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
        txtUrl.Text = ds.Tables[0].Rows[0]["Url"].ToString();
        txtText.Text = ds.Tables[0].Rows[0]["txt"].ToString();
        ddlLang.SelectedValue = ds.Tables[0].Rows[0]["lang"].ToString();
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (!txtUrl.Text.Equals("#") &&  !txtUrl.Text.ToLower().StartsWith("http"))
        {
            txtUrl.Text = "http://" + txtUrl.Text;
        }

        
        if (string.IsNullOrEmpty(txtTitle.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار العنوان.\")</SCRIPT>", false);
            return;
        }
        
        

        if (!txtUrl.Text.Equals("#") && !Tools.IsValidUrl(txtUrl.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء التأكد من الرابط التشعبي\")</SCRIPT>", false);
            return;
        }

        



        db.AddParameter("@title", txtTitle.Text);
        db.AddParameter("@txt", txtText.Text);
        db.AddParameter("@Url", txtUrl.Text);
        db.AddParameter("@lang", ddlLang.SelectedValue);
        



        if (Request.QueryString["Op"].Equals("Edit"))
        {
            try
            {
                db.AddParameter("@id", Request.QueryString["id"]);
                db.ExecuteNonQuery("Update " + tablename + " Set title=@title,txt=@txt,lang=@lang,Url=@Url where Id=@id");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم التعديل ','تم التعديل بنجاح').set('onok', function(closeEvent){ location.href='" + listpage+"'; } );", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
            }

        }
        else if (Request.QueryString["Op"] == "Add")
        {
            db.ExecuteNonQuery("Insert into " + tablename + "(Title,txt,lang,Url) Values(@Title,@txt,@lang,@url)");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم الاضافة ','تم الاضافة بنجاح').set('onok', function(closeEvent){ location.href='" + listpage + "'; } );", true);
        }
    }

}