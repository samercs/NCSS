using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ContactUs : UICaltureBase
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
            //db.LoadDDL("Country",ref ddlCountry,lang.getByKey("Country"));
db.LoadDDL("Country", "name", "id", ref ddlCountry, lang.getByKey("Country"), "lang=" + lang.getCurrentLang(), "showOrder");            
ddlTitle.Items.Add(new ListItem(lang.getByKey("Mr.")));
            ddlTitle.Items.Add(new ListItem(lang.getByKey("Miss.")));
            ddlTitle.Items.Add(new ListItem(lang.getByKey("Mrs.")));
        }
    }

    protected void LinkButton1_OnClick(object sender, EventArgs e)
    {
        if (ValidateData())
        {
            Database db = new Database();
            var lang = new Lang();
            db.AddParameter("@name", txtName.Text);
            db.AddParameter("@country", ddlCountry.SelectedValue);
            db.AddParameter("@Email", txtEmail.Text);
            db.AddParameter("@Phone", txtPhone.Text);
            db.AddParameter("@title", ddlTitle.SelectedValue);
            db.AddParameter("@subject", txtSubject.Text);
            db.AddParameter("@txt", txtMessage.Text);
            

            db.ExecuteNonQuery(
                "insert into ContactUs(name,email,phone,country,title,txt,subject) values (@name,@email,@phone,@country,@title,@txt,@subject)");


            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("CaontactUsSubmitSuccessfully") + "').set('onok', function(closeEvent){ location.href='/ContactUs.aspx';} );", true);

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
        if (ddlCountry.SelectedValue.Equals("-1"))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("CountryError") + "');", true);
            return false;
        }
        

        Regex reg = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(2000));
        if (!reg.IsMatch(txtEmail.Text))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("EmailError2") + "');", true);
            return false;
        }
        if (string.IsNullOrWhiteSpace(txtSubject.Text))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("SubjectError") + "');", true);
            return false;
        }
        if (string.IsNullOrWhiteSpace(txtMessage.Text))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("MessageError") + "');", true);
            return false;
        }

        return true;
    }
}