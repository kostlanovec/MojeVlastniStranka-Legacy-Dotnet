using Microsoft.AspNetCore.Mvc;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.Web.Controllers
{
    public class GalerieController : Controller
    {
        public class GalerieViewModel
        {
            public IEnumerable<DataAccess.Entities.Image> Images { get; set; }
        }

        private readonly DataContext dataContext;

        public GalerieController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var images = this.dataContext.Images.ToList();
            var viewModel = new GalerieViewModel { Images = images };
            return View(viewModel);
        }
    }
}
