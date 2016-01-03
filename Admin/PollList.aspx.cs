using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_PollList : System.Web.UI.Page
{
    string tablename = "Poll";
    private string editPage = "PollOp.aspx?Op=Edit&id={0}";
    private string addPage = "PollOp.aspx?Op=Add";
    public string name = "استطلاعات الرأي";

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
        System.Data.DataSet ds = db.ExecuteDataSet("select * from " + tablename + " Order By AddDate desc");
        RepeaterLists.DataSource = ds.Tables[0];
        RepeaterLists.DataBind();
        Cache["dt1"] = ds.Tables[0];
    }
    protected void CheckBox10_CheckedChanged(object sender, EventArgs e)
    {
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

        string sql2 = "delete from PollOption where PollId =" + e.CommandArgument;
        sql = "delete from " + tablename + " where id =" + e.CommandArgument;
        db.ExecuteNonQuery(sql2);
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
                arrlist.Add(id.Value);
            }
            x++;
        }

        string sql = string.Empty;

        string sql2 = "delete from PollOption where PollId in (";
        sql = "delete from " + tablename + " where id in (";

        if (arrlist.Count > 0)
        {
            for (int i = 0; i < arrlist.Count; i++)
            {
                if (i == 0)
                {
                    sql += arrlist[i].ToString();
                    sql2 += arrlist[i].ToString();
                }
                else
                {
                    sql += "," + arrlist[i].ToString();
                    sql2 += "," + arrlist[i].ToString();
                }

            }

            sql += ")";
            sql2 += ")";
            db.ExecuteNonQuery(sql2);
            if (db.ExecuteNonQuery(sql) >= 1)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.success(\"تم الحذف بنجاح\")</SCRIPT>", false);
            }
            LoadData();
            CheckBox10.Checked = false;
        }
    }

    protected void RepeaterLists_OnItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if(e.Item.ItemType==ListViewItemType.DataItem)
        {
            Repeater rep=e.Item.FindControl("Repeater1") as Repeater;
            HiddenField id=e.Item.FindControl("id") as HiddenField;
            Database db=new Database();
            db.AddParameter("@PollId", id.Value);
            DataTable dt = db.ExecuteDataTable("PollResult",CommandType.StoredProcedure);
            rep.DataSource = dt;
            rep.DataBind();
        }
    }
}