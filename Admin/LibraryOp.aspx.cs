using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ExpertiseOp : System.Web.UI.Page
{
    string tablename = "Library";
    string listpage = "LibraryList.aspx";
    public string name = "المكتبة";
    Database db = new Database();
    Dates datets=new Dates();
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Request.QueryString["Op"] == null) Response.Redirect("Default.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Database db = new Database();
            db.LoadDDL("ResearchType", "title", ref ddlType, "التصنيف");
            if (Request.QueryString["Op"].Equals("Edit"))
            {
                LoadData();
            }
            else
            {
                txtAddDate.Text = datets.GregToHijri(DateTime.Now.ToString("d/M/yyyy"), "d/M/yyyy");
            }
        }
    }
    void LoadData()
    {
        db.AddParameter("@id", Request.QueryString["id"]);
        System.Data.DataSet ds = db.ExecuteDataSet("select * from " + tablename + " where id=@id" + ";" + "");
        txtTitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
        txtWriter.Text = ds.Tables[0].Rows[0]["writer"].ToString();
        txtAddDate.Text =  datets.GregToHijri(DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString()).ToString("d/M/yyyy"),"d/M/yyyy");
        txtPublishDate.Text = datets.GregToHijri(DateTime.Parse(ds.Tables[0].Rows[0]["PublishDate"].ToString()).ToString("d/M/yyyy"), "d/M/yyyy");
        ddlLang.SelectedValue = ds.Tables[0].Rows[0]["lang"].ToString();
        ddlType.SelectedValue = ds.Tables[0].Rows[0]["type"].ToString();
        ViewState["file"] = ds.Tables[0].Rows[0]["file"].ToString();



    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Op"].Equals("Add") && !fileFile.HasFile)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار الملف.\")</SCRIPT>", false);
            return;
        }
        if (string.IsNullOrEmpty(txtTitle.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار العنوان.\")</SCRIPT>", false);
            return;
        }
        if (string.IsNullOrEmpty(txtWriter.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار المؤلف.\")</SCRIPT>", false);
            return;
        }
        if (ddlType.SelectedValue.Equals("-1"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار التصنيف\")</SCRIPT>", false);
            return;
        }
        DateTime tmp,tmp2;

        if (!DateTime.TryParseExact(datets.HijriToGreg(txtPublishDate.Text, "d/M/yyyy"), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tmp2))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء التأكد من التاريخ النشر\")</SCRIPT>", false);
            return;
        }

        if (!DateTime.TryParseExact(datets.HijriToGreg(txtAddDate.Text, "d/M/yyyy"), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tmp))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء التأكد من التاريخ الاضافة\")</SCRIPT>", false);
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
                    System.IO.File.Delete(Server.MapPath("~/Images/Library/" + ViewState["file"].ToString()));
                }
                ViewState["file"] = DateTime.Now.Ticks + System.IO.Path.GetFileName(fileFile.PostedFile.FileName);

                fileFile.PostedFile.SaveAs(Server.MapPath("~/images/Library/" + ViewState["file"].ToString()));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
                return;
            }
        }



        db.AddParameter("@title", txtTitle.Text);
        db.AddParameter("@writer", txtWriter.Text);
        db.AddParameter("@lang", ddlLang.SelectedValue);
        db.AddParameter("@Type", ddlType.SelectedValue);
        db.AddParameter("@AddDate",tmp );
        db.AddParameter("@PublishDate", tmp2);
        db.AddParameter("@file", ViewState["file"].ToString());



        if (Request.QueryString["Op"].Equals("Edit"))
        {
            try
            {
                db.AddParameter("@id", Request.QueryString["id"]);
                db.ExecuteNonQuery("Update " + tablename + " Set title=@title,[Type]=@Type,[File]=@file,lang=@lang,Writer=@writer,AddDate=@addDate,PublishDate=@PublishDate where Id=@id");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم التعديل ','تم التعديل بنجاح').set('onok', function(closeEvent){ location.href='" + listpage+"'; } );", true);

                

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
            }

        }
        else if (Request.QueryString["Op"] == "Add")
        {
            db.ExecuteNonQuery("Insert into " + tablename + "(Title,[Type],[File],lang,Writer,AddDate,publishDate) Values(@Title,@Type,@File,@lang,@Writer,@AddDate,@publishDate)");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم الاضافة ','تم الاضافة بنجاح').set('onok', function(closeEvent){ location.href='" + listpage + "'; } );", true);
        }
    }

}