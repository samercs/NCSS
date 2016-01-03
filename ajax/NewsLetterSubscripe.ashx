<%@ WebHandler Language="C#" Class="NewsLetterSubscripe" %>

using System;
using System.Web;

public class NewsLetterSubscripe : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
        if (context.Request.QueryString["email"] != null && context.Request.QueryString["name"] != null)
        {
            Database db=new Database();
            db.AddParameter("@name", context.Request.QueryString["name"]);
            db.AddParameter("@email", context.Request.QueryString["email"]);
            db.ExecuteNonQuery("insert into NewsLetter(name,email) values(@name,@email)");
        }

    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}