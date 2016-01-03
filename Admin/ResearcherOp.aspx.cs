using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ResearcherOp : System.Web.UI.Page
{
    string tablename = "Researcher";
    string listpage = "ResearcherList.aspx";
    public string name = "الباحثين";
    Database db = new Database();
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Request.QueryString["Op"] == null) Response.Redirect("Default.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Database db = new Database();
            db.LoadDDL("country", "name", ref ddlCountry, "الدولة");
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
        txtName.Text = ds.Tables[0].Rows[0]["name"].ToString();
        ddlCountry.SelectedValue = ds.Tables[0].Rows[0]["country"].ToString();
        txtMajor.Text = ds.Tables[0].Rows[0]["major"].ToString();
        ddlLevel.SelectedValue = ds.Tables[0].Rows[0]["Level"].ToString();
        txtOrganization.Text = ds.Tables[0].Rows[0]["Organization"].ToString();
        txtEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();
        txtPhone.Text = ds.Tables[0].Rows[0]["phone"].ToString();
        txtFacebook.Text = ds.Tables[0].Rows[0]["facebook"].ToString();
        txtTwitter.Text = ds.Tables[0].Rows[0]["twitter"].ToString();
        txtLinkedin.Text = ds.Tables[0].Rows[0]["linkedin"].ToString();
        txtPrev.Text = ds.Tables[0].Rows[0]["Prev"].ToString();
        ddlLang.SelectedValue = ds.Tables[0].Rows[0]["lang"].ToString();
        bool tmp=true;
        Boolean.TryParse(ds.Tables[0].Rows[0]["IsAproved"].ToString(), out tmp);
        cbAproved.Checked=tmp;
        ViewState["img"] = ds.Tables[0].Rows[0]["img"].ToString();



    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Op"].Equals("Add") && !fileImg.HasFile)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار الصورة.\")</SCRIPT>", false);
            return;
        }
        if (string.IsNullOrEmpty(txtName.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء ادخال الاسم.\")</SCRIPT>", false);
            return;
        }
        
        if (ddlCountry.SelectedValue.Equals("-1"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار الدولة\")</SCRIPT>", false);
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
                    System.IO.File.Delete(Server.MapPath("~/Images/Researchers/" + ViewState["img"].ToString()));
                }
                ViewState["img"] = DateTime.Now.Ticks + System.IO.Path.GetFileName(fileImg.PostedFile.FileName);

                fileImg.PostedFile.SaveAs(Server.MapPath("~/images/Researchers/" + ViewState["img"].ToString()));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
                return;
            }
        }



        db.AddParameter("@name", txtName.Text);
        db.AddParameter("@Country", ddlCountry.SelectedValue);
        db.AddParameter("@Major", txtMajor.Text);
        db.AddParameter("@Level", ddlLevel.SelectedValue);
        db.AddParameter("@Organization", txtOrganization.Text);
        db.AddParameter("@email", txtEmail.Text);
        db.AddParameter("@phone", txtPhone.Text);
        db.AddParameter("@facebook", txtFacebook.Text);
        db.AddParameter("@twitter", txtTwitter.Text);
        db.AddParameter("@linkedin", txtLinkedin.Text);
        db.AddParameter("@prev", txtPrev.Text);
        db.AddParameter("@lang", ddlLang.SelectedValue);
        db.AddParameter("@isAproved", cbAproved.Checked);
        db.AddParameter("@img", ViewState["img"].ToString());
        AdminInfo admininfo = (AdminInfo)Session["AdminInfo"];
        db.AddParameter("@AprovedBy",admininfo.Id );



        if (Request.QueryString["Op"].Equals("Edit"))
        {
            try
            {
                db.AddParameter("@id", Request.QueryString["id"]);
                db.ExecuteNonQuery("Update " + tablename + " Set name=@name,country=@country,major=@major,level=@level,organization=@organization,email=@email,phone=@phone,facebook=@facebook,twitter=@twitter,linkedin=@linkedin,prev=@prev,img=@img,lang=@lang,IsAproved=@IsAproved,AprovedBy=@AprovedBy where Id=@id");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم التعديل ','تم التعديل بنجاح').set('onok', function(closeEvent){ location.href='" + listpage+"'; } );", true);
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
            }

        }
        else if (Request.QueryString["Op"] == "Add")
        {
            db.ExecuteNonQuery("Insert into " + tablename + " (name,country,major,level,organization,email,phone,facebook,twitter,linkedin,prev,img,lang,IsAproved,AprovedBy) Values(@name,@country,@major,@level,@organization,@email,@phone,@facebook,@twitter,@linkedin,@prev,@img,@lang,@IsAproved,@AprovedBy)");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم الاضافة ','تم الاضافة بنجاح').set('onok', function(closeEvent){ location.href='" + listpage + "'; } );", true);
        }
    }

}