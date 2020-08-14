using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Business.Interfaces;
using Library.Data.Entity;
using Library.UI.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace Library.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult List()
        {
            List<Category> model = new List<Category>();
            model = _categoryService.GetAll();
            return View(model);
        }

        public ActionResult Add(string IsSuccess)
        {
            ViewBag.Issuccess = IsSuccess ?? "Empty";
            var model = new AddViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                Category category = new Category();
                category.Name = model.Name;
                _categoryService.Add(category);
                return RedirectToAction("Add", "Category", new { IsSuccess = "True" });
            }
            catch
            {
                return RedirectToAction("Add", "Category", new { IsSuccess = "False" });
            }
        }

        public ActionResult Edit(int id, string IsSuccess)
        {
            ViewBag.Issuccess = IsSuccess ?? "Empty";
            var model = new AddViewModel();
            Category category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return View("_ErrorNotExist");
            }
            model.Id = category.Id;
            model.Name = category.Name;
           
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AddViewModel model)
        {
            try
            {
                var category = _categoryService.GetCategoryById(model.Id);
                if (category == null)
                {
                    return View("_ErrorNotExist");
                }
                category.Name = model.Name;
                _categoryService.Update(category);
                return RedirectToAction("Edit", "Category", new { Id = model.Id, IsSuccess = "True" });
            }
            catch
            {
                return RedirectToAction("Edit", "Category", new { Id = model.Id, IsSuccess = "False" });
            }
        }
    }
}
