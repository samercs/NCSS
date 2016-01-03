using System;
using System.Collections.Generic;

using System.Web;
using System.Threading;

/// <summary>
/// Summary description for Lang
/// </summary>
public class Lang
{
    private void loadDic()
    {
        Dictionary<string, Dictionary<string, string>> dic = new Dictionary<string, Dictionary<string, string>>();
        Database db = new Database();
        System.Data.DataTable languages = db.ExecuteDataTable("select * from languages");
        foreach (System.Data.DataRow r in languages.Rows)
        {
            db.AddParameter("@lang", r["id"].ToString());
            System.Data.DataTable labels = db.ExecuteDataTable("select * from labels where lang=@lang");
            Dictionary<string, string> tmp = new Dictionary<string, string>();
            foreach (System.Data.DataRow r2 in labels.Rows)
            {
                tmp.Add(r2["key"].ToString().ToLower(), r2["value"].ToString());
            }
            dic.Add(r["id"].ToString(), tmp);
        }
        System.Web.HttpContext.Current.Cache["dic"] = dic;

    }

    public Lang()
    {
        if (System.Web.HttpContext.Current.Cache["dic"] == null)
        {
            loadDic();
        }
    }


    public string getCurrentLang()
    {
        string result = "";
        Database db = new Database();
        //db.AddParameter("@Culter", System.Threading.Thread.CurrentThread.CurrentCulture.Name);
        result = db.GetProName("Languages", "id", "Culter", System.Threading.Thread.CurrentThread.CurrentCulture.Name);
        if (result.Length == 0)
        {
            result = "1";
        }



        return result;

    }

    public string getByKey(string key)
    {
        string result = "";
        Dictionary<string, Dictionary<string, string>> dic = System.Web.HttpContext.Current.Cache["dic"] as Dictionary<string, Dictionary<string, string>>;
        Dictionary<string, string> labels;
        if (dic.TryGetValue(getCurrentLang(), out labels))
        {
            if (!labels.TryGetValue(key.ToLower(), out result))
            {
                result = "";
            }
        }

        return result;
    }

    public string[] getByKeyAll(string key)
    {
        string[] result = new string[2];
        string tmp;
        Dictionary<string, Dictionary<string, string>> dic = System.Web.HttpContext.Current.Cache["dic"] as Dictionary<string, Dictionary<string, string>>;
        Dictionary<string, string> labels;
        if (dic.TryGetValue("1", out labels))
        {
            if (!labels.TryGetValue(key.ToLower(), out tmp))
            {
                result[0] = "-";
            }
            else
            {
                result[0] = tmp;
            }
        }
        else
        {
            result[0] = "-";
        }
        if (dic.TryGetValue("2", out labels))
        {
            if (!labels.TryGetValue(key.ToLower(), out tmp))
            {
                result[1] = "-";
            }
            else
            {
                result[1] = tmp;
            }
        }
        else
        {
            result[1] = "-";
        }

        return result;
    }

}