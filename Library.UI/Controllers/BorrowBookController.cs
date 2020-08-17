using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Business.Common;
using Library.Business.Interfaces;
using Library.Business.Models.BorrowBook;
using Library.Data.Entity;
using Library.UI.Models.BorrowBook;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.UI.Controllers
{
    public class BorrowBookController : Controller
    {
        private readonly IBorrowBookService _borrowBookService;
        private readonly IBookService _bookService;
        private readonly IMemberService _memberService;
        public BorrowBookController(IBorrowBookService borrowBookService, IBookService bookService, IMemberService memberService)
        {
            _borrowBookService = borrowBookService;
            _bookService = bookService;
            _memberService = memberService;
        }

        //ödünç verilen kitaplar listesi
        public ActionResult List()
        {
            List<BorrowBookWithDetail> model = new List<BorrowBookWithDetail>();
            model = _borrowBookService.GetAllBorrowedBooks();
            return View(model);
        }

        //ödünç kitap ekleme
        public ActionResult Add(string IsSuccess)
        {
            ViewBag.Issuccess = IsSuccess ?? "Empty";
            AddViewModel model = new AddViewModel();
            model.BookList = (from c in _bookService.GetAll()
                              select new SelectListItem
                              {
                                  Text = c.Name,
                                  Value = c.Id.ToString()
                              }).ToList();
            model.MemberList = (from c in _memberService.GetAll()
                                select new SelectListItem
                                {
                                    Text = c.Name,
                                    Value = c.Id.ToString()
                                }).ToList();
            model.ExpirationDate = DateTime.Now.AddDays(30).ToShortDateString();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddViewModel model)
        {
            try
            {
                bool member_Penal = _memberService.GetById(model.MemberId).Panel;
                if (!member_Penal)
                {
                    BorrowBook record = new BorrowBook();
                    record.MemberId = model.MemberId;
                    record.BookId = model.BookId;
                    record.CreatedDateTime = DateTime.Now;
                    record.CreatedBy = SessionHelper.CurrentUser.ID;
                    record.ExpirationDateTime = DateTime.Now.AddDays(30);
                    record.IsBring = false;
                    _borrowBookService.Add(record);
                    return RedirectToAction("Add", "BorrowBook", new { IsSuccess = "True" });
                }
                else
                {
                    return RedirectToAction("Add", "BorrowBook", new { IsSuccess = "Penal" });
                }
            }
            catch { return RedirectToAction("Add", "BorrowBook", new { IsSuccess = "False" }); }
        }


        [HttpPost]
        public JsonResult Brought(string id)
        {
            try
            {
                int bookId = Convert.ToInt32(id);
                var borrowBook = _borrowBookService.GetBorrowBookById(bookId);

                if (DateTime.Now > borrowBook.ExpirationDateTime)
                {
                    var member = _memberService.GetById(borrowBook.MemberId);
                    member.Panel = true;
                    _memberService.Update(member);
                }

                borrowBook.IsBring = true;
                _borrowBookService.Update(borrowBook);
                return Json("1");
            }
            catch { return Json("0"); }
        }


        public ActionResult BroughtBookList()
        {
            List<BorrowBookWithDetail> model = new List<BorrowBookWithDetail>();
            model = _borrowBookService.GetAllBroughtBookList();
            return View(model);
        }

        [HttpPost]
        public JsonResult BroughtBookEdit(int[] data)
        {
            try
            {
                if (data == null) return Json("2");
                foreach (var broughtBookId in data)
                {
                    var broughtBook = _borrowBookService.GetBorrowBookById(broughtBookId);
                    broughtBook.IsBring = false;
                    _borrowBookService.Update(broughtBook);
                }
                return Json("1");
            }
            catch { return Json("0"); }
        }


    }
}
