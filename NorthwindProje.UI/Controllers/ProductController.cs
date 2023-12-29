using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwindProje.BL.Abstract;
using NorthwindProje.BL.Concrete;
using NorthwindProje.Entities;

namespace NorthwindProje.UI.Controllers
{
    public class ProductController : Controller
    {
        private IGeneralService<Product> _productService;
        private IGeneralService<Category> _catService;
        public ProductController()
        {
            _productService = new ProductManager();
            _catService = new CategoryManager();
        }
        // GET: ProductController
        public ActionResult Index()
        {
            return View(_productService.GetAllT());
        }
        public ActionResult ListOzel4()
        {
            return View(_productService.GetAllT().OrderByDescending(x=>x.ProductName));
        }
        public ActionResult ListOzel3()
        {
            return View(_productService.GetAllT().OrderByDescending(x => x.UnitsInStock));
        }
        public ActionResult ListOzel2()
        {
            return View(_productService.GetAllT().Where(x=>x.UnitPrice>10&&x.UnitPrice<100).OrderByDescending(x => x.UnitPrice));
        }
        public ActionResult ListOzel1()
        {
            return View(_productService.GetAllT().OrderByDescending(x => x.UnitPrice).ToList());
        }
        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        [HttpGet]
        public ActionResult Create()
        {
            var veri = _catService.GetAllT();
            ViewBag.CategoryId = new SelectList(veri,"CategoryId","CategoryName");
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product pr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productService.Create(pr);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                return View(pr);
            }

            return View();
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var kayitpro=_productService.GetById(id);
            ViewBag.CategoryId = new SelectList(_catService.GetAllT(), "CategoryId", "CategoryName", kayitpro.CategoryId);
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product pro)
        {
            try
            {
               _productService.Update(pro);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
