using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_Header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Database db=new Database();
            Lang lang = new Lang();

            

            
            db.AddParameter("@lang",lang.getCurrentLang());

            string researchTypeSql = "select id,title  from ResearchType";
            if (Page.Culture.Contains("Arabic"))
            {
                researchTypeSql = "select id,titleAr as title  from ResearchType";
                btnChangeLang.Text = lang.getByKey("English");
                btnLang.Text = lang.getByKey("English");
            }
            else
            {
                btnLang.Text = lang.getByKey("Arabic");
                btnChangeLang.Text= lang.getByKey("Arabic");
            }

            DataSet ds = db.ExecuteDataSet(researchTypeSql);
            Repeater1.DataSource = ds.Tables[0];
            Repeater1.DataBind();

            string pageName = System.IO.Path.GetFileName(Request.PhysicalPath).ToLower();
            switch (pageName)
            {
                case "default.aspx":
                    HomeLink.Attributes.Add("class","selected");
                    break;
                case "about.aspx":
                case "organizationalstructure.aspx":
                    AboutLink.Attributes.Add("class", "selected");
                    break;
                case "library.aspx":
                    LibraryLink.Attributes.Add("class", "selected");
                    break;
                case "experts.aspx":
                case "researcher.aspx":
                case "researchersform.aspx":
                    ExpertsLink.Attributes.Add("class", "selected");
                    break;
                case "phenomenon.aspx":
                case "phenomenondetails.aspx":
                    PhenomenonLink.Attributes.Add("class", "selected");
                    break;
                case "events.aspx":
                    EventLink.Attributes.Add("class", "selected");
                    break;
                case "publications.aspx":
                case "publicationsdetails.aspx":
                    PublicationLink.Attributes.Add("class", "selected");
                    break;
                case "mediacenter.aspx":
                case "newsdetails.aspx":
                case "reportdetails.aspx":
                    MediaCenterLink.Attributes.Add("class", "selected");
                    break;
                case "contactus.aspx":
                    ContactUsLink.Attributes.Add("class", "selected");
                    break;
            }
            

        }
    }

    

    protected void btnLang_OnClick(object sender, EventArgs e)
    {
        HttpCookie CultureCookie;
        if(Page.Culture.Contains("Arabic"))
        {
            CultureCookie = new HttpCookie("RCLang", "en-US");
        }
        else
        {
            CultureCookie = new HttpCookie("RCLang", "ar-JO");
        }
        CultureCookie.Expires = DateTime.Now.AddYears(1);
        Response.Cookies.Add(CultureCookie);
        Response.Redirect(Request.Url.ToString());
    }

    protected void btnChangeLang_OnClick(object sender, EventArgs e)
    {
        HttpCookie CultureCookie;
        if (Page.Culture.Contains("Arabic"))
        {
            CultureCookie = new HttpCookie("RCLang", "en-US");
        }
        else
        {
            CultureCookie = new HttpCookie("RCLang", "ar-JO");
        }
        CultureCookie.Expires = DateTime.Now.AddYears(1);
        Response.Cookies.Add(CultureCookie);
        Response.Redirect(Request.Url.ToString());
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}