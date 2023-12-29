using Microsoft.AspNetCore.Mvc;
using NorthwindProje.BL.Abstract;
using NorthwindProje.BL.Concrete;
using NorthwindProje.Entities;

namespace NorthwindProje.UI.Controllers
{
    public class CategoryController : Controller
    {
        private IGeneralService<Category> _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryManager();
        }
        
        public IActionResult Index()
        {
            return View(_categoryService.GetAllT());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category Cat)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Create(Cat);
                return RedirectToAction("Index");
            }

            return View(Cat);
        }
       
        public IActionResult Edit(int id)
        {
            var kayit= _categoryService.GetById(id);
            return View(kayit);
        }
        [HttpPost]
        public IActionResult Edit(Category cat)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(cat);
                return RedirectToAction("Index");
            }
            return View(cat);
            
        }

        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
