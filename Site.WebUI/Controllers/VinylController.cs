using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Domain.Abstract;
using Site.Domain.Entities;
using Site.WebUI.Models;

namespace Site.WebUI.Controllers
{
    public class VinylController : Controller
    {
        private IVinylRepository repository;
        public int pageSize = 4;
        public VinylController(IVinylRepository repo)
        {
            repository = repo;
        }
        public ActionResult List(string style, int page = 1, int pageSize = 6)
        {
            VinylListViewModel model = new VinylListViewModel
            {
                products = repository.products
                .Where(p => style == null || p.Style == style)
                .OrderBy(vinyl => vinyl.VinylId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = style == null ?
                    repository.products.Count() :
                    repository.products.Where(vinyl => vinyl.Style == style).Count()
                },
                CurrentStyle = style
            };
            return View(model);
        }

        public FileContentResult GetImage(int vinylId)
        {
            Vinyl vinyl = repository.products
                .FirstOrDefault(g => g.VinylId == vinylId);

            if (vinyl != null)
            {
                return File(vinyl.ImageData, vinyl.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}