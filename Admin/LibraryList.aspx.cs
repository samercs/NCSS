using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ExpertiseList : System.Web.UI.Page
{
    string tablename = "Library";
    private string editPage = "LibraryOp.aspx?Op=Edit&id={0}";
    private string addPage = "LibraryOp.aspx?Op=Add";
    public string name = "المكتبة";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            HyperLink3.NavigateUrl = addPage;
            LoadData();
        }
    }
    void LoadData()
    {
        Database db = new Database();
        System.Data.DataSet ds = db.ExecuteDataSet("select Library.*,ResearchType.Title as TypeName from " + tablename + " inner join ResearchType on (Library.Type=ResearchType.Id) order by Library.Lang,Library.Type" + ";" + "");
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
        if (!string.IsNullOrWhiteSpace(e.CommandName))
        {
            System.IO.File.Delete(Server.MapPath("~/images/Library/"+ e.CommandName));
        }

        Database db = new Database(); string sql = string.Empty;

        sql = "delete from " + tablename + " where id =" + e.CommandArgument;

        if (db.ExecuteNonQuery(sql) >= 1)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.success(\"تم الحذف بنجاح.\")</SCRIPT>", false);
        }
        LoadData();
    }
    protected void btnEdit_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect(String.Format(editPage,e.CommandArgument.ToString()));
    }
    protected void btnContactDelete_Click(object sender, EventArgs e)
    {
        Database db = new Database();
        HiddenField id, file;
        ArrayList arrlist = new ArrayList();

        int x = 0;

        foreach (ListViewItem rptItem in RepeaterLists.Items)
        {

            CheckBox chk = (CheckBox)rptItem.FindControl("CheckBox1");
            if (chk.Checked)
            {
                id = (HiddenField)RepeaterLists.Items[x].FindControl("id");
                file = (HiddenField)RepeaterLists.Items[x].FindControl("file");
                if (!string.IsNullOrWhiteSpace(file.Value))
                {
                    System.IO.File.Delete(Server.MapPath("~/Images/Library/" + file.Value));
                }
                arrlist.Add(id.Value);

            }
            x++;
        }

        string sql = string.Empty;

        sql = "delete from " + tablename + " where id in (";

        if (arrlist.Count > 0)
        {
            for (int i = 0; i < arrlist.Count; i++)
            {
                if (i == 0)
                {
                    sql += arrlist[i].ToString();
                }
                else
                {
                    sql += "," + arrlist[i].ToString();
                }

            }

            sql += ")";
            if (db.ExecuteNonQuery(sql) >= 1)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.success(\"تم الحذف بنجاح\")</SCRIPT>", false);
            }
            LoadData();
            CheckBox10.Checked = false;
        }
    }

}