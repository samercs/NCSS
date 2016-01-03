using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_Images : System.Web.UI.UserControl
{
    private string key;
    public string Key
    {
        get
        {
            return key;
        }
        set
        {
            key = value;
            LoadData();
        }
    }

    private string cssclass;
    public string cssClass
    {
        get
        {
            return this.cssclass;
        }
        set
        {
            cssclass = value;
            Image1.CssClass = cssclass;
        }
    }

    private int w, h;
    public int W
    {
        get
        {
            return this.w;
        }
        set
        {
            this.w = value;
            if(w==100)
            {
                this.Image1.Width = Unit.Percentage(100);
            }
            else
            {
                this.Image1.Width = Unit.Pixel(w);
            }
        }
    }
    public int H
    {
        get
        {
            return this.h;
        }
        set
        {
            this.h = value;
            if (h == 100)
            {
                this.Image1.Height = Unit.Percentage(100);
            }
            else
            {
                this.Image1.Height = Unit.Pixel(h);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    private void LoadData()
    {
        Database db = new Database();
        db.AddParameter("@imgkey", key);
        db.AddParameter("@lang", new Lang().getCurrentLang());
        System.Data.DataTable dt = db.ExecuteDataTable("select * from images where  lang=@lang and imgkey=@imgkey");
        if (dt.Rows.Count != 0)
        {
            Image1.ImageUrl = "~/images/images/" + dt.Rows[0]["src"].ToString();
            int w=-1;
            if (int.TryParse(dt.Rows[0]["width"].ToString(), out w))
            {
                if (w == 100)
                {
                    Image1.Width = Unit.Percentage(100);
                }
                else
                {
                    Image1.Width = Unit.Pixel(w);
                    
                }
            }

            int h = -1;
            if (int.TryParse(dt.Rows[0]["hieght"].ToString(), out h))
            {
                if (h == 100)
                {
                    Image1.Height = Unit.Percentage(100);
                }
                else
                {
                    Image1.Height = Unit.Pixel(h);

                }
            }


            Image1.AlternateText = dt.Rows[0]["alt"].ToString();
            Image1.ToolTip = dt.Rows[0]["alt"].ToString();
        }
        else
        {
            Image1.Visible = false;
        }
    }
}