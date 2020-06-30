using APP27062020.DAL.DataManagers;
using APP27062020.DAL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace APP24062020.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View("~/Views/InsProduct/Index.cshtml", new ProductManager().GetInsuranceProductData());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View("~/Views/InsProduct/Create.cshtml");
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductInsurance productInsurance)
        {
            try
            {
                new ProductManager().CreateInsuranceProduct(productInsurance);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}