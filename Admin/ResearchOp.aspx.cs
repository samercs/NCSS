using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ResearchOp : System.Web.UI.Page
{
    string tablename = "Research";
    string listpage = "ResearchList.aspx";
    public string name = "الابحاث";
    Database db = new Database();
    Dates _dates=new Dates();
    protected void Page_Init(object sender, EventArgs e)
    {
        int pid;
        if(!int.TryParse(Request.QueryString["pid"],out pid))
        {
            Response.Redirect("ResearcherList.aspx");
        }
        if (Request.QueryString["Op"] == null) Response.Redirect("Default.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Database db = new Database();
            db.LoadDDL("Researcher", "name", ref ddlResearcher, "الباحث");
            if (Request.QueryString["Op"].Equals("Edit"))
            {
                LoadData();
            }
            else
            {
                txtAddDate.Text = _dates.GregToHijri(DateTime.Now.ToString("d/M/yyyy"));
            }
            listpage += "&id=" + Request.QueryString["pid"];
            name += " " + db.GetProName("Researcher", "name", "id", Request.QueryString["pid"]);
            ddlResearcher.SelectedValue = Request.QueryString["pid"];
        }
    }
    void LoadData()
    {
        db.AddParameter("@id", Request.QueryString["id"]);
        System.Data.DataSet ds = db.ExecuteDataSet("select * from " + tablename + " where id=@id" + ";" + "");
        txtTitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
        ddlResearcher.SelectedValue = ds.Tables[0].Rows[0]["ResearcherId"].ToString();
        txtAddDate.Text = _dates.GregToHijri(DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString()).ToString("d/M/yyyy"));
        ddlLang.SelectedValue = ds.Tables[0].Rows[0]["lang"].ToString();
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
        if (ddlResearcher.SelectedValue.Equals("-1"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار الباحث.\")</SCRIPT>", false);
            return;
        }
        
        DateTime tmp;
        if (!DateTime.TryParseExact(_dates.HijriToGreg(txtAddDate.Text,"dd/MM/yyyy"), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tmp))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء التأكد من التاريخ\")</SCRIPT>", false);
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



        db.AddParameter("@title", txtTitle.Text);
        db.AddParameter("@ResearcherId", ddlResearcher.SelectedValue);
        db.AddParameter("@lang", ddlLang.SelectedValue);
        db.AddParameter("@AddDate", tmp);
        db.AddParameter("@file", ViewState["file"].ToString());



        if (Request.QueryString["Op"].Equals("Edit"))
        {
            try
            {
                db.AddParameter("@id", Request.QueryString["id"]);
                db.ExecuteNonQuery("Update " + tablename + " Set title=@title,[File]=@file,lang=@lang,ResearcherId=@ResearcherId,AddDate=@addDate where Id=@id");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم التعديل ','تم التعديل بنجاح').set('onok', function(closeEvent){ location.href='ResearchList.aspx?id="+ddlResearcher.SelectedValue+"'; } );", true);
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
            }

        }
        else if (Request.QueryString["Op"] == "Add")
        {
            db.ExecuteNonQuery("Insert into " + tablename + "(Title,[File],lang,ResearcherId,AddDate) Values(@Title,@File,@lang,@ResearcherId,@AddDate)");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم الاضافة ','تم الاضافة بنجاح').set('onok', function(closeEvent){ location.href='ResearchList.aspx?id=" + ddlResearcher.SelectedValue + "'; } );", true);
        }
    }

}