using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_PublicationsOp : System.Web.UI.Page
{
    string tablename = "Publications";
    string listpage = "PublicationsList.aspx";
    public string name = "المنشورات";
    private Dates _dates = new Dates();
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
                txtAddDate.Text = _dates.GregToHijri(DateTime.Now.ToString("dd/MM/yyyy"));
            }
        }
    }
    void LoadData()
    {
        db.AddParameter("@id", Request.QueryString["id"]);
        System.Data.DataSet ds = db.ExecuteDataSet("select * from " + tablename + " where id=@id" + ";" + "");
        txtTitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
        txtPrev.Text = ds.Tables[0].Rows[0]["prev"].ToString();
        txtTxt.Text = ds.Tables[0].Rows[0]["txt"].ToString();
        txtAddDate.Text = _dates.GregToHijri(DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString()).ToString("dd/MM/yyyy"), "dd/MM/yyyy");
        ddlLang.SelectedValue = ds.Tables[0].Rows[0]["lang"].ToString();
        ViewState["img"] = ds.Tables[0].Rows[0]["img"].ToString();



    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Op"].Equals("Add") && !fileImg.HasFile)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار الملف.\")</SCRIPT>", false);
            return;
        }
        if (string.IsNullOrEmpty(txtTitle.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار العنوان.\")</SCRIPT>", false);
            return;
        }
        if (string.IsNullOrWhiteSpace(txtPrev.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء ادخال الملخص.\")</SCRIPT>", false);
            return;
        }
        if (string.IsNullOrWhiteSpace(txtTxt.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء ادخال التفاصيل.\")</SCRIPT>", false);
            return;
        }
        
        DateTime tmp;
        if (!DateTime.TryParseExact(_dates.HijriToGreg(txtAddDate.Text, "dd/MM/yyyy"), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tmp))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء التأكد من التاريخ\")</SCRIPT>", false);
            return;
        }

        if (fileImg.HasFile)
        {

            if (!Tools.IsImage(fileImg.PostedFile.FileName))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء التأكد من الصورة\")</SCRIPT>", false);
                return;
            }
            try
            {
                if (ViewState["img"] != null)
                {
                    System.IO.File.Delete(Server.MapPath("~/Images/Publications/" + ViewState["img"].ToString()));
                }
                ViewState["img"] = DateTime.Now.Ticks + System.IO.Path.GetFileName(fileImg.PostedFile.FileName);

                fileImg.PostedFile.SaveAs(Server.MapPath("~/images/Publications/" + ViewState["img"].ToString()));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
                return;
            }
        }



        db.AddParameter("@title", txtTitle.Text);
        db.AddParameter("@prev", txtPrev.Text);
        db.AddParameter("@txt", txtTxt.Text);
        db.AddParameter("@lang", ddlLang.SelectedValue);
        db.AddParameter("@adddate", tmp);
        db.AddParameter("@img", ViewState["img"].ToString());



        if (Request.QueryString["Op"].Equals("Edit"))
        {
            try
            {
                db.AddParameter("@id", Request.QueryString["id"]);
                db.ExecuteNonQuery("Update " + tablename + " Set title=@title,prev=@prev,txt=@txt,img=@img,lang=@lang,AddDate=@AddDate where Id=@id");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم التعديل ','تم التعديل بنجاح').set('onok', function(closeEvent){ location.href='" + listpage+ "'; } ) ;", true);

                

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
            }

        }
        else if (Request.QueryString["Op"] == "Add")
        {
            db.ExecuteNonQuery("Insert into " + tablename + "(Title,prev,txt,img,lang,AddDate) Values(@Title,@prev,@txt,@img,@lang,@AddDate)");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم الاضافة ','تم الاضافة بنجاح').set('onok', function(closeEvent){ location.href='" + listpage + "'; } );", true);
        }
    }

}