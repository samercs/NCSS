using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_PollOp : System.Web.UI.Page
{
    string tablename = "Poll";
    string listpage = "PollList.aspx";
    public string name = "استطلاع الراي";
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
            else
            {
                txtAddDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }
    }
    void LoadData()
    {
        db.AddParameter("@id", Request.QueryString["id"]);
        System.Data.DataSet ds = db.ExecuteDataSet("select * from " + tablename + " where id=@id" + ";" + "");
        txtTitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
        txtTitleAr.Text = ds.Tables[0].Rows[0]["titleAr"].ToString();
        txtAddDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["Adddate"].ToString()).ToString("dd/MM/yyyy");

        bool tmp;
        if(bool.TryParse(ds.Tables[0].Rows[0]["ShowInHome"].ToString(),out tmp))
        {
            cbShowInHome.Checked = tmp;
        }
        else
        {
            cbShowInHome.Checked = false;
        }
        
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtTitle.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار العنوان انجليزي.\")</SCRIPT>", false);
            return;
        }
        if (string.IsNullOrEmpty(txtTitleAr.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار العنوان عربي.\")</SCRIPT>", false);
            return;
        }

        DateTime tmp;
        if (!DateTime.TryParseExact(txtAddDate.Text, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tmp))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء التأكد من التاريخ\")</SCRIPT>", false);
            return;
        }

        

        

        if(cbShowInHome.Checked)
        {
            db.ExecuteNonQuery("update poll set ShowInHome=0");
        }

        db.AddParameter("@title", txtTitle.Text);
        db.AddParameter("@titleAr", txtTitleAr.Text);
        db.AddParameter("@AddDate", tmp);
        db.AddParameter("@ShowInHome", cbShowInHome.Checked);

        if (Request.QueryString["Op"].Equals("Edit"))
        {
            try
            {
                db.AddParameter("@id", Request.QueryString["id"]);
                db.ExecuteNonQuery("Update " + tablename + " Set title=@title,titleAr=@titleAr,addDate=@addDate,ShowInHome=@ShowInHome where Id=@id");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم التعديل ','تم التعديل بنجاح').set('onok', function(closeEvent){ location.href='" + listpage+"'; } );", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
            }

        }
        else if (Request.QueryString["Op"] == "Add")
        {
            db.ExecuteNonQuery("Insert into " + tablename + "(Title,TitleAr,AddDate,ShowInHome) Values(@Title,@TitleAr,@AddDate,@ShowInHome)");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم الاضافة ','تم الاضافة بنجاح').set('onok', function(closeEvent){ location.href='" + listpage + "'; } );", true);
        }
    }

}