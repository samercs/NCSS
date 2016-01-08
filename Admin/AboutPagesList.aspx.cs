using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AboutPagesList : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadData();
        }
    }
    void LoadData()
    {
        Database db = new Database();
        System.Data.DataSet ds = db.ExecuteDataSet("select Pages.* from PageImages inner join Pages on (PageImages.PageId=Pages.Id and PageImages.ImageId is null) ");
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
    protected void btnEdit_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("AboutPagesOp.aspx?id=" + e.CommandArgument + "&Op=Edit");
    }

    protected void btnDelete_OnCommand(object sender, CommandEventArgs e)
    {
        Database db = new Database(); string sql = string.Empty;

        sql = "delete from pages where id =@id;delete from PageImages where PageId=@id";
        db.AddParameter("@id", e.CommandArgument.ToString());
        if (db.ExecuteNonQuery(sql) >= 1)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.success(\"تم الحذف بنجاح.\")</SCRIPT>", false);
        }
        LoadData();
    }
}