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
        txtWriter.Text = ds.Tables[0].Rows[0]["Writer"].ToString();
        txtPrev.Text = ds.Tables[0].Rows[0]["prev"].ToString();
        txtTxt.Text = ds.Tables[0].Rows[0]["txt"].ToString();
        txtAddDate.Text = _dates.GregToHijri(DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString()).ToString("dd/MM/yyyy"), "dd/MM/yyyy");
        ddlLang.SelectedValue = ds.Tables[0].Rows[0]["lang"].ToString();
        ViewState["img"] = ds.Tables[0].Rows[0]["img"].ToString();
        ViewState["img2"] = ds.Tables[0].Rows[0]["img2"].ToString();
        ViewState["url"] = ds.Tables[0].Rows[0]["url"].ToString();



    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Op"].Equals("Add") && !fileImg.HasFile)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار الغلاف.\")</SCRIPT>", false);
            return;
        }
        if (Request.QueryString["Op"].Equals("Add") && !fileImg2.HasFile)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار الفهرس.\")</SCRIPT>", false);
            return;
        }
        if (Request.QueryString["Op"].Equals("Add") && !fileUrl.HasFile)
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

        if (fileImg2.HasFile)
        {

            if (!Tools.IsImage(fileImg2.PostedFile.FileName))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء التأكد من الفهرس\")</SCRIPT>", false);
                return;
            }
            try
            {
                if (ViewState["img2"] != null)
                {
                    System.IO.File.Delete(Server.MapPath("~/Images/Publications/" + ViewState["img2"].ToString()));
                }
                ViewState["img2"] = DateTime.Now.Ticks + System.IO.Path.GetFileName(fileImg2.PostedFile.FileName);

                fileImg2.PostedFile.SaveAs(Server.MapPath("~/images/Publications/" + ViewState["img2"].ToString()));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
                return;
            }
        }

        if (fileUrl.HasFile)
        {

            if (!Tools.IsDoc(fileUrl.PostedFile.FileName))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء التأكد من الملف\")</SCRIPT>", false);
                return;
            }
            try
            {
                if (ViewState["url"] != null)
                {
                    System.IO.File.Delete(Server.MapPath("~/Images/Publications/" + ViewState["url"].ToString()));
                }
                ViewState["url"] = DateTime.Now.Ticks + System.IO.Path.GetFileName(fileUrl.PostedFile.FileName);

                fileUrl.PostedFile.SaveAs(Server.MapPath("~/images/Publications/" + ViewState["url"].ToString()));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
                return;
            }
        }



        db.AddParameter("@title", txtTitle.Text);
        db.AddParameter("@writer", txtWriter.Text);
        db.AddParameter("@prev", txtPrev.Text);
        db.AddParameter("@txt", txtTxt.Text);
        db.AddParameter("@lang", ddlLang.SelectedValue);
        db.AddParameter("@adddate", tmp);
        db.AddParameter("@img", ViewState["img"].ToString());
        db.AddParameter("@img2", ViewState["img2"].ToString());
        db.AddParameter("@url", ViewState["url"].ToString());



        if (Request.QueryString["Op"].Equals("Edit"))
        {
            try
            {
                db.AddParameter("@id", Request.QueryString["id"]);
                db.ExecuteNonQuery("Update " + tablename + " Set writer=@writer,title=@title,prev=@prev,txt=@txt,img=@img,img2=@img2,url=@url,lang=@lang,AddDate=@AddDate where Id=@id");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم التعديل ','تم التعديل بنجاح').set('onok', function(closeEvent){ location.href='" + listpage+ "'; } ) ;", true);

                

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
            }

        }
        else if (Request.QueryString["Op"] == "Add")
        {
            db.ExecuteNonQuery("Insert into " + tablename + "(Title,writer,prev,txt,img,img2,url,lang,AddDate) Values(@Title,@Writer,@prev,@txt,@img,@img2,@url,@lang,@AddDate)");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم الاضافة ','تم الاضافة بنجاح').set('onok', function(closeEvent){ location.href='" + listpage + "'; } );", true);
        }
    }

}