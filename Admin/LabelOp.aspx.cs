using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_LabelOp : System.Web.UI.Page
{
    string tablename = "labels";
    string listpage = "labelList.aspx";
    public string name = "النصوص";
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
        txtTitle.Text = ds.Tables[0].Rows[0]["value"].ToString();
        txtKey.Text = ds.Tables[0].Rows[0]["key"].ToString();
        ddlLang.SelectedValue = ds.Tables[0].Rows[0]["lang"].ToString();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        if (string.IsNullOrEmpty(txtTitle.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار العنوان.\")</SCRIPT>", false);
            return;
        }
        if (string.IsNullOrWhiteSpace(txtKey.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء ادخال الرمز.\")</SCRIPT>", false);
            return;
        }
        
        db.AddParameter("@title", txtTitle.Text);
        db.AddParameter("@key", txtKey.Text);
        db.AddParameter("@lang", ddlLang.SelectedValue);
        

        if (Request.QueryString["Op"].Equals("Edit"))
        {
            try
            {
                db.AddParameter("@id", Request.QueryString["id"]);
                db.ExecuteNonQuery("Update " + tablename + " Set [value]=@title,[key]=@key,lang=@lang where Id=@id");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم التعديل ','تم التعديل بنجاح').set('onok', function(closeEvent){ location.href='" + listpage+"'; } );", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
            }

        }
        else if (Request.QueryString["Op"] == "Add")
        {
            try
            {
                db.ExecuteNonQuery("Insert into " + tablename + "([value],[key],lang) Values(@Title,@key,@lang)");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم الاضافة ','تم الاضافة بنجاح').set('onok', function(closeEvent){ location.href='" + listpage + "'; } );", true);
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
            }
            
        }
    }

}