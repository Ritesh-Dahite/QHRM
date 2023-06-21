using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QHRM.Infrastructure.IRepository;
using QHRM.Models;

namespace QHRM.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _services;

        public ProductController(IProduct services)
        {
            _services = services;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            ProductInfoModel model = new ProductInfoModel();
            model.ProductsList = _services.GetProductsData();
            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            ProductInfo model = new ProductInfo();
            model = _services.GetProductById(id);
            return View(model);
        }

        // GET: ProductController/AddEditProduct
        [HttpGet]
        public ActionResult AddEditProduct(int id)
        {
            ProductInfo model = new ProductInfo();
            model = _services.GetProductById(id);
            if (model == null)
            {
                return View();
            }
            else
            {
                return View(model);
            }
        }

        // POST: ProductController/Create
        [HttpPost]
        public ActionResult Create(ProductInfo infoModel)
        {
            ProductInfo model = new ProductInfo();
            try
            {
                model = _services.AddProduct(infoModel);

                if(model.TotalRowCount > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return View();
            }
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        public ActionResult Delete(ProductInfo infoModel)
        {
            ProductInfo model = new ProductInfo();
            try
            {
                model = _services.DeleteProduct(infoModel);

                if (model.TotalRowCount > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
