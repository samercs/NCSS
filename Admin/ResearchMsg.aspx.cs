using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ResearchMsg : System.Web.UI.Page
{
    string tablename = "Event";
    public string name = "مراسلة الباحثين";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string json="";
            Database db=new Database();
            DataTable dt = db.ExecuteDataTable("select * from Researcher where isAproved=1");
            json = "[";
            for (int i=0;i<dt.Rows.Count; i++)
            {
                if(i==0)
                {
                    json += "{ id: "+ dt.Rows[i]["id"].ToString() + ", name: \""+ dt.Rows[i]["name"].ToString() + "\" }";
                }
                else
                {
                    json += ",{ id: " + dt.Rows[i]["id"].ToString() + ", name: \"" + dt.Rows[i]["name"].ToString() + "\" }";
                }
                
            }
            json += "]";
            ViewState["json"] = json;
        }
    }


    protected void btnSave_OnClick(object sender, EventArgs e)
    {
        string researchid = txtResearchList.Text;
        if(string.IsNullOrWhiteSpace(researchid) && !CheckBox1.Checked)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء اختيار باحث على الاقل\")</SCRIPT>", false);
            return;
        }
        if (string.IsNullOrWhiteSpace(txtSubject.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء ادخال عنوان الرسالة\")</SCRIPT>", false);
            return;
        }
        if (string.IsNullOrWhiteSpace(txtTxt.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.error(\"الرجاء ادخال  الرسالة\")</SCRIPT>", false);
            return;
        }
        Database db=new Database();
        DataTable dt;

        if(!CheckBox1.Checked)
        {
            dt = db.ExecuteDataTable("select * from Researcher where isAproved=1 and (id in (" + researchid + "))");
        }
        else
        {
            dt = db.ExecuteDataTable("select * from Researcher where isAproved=1");
        }
        List<string> to=new List<string>();
        AppFunctions validate=new AppFunctions();
        foreach (DataRow row in dt.Rows)
        {
            if(RadioButtonList1.SelectedValue.Equals("1"))
            {
                if (validate.IsEmailValid(row["email"].ToString()))
                {
                    to.Add(row["email"].ToString());
                }
            }
            else
            {
                if (validate.IsPhoneValid(row["phone"].ToString()))
                {
                    to.Add(row["phone"].ToString());
                }
            }
        }

        if (RadioButtonList1.SelectedValue.Equals("1"))
        {
            SendMail mail = new SendMail();
            mail.SendMsg(to, txtSubject.Text, txtTxt.Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.success(\"تم ارسال رسالة بريد الالكتروني الى الباحثين و عددهم " + dt.Rows.Count+"\")</SCRIPT>", false);
        }
        else
        {
            Tools t = new Tools();
            SMSSender sms = new SMSSender();
            sms.Message = txtTxt.Text;
            sms.SendSms(to);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "WriteMsg", "<SCRIPT LANGUAGE=\"JavaScript\">alertify.success(\"تم ارسال رسالة نصية الى الباحثين و عددهم " + dt.Rows.Count + "\")</SCRIPT>", false);
        }
       
        
    }

    protected void CheckBox1_OnCheckedChanged(object sender, EventArgs e)
    {
        rowData.Visible = !CheckBox1.Checked;
        
    }
}