using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Experts : UICaltureBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            txtEnName.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {__doPostBack('" + btnSearch.UniqueID + "','');}} ");
            txtEnMajor.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {__doPostBack('" + btnSearch.UniqueID + "','');}} ");
            txtEnWork.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {__doPostBack('" + btnSearch.UniqueID + "','');}} ");

            Database db=new Database();
            Lang lang=new Lang();
            ddlEnDegree.Items.Add(new ListItem(lang.getByKey("Degree"),"-1"));
            ddlEnDegree.Items.Add(new ListItem(lang.getByKey("BSc"), "BSc"));
            ddlEnDegree.Items.Add(new ListItem(lang.getByKey("Master"), "Master"));
            ddlEnDegree.Items.Add(new ListItem(lang.getByKey("PhD"), "PhD"));
            db.LoadDDL("Country",ref ddlEnCountry,lang.getByKey("Country"));
            
            SearchResearcher("","","","","");
            
        }
    }

    private void SearchResearcher(string name, string country, string major, string degree, string work)
    {
        Database db=new Database();
        string sqlSearch = "select * from Researcher where lang=@lang and IsAproved=1";
        if (!string.IsNullOrWhiteSpace(name))
        {
            sqlSearch += " and [name] like '%' + @name + '%'";
            db.AddParameter("@name", name);
        }
        if (!string.IsNullOrWhiteSpace(country) && !country.Equals("-1"))
        {
            sqlSearch += " and [country] =@country";
            db.AddParameter("@country", country);
        }
        if (!string.IsNullOrWhiteSpace(major))
        {
            sqlSearch += " and [major] like '%' + @major + '%'";
            db.AddParameter("@major", major);
        }
        if (!string.IsNullOrWhiteSpace(degree) && !degree.Equals("-1"))
        {
            string[] langDic=new Lang().getByKeyAll(degree);
            sqlSearch += " and ( [level]=@level1 Or [level]=@level2 ) ";
            db.AddParameter("@level1", langDic[0]);
            db.AddParameter("@level2", langDic[1]);
            Response.Write(langDic[0] + " " + langDic[1]);
            
        }
        if (!string.IsNullOrWhiteSpace(work))
        {
            sqlSearch += " and [organization] like '%' +@organization + '%'";
            db.AddParameter("@organization", work);
        }
        db.AddParameter("@lang", new Lang().getCurrentLang());
        DataTable dt = db.ExecuteDataTable(sqlSearch);
        ListView1.DataSource = dt;
        ListView1.DataBind();
        
    }

    protected void HyperLink1_OnClick(object sender, EventArgs e)
    {
        SearchResearcher(txtEnName.Text,ddlEnCountry.SelectedValue,txtEnMajor.Text,ddlEnDegree.SelectedValue,txtEnWork.Text);
    }

    
}