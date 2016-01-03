<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (DictionaryEntry CachedItem in Cache)
        {
            string CacheKey = CachedItem.Key.ToString();
            Cache.Remove(CacheKey);
            
        }
        Response.Redirect("~/Default.aspx");
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
