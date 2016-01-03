using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EventOp : System.Web.UI.Page
{
    string tablename = "Event";
    string listpage = "EventList.aspx";
    public string name = "الاحداث و النشاطات";
    Database db = new Database();
    private Dates _dates=new Dates();
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
                txtAddDate.Text = _dates.GregToHijri(DateTime.Now.ToString("dd/MM/yyyy"));
            }
        }
    }
    void LoadData()
    {
        db.AddParameter("@id", Request.QueryString["id"]);
        System.Data.DataSet ds = db.ExecuteDataSet("select * from " + tablename + " where id=@id" + ";" + "");
        txtTitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
        txtMap.Text = ds.Tables[0].Rows[0]["map"].ToString();
        txtTxt.Text = ds.Tables[0].Rows[0]["txt"].ToString();
        txtAddDate.Text = _dates.GregToHijri(DateTime.Parse(ds.Tables[0].Rows[0]["Eventdate"].ToString()).ToString("dd/MM/yyyy"),"dd/MM/yyyy");
        ddlLang.SelectedValue = ds.Tables[0].Rows[0]["lang"].ToString();
        



    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
       
        if (string.IsNullOrEmpty(txtTitle.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار العنوان.\")</SCRIPT>", false);
            return;
        }
        if (string.IsNullOrWhiteSpace(txtTxt.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء ادخال التفاصيل.\")</SCRIPT>", false);
            return;
        }
        if (string.IsNullOrWhiteSpace(txtY.Value) || string.IsNullOrWhiteSpace(txtX.Value))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء ادخال الخريطة.\")</SCRIPT>", false);
            return;
        }
        DateTime tmp;
        if (!DateTime.TryParseExact(_dates.HijriToGreg(txtAddDate.Text,"dd/MM/yyyy"), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tmp))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء التأكد من التاريخ\")</SCRIPT>", false);
            return;
        }

        

        db.AddParameter("@title", txtTitle.Text);
        db.AddParameter("@txt", txtTxt.Text);
        db.AddParameter("@lang", ddlLang.SelectedValue);
        db.AddParameter("@map", txtX.Value+","+txtY.Value);
        db.AddParameter("@EventDate", tmp);
        



        if (Request.QueryString["Op"].Equals("Edit"))
        {
            try
            {
                db.AddParameter("@id", Request.QueryString["id"]);
                db.ExecuteNonQuery("Update " + tablename + " Set title=@title,txt=@txt,lang=@lang,map=@map,eventDate=@eventDate where Id=@id");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم التعديل ','تم التعديل بنجاح').set('onok', function(closeEvent){ location.href='" + listpage+"'; } );", true);
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
            }

        }
        else if (Request.QueryString["Op"] == "Add")
        {
            db.ExecuteNonQuery("Insert into " + tablename + "(Title,txt,lang,map,EventDate) Values(@Title,@txt,@lang,@map,@EventDate)");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم الاضافة ','تم الاضافة بنجاح').set('onok', function(closeEvent){ location.href='" + listpage + "'; } );", true);
        }
    }

}