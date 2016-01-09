using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EventDocOp : System.Web.UI.Page
{
    string tablename = "EventDoc";
    string listpage = "EventDocList.aspx";
    public string name = "المرفقات";
    Database db = new Database();
    Dates _dates=new Dates();
    protected void Page_Init(object sender, EventArgs e)
    {
        int pid;
        if(!int.TryParse(Request.QueryString["pid"],out pid))
        {
            Response.Redirect("EventList.aspx");
        }
        if (Request.QueryString["Op"] == null) Response.Redirect("EventList.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Database db = new Database();
            
            if (Request.QueryString["Op"].Equals("Edit"))
            {
                LoadData();
            }
            
            listpage += "?id=" + Request.QueryString["pid"];
            name += " " + db.GetProName("Event", "title", "id", Request.QueryString["pid"]);
            HyperLink2.NavigateUrl = listpage;
        }
    }
    void LoadData()
    {
        db.AddParameter("@id", Request.QueryString["id"]);
        System.Data.DataSet ds = db.ExecuteDataSet("select * from " + tablename + " where id=@id" + ";" + "");
        txtTitle.Text = ds.Tables[0].Rows[0]["name"].ToString();
        ViewState["url"] = ds.Tables[0].Rows[0]["Url"].ToString();



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
        
        if (fileFile.HasFile)
        {
            if (!Tools.IsDoc(fileFile.PostedFile.FileName))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء التأكد من الملف\")</SCRIPT>", false);
                return;
            }
            try
            {
                if (ViewState["url"] != null)
                {
                    System.IO.File.Delete(Server.MapPath("~/Images/EventDoc/" + ViewState["url"].ToString()));
                }
                ViewState["url"] = DateTime.Now.Ticks + System.IO.Path.GetFileName(fileFile.PostedFile.FileName);

                fileFile.PostedFile.SaveAs(Server.MapPath("~/images/EventDoc/" + ViewState["url"].ToString()));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
                return;
            }
        }



        db.AddParameter("@name", txtTitle.Text);
        db.AddParameter("@eventId", Request.QueryString["pid"]);
        db.AddParameter("@url", ViewState["url"].ToString());



        if (Request.QueryString["Op"].Equals("Edit"))
        {
            try
            {
                db.AddParameter("@id", Request.QueryString["id"]);
                db.ExecuteNonQuery("Update " + tablename + " Set name=@name,url=@url where Id=@id");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم التعديل ','تم التعديل بنجاح').set('onok', function(closeEvent){ location.href='EventDocList.aspx?id=" + Request.QueryString["pid"]+"'; } );", true);
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
            }

        }
        else if (Request.QueryString["Op"] == "Add")
        {
            db.ExecuteNonQuery("Insert into " + tablename + "(name,url,eventId) Values(@name,@url,@eventId)");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "alertify.alert('تم الاضافة ','تم الاضافة بنجاح').set('onok', function(closeEvent){ location.href='EventDocList.aspx?id=" + Request.QueryString["pid"] + "'; } );", true);
        }
    }

}