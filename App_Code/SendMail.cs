using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Text;
public class SendMail
{
    public SendMail()
    {
        
    }
    
    public void SendMsg( string to1, string subject, string body)
    {
        

            System.Net.Mail.MailMessage eMail = new System.Net.Mail.MailMessage();
            eMail.IsBodyHtml = true;
            eMail.Body = body;
            eMail.From = new System.Net.Mail.MailAddress("noreplay@ncss.gov.sa", "المركز الوطني للدراسات و البحوث الاجتماعية");
            eMail.To.Add(to1);
            eMail.Subject = subject;
            eMail.Priority = MailPriority.High;
            System.Net.Mail.SmtpClient SMTP = new System.Net.Mail.SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
            NetworkCredential Xcred = new NetworkCredential("samercs", "samer2006");
            SMTP.Credentials = Xcred;
            SMTP.Send(eMail);
        
      
            
    }

    public void SendMsg(List<string> to , string subject, string body)
    {


        System.Net.Mail.MailMessage eMail = new System.Net.Mail.MailMessage();
        eMail.IsBodyHtml = true;
        eMail.Body = body;
        eMail.From = new System.Net.Mail.MailAddress("noreplay@ncss.gov.sa", "المركز الوطني للدراسات و البحوث الاجتماعية");
        eMail.To.Add(new MailAddress("noreplay@ncss.gov.sa"));
        foreach (string str in to)
        {
            eMail.Bcc.Add(new MailAddress(str));
        }
        eMail.Subject = subject;
        eMail.Priority = MailPriority.High;
        System.Net.Mail.SmtpClient SMTP = new System.Net.Mail.SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
        NetworkCredential Xcred = new NetworkCredential("samercs", "samer2006");
        SMTP.Credentials = Xcred;
        SMTP.Send(eMail);



    }

    public void SendMailList(string to1, string subject, string body, string filename)
    {
        try
        {

            System.Net.Mail.MailMessage eMail = new System.Net.Mail.MailMessage();
            eMail.IsBodyHtml = true;
            eMail.Body = body;
            eMail.From = new System.Net.Mail.MailAddress("noreply@ikbjo.com", "مسابقة اصغر رجل اعمال-القائمة البريدية");
            eMail.To.Add(to1);
            eMail.Subject = subject;
            eMail.Priority = MailPriority.High;
            Attachment attach = new Attachment(filename);
            eMail.Attachments.Add(attach);

            System.Net.Mail.SmtpClient SMTP = new System.Net.Mail.SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
            NetworkCredential Xcred = new NetworkCredential("samercs", "samer2006");
            SMTP.Credentials = Xcred;
            SMTP.Send(eMail);


        }
        catch (System.Exception e)
        {
            /*Database db = new Database();
            db.AddParameter("@msgfrom", "noreply@ikbjo.com");
            db.AddParameter("@msgto", to1);
            db.AddParameter("@subject", subject);
            db.AddParameter("@body", body);
            db.AddParameter("@ErrorMsg", e.Message);
            db.ExecuteNonQuery("Insert Into mailError(msgfrom,msgto,subject,body,ErrorMsg) values(@msgfrom,@msgto,@subject,@body,@ErrorMsg)");
             */ 
        }


    }


    
    
    
   
    
}
