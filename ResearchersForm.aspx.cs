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
            Database db = new Database();
            Lang lang = new Lang();
            db.AddParameter("@lang", lang.getCurrentLang());
            db.AddParameter("@pagekey", "ContactInformation");
            DataTable dt = db.ExecuteDataTable("select * from pages where lang=@lang and pagekey=@pagekey");
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

           db.LoadDDL("Country", "name", "id", ref ddlCountry, lang.getByKey("Country"), "lang=" + lang.getCurrentLang(), "showOrder");
//db.LoadDDL("Country",ref ddlCountry,lang.getByKey("Country"));

            ddlDegree.Items.Add(new ListItem(lang.getByKey("Degree"), "-1"));
            ddlDegree.Items.Add(new ListItem(lang.getByKey("BSc")));
            ddlDegree.Items.Add(new ListItem(lang.getByKey("Master")));
            ddlDegree.Items.Add(new ListItem(lang.getByKey("PhD")));
            LoadInfo();


        }
    }
    void LoadInfo()
    {
        if (Session["ReInfo"] != null && Request.QueryString["op"] == "Edit")
        {
            Lang lang = new Lang();
            btnSend.Text = lang.getByKey("fsave");
            Researchers re = Session["ReInfo"] as Researchers;
            if (Request.QueryString["id"] == re.ID)
            {
                txtName.Text = re.Name;
                ddlCountry.SelectedValue = re.Country;
                txtQualification.Text = re.Qualification;
                txtMajor.Text = re.major;
                txtSpecialization.Text = re.Specialization;
                txtCurrentWork.Text = re.CurrentWork;
                ddlDegree.SelectedValue = re.Level;
                txtWorkPlace.Text = re.organization;
                txtEmail.Text = re.Email;
                txtPhone.Text = re.Phone;
                txtMobile.Text = re.Mobile;
                txtFacebook.Text = re.Facebook;
                txtTwitter.Text = re.Twitter;
                txtLinkedin.Text = re.LinkedIn;
                txtPrev.Text = re.Prev;
                //db.AddParameter("@Img", filename);
                // db.AddParameter("@CV", CVFile);
                //db.AddParameter("@lang", new Lang().getCurrentLang());
            }
        }
    }
    protected void btnSend_OnClick(object sender, EventArgs e)
    {

        var lang = new Lang();
        Database db = new Database(); string filename = "", CVFile = "";
        if (ValidateData())
        {
            db.AddParameter("@name", txtName.Text);
            db.AddParameter("@country", ddlCountry.SelectedValue);
            db.AddParameter("@Qualification", txtQualification.Text);
            db.AddParameter("@major", txtMajor.Text);
            db.AddParameter("@Specialization", txtSpecialization.Text);
            db.AddParameter("@CurrentWork", txtCurrentWork.Text);
            db.AddParameter("@level", ddlDegree.SelectedValue);
            db.AddParameter("@Organization", txtWorkPlace.Text);
            db.AddParameter("@Email", txtEmail.Text);
            db.AddParameter("@Phone", txtPhone.Text);
            db.AddParameter("@Mobile", txtMobile.Text);
            db.AddParameter("@facebook", txtFacebook.Text);
            db.AddParameter("@Twitter", txtTwitter.Text);
            db.AddParameter("@Linkedin", txtLinkedin.Text);
            db.AddParameter("@Prev", txtPrev.Text);


            db.AddParameter("@lang", new Lang().getCurrentLang());
            if (Request.QueryString["op"] == "Edit")
            {
                if (Session["ReInfo"] == null)
                {
                    Response.Redirect("ResearchersLogin.aspx");
                }
                Researchers re = Session["ReInfo"] as Researchers;
                if (re.ID == Request.QueryString["id"])
                {
                    if (fileImage.HasFile)
                    {
                        filename = DateTime.Now.Ticks + "_" + System.IO.Path.GetFileName(fileImage.PostedFile.FileName);
                        fileImage.PostedFile.SaveAs(Server.MapPath("~/images/Researchers/") + filename);
                        db.AddParameter("@Img", filename);
                    }
                    else
                    {
                        db.AddParameter("@Img", re.Img);

                    }
                    if (fileCv.HasFile)
                    {
                        if (!Tools.IsDoc(fileCv.PostedFile.FileName))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء التأكد من الملف\")</SCRIPT>", false);
                            return;
                        }
                        CVFile = DateTime.Now.Ticks + "_" + System.IO.Path.GetFileName(fileCv.PostedFile.FileName);
                        fileCv.PostedFile.SaveAs(Server.MapPath("~/images/Researchers/CVs/") + CVFile);
                        db.AddParameter("@CV", CVFile);
                    }
                    else
                    {
                        db.AddParameter("@CV", re.CV);
                    }
                    if (string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrEmpty(txtPassword.Text))
                    {
                        db.AddParameter("@Password", re.Password);
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("PasswordError") + "');", true);
                            return;
                        }
                        if (string.IsNullOrEmpty(txtPassword.Text))
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("PasswordError") + "');", true);
                            return;
                        }
                        if (txtConfirmPass.Text != txtPassword.Text)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("ConfirmPasswordError") + "');", true);
                            return;
                        }
                        db.AddParameter("@Password", txtPassword.Text);
                    }
                    db.AddParameter("@uid", re.ID);
                    db.ExecuteNonQuery("update Researcher set name=@name,country=@country,Qualification=@Qualification,major=@major,Specialization=@Specialization,CurrentWork=@CurrentWork,level=@level,Organization=@Organization,Email=@Email,Phone=@Phone,Mobile=@Mobile,facebook=@facebook,Twitter=@Twitter,Linkedin=@Linkedin,Prev=@Prev,Img=@Img,CV=@CV,Password=@Password where id=@uid");
                    db.AddParameter("@uid", re.ID);
                    System.Data.DataTable dt = db.ExecuteDataTable("Select * from Researcher where id=@uid");
                    re.ID = dt.Rows[0]["id"].ToString();
                    re.Name = dt.Rows[0]["name"].ToString();
                    re.Country = dt.Rows[0]["Country"].ToString();
                    re.Qualification = dt.Rows[0]["Qualification"].ToString();
                    re.major = dt.Rows[0]["major"].ToString();
                    re.Specialization = dt.Rows[0]["Specialization"].ToString();
                    re.CurrentWork = dt.Rows[0]["CurrentWork"].ToString();
                    re.Level = dt.Rows[0]["Level"].ToString();
                    re.organization = dt.Rows[0]["organization"].ToString();
                    re.Email = dt.Rows[0]["Email"].ToString();
                    re.Phone = dt.Rows[0]["Phone"].ToString();
                    re.Mobile = dt.Rows[0]["Mobile"].ToString();
                    re.Facebook = dt.Rows[0]["Facebook"].ToString();
                    re.Twitter = dt.Rows[0]["Twitter"].ToString();
                    re.LinkedIn = dt.Rows[0]["linkedin"].ToString();
                    re.Prev = dt.Rows[0]["Prev"].ToString();
                    re.Img = dt.Rows[0]["Img"].ToString();
                    re.CV = dt.Rows[0]["CV"].ToString();
                    re.Password = dt.Rows[0]["Password"].ToString();
                    Session["ReInfo"] = re;
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("ResearchEitSuccessfully") + "').set('onok', function(closeEvent){ location.href='/Researcher.aspx?id=" + re.ID + "';} );", true);
                }
            }
            else
            {
                db.AddParameter("@Password", txtPassword.Text);

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("PasswordError") + "');", true);
                    return;
                }
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("PasswordError") + "');", true);
                    return;
                }
                if (txtConfirmPass.Text != txtPassword.Text)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("ConfirmPasswordError") + "');", true);
                    return;
                }
                if (!fileImage.HasFile)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("ImageError") + "');", true);
                    return;
                }
                if (!fileCv.HasFile)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("CVError") + "');", true);

                    return;
                }
                if (fileCv.HasFile && !Tools.IsDoc(fileCv.PostedFile.FileName))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء التأكد من الملف\")</SCRIPT>", false);
                    return;
                }

                filename = DateTime.Now.Ticks + "_" + System.IO.Path.GetFileName(fileImage.PostedFile.FileName);
                fileImage.PostedFile.SaveAs(Server.MapPath("~/images/Researchers/") + filename);
                CVFile = DateTime.Now.Ticks + "_" + System.IO.Path.GetFileName(fileCv.PostedFile.FileName);
                fileCv.PostedFile.SaveAs(Server.MapPath("~/images/Researchers/CVs/") + CVFile);
                db.AddParameter("@Img", filename);
                db.AddParameter("@CV", CVFile);



                db.ExecuteNonQuery("insert into Researcher(name,country,Qualification,major,Specialization,CurrentWork,level,Organization,Email,Phone,Mobile,facebook,Twitter,Linkedin,Prev,Img,CV,lang,Password) values(@name,@country,@Qualification,@major,@Specialization,@CurrentWork,@level,@Organization,@Email,@Phone,@Mobile,@facebook,@Twitter,@Linkedin,@Prev,@Img,@CV,@lang,@Password)");
                txtName.Text = string.Empty;
                ddlCountry.SelectedValue = "-1";
                txtQualification.Text = string.Empty;
                txtMajor.Text = string.Empty;
                txtSpecialization.Text = string.Empty;
                txtCurrentWork.Text = string.Empty;
                ddlDegree.SelectedValue = "-1";
                txtWorkPlace.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtMobile.Text = string.Empty;
                txtFacebook.Text = string.Empty;
                txtTwitter.Text = string.Empty;
                txtLinkedin.Text = string.Empty;
                txtPrev.Text = string.Empty;
                txtPassword.Text = string.Empty;
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("ResearchSubmitSuccessfully") + "').set('onok', function(closeEvent){ location.href='/Experts.aspx';} );", true);
            }

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
        if (string.IsNullOrWhiteSpace(txtQualification.Text))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("QualificationError") + "');", true);
            return false;
        }
        if (string.IsNullOrWhiteSpace(txtMajor.Text))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("MajorError") + "');", true);
            return false;
        }
        if (ddlDegree.SelectedValue.Equals("-1"))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("DegreeError") + "');", true);
            return false;
        }
        if (string.IsNullOrWhiteSpace(txtWorkPlace.Text))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("WorkPlaceError") + "');", true);
            return false;
        }
        if (string.IsNullOrWhiteSpace(txtCurrentWork.Text))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("CurrentWorkError") + "');", true);
            return false;
        }
        if (string.IsNullOrWhiteSpace(txtMobile.Text))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("MobileError") + "');", true);
            return false;
        }
        AppFunctions v = new AppFunctions();
        if (!v.IsEmailValid(txtEmail.Text))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("EmailError") + "');", true);
            return false;
        }

        //if (!v.IsPhoneValid(txtPhone.Text))
        //{
        //    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("PhoneError") + "');", true);
        //    return false;
        //}

        Regex reg = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(2000));
        if (!reg.IsMatch(txtEmail.Text))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("EmailError2") + "');", true);
            return false;
        }

        Regex reg2 = new Regex(@"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(2000));
        if ((!reg2.IsMatch(txtFacebook.Text) || !txtFacebook.Text.ToLower().Contains("facebook.com")) && txtFacebook.Text.Length > 3)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("FacebookError") + "');", true);
            return false;
        }

        if ((!reg2.IsMatch(txtTwitter.Text) || !txtTwitter.Text.ToLower().Contains("twitter.com")) && txtTwitter.Text.Length > 3)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("TwitterError") + "');", true);
            return false;
        }

        if (!txtLinkedin.Text.ToLower().Contains("linkedin.com") && txtLinkedin.Text.Length > 3)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("LinkedinrError") + "');", true);
            return false;
        }
        //if (string.IsNullOrWhiteSpace(txtPrev.Text))
        //{
        //    ClientScript.RegisterClientScriptBlock( this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("") + "','" + lang.getByKey("PrevError") + "');", true);
        //    return false;
        //}



        return true;
    }

}