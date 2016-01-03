using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ContactUsOp : System.Web.UI.Page
{
    string tablename = "ContactUs";
    string listpage = "ContactUsList.aspx";
    public string name = "البريد الوارد";
    Database db = new Database();
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null) Response.Redirect("ContactUsList.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            HyperLink2.NavigateUrl = listpage;
            LoadData();
            
        }
    }
    void LoadData()
    {
        db.AddParameter("@id", Request.QueryString["id"]);
        System.Data.DataSet ds = db.ExecuteDataSet("select contactUs.*,Country.name as countryname from " + tablename + " inner join country on (country.Id=contactUs.Country) where contactUs.id=@id" + ";update contactus set isread=1 where id=@id");
        lblName.Text = ds.Tables[0].Rows[0]["title"].ToString() + " " + ds.Tables[0].Rows[0]["name"].ToString() ;
        lblEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();
        lblPhone.Text = ds.Tables[0].Rows[0]["phone"].ToString();
        lblAddDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["addDate"].ToString()).ToString("dd/MM/yyyy");
        lblCountry.Text = ds.Tables[0].Rows[0]["countryname"].ToString();
        lblSubject.Text = ds.Tables[0].Rows[0]["subject"].ToString();
        lblTxt.Text = ds.Tables[0].Rows[0]["txt"].ToString();
        

    }
    

}