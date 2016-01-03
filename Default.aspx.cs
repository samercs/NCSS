using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class _Default : UICaltureBase
{
    protected void Page_Load(object sender, EventArgs e)
    {



        if (!Page.IsPostBack)
        {
            Database db=new Database();
            Lang lan=new Lang();

            string showcaseSql = "select * from Showcase where lang=@lang order by showorder";
            string aboutHomeSql = "select * from Pages where PageKey=@homeAbout and lang=@lang";
            string partnerSql = "select * from Partners where lang=@lang Order By ShowOrder";
            string PublicationsSql = "select top(2) * from Publications where lang=@lang Order By id desc";
            string newsSql = "select top(2) * from News where lang=@lang Order By id desc";
            string publicResearchSql = "select top(5) * from Library where lang=@lang Order By Id Desc";
            
            db.AddParameter("@lang", lan.getCurrentLang());
            db.AddParameter("@homeAbout", "HomeAbout");

            DataSet ds = db.ExecuteDataSet(showcaseSql+";"+aboutHomeSql+";"+partnerSql+";"+PublicationsSql+ ";"+newsSql+";"+publicResearchSql);
            Repeater1.DataSource = ds.Tables[0];

            if (ds.Tables[0].Rows.Count < 1)
            {

                myCarousel.Visible = false;
            }
            else
            {
                myCarousel.Visible = true;
            }
            Repeater1.DataBind();



            Repeater2.DataSource = ds.Tables[1];
            Repeater2.DataBind();

            Repeater3.DataSource = ds.Tables[2];
            Repeater3.DataBind();

            Repeater4.DataSource = ds.Tables[3];
            Repeater4.DataBind();

            Repeater5.DataSource = ds.Tables[4];
            Repeater5.DataBind();

            Repeater6.DataSource = ds.Tables[5];
            Repeater6.DataBind();
            LoadPoll();


            

           
           



        }

        
    }








    private void LoadPoll()
    {
        string pollSql = "select top(1) Id,AddDate,Title from Poll where ShowInHome=1  Order By AddDate Desc, Id Desc";
        if(Page.Culture.Contains("Arabic"))
        {
            pollSql = "select top(1) Id,AddDate,TitleAr as title from Poll where ShowInHome=1  Order By AddDate Desc, Id Desc";
        }
        Database db = new Database();
        Lang lan = new Lang();
        
        DataTable dt = db.ExecuteDataTable(pollSql);
        Repeater7.DataSource = dt;
        Repeater7.DataBind();
    }

    protected void Repeater8_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rep=e.Item.FindControl("Repeater8") as Repeater;
            HiddenField id = e.Item.FindControl("id") as HiddenField;
            Database db=new Database();
            db.AddParameter("@PollId", id.Value);
            DataTable dt = db.ExecuteDataTable("PollResult",CommandType.StoredProcedure);
            rep.DataSource = dt;
            rep.DataBind();
        }
    }

    

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater Repeater1 = sender as Repeater;
        if (Repeater1 != null && Repeater1.Items.Count < 1)
        {
             if (e.Item.ItemType == ListItemType.Footer)
        {
            // Show the Error Label (if no data is present).
            Label Label2 = e.Item.FindControl("Label2") as Label;
            if (Label2 != null)
            {
                Label2.Visible = true;
            }
        }
    
        }
    }



    protected void Repeater8_OnItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
        Lang lang = new Lang();
        HiddenField pollId = e.Item.FindControl("pollid") as HiddenField;
        HiddenField optionId = e.Item.FindControl("optionid") as HiddenField;

        if (Request.Cookies["Poll" + pollId.Value] == null)
        {
            Database db = new Database();
            db.AddParameter("@id", optionId.Value);
            db.ExecuteNonQuery("update PollOption set count=count+1 where id=@id");
            HttpCookie c = new HttpCookie("Poll" + pollId.Value);
            c.Value = optionId.Value;
            c.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(c);
            LoadPoll();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert1", "alertify.alert('" + lang.getByKey("SiteTitle") + "','" + lang.getByKey("PollSubmitOk") + "');", true);
        }
        else
        {
            
            ClientScript.RegisterStartupScript(this.GetType(), "Alert2", "alertify.alert('" + lang.getByKey("SiteTitle") + "','" + lang.getByKey("PollSubmitError") + "');", true);
        }
    
       
    }
}