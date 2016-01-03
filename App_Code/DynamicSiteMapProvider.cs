using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Collections.Specialized;
using System.Data;


namespace Kalboard360.ClassCode
{
    public class DynamicSiteMapProvider : StaticSiteMapProvider
    {
        private String _siteMapFileName;
        private SiteMapNode _rootNode = null;

        public override SiteMapNode RootNode
        {
            get { return BuildSiteMap(); }
        }

        public override void Initialize(string name, NameValueCollection attributes)
        {
            base.Initialize(name, attributes);
            _siteMapFileName = attributes["siteMapFile"];
        }

        protected override SiteMapNode GetRootNodeCore()
        {
            return RootNode;
        }

        protected override void Clear()
        {
            lock (this)
            {
                _rootNode = null;
                base.Clear();
            }
        }

        private const String SiteMapNodeName = "siteMapNode";

        public override SiteMapNode BuildSiteMap()
        {
            lock (this)
            {
                if (null == _rootNode)
                {
                    Clear();
                    // Load the sitemap's xml from the file.
                    XmlDocument siteMapXml = LoadSiteMapXml();
                    // Create the first site map item from the top node in the xml.
                    XmlElement rootElement =
                        (XmlElement)siteMapXml.GetElementsByTagName(
                        SiteMapNodeName)[0];
                    // This is the key method - add the dynamic nodes to the xml
                    AddDynamicNodes(rootElement);
                    // Now build up the site map structure from the xml
                    GenerateSiteMapNodes(rootElement);
                }
            }
            return _rootNode;
        }


        private XmlDocument LoadSiteMapXml()
        {
            XmlDocument siteMapXml = new XmlDocument();
            siteMapXml.Load(AppDomain.CurrentDomain.BaseDirectory + _siteMapFileName);
            return siteMapXml;
        }

        private void AddDynamicNodes(XmlElement rootElement)
        {
            Database db = new Database();
            Lang lang = new Lang();
            /*XmlElement home = AddDynamicChildElement(rootElement, "~/Default.aspx", lang.getByKey(""), "");
            XmlElement Product = AddDynamicChildElement(rootElement, "~/Products.aspx", lang.getByKey(2), "");
            XmlElement News = AddDynamicChildElement(rootElement, "~/News.aspx", lang.getByKey(6), "");
            XmlElement AboutUs = AddDynamicChildElement(rootElement, "~/AboutUs.aspx", lang.getByKey(4), "");
            XmlElement ContactUs = AddDynamicChildElement(rootElement, "~/ContactUs.aspx", lang.getByKey(5), "");
            

            db.AddParameter("@lang",lang.getCurrentLang());
            System.Data.DataTable dt = db.ExecuteDataTable("Select * from Category where lang=@lang Order By Name");
            foreach (DataRow r in dt.Rows)
            {
                XmlElement tmp = AddDynamicChildElement(Product, "~/Products.aspx?catid="+r["id"].ToString(), r["name"].ToString(), "");
                db.AddParameter("@catid", r["id"].ToString());
                db.AddParameter("@lang", lang.getCurrentLang());
                System.Data.DataTable dt2 = db.ExecuteDataTable("Select * from Products where catId=@catId and lang=@lang Order By title");
                foreach (DataRow r2 in dt2.Rows)
                {
                    AddDynamicChildElement(tmp, "~/ProductDetail.aspx?id=" + r2["id"].ToString(), r2["title"].ToString(), "");
                }
                
            }

            db.AddParameter("@lang",lang.getCurrentLang());
            dt = db.ExecuteDataTable("Select * from News where lang=@lang Order By Id Desc");
            foreach (DataRow r in dt.Rows)
            {
                AddDynamicChildElement(News, "~/NewsDetail.aspx?id=" + r["id"].ToString(), r["title"].ToString(), "");
            }
            */





            db.Dispose1();

        }

        private static XmlElement AddDynamicChildElement(XmlElement parentElement, String url, String title, String description)
        {
            // Create new element from the parameters
            XmlElement childElement = parentElement.OwnerDocument.CreateElement(SiteMapNodeName);
            childElement.SetAttribute("url", url);
            childElement.SetAttribute("title", title);
            childElement.SetAttribute("description", description);

            // Add it to the parent
            parentElement.AppendChild(childElement);
            return childElement;
        }


        private void GenerateSiteMapNodes(XmlElement rootElement)
        {
            _rootNode = GetSiteMapNodeFromElement(rootElement);
            AddNode(_rootNode);
            CreateChildNodes(rootElement, _rootNode);
        }

        private void CreateChildNodes(XmlElement parentElement, SiteMapNode parentNode)
        {
            foreach (XmlNode xmlElement in parentElement.ChildNodes)
            {
                if (xmlElement.Name == SiteMapNodeName)
                {
                    SiteMapNode childNode = GetSiteMapNodeFromElement((XmlElement)xmlElement);
                    AddNode(childNode, parentNode);
                    CreateChildNodes((XmlElement)xmlElement, childNode);
                }
            }
        }

        private SiteMapNode GetSiteMapNodeFromElement(XmlElement rootElement)
        {
            SiteMapNode newSiteMapNode;
            String url = rootElement.GetAttribute("url");
            String title = rootElement.GetAttribute("title");
            String description = rootElement.GetAttribute("description");

            // The key needs to be unique, so hash the url and title.
            newSiteMapNode = new SiteMapNode(this,
                (url + title).GetHashCode().ToString(), url, title, description);

            return newSiteMapNode;
        }




    }
}