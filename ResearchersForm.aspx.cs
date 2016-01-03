using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResearchersForm : UICaltureBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Database db=new Database();
            Lang lang=new Lang();
            db.AddParameter("@lang", lang.getCurrentLang());
            db.AddParameter("@pagekey", "ContactInformation");
            DataTable dt = db.ExecuteDataTable("select * from pages where lang=@lang and pagekey=@pagekey");
            Repeater1.DataSource=dt;
            Repeater1.DataBind();

            db.LoadDDL("Country",ref ddlCountry,lang.getByKey("Country"));

            ddlDegree.Items.Add(new ListItem(lang.getByKey("Degree"),"-1"));
            ddlDegree.Items.Add(new ListItem(lang.getByKey("BSc")));
            ddlDegree.Items.Add(new ListItem(lang.getByKey("Master")));
            ddlDegree.Items.Add(new ListItem(lang.getByKey("PhD")));


        }
    }

    protected void btnSend_OnClick(object sender, EventArgs e)
    {

        

        if (ValidateData())
        {
            string filename = DateTime.Now.Ticks + "_" + System.IO.Path.GetFileName(fileImage.PostedFile.FileName);
            fileImage.PostedFile.SaveAs(Server.MapPath("~/images/Researchers/")+filename);

            Database db = new Database();
            var lang=new Lang();
            db.AddParameter("@name", txtName.Text);
            db.AddParameter("@countrty", ddlCountry.SelectedValue);
            db.AddParameter("@major", txtMajor.Text);
            db.AddParameter("@level", ddlDegree.SelectedValue);
            db.AddParameter("@Organization", txtWorkPlace.Text);
            db.AddParameter("@Email", txtEmail.Text);
            db.AddParameter("@Phone", txtPhone.Text);
            db.AddParameter("@facebook", txtFacebook.Text);
            db.AddParameter("@Twitter", txtTwitter.Text);
            db.AddParameter("@Linkedin", txtLinkedin.Text);
            db.AddParameter("@Prev", txtPrev.Text);
            db.AddParameter("@Img", filename);
            db.AddParameter("@lang", new Lang().getCurrentLang());

            db.ExecuteNonQuery(
                "insert into Researcher(name,country,major,level,Organization,Email,Phone,facebook,Twitter,Linkedin,Prev,Img,lang) values(@name,@countrty,@major,@level,@Organization,@Email,@Phone,@facebook,@Twitter,@Linkedin,@Prev,@Img,@lang)");


            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("ResearchSubmitSuccessfully") + "').set('onok', function(closeEvent){ location.href='/Experts.aspx';} );", true);

        }
    }


    private bool ValidateData()
    {
        Lang lang=new Lang();
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(),"Alert1", "alertify.alert('"+lang.getByKey("")+"','"+lang.getByKey("NameError") +"');", true);
            return false;
        }
        if (ddlCountry.SelectedValue.Equals("-1"))
        {
            ClientScript.RegisterClientScriptBlock( this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("CountryError") + "');", true);
            return false;
        }
        if (string.IsNullOrWhiteSpace(txtMajor.Text))
        {
            ClientScript.RegisterClientScriptBlock( this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("MajorError") + "');", true);
            return false;
        }
        if (ddlDegree.SelectedValue.Equals("-1"))
        {
            ClientScript.RegisterClientScriptBlock( this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("DegreeError") + "');", true);
            return false;
        }
        if (string.IsNullOrWhiteSpace(txtWorkPlace.Text))
        {
            ClientScript.RegisterClientScriptBlock( this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("WorkPlaceError") + "');", true);
            return false;
        }
        AppFunctions v=new AppFunctions();
        if (!v.IsEmailValid(txtEmail.Text))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("EmailError") + "');", true);
            return false;
        }
        if (!v.IsPhoneValid(txtPhone.Text))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("PhoneError") + "');", true);
            return false;
        }


        Regex reg=new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(2000));
        if (!reg.IsMatch(txtEmail.Text))
        {
            ClientScript.RegisterClientScriptBlock( this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("EmailError2") + "');", true);
            return false;
        }

        Regex reg2=new Regex(@"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$", RegexOptions.IgnoreCase,TimeSpan.FromMilliseconds(2000));
        if (!reg2.IsMatch(txtFacebook.Text) || !txtFacebook.Text.ToLower().Contains("facebook.com"))
        {
            ClientScript.RegisterClientScriptBlock( this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("FacebookError") + "');", true);
            return false;
        }

        if (!reg2.IsMatch(txtTwitter.Text) || !txtTwitter.Text.ToLower().Contains("twitter.com"))
        {
            ClientScript.RegisterClientScriptBlock( this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("TwitterError") + "');", true);
            return false;
        }

        if ( !txtLinkedin.Text.ToLower().Contains("linkedin.com"))
        {
            ClientScript.RegisterClientScriptBlock( this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("LinkedinrError") + "');", true);
            return false;
        }
        if (string.IsNullOrWhiteSpace(txtPrev.Text))
        {
            ClientScript.RegisterClientScriptBlock( this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("PrevError") + "');", true);
            return false;
        }
        if (!fileImage.HasFile)
        {
            ClientScript.RegisterClientScriptBlock( this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("ImageError") + "');", true);
            return false;
        }

        return true;
    }

}