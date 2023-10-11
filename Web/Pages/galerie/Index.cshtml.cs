using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.Web.Pages.galerie
{
    public class IndexModel : PageModel
    {
        private readonly DataContext dataContext;

        public IndexModel(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IEnumerable<Image> Images { get; private set; }

        public void OnGet()
        {
            Images = dataContext.Images.ToList();
        }
    }
}