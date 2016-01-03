using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ShowcaseOp : System.Web.UI.Page
{

    string tablename = "Showcase";
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
        txtTitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
        ddlLang.SelectedValue= ds.Tables[0].Rows[0]["lang"].ToString();
        txtShowOrder.Text = ds.Tables[0].Rows[0]["ShowOrder"].ToString();
        
        ViewState["img"]= ds.Tables[0].Rows[0]["img"].ToString();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtTitle.Text))
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء ادخال العنوان.\")</SCRIPT>", false);
            return;
        }
        
        if (string.IsNullOrEmpty(txtShowOrder.Text))
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء ادخال ترتيب العرض.\")</SCRIPT>", false);
            return;
        }
        

        int x = 0;
        if (!int.TryParse(txtShowOrder.Text, out x))
        {

            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"ترتيب العرض يجب ان يكون رقم\")</SCRIPT>", false);
            return;

        }

        if (!fileImg.HasFile && Request.QueryString["Op"] == "Add")
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار الصورة.\")</SCRIPT>", false);
            return;

        }
        System.Data.DataTable dt = new System.Data.DataTable();
        db.AddParameter("@title", txtTitle.Text.Replace("<p>","").Replace("</p>",""));
        db.AddParameter("@lang",ddlLang.SelectedValue);
        db.AddParameter("@showOrder", txtShowOrder.Text);
        db.AddParameter("@url", "#");


        if (Request.QueryString["Op"] == "Edit")
        {
           
                if (fileImg.HasFile)
                {

                if (!Tools.IsImage(fileImg.PostedFile.FileName))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء التأكد من الصورة\")</SCRIPT>", false);
                    return;
                }

                string fileName = DateTime.Now.Ticks.ToString() + "_" +
                                  System.IO.Path.GetFileName(fileImg.PostedFile.FileName);
                    fileImg.PostedFile.SaveAs(Server.MapPath("~/images/showcase/" + fileName));
                    db.AddParameter("@img", fileName);
                    /*if (!string.IsNullOrWhiteSpace(ViewState["img"].ToString()))
                    {
                        System.IO.File.Delete(Server.MapPath("~/images/showcase/" + ViewState["img"]));
                    }*/
                }
                else
                {
                    db.AddParameter("@img", ViewState["img"].ToString());
                }
                

                db.AddParameter("@id", Request.QueryString["id"]);
                dt = db.ExecuteDataTable("Update " + tablename + " Set title=@title,url=@url,showOrder=@showOrder,img=@img,lang=@lang  where Id=@id");
                Response.Redirect("ShowcaseList.aspx");
            
        }
        else if (Request.QueryString["Op"] == "Add")
        {
            if (!Tools.IsImage(fileImg.PostedFile.FileName))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء التأكد من الصورة\")</SCRIPT>", false);
                return;
            }
            try
            {
                string fileName = DateTime.Now.Ticks.ToString() + "_" +
                                  System.IO.Path.GetFileName(fileImg.PostedFile.FileName);
                fileImg.PostedFile.SaveAs(Server.MapPath("~/images/showcase/"+fileName));
                db.AddParameter("@img", fileName);
                db.ExecuteNonQuery("insert into " + tablename + "(title,img,lang,showOrder,Url) Values(@title,@img,@lang,@showOrder,@Url)");
                Response.Redirect("ShowcaseList.aspx");
                // ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.success(\"Contact Added successfully.\")</SCRIPT>", false);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Error : " + ex.Message + "\")</SCRIPT>", false);
            }
        }
    }

}