using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Reflection;
using System.Web;


public class UICaltureBase : System.Web.UI.Page
{
    protected override void InitializeCulture()
    {

        HttpCookie CultureCookie = Request.Cookies["RCLang"];
        
        CultureInfo ci ;
        if (CultureCookie == null)
        {
            ci = new CultureInfo("ar-JO");
        }
        else
        {
            ci = new CultureInfo(CultureCookie.Value);
        }
        Thread.CurrentThread.CurrentCulture = ci;
        Thread.CurrentThread.CurrentUICulture = ci;
        base.InitializeCulture();
        switch (Page.Culture)
        {
            case "Arabic (Jordan)":
                Page.Theme = "Ar";
                break;
            default:
                Page.Theme = "En";
                break;
        }
        

    }
}
