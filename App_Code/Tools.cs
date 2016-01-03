using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Tools
/// </summary>
public class Tools
{
	public Tools()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string GetYouTubeId(string url)
    {
        

        Regex YoutubeVideoRegex = new Regex(@"youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)");

        Match youtubeMatch = YoutubeVideoRegex.Match(url);


        string id = string.Empty;

        if (youtubeMatch.Success)
            id = youtubeMatch.Groups[1].Value;
        return id;

    } 

    public string ToDecimal(string old)
    {
        string result="";
        foreach (char v in old)
        {
            if (v.Equals(' '))
            {
                result += "00032";
            }
            else
            {
                result += ((int)v).ToString();
            }

        }
        return result;
    }


    public static bool IsImage(string contentType)
    {
        return AllowedFormats.Any(format => contentType.EndsWith(format,
                   StringComparison.OrdinalIgnoreCase));
    }

    public static List<string> AllowedFormats
    {
        get { return new List<string>() { ".jpg", ".png", ".jpeg",".gif",".bmp" }; }
    }

    public static bool IsDoc(string contentType)
    {
        return AllowedFormatsDoc.Any(format => contentType.EndsWith(format,
                   StringComparison.OrdinalIgnoreCase));
    }

    public static List<string> AllowedFormatsDoc
    {
        get { return new List<string>() { ".pdf", ".doc", ".docx" }; }
    }

}