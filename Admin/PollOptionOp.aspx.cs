using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_PollOptionOp : System.Web.UI.Page
{
    string tablename = "PollOption";
    string listpage = "PollOptionList.aspx";
    public string name = "الخيارات";
    Database db = new Database();
    protected void Page_Init(object sender, EventArgs e)
    {
        int pid;
        if(!int.TryParse(Request.QueryString["pid"],out pid))
        {
            Response.Redirect("PollList.aspx");
        }
        if (Request.QueryString["Op"] == null) Response.Redirect("Default.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["Op"].Equals("Edit"))
            {
                LoadData();
            }
            listpage += "&id=" + Request.QueryString["pid"];
            name += " " + db.GetProName("Poll", "title", "id", Request.QueryString["pid"]);
            if(Request.QueryString["Op"].Equals("Add"))
            {
                txtCount.Text = "0";
            }
            
        }
    }
    void LoadData()
    {
        db.AddParameter("@id", Request.QueryString["id"]);
        System.Data.DataSet ds = db.ExecuteDataSet("select * from " + tablename + " where id=@id" + ";" + "");
        txtTitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
        txtTitleAr.Text = ds.Tables[0].Rows[0]["titleAr"].ToString();
        txtCount.Text = ds.Tables[0].Rows[0]["count"].ToString();
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
        int x = 0;
        if (!int.TryParse(txtCount.Text, out x))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء التأكد من العداد\")</SCRIPT>", false);
            return;
        }

        db.AddParameter("@title", txtTitle.Text);
        db.AddParameter("@titleAr", txtTitleAr.Text);
        db.AddParameter("@count", txtCount.Text);
        db.AddParameter("@PollId",Request.QueryString["pid"]);


        if (Request.QueryString["Op"].Equals("Edit"))
        {
            try
            {
                db.AddParameter("@id", Request.QueryString["id"]);
                db.ExecuteNonQuery("Update " + tablename + " Set title=@title,titleAr=@titleAr,[count]=@count where Id=@id");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم التعديل ','تم التعديل بنجاح').set('onok', function(closeEvent){ location.href='PollOptionList.aspx?id=" + Request.QueryString["pid"]+"'; } );", true);
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
            }

        }
        else if (Request.QueryString["Op"] == "Add")
        {
            db.ExecuteNonQuery("Insert into " + tablename + "(Title,TitleAr,[count],pollId) Values(@Title,@TitleAr,@count,@pollId)");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم الاضافة ','تم الاضافة بنجاح').set('onok', function(closeEvent){ location.href='PollOptionList.aspx?id=" + Request.QueryString["pid"] + "'; } );", true);
        }
    }

}