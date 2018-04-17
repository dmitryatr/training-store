using System;
using System.Data.Entity;
using Site.Domain.Abstract;
using Site.Domain.Entities;
using System.Web.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Site.WebUI.Models;

namespace Site.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IVinylRepository repository;
        public AdminController(IVinylRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index(){
            return View(repository.products);
        }

        public ViewResult Edit(int vinylId)
        {
            Vinyl vinyl =
                repository.products.FirstOrDefault(p => p.VinylId == vinylId);
                return View(vinyl);
        }

        [HttpPost]
        public ActionResult Edit(Vinyl vinyl, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    vinyl.ImageMimeType = image.ContentType;
                    vinyl.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(vinyl.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(vinyl);
                TempData["message"] = string.Format("{0} has been saved", vinyl.Artist + " - " + vinyl.Title);
                return RedirectToAction("Index");
            }
            else
            {
                return View(vinyl);
            }
        }
        public ViewResult Create()
        {
            return View("Edit", new Vinyl());
        }

        [HttpPost]
        public ActionResult Delete(int vinylId)
        {
            Vinyl vinyl =
                repository.products.FirstOrDefault(p => p.VinylId == vinylId);
            if (vinyl != null)
            {
                repository.DeteteProduct(vinylId);
                TempData["message"] = string.Format("{0} was deleted", vinyl.Artist + " - " + vinyl.Title);
            }
            return RedirectToAction("Index", "Admin");
        }


        }
}
