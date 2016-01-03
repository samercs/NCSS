using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_UserDetail : System.Web.UI.Page
{
    string tablename = "ContactUs";
    string listpage = "Default.aspx";
    public string name = "بيانات المستخدم";
    Database db = new Database();
    
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
        
        AdminInfo adminInfo = Session["AdminInfo"] as AdminInfo;
        lblName.Text = adminInfo.Name;
        lblEmail.Text = adminInfo.Email;
        lblUserName.Text = adminInfo.Username ;
        lblPassword.Text = "#######";
        

    }


    protected void LinkButton1_OnClick(object sender, EventArgs e)
    {
        AdminInfo adminInfo = Session["AdminInfo"] as AdminInfo;
        Response.Redirect("AdminOp.aspx?Op=Edit&id=" + adminInfo.Id);
    }
}