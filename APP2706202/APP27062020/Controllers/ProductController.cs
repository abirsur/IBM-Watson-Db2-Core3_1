using APP27062020.DAL.DataManagers;
using APP27062020.DAL.DTO;
using APP27062020.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APP24062020.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View("~/Views/Products/Index.cshtml", new ProductManager().GetInsuranceProductData());
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
                new ProductManager().CreateInsuranceProduct(productInsurance);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }


    }
}