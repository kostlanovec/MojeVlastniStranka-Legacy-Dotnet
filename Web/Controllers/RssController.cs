using Microsoft.AspNetCore.Mvc;
using MojeVlastniStranka.DataAccess;
using System.Globalization;
using System.Xml.Linq;

namespace MojeVlastniStranka.Web.Controllers
{
	public class RssController : BaseController
	{
		private readonly DataContext context;

		public RssController(DataContext context)
		{
			this.context = context;
		}

		//zlepšit rss na jinou úroveň
		public class RssDocument
		{
			public XDocument CreateRssXML(IEnumerable<XElement> rssItems)
			{
				XNamespace contentNamespace = "http://purl.org/rss/1.0/modules/content/";
				XElement channelElement = new XElement("channel",
					new XElement("title", "Moje Vlastní Stránka"),
					new XElement("link", "https://kostlanovec.cz"),
					new XElement("description", "Nejnovější projekty a blogové příspěvky."),
					new XElement("language", "cs-CZ"),
					rssItems
				);

				XElement rssElement = new XElement("rss", new XAttribute("version", "2.0"), channelElement);

				return new XDocument(rssElement);
			}

			public XElement CreateRssItem(string title, string link, string description, DateTime? pubDate)
			{
				XElement itemElement = new XElement("item",
					new XElement("title", title),
					new XElement("link", link),
					new XElement("description", description),
					pubDate.HasValue ? new XElement("pubDate", pubDate.Value.ToString("R", CultureInfo.InvariantCulture)) : null
				);

				return itemElement;
			}
		}

		[Route("rss.xml")]
		public IActionResult GenerateRss()
		{
			var rssItems = new List<XElement>();

			var projects = context.Projects.ToList();
			foreach (var project in projects)
			{
				var url = $"{Request.Scheme}://{Request.Host}/projekty/{project.Slug}";
				var item = new RssDocument().CreateRssItem(
					title: project.Title,
					link: url,
					description: project.Description,
					pubDate: project.Date
				);

				rssItems.Add(item);
			}

			var blogPosts = context.BlogPosts.ToList();
			foreach (var post in blogPosts)
			{
				var url = $"{Request.Scheme}://{Request.Host}/blog/{post.Slug}";
				var item = new RssDocument().CreateRssItem(
					title: post.Title,
					link: url,
					description: post.Description,
					pubDate: post.Date
				);

				rssItems.Add(item);
			}

			var rssDocument = new RssDocument();
			var xmlRss = rssDocument.CreateRssXML(rssItems);

			return Content(xmlRss.ToString(), "application/xml");
		}
	}
}
