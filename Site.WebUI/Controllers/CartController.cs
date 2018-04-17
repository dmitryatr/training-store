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
    public class CartController : Controller
    {
        private IVinylRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController(IVinylRepository repo, IOrderProcessor processor)
        {
            repository = repo;
            orderProcessor = processor;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int vinylId, string returnUrl)
        {
            Vinyl vinyl = repository.products
                .FirstOrDefault(g => g.VinylId == vinylId);

            if (vinyl != null)
            {
                cart.AddItem(vinyl, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int vinylId, string returnUrl)
        {
            Vinyl vinyl = repository.products
                .FirstOrDefault(g => g.VinylId == vinylId);

            if (vinyl != null)
            {
                cart.RemoveLine(vinyl);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(new CartIndexViewModel
            {
                Cart = cart
            });
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
    }
}