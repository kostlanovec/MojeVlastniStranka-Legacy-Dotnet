using Microsoft.AspNetCore.Mvc;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.Web.Controllers.api
{
    public class SearchController : Controller
    {
        private readonly DataContext _context;

        public SearchController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var articles = _context.BlogPosts
                .Where(a => a.Title.Contains(query) || a.Content.Contains(query))
                .Select(a => new { a.Title, a.Content })
                .ToList();

            return Ok(articles);
        }
    }
}
