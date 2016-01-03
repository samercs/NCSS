using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Summary description for SMSSender
/// </summary>
public class SMSSender
{
    public string Message { get; set; }
    public string  Subject { get; set; }
    public SMSSender()
    {
        
    }

    public string SendSms(string mobile)
    {
        using (var client = new WebClient())
        {
            try
            {
                string langCode = "1";
                if (Regex.IsMatch(Message, @"\p{IsArabic}+"))
                {
                    langCode = "2";
                }

                client.Headers.Add("content-type", "text/plain");
                string result = client.DownloadString(String.Format("http://brazilboxtech.com/api/send.aspx?username=smartksa&password=ksasmrt95647&language={0}&sender=NCSS&mobile={1}&message={2}",langCode, mobile, Message));
                if (result.StartsWith("OK"))
                {
                    return String.Empty;
                }
                return result;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            
        }
    }
    public string SendSms(List<string> mobiles)
    {
        using (var client = new WebClient())
        {
            try
            {
                string langCode = "1";
                if (Regex.IsMatch(Message, @"\p{IsArabic}+"))
                {
                    langCode = "2";
                }

                client.Headers.Add("content-type", "text/plain");
                string mobile=String.Join(",",mobiles.ToArray());
                string result = client.DownloadString(String.Format("http://brazilboxtech.com/api/send.aspx?username=smartksa&password=ksasmrt95647&language={0}&sender=NCSS&mobile={1}&message={2}",langCode, mobile, Message));
                if (result.StartsWith("OK"))
                {
                    return String.Empty;
                }
                return result;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
    }
}