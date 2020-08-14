using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Business.Interfaces;
using Library.Business.Models.Book;
using Library.Data.Entity;
using Library.UI.Models.Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.UI.Controllers
{
    public class BookController : Controller
    {

        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;

        public BookController(IBookService bookService,ICategoryService categoryService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
        }

        public IActionResult List()
        {
            List<BookWithDetail> model = new List<BookWithDetail>();
            model = _bookService.GetAllWithDetail();
            return View(model);
        }

        public ActionResult Add(string IsSuccess)
        {
            ViewBag.Issuccess = IsSuccess ?? "Empty";
            var model = new AddViewModel();
            //select list
            model.CategoryList = GetCategorySelectList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddViewModel model)
        {
            //select list
            model.CategoryList = GetCategorySelectList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                Book book = new Book();
                book.CategoryId = model.CategoryId;
                book.Name = model.Name;
                book.AuthorName = model.AuthorName;
                book.AuthorSurname = model.AuthorSurname;
                book.CreatedDateTime = DateTime.Now;
                book.CreatedBy = 1;//todo : suanlık 1 ama sesiondan alınacak

                _bookService.Add(book);

                return RedirectToAction("Add", "Book", new { IsSuccess = "True" });
            }
            catch
            {
                return RedirectToAction("Add", "Book", new { IsSuccess = "False" });
            }
        }

        public ActionResult Edit(int id, string IsSuccess)
        {
            ViewBag.Issuccess = IsSuccess ?? "Empty";
            var model = new AddViewModel();
            Book book = _bookService.GetById(id);
            if (book == null)
            {
                return View("_ErrorNotExist");
            }
            model.Id = book.Id;
            model.CategoryId = book.CategoryId;
            model.Name = book.Name;
            model.AuthorName = book.AuthorName;
            model.AuthorSurname = book.AuthorSurname;
            //select list
            model.CategoryList = GetCategorySelectList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AddViewModel model)
        {
            //select list
            model.CategoryList = GetCategorySelectList();
            try
            {
                var book = _bookService.GetById(model.Id);
                if (book == null)
                {
                    return View("_ErrorNotExist");
                }
                book.CategoryId = model.CategoryId;
                book.Name = model.Name;
                book.AuthorName = model.AuthorName;
                book.AuthorSurname = model.AuthorSurname;
                _bookService.Update(book);

                return RedirectToAction("Edit", "Book", new { Id = model.Id, IsSuccess = "True" });
            }
            catch
            {
                return RedirectToAction("Edit", "Book", new { Id = model.Id, IsSuccess = "False" });
            }
        }

        [HttpPost]
        public JsonResult Delete(int[] data)
        {
            try
            {
                if (data == null) return Json("2");
                foreach (var bookId in data)
                {
                    _bookService.Delete(bookId, 1);//todo session dan sonra
                }
                return Json("1");
            }
            catch { return Json("0"); }
        }


        [NonAction]
        private List<SelectListItem> GetCategorySelectList()
        {
            // kategori kayıtları listelenir
            List<SelectListItem> resultList = new List<SelectListItem>();
            resultList = (from c in _categoryService.GetAll()
                          select new SelectListItem
                          {
                              Text = c.Name,
                              Value = c.Id.ToString()
                          }).ToList();
            
            return resultList;
        }

    }
}
