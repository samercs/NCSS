using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ResaerchTypeList : System.Web.UI.Page
{
    string tablename = "ResearchType";
    private string editPage = "ResaerchTypeOp.aspx?Op=Edit&id={0}";
    private string addPage = "ResaerchTypeOp.aspx?Op=Add";
    public string name = "التصنيفات";

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
        System.Data.DataSet ds = db.ExecuteDataSet("select * from " + tablename);
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