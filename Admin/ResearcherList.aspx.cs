﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_ResearcherList : System.Web.UI.Page
{
    string tablename = "Researcher";
    private string editPage = "ResearcherOp.aspx?Op=Edit&id={0}";
    private string addPage = "ResearcherOp.aspx?Op=Add";
    public string name = "الباحثين";

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
        System.Data.DataSet ds = db.ExecuteDataSet("select Researcher.*,country.name as countryName from " + tablename + " inner join country on (Researcher.Country=Country.Id) order by Researcher.IsAproved desc, Researcher.Lang,Researcher.country" + ";" + "");
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

        if (!string.IsNullOrWhiteSpace(e.CommandName))
        {
            System.IO.File.Delete(Server.MapPath("~/images/Researchers/" + e.CommandName));
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
                file = (HiddenField)RepeaterLists.Items[x].FindControl("img");
                if (!string.IsNullOrWhiteSpace(file.Value))
                {
                    System.IO.File.Delete(Server.MapPath("~/Images/Researchers/" + file.Value));
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

    protected void RepeaterLists_OnItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if(e.Item.ItemType==ListViewItemType.DataItem)
        {
            HtmlTableCell cell = e.Item.FindControl("imgTd") as HtmlTableCell;
            HiddenField isAproved=e.Item.FindControl("isAproved") as HiddenField; 
            if(isAproved.Value.Equals("True"))
            {
                cell.Style.Add("background-color","green");
            }
            else
            {
                cell.Style.Add("background-color", "red");
            }
        }
    }
}