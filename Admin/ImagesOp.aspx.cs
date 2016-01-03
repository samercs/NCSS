using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ImagesOp : System.Web.UI.Page
{

    string tablename = "Images";
    Database db = new Database();
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Request.QueryString["Op"] == null) Response.Redirect("Default.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["op"].ToString() == "Edit")
            {
                LoadData();

            }
        }
    }
    void LoadData()
    {
        db.AddParameter("@id", Request.QueryString["id"]);
        System.Data.DataSet ds = db.ExecuteDataSet("select * from " + tablename + " where id=@id" + ";" + "");
        txtImgKey.Text = ds.Tables[0].Rows[0]["ImgKey"].ToString();
        ddlLang.SelectedValue= ds.Tables[0].Rows[0]["ImgKey"].ToString();
        txtWidth.Text = ds.Tables[0].Rows[0]["Width"].ToString();
        txtHieght.Text = ds.Tables[0].Rows[0]["Hieght"].ToString();
        txtAlt.Text = ds.Tables[0].Rows[0]["Alt"].ToString();
        ViewState["Image"] = ds.Tables[0].Rows[0]["Src"].ToString();


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["op"].Equals("Add"))
        {
            if (!fileImg.HasFile)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار الصورة.\")</SCRIPT>", false);
                return;
            }
        }
        

        if (string.IsNullOrEmpty(txtAlt.Text))
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء ادخال النص البديل.\")</SCRIPT>", false);
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
                if (ViewState["Image"] != null)
                {
                    System.IO.File.Delete(Server.MapPath("~/Images/images/" + ViewState["Image"].ToString()));
                }
                ViewState["Image"] = DateTime.Now.Ticks + System.IO.Path.GetFileName(fileImg.PostedFile.FileName);

                fileImg.PostedFile.SaveAs(Server.MapPath("~/images/images/" + ViewState["Image"].ToString()));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
                return;
            }
        }
        
        db.AddParameter("@imgKey", txtImgKey.Text);
        db.AddParameter("@alt", txtAlt.Text);
        if (string.IsNullOrWhiteSpace(txtWidth.Text))
        {
            db.AddParameter("@width", DBNull.Value);
        }
        else
        {
            db.AddParameter("@width", txtWidth.Text);
        }

        if (string.IsNullOrWhiteSpace(txtHieght.Text))
        {
            db.AddParameter("@hieght", DBNull.Value);
        }
        else
        {
            db.AddParameter("@hieght", txtWidth.Text);
        }

        db.AddParameter("@lang", ddlLang.SelectedValue);
        db.AddParameter("@src", ViewState["Image"].ToString());


        if (Request.QueryString["Op"] == "Edit")
        {
            try
            {
                db.AddParameter("@id", Request.QueryString["id"]);
                db.ExecuteDataTable("Update " + tablename + " Set src=@src,imgkey=@imgkey,alt=@alt,width=@width,Hieght=@Hieght,lang=@lang where Id=@id");
                Response.Redirect("ImagesList.aspx");
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
            }
        }
        else if (Request.QueryString["Op"] == "Add")
        {
            try
            {

                db.ExecuteNonQuery("Insert into " + tablename + "(src,ImgKey,Alt,Width,Hieght,lang) Values(@src,@ImgKey,@Alt,@Width,@Hieght,@lang)");
                Response.Redirect("ImagesList.aspx");

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
            }
        }
    }

}