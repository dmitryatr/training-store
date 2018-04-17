using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Domain.Abstract;

namespace Site.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IVinylRepository repository;

        public NavController(IVinylRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string style = null)
        {
            ViewBag.SelectedStyle = style;
            IEnumerable<string> styles = repository.products
                .Select(vinyl => vinyl.Style)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(styles);
        }

        public PartialViewResult Menu2()
        {
            IEnumerable<string> styles = repository.products
                .Select(vinyl => vinyl.Style)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(styles);
        }
    }
}