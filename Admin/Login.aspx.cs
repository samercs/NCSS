using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            HttpCookie UName = Request.Cookies["NCSSUserName"];
            HttpCookie UPassword = Request.Cookies["NCSSPassword"];
            if (UName != null)
            {
                txtUserName.Text = UName.Value;
                cbRememberMe.Checked = true;
            }
            
            if (UPassword != null)
            {
                txtPassword.Attributes.Add("value", UPassword.Value);
                cbRememberMe.Checked = true;
            }
            txtUserName.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {__doPostBack('" + btnLogin.UniqueID + "','');}} ");
            txtPassword.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {__doPostBack('" + btnLogin.UniqueID + "','');}} ");
            if (Request.Cookies["NCSSCMSKeepOnline"] != null)
            {
                int id;
                if (int.TryParse(Request.Cookies["NCSSCMSKeepOnline"].Value, out id))
                {
                    Database db = new Database();
                    db.AddParameter("@id", id);
                    System.Data.DataTable dt = db.ExecuteDataTable("select * from adminUsers where id=@id");
                    txtUserName.Text = dt.Rows[0]["username"].ToString();
                    txtPassword.Text = dt.Rows[0]["password"].ToString();
                    btnLogin_Click(null, null);
                }
            }

        }

    }
    protected void btnGoForget_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Database db = new Database();
        db.AddParameter("@uname", txtUserName.Text);
        db.AddParameter("@password", txtPassword.Text);
        System.Data.DataTable dt = db.ExecuteDataTable("Select * from AdminUsers where (username=@uname or email=@uname) and (password=@password)");
        if (dt.Rows.Count != 0)
        {

            if(cbRememberMe.Checked)
            {
                HttpCookie c=new HttpCookie("NCSSUserName", txtUserName.Text);
                c.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(c);
                c = new HttpCookie("NCSSPassword", txtPassword.Text);
                c.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(c);
            }
            else
            {
                HttpCookie c = new HttpCookie("NCSSUserName", "");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
                c = new HttpCookie("NCSSPassword", "");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }

            if(cbKeepMeLogin.Checked)
            {
                HttpCookie c = new HttpCookie("NCSSCMSKeepOnline", dt.Rows[0]["id"].ToString());
                c.Expires = DateTime.Now.AddDays(20);
                Response.Cookies.Add(c);
            }
            else
            {
                HttpCookie c = new HttpCookie("NCSSCMSKeepOnline", "");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }

            AdminInfo admininfo = new AdminInfo(dt.Rows[0]["id"].ToString(), dt.Rows[0]["name"].ToString(), dt.Rows[0]["username"].ToString(), dt.Rows[0]["password"].ToString(), dt.Rows[0]["email"].ToString(), dt.Rows[0]["permition"].ToString());
            Session["AdminInfo"] = admininfo;
            
            if (Request.QueryString["url"] == null)
            {
                Response.Redirect("default.aspx");
            }
            else
            {
                Response.Redirect(Request.QueryString.ToString().Replace("url=", "").Replace("%2f", "").Replace("Admin", "").Replace("admin", "").Replace("%3f", "?").Replace("%3d", "="));
            }
        }
        else
        {
            ErrorDiv.Visible = true;
            sp1.Visible = true;
            lblError.Text = "<i class=\"fa fa-exclamation-triangle fcRed\"></i> Error Login :  Check Your Login Information And Try again ";
        }

    }
    protected void btnBackLogin_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void btnForgetPass_Click(object sender, EventArgs e)
    {
        AppFunctions v = new AppFunctions();
        if (!v.IsEmailValid(txtEmail.Text))
        {
            ErrorDiv.Visible = true;
            sp1.Visible = true;
            lblError.Text = "<i class=\"fa fa-exclamation-triangle fcRed\"></i> invalid email address format";
            return;
        }

        Database db = new Database();
        db.AddParameter("@email", txtEmail.Text);
        System.Data.DataTable dt = db.ExecuteDataTable("Select * from AdminUsers where email=@email");
        if (dt.Rows.Count == 0)
        {
            ErrorDiv.Visible = true;
            sp1.Visible = true;
            lblError.Text = "<i class=\"fa fa-exclamation-triangle fcRed\"></i> invalid email address";
            return;
        }

        string body = "<h2>";
        body += "هذة معلومات الدخول الى لوحة التحكم الخاصة المركز الوطني للدراسات والبحوث الإجتماعية<br/>";
        body += "اسم المستخدم : " + dt.Rows[0]["username"].ToString() + "<br/>";
        body += "البريد الالكتروني : " + dt.Rows[0]["email"].ToString() + "<br/>";
        body += "كلمة السر : " + dt.Rows[0]["password"].ToString() + "<br/>";
        body += "</h2>";
        SendMail mail = new SendMail();
        mail.SendMsg(txtEmail.Text, "المركز الوطني للدراسات والبحوث الإجتماعية", body);

    }
}