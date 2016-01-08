using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : UICaltureBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Database db=new Database();
            Lang lang=new Lang();

            string albumsSql = "select images.* from PageImages inner join images on (PageImages.imageId=images.id and PageImages.PageId=@id) where images.lang=@lang order by images.ImgKey";
            string aboutSql = "select  * from pages where id=@id and lang=@lang";
            db.AddParameter("@lang", lang.getCurrentLang());
            if (Request.QueryString["id"] != null)
            {
                db.AddParameter("@id", Request.QueryString["id"]);    
            }
            else
            {
                aboutSql = "select  * from pages where PageKey=@PageKey and lang=@lang";
                db.AddParameter("@PageKey", "HomeAbout");
            }
            
            DataSet ds = db.ExecuteDataSet(aboutSql+";"+albumsSql);
            Repeater1.DataSource = ds.Tables[0];
            Repeater1.DataBind();

            Repeater2.DataSource = ds.Tables[1];
            Repeater2.DataBind();

        }
    }
}