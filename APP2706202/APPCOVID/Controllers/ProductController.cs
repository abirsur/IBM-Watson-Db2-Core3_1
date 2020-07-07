using APPCOVID.BAL.Helpers;
using APPCOVID.Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace APPCOVID.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            IList<ProductViewModel> prodList = new ProductHelper().GetAll();
            return View("~/Views/Products/Index.cshtml", prodList);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View("~/Views/Products/Create.cshtml");
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductViewModel productInsurance)
        {
            try
            {
                new ProductHelper().CreateProduct(productInsurance);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }


    }
}