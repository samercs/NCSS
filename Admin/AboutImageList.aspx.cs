using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AboutImageList : System.Web.UI.Page
{
    
    
    public string name = "الصور";

    protected void Page_Load(object sender, EventArgs e)
    {
        int id;
        if(!int.TryParse(Request.QueryString["id"],out id))
        {
            Response.Redirect("AboutPagesList.aspx");
        }
        if (!Page.IsPostBack)
        {
            LoadData();
            HyperLink3.NavigateUrl = "AboutImageOp.aspx?Op=add&pid=" + Request.QueryString["id"];
        }
    }
    void LoadData()
    {
        Database db = new Database();
        db.AddParameter("@id", Request.QueryString["id"]);
        System.Data.DataSet ds = db.ExecuteDataSet("select images.* from PageImages inner join images on(PageImages.imageId=images.Id and not PageImages.imageId is null) where PageImages.PageId=@id");
        RepeaterLists.DataSource = ds.Tables[0];
        RepeaterLists.DataBind();
        Cache["dt1"] = ds.Tables[0];
        
    }
    protected void CheckBox10_CheckedChanged(object sender, EventArgs e)
    {
        //CheckBox cbAll = RepeaterLists.Controls[0].Controls[0].FindControl("CheckBox10") as CheckBox;
        foreach (ListViewItem r in RepeaterLists.Items)
        {
            CheckBox cb = r.FindControl("CheckBox1") as CheckBox;
            if (CheckBox10.Checked)
            {
                cb.Checked = true;
            }
            else
            {
                cb.Checked = false;
            }
        }
    }
    protected void ListView1_PagePropertiesChanged(object sender, EventArgs e)
    {
        if (Cache["dt1"] != null)
        {
            RepeaterLists.DataSource = (System.Data.DataTable)Cache["dt1"];
            RepeaterLists.DataBind();
        }
        else
        {
            LoadData();
        }
        CheckBox10.Checked = false;
    }
    protected void btnDelete_Command(object sender, CommandEventArgs e)
    {
        Database db = new Database(); string sql = string.Empty;

        sql = "delete from images where id =@id;delete from pageImages where imageId=@id";
        db.AddParameter("@id", e.CommandArgument.ToString());

        if (db.ExecuteNonQuery(sql) >= 1)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.success(\"تم الحذف بنجاح.\")</SCRIPT>", false);
        }
        LoadData();
    }
    protected void btnEdit_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("AboutImageOp.aspx?Op=edit&id="+e.CommandArgument.ToString()+"&pid=" + Request.QueryString["id"]);
    }
    

}