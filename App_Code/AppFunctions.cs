using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Text;


    public class AppFunctions
    {
        public bool IsEmailValid(string Emailadd)
        {
            Regex reg = new Regex("\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
            if (reg.IsMatch(Emailadd))
            {
                return true;
            }
            else
            {
                return false;
            }
            return true;
        }
        public bool IsPhoneValid(string Phone)
        {
            Regex reg = new Regex("\\d+");
            Regex reg2 = new Regex("\\d{5}\\-\\d+");
            if (reg.IsMatch(Phone) | reg2.IsMatch(Phone))
            {
                return true;
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool IsYearValid(string Year)
        {
            Regex reg = new Regex("\\d{4}");
            Regex reg2 = new Regex("\\d{5}\\-\\d+");
            if (reg.IsMatch(Year) | reg2.IsMatch(Year))
            {
                return true;
            }
            else
            {
                return false;
            }
            return true;
        }

        public System.DateTime StartingDate()
        {
            System.DateTime startDate = default(System.DateTime);
            int i = 0;

            i = Weekday(DateTime.Today, DayOfWeek.Saturday);
            i = 8 - i;
            startDate = DateTime.Today.AddDays(i);
            return startDate;

        }

        public System.DateTime StartingDate1(System.DateTime getDate)
        {
            System.DateTime startDate = default(System.DateTime);
            int i = 0;
            i = Weekday(getDate, DayOfWeek.Saturday);
            i = 8 - i;
            startDate = getDate.AddDays(i);
            return startDate;
        }

        public bool Isdatevalid(string d)
        {
            bool blnValid = false;
            try
            {
                DateTime.Parse(d);
                blnValid = true;
            }
            catch
            {
                blnValid = false;
            }
            return blnValid;
        }

        public string FixQuotes(string theString)
        {
            if (!string.IsNullOrEmpty(theString))
            {
                theString = theString.Replace("'", "''").Trim();
            }
            return theString;
        }



        public bool Check_english(string str)
        {
            Regex reg = new Regex("^[a-zA-z' ]{1,100}$");
            if (reg.IsMatch(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Check_arabic(string str)
        {
            Regex reg = new Regex("^[^a-zA-z]{1,100}$");
            if (reg.IsMatch(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SendMail(string @from, string recepient, string bcc, string cc, string subject, string body)
        {
            MailMessage mMailMessage = new MailMessage();
            mMailMessage.From = new MailAddress(@from);
            mMailMessage.To.Add(new MailAddress(recepient));
            if ((bcc != null) & bcc != string.Empty)
            {
                mMailMessage.Bcc.Add(new MailAddress(bcc));
            }
            if ((cc != null) & cc != string.Empty)
            {
                mMailMessage.CC.Add(new MailAddress(cc));
            }
            mMailMessage.Subject = subject;
            mMailMessage.Body = body;
            mMailMessage.IsBodyHtml = true;
            mMailMessage.Priority = MailPriority.Normal;
            SmtpClient mSmtpClient = new SmtpClient();
            mSmtpClient.UseDefaultCredentials = true;
            try
            {
                mSmtpClient.Send(mMailMessage);
            }
            catch
            {
            }
        }

        public void SendMail(string @from, string recepient, string bcc, string cc, string subject, string body, string AttachFile)
        {
            MailMessage mMailMessage = new MailMessage();
            mMailMessage.From = new MailAddress(@from);
            mMailMessage.To.Add(new MailAddress(recepient));
            if ((bcc != null) & bcc != string.Empty)
            {
                mMailMessage.Bcc.Add(new MailAddress(bcc));
            }
            if ((cc != null) & cc != string.Empty)
            {
                mMailMessage.CC.Add(new MailAddress(cc));
            }
            mMailMessage.Subject = subject;
            mMailMessage.Body = body;
            mMailMessage.IsBodyHtml = true;
            mMailMessage.Priority = MailPriority.Normal;
            SmtpClient mSmtpClient = new SmtpClient();
            mSmtpClient.UseDefaultCredentials = true;
            try
            {
                mSmtpClient.Send(mMailMessage);
            }
            catch
            {
            }
        }

        public void Write_cookie(string email, string secretword)
        {
            HttpCookie mycookie = new HttpCookie("nestlefamily");
            mycookie.Values.Add("emailadd1", email);
            mycookie.Values.Add("secretword", secretword);
            mycookie.Expires = DateTime.Now.AddYears(10);
        }

        public void Remove_cookie()
        {
            HttpCookie mycookie = new HttpCookie("nestlefamily");
            mycookie.Expires = DateTime.Now.AddSeconds(-1);
        }
        public static int Weekday(DateTime dt, DayOfWeek startOfWeek) { return (dt.DayOfWeek - startOfWeek + 7) % 7; }
    }
