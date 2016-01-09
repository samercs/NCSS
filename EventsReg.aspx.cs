using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EventsReg : UICaltureBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Database db = new Database();
            Lang lang = new Lang();
            db.AddParameter("@lang", lang.getCurrentLang());
            db.AddParameter("@key", "ContactInformation");
            DataTable dt = db.ExecuteDataTable("select * from pages where pagekey=@key and lang=@lang");
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            db.AddParameter("@lang", lang.getCurrentLang());
            db.AddParameter("@key", "MapURL");
            dt = db.ExecuteDataTable("select * from pages where pagekey=@key and lang=@lang");
            Repeater2.DataSource = dt;
            Repeater2.DataBind();

            
            db.AddParameter("@id", Request.QueryString["id"]);
            dt = db.ExecuteDataTable("select * from event where id=@id");
            if (dt.Rows.Count > 0)
            {
                lblEventTitle.Text = dt.Rows[0]["title"].ToString();
            }

        }
    }

    protected void LinkButton1_OnClick(object sender, EventArgs e)
    {
        if (ValidateData())
        {
            Database db = new Database();
            var lang = new Lang();
            db.AddParameter("@name", txtName.Text);
            db.AddParameter("@Age", txtAge.Text);
            db.AddParameter("@Major", txtMajor.Text);
            db.AddParameter("@Email", txtEmail.Text);
            db.AddParameter("@Phone", txtPhone.Text);
            db.AddParameter("@EventId", Request.QueryString["id"]);
            db.ExecuteNonQuery(
                "insert into EventReg(name,email,phone,age,major,eventId) values (@name,@email,@phone,@age,@major,@eventId)");


            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("EventRegisterSuccessfully") + "').set('onok', function(closeEvent){ location.href='/Events.aspx';} );", true);

        }

    }


    private bool ValidateData()
    {
        Lang lang = new Lang();
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("NameError") + "');", true);
            return false;
        }
        
        Regex reg = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(2000));
        if (!reg.IsMatch(txtEmail.Text))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("EmailError2") + "');", true);
            return false;
        }
        
        AppFunctions t =new AppFunctions();
        if (!t.IsPhoneValid(txtPhone.Text))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("PhoneError") + "');", true);
            return false;
        }


        int age;
        if (!int.TryParse(txtAge.Text, out age))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("AgeError") + "');", true);
            return false;
        }

        if (age < 18 || age > 100)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("AgeError") + "');", true);
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtMajor.Text))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("MajorError") + "');", true);
            return false;
        }



        return true;
    }
}