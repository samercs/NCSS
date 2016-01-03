using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminOp : System.Web.UI.Page
{
    string tablename = "AdminUsers";
    Database db = new Database();
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Request.QueryString["Op"] == null) Response.Redirect("Default.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminInfo adminInfo = Session["AdminInfo"] as AdminInfo;
        if (!adminInfo.Permition.Equals("1"))
        {
            Response.Redirect("Default.aspx");
        }

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
        txtFirstName.Text = ds.Tables[0].Rows[0]["name"].ToString();
        txtUsername.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
        txtPassword.Text = ds.Tables[0].Rows[0]["password"].ToString();
        txtEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();
        ddlPermition.SelectedValue= ds.Tables[0].Rows[0]["permition"].ToString();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        AppFunctions v = new AppFunctions();
        if (Request.QueryString["Op"].ToLower() == "add")
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء ادخال الاسم.\")</SCRIPT>", false);
                return;
            }

            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء ادخال اسم المستخدم.\")</SCRIPT>", false);
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء ادخال البريد الالكتروني.\")</SCRIPT>", false);
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء ادخال كلمة السر.\")</SCRIPT>", false);
                return;
            }
        }
        if (!v.IsEmailValid(txtEmail.Text))
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء التحقق من البريد الالكتوني.\")</SCRIPT>", false);
            return;

        }
        if (txtPassword.Text.Length < 6)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"كلمة السر يجب ان تكون بطول 6 احرف على الاقل\")</SCRIPT>", false);
            return;
        }


        System.Data.DataTable dt = new System.Data.DataTable();
        db.AddParameter("@username", txtUsername.Text);
        db.AddParameter("@Email", txtEmail.Text);
        if (Request.QueryString["Op"].ToLower().Equals("add"))
        {
            dt = db.ExecuteDataTable("Select * from AdminUsers Where UserName=@username Or Email=@Email");
        }
        else if (Request.QueryString["Op"].ToLower().Equals("edit"))
        {
            db.AddParameter("@id", Request.QueryString["id"]);
            dt = db.ExecuteDataTable("Select * from AdminUsers Where (UserName=@username Or Email=@Email) and not id=@id");
        }

        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"خطأ : هذة البريد الالكتروني موجود مسبقا\")</SCRIPT>", false);
            return;
        }
        db.AddParameter("@Name", txtFirstName.Text);
        db.AddParameter("@UName", txtUsername.Text);
        db.AddParameter("@Password", txtPassword.Text);
        db.AddParameter("@Email", txtEmail.Text);
        db.AddParameter("@permition", ddlPermition.SelectedValue);
        if (Request.QueryString["Op"] == "Edit")
        {
            db.AddParameter("@id", Request.QueryString["id"]);
            db.ExecuteNonQuery("update " + tablename + " set email=@Email,Name=@Name,UserName=@UName,Password=@Password,permition=@permition where id=@id");
            //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.success(\"Contact Added successfully.\")</SCRIPT>", false);
            Response.Redirect("AdminList.aspx");
            //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.success(\"Contact Added successfully.\")</SCRIPT>", false);
        }
        else if (Request.QueryString["Op"] == "Add")
        {
            try
            {
                if (txtPassword.Text.Length <= 5)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Password Must Be 6 Char lenght at least\")</SCRIPT>", false);
                    return;
                }
                db.ExecuteNonQuery("insert into " + tablename + "(Name,UserName,Password,email,permition) Values(@Name,@UName,@Password,@Email,@permition)");
                Response.Redirect("AdminList.aspx");
                // ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.success(\"Contact Added successfully.\")</SCRIPT>", false);

            }
            catch
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"Please try again.\")</SCRIPT>", false);
            }
        }
    }

}