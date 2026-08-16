#nullable disable
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
			var baseUrl = "https://kostlanovec.cz";

			var staticPages = new[]
			{
				new { Path = "",                         Freq = SitemapFrequency.Monthly, Pri = 1.0  },
				new { Path = "/kontakt",                 Freq = SitemapFrequency.Monthly, Pri = 0.9  },
				new { Path = "/blog",                    Freq = SitemapFrequency.Daily,   Pri = 0.9  },
				new { Path = "/projekty",                Freq = SitemapFrequency.Weekly,  Pri = 0.9  },
				new { Path = "/namety-na-hry",           Freq = SitemapFrequency.Weekly,  Pri = 0.6  },
			};

			var nodes = new List<SitemapNode>();

			foreach (var page in staticPages)
			{
				nodes.Add(new SitemapNode { Url = baseUrl + (page.Path == "" ? "" : "/cs" + page.Path), Frequency = page.Freq, Priority = page.Pri });
				nodes.Add(new SitemapNode { Url = baseUrl + "/en" + (page.Path == "" ? "" : page.Path), Frequency = page.Freq, Priority = page.Pri });
			}

			var projects = context.Projects.ToList();
			foreach (var project in projects)
			{
				nodes.Add(new SitemapNode { Url = $"{baseUrl}/cs/projekty/{project.Slug}", LastModified = project.Date, Frequency = SitemapFrequency.Weekly, Priority = 0.7 });
				if (!string.IsNullOrEmpty(project.ContentEn))
					nodes.Add(new SitemapNode { Url = $"{baseUrl}/en/projekty/{project.Slug}", LastModified = project.Date, Frequency = SitemapFrequency.Weekly, Priority = 0.7 });
			}

			var blogPosts = context.BlogPosts.ToList();
			foreach (var post in blogPosts)
			{
				nodes.Add(new SitemapNode { Url = $"{baseUrl}/cs/blog/{post.Slug}", LastModified = post.Date, Frequency = SitemapFrequency.Always, Priority = 0.6 });
				if (!string.IsNullOrEmpty(post.ContentEn))
					nodes.Add(new SitemapNode { Url = $"{baseUrl}/en/blog/{post.Slug}", LastModified = post.Date, Frequency = SitemapFrequency.Always, Priority = 0.6 });
			}

			var sitemapDocument = new SitemapDocument();
			var xmlSitemap = sitemapDocument.CreateSitemapXML(nodes);

			return Content(xmlSitemap.ToString(), "application/xml");
		}
	}
}