using Microsoft.AspNetCore.Mvc;
using MojeVlastniStranka.DataAccess;
using SitemapNode = AspNetCore.SEOHelper.Sitemap.SitemapNode;
using System.Globalization;
using System.Xml.Linq;
using AspNetCore.SEOHelper.Sitemap;

namespace MojeVlastniStranka.Web.Controllers
{
    public class SitemapController : BaseController
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
                        new XElement(xnamespace + "loc", sitemapNode.Url),
                        sitemapNode.LastModified.HasValue ? new XElement(xnamespace + "lastmod", sitemapNode.LastModified.Value.ToString("yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture)) : null,
                        sitemapNode.Frequency.HasValue ? new XElement(xnamespace + "changefreq", sitemapNode.Frequency.Value.ToString().ToLowerInvariant()) : null,
                        sitemapNode.Priority.HasValue ? new XElement(xnamespace + "priority", sitemapNode.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)) : null
                    );
                    xelement.Add(content);
                }

                return new XDocument(xelement);
            }
        }

        [Route("sitemap.xml")]
        public IActionResult GenerateSitemap()
        {
            var nodes = new List<SitemapNode>
            {
                new()
                {
                    Url = "https://kostlanovec.cz",
                    Frequency = SitemapFrequency.Monthly,
                    Priority = 1
                },
                 new()
                {
                    Url = "https://kostlanovec.cz/kontakt",
                    Frequency = SitemapFrequency.Monthly,
                    Priority = 0.9
                },
                new()
                {
                    Url = "https://kostlanovec.cz/blog",
                    Frequency = SitemapFrequency.Daily,
                    Priority = 0.9
                },
                new()
                {
                    Url = "https://kostlanovec.cz/projekty",
                    Frequency = SitemapFrequency.Weekly,
                    Priority = 0.9
                },
                new()
                {
                    Url = "https://kostlanovec.cz/sluzby/webovestranky",
                    Frequency = SitemapFrequency.Monthly,
                    Priority = 0.8
                },
				  new()
				{
					Url = "https://kostlanovec.cz/sluzby/seo",
					Frequency = SitemapFrequency.Monthly,
					Priority = 0.8
				},

				new()
                {
                    Url = "https://kostlanovec.cz/sluzby/tvorbaher",
                    Frequency = SitemapFrequency.Monthly,
                    Priority = 0.8
                },
                new()
                {
                    Url = "https://kostlanovec.cz/sluzby/socialnisite",
                    Frequency = SitemapFrequency.Monthly,
                    Priority = 0.8
                }
            };

            var projects = context.Projects.ToList();
            foreach (var project in projects)
            {
                var url = $"{Request.Scheme}://{Request.Host}/projekty/{project.Slug}";

                var node = new SitemapNode
                {
                    Url = url,
                    LastModified = project.Date,
                    Frequency = SitemapFrequency.Weekly,
                    Priority = 0.7
                };

                nodes.Add(node);
            }

            var blogPosts = context.BlogPosts.ToList();
            foreach (var post in blogPosts)
            {
                var url = $"{Request.Scheme}://{Request.Host}/blog/{post.Slug}";

                var node = new SitemapNode
                {
                    Url = url,
                    LastModified = post.Date,
                    Frequency = SitemapFrequency.Always,
                    Priority = 0.6
                };

                nodes.Add(node);
            }

            var sitemapDocument = new SitemapDocument();
            var xmlSitemap = sitemapDocument.CreateSitemapXML(nodes);

            return Content(xmlSitemap.ToString(), "application/xml");
        }
    }
}