#nullable disable
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

		//todo zlepšit rss na jinou úroveň
		public class RssDocument
		{
			public XDocument CreateRssXML(IEnumerable<XElement> rssItems, string language)
			{
				XNamespace contentNamespace = "http://purl.org/rss/1.0/modules/content/";
				XElement channelElement = new XElement("channel",
					new XElement("title", language == "en-US" ? "Kostlanovec" : "Moje Vlastní Stránka"),
					new XElement("link", "https://kostlanovec.cz"),
					new XElement("description", language == "en-US" ? "Latest projects and blog posts." : "Nejnovější projekty a blogové příspěvky."),
					new XElement("language", language),
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
		public IActionResult GenerateRss([FromQuery] string lang)
		{
			bool isEn = string.Equals(lang, "en", StringComparison.OrdinalIgnoreCase);
			string culturePfx = isEn ? "/en" : "/cs";
			var rssItems = new List<XElement>();

			var projects = context.Projects.ToList();
			foreach (var project in projects)
			{
				if (isEn && string.IsNullOrEmpty(project.ContentEn))
				{
					continue;
				}

				var url = $"{Request.Scheme}://{Request.Host}{culturePfx}/projekty/{project.Slug}";
				var item = new RssDocument().CreateRssItem(
					title: isEn && !string.IsNullOrEmpty(project.TitleEn) ? project.TitleEn : project.Title,
					link: url,
					description: isEn && !string.IsNullOrEmpty(project.DescriptionEn) ? project.DescriptionEn : project.Description,
					pubDate: project.Date
				);

				rssItems.Add(item);
			}

			var blogPosts = context.BlogPosts.ToList();
			foreach (var post in blogPosts)
			{
				if (isEn && string.IsNullOrEmpty(post.ContentEn))
				{
					continue;
				}

				var url = $"{Request.Scheme}://{Request.Host}{culturePfx}/blog/{post.Slug}";
				var item = new RssDocument().CreateRssItem(
					title: isEn && !string.IsNullOrEmpty(post.TitleEn) ? post.TitleEn : post.Title,
					link: url,
					description: isEn && !string.IsNullOrEmpty(post.DescriptionEn) ? post.DescriptionEn : post.Description,
					pubDate: post.Date
				);

				rssItems.Add(item);
			}

			var rssDocument = new RssDocument();
			var xmlRss = rssDocument.CreateRssXML(rssItems, isEn ? "en-US" : "cs-CZ");

			return Content(xmlRss.ToString(), "application/xml");
		}
	}
}
