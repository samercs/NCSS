using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddResearchForm : UICaltureBase
{
    Database db = new Database();
    Dates _dates = new Dates(); string tablename = "Research";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ReInfo"] == null) { Response.Redirect("Experts.aspx"); }

        if (!Page.IsPostBack)
        {
            Database db = new Database();
            if (Request.QueryString["op"].Equals("Edit"))
            {
                LoadData();
            }
            else
            {
                txtAddDate.Text = _dates.GregToHijri(DateTime.Now.ToString("d/M/yyyy"));
            }
        }
    }
    void LoadData()
    {
        db.AddParameter("@id", Request.QueryString["rid"]);
        System.Data.DataSet ds = db.ExecuteDataSet("select * from " + tablename + " where id=@id" + ";" + "");
        txtTitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
        txtAddDate.Text = _dates.GregToHijri(DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString()).ToString("d/M/yyyy"));
        txtPublishDate.Text = _dates.GregToHijri(DateTime.Parse(ds.Tables[0].Rows[0]["PublishDate"].ToString()).ToString("d/M/yyyy"));
        ddlLang.SelectedValue = ds.Tables[0].Rows[0]["lang"].ToString();
        ViewState["file"] = ds.Tables[0].Rows[0]["file"].ToString();



    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["op"].Equals("Add") && !fileFile.HasFile)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار الملف.\")</SCRIPT>", false);
            return;
        }
        if (string.IsNullOrEmpty(txtTitle.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار العنوان.\")</SCRIPT>", false);
            return;
        }

        DateTime tmp, tmp2;
        if (!DateTime.TryParseExact(_dates.HijriToGreg(txtAddDate.Text, "dd/MM/yyyy"), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tmp))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء التأكد من التاريخ\")</SCRIPT>", false);
            return;
        }
        if (!DateTime.TryParseExact(_dates.HijriToGreg(txtPublishDate.Text, "dd/MM/yyyy"), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tmp2))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء التأكد من التاريخ النشر\")</SCRIPT>", false);
            return;
        }

        if (fileFile.HasFile)
        {
            if (!Tools.IsDoc(fileFile.PostedFile.FileName))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء التأكد من الملف\")</SCRIPT>", false);
                return;
            }
            try
            {
                if (ViewState["file"] != null)
                {
                    System.IO.File.Delete(Server.MapPath("~/Images/Research/" + ViewState["file"].ToString()));
                }
                ViewState["file"] = DateTime.Now.Ticks + System.IO.Path.GetFileName(fileFile.PostedFile.FileName);

                fileFile.PostedFile.SaveAs(Server.MapPath("~/images/Research/" + ViewState["file"].ToString()));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
                return;
            }
        }


        Researchers re = Session["ReInfo"] as Researchers;
        db.AddParameter("@title", txtTitle.Text);
        db.AddParameter("@ResearcherId", re.ID);
        db.AddParameter("@lang", ddlLang.SelectedValue);
        db.AddParameter("@AddDate", tmp);
        db.AddParameter("@PublishDate", tmp2);
        db.AddParameter("@file", ViewState["file"].ToString());



        if (Request.QueryString["op"].Equals("Edit"))
        {
            try
            {
                db.AddParameter("@id", Request.QueryString["rid"]);
                db.ExecuteNonQuery("Update " + tablename + " Set title=@title,[File]=@file,lang=@lang,ResearcherId=@ResearcherId,AddDate=@addDate,publishDate=@publishDate where Id=@id");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم التعديل ','تم التعديل بنجاح').set('onok', function(closeEvent){ location.href='Researcher.aspx?id=" + re.ID + "'; } );", true);

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\""+ex.Message+"\")</SCRIPT>", false);
            }

        }
        else if (Request.QueryString["op"] == "Add")
        {
            db.ExecuteNonQuery("Insert into " + tablename + "(Title,[File],lang,ResearcherId,AddDate,PublishDate) Values(@Title,@File,@lang,@ResearcherId,@AddDate,@PublishDate)");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم الاضافة ','تم الاضافة بنجاح').set('onok', function(closeEvent){ location.href='Researcher.aspx?id=" + re.ID + "'; } );", true);
        }
    }
}