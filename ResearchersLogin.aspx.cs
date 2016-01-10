using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResearchersLogin : UICaltureBase
{  Database db = new Database();
        Lang lang = new Lang();
    protected void Page_Load(object sender, EventArgs e)
    {
      
        txtRePass.Attributes.Add("placeholder", lang.getByKey("Password"));
        txtReUser.Attributes.Add("placeholder", lang.getByKey("Email"));
        txtFEmail.Attributes.Add("placeholder", lang.getByKey("Email"));
        btnReLogin.Text = lang.getByKey("slogin");
        cbRememberMe.Text= lang.getByKey("RememberMe");
        cbReKeepOnline.Text = lang.getByKey("KeepOnline");
        if (!Page.IsPostBack)
        {
            HttpCookie UName = Request.Cookies["ReUser"];
            HttpCookie UPassword = Request.Cookies["RePass"];
            if (UName != null)
            {
                txtReUser.Text = UName.Value;
                cbRememberMe.Checked = true;
            }

            if (UPassword != null)
            {
                txtRePass.Attributes.Add("value", UPassword.Value);
                cbRememberMe.Checked = true;
            }
            if (Request.Cookies["ReKeepOnline"] != null)
            {
                int id;
                if (int.TryParse(Request.Cookies["ReKeepOnline"].Value, out id))
                {
                    db.AddParameter("@id", id);
                    System.Data.DataTable dt = db.ExecuteDataTable("select * from Researcher where id=@id and IsAproved=1");
                    txtReUser.Text = dt.Rows[0]["Email"].ToString();
                    txtRePass.Text = dt.Rows[0]["password"].ToString();
                    btnReLogin_Click(null, null);
                }
            }

        }
    }

    protected void btnReLogin_Click(object sender, EventArgs e)
    {
        
        db.AddParameter("@uname", txtReUser.Text);
        db.AddParameter("@password", txtRePass.Text);
        System.Data.DataTable dt = db.ExecuteDataTable("Select * from Researcher where (email=@uname or email=@uname) and (password=@password) and IsAproved=1");
        if (dt.Rows.Count != 0)
        {

            if (cbRememberMe.Checked)
            {
                HttpCookie c = new HttpCookie("ReUser", txtReUser.Text);
                c.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(c);
                c = new HttpCookie("RePass", txtRePass.Text);
                c.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(c);
            }
            else
            {
                HttpCookie c = new HttpCookie("ReUser", "");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
                c = new HttpCookie("RePass", "");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }

            if (cbReKeepOnline.Checked)
            {
                HttpCookie c = new HttpCookie("ReKeepOnline", dt.Rows[0]["id"].ToString());
                c.Expires = DateTime.Now.AddDays(20);
                Response.Cookies.Add(c);
            }
            else
            {
                HttpCookie c = new HttpCookie("ReKeepOnline", "");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }

            Researchers ReInfo = new Researchers();
            ReInfo.ID = dt.Rows[0]["id"].ToString();
            ReInfo.Name = dt.Rows[0]["name"].ToString();
            ReInfo.Country = dt.Rows[0]["Country"].ToString();
            ReInfo.Qualification = dt.Rows[0]["Qualification"].ToString();
            ReInfo.major = dt.Rows[0]["major"].ToString();
            ReInfo.Specialization = dt.Rows[0]["Specialization"].ToString();
            ReInfo.CurrentWork = dt.Rows[0]["CurrentWork"].ToString();
            ReInfo.Level = dt.Rows[0]["Level"].ToString();
            ReInfo.organization = dt.Rows[0]["organization"].ToString();
            ReInfo.Email = dt.Rows[0]["Email"].ToString();
            ReInfo.Phone = dt.Rows[0]["Phone"].ToString();
            ReInfo.Mobile = dt.Rows[0]["Mobile"].ToString();
            ReInfo.Facebook = dt.Rows[0]["Facebook"].ToString();
            ReInfo.Twitter = dt.Rows[0]["Twitter"].ToString();
            ReInfo.LinkedIn = dt.Rows[0]["linkedin"].ToString();
            ReInfo.Prev = dt.Rows[0]["Prev"].ToString();
            ReInfo.Img = dt.Rows[0]["Img"].ToString();
            ReInfo.CV = dt.Rows[0]["CV"].ToString();
            ReInfo.Password = dt.Rows[0]["Password"].ToString();
            Session["ReInfo"] = ReInfo;

            Response.Redirect("Researcher.aspx?id=" + ReInfo.ID);

        }
        else
        {
            db.AddParameter("@uname", txtReUser.Text);
            db.AddParameter("@password", txtRePass.Text);
            dt = db.ExecuteDataTable("Select * from Researcher where (email=@uname or email=@uname) and (password=@password) and IsAproved != 1");
            if (dt.Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alertify.alert('" + lang.getByKey("ReIsAprovedError") + "');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alertify.alert('" + lang.getByKey("ReLoginError") + "');", true);
            }
        }

    }

    protected void btnForgotPass_Click(object sender, EventArgs e)
    {
        AppFunctions v = new AppFunctions();
        if (!v.IsEmailValid(txtFEmail.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alertify.alert('" + lang.getByKey("EmailError") + "');", true);
            return;
        }

        Database db = new Database();
        db.AddParameter("@email", txtFEmail.Text);
        System.Data.DataTable dt = db.ExecuteDataTable("Select * from Researcher where email=@email");
        if (dt.Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alertify.alert('" + lang.getByKey("emalorpassError") + "');", true);
            return;
        }

        string body = "<h2>";
        body += "هذة معلومات الدخول الى لوحة التحكم الخاصة المركز الوطني للدراسات والبحوث الإجتماعية<br/>";
        body += "اسم المستخدم : " + dt.Rows[0]["name"].ToString() + "<br/>";
        body += "البريد الالكتروني : " + dt.Rows[0]["email"].ToString() + "<br/>";
        body += "كلمة السر : " + dt.Rows[0]["password"].ToString() + "<br/>";
        body += "</h2>";
        SendMail mail = new SendMail();
        mail.SendMsg(txtFEmail.Text, "المركز الوطني للدراسات والبحوث الإجتماعية", body);
    }

    protected void btnBackLogin_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
    }


    protected void btnGoToForgotPass_Click(object sender, EventArgs e)
    {

        Panel1.Visible = false;
        Panel2.Visible = true;
    }
}