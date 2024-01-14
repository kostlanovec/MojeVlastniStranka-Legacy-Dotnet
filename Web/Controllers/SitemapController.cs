using Microsoft.AspNetCore.Mvc;
using MojeVlastniStranka.DataAccess;
using SitemapNode = AspNetCore.SEOHelper.Sitemap.SitemapNode;
using System.Globalization;
using System.Xml.Linq;
using AspNetCore.SEOHelper.Sitemap;

namespace MojeVlastniStranka.Web.Controllers
{
    public class SitemapController : Controller
    {
        private readonly DataContext context;

        public SitemapController(DataContext context)
        {
            this.context = context;
        }

        public class SitemapDocument
        {
            public XDocument CreateSitemapXML(IEnumerable<SitemapNode> sitemapNodes)
            {
                XNamespace xnamespace = "http://www.sitemaps.org/schemas/sitemap/0.9";
                XElement xelement = new XElement(xnamespace + "urlset");

                foreach (SitemapNode sitemapNode in sitemapNodes)
                {
                    XElement content = new XElement(xnamespace + "url",
                        new XElement(xnamespace + "loc", Uri.EscapeUriString(sitemapNode.Url)),
                        !sitemapNode.LastModified.HasValue ? null : new XElement(xnamespace + "lastmod", sitemapNode.LastModified.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                        !sitemapNode.Frequency.HasValue ? null : new XElement(xnamespace + "changefreq", sitemapNode.Frequency.Value.ToString().ToLowerInvariant()),
                        !sitemapNode.Priority.HasValue ? null : new XElement(xnamespace + "priority", sitemapNode.Priority.Value.ToString("F1", CultureInfo.InvariantCulture))
                    );
                    xelement.Add(content);
                }

                return new XDocument(xelement);
            }
        }

        [Route("sitemap.xml")]
        public IActionResult GenerateSitemap()
        {
            var nodes = new List<SitemapNode>();

            var blogPosts = context.BlogPosts.ToList();
            foreach (var post in blogPosts)
            {
                var url = $"{Request.Scheme}://{Request.Host}/blog/detail/{post.Slug}";

                var node = new SitemapNode
                {
                    Url = url,
                    LastModified = post.Date,
                    Frequency = SitemapFrequency.Always
                };

                nodes.Add(node);
            }

            var sitemapDocument = new SitemapDocument();
            var xmlSitemap = sitemapDocument.CreateSitemapXML(nodes);

            return Content(xmlSitemap.ToString(), "application/xml");
        }
    }
}