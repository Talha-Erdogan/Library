using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Business.Enums;
using Library.Business.Interfaces;
using Library.Data.Entity;
using Library.UI.Filters;
using Library.UI.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Library.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AppAuthorizeFilter(AuthCodeStatic.PAGE_AUTH_LIST)]
        public IActionResult List()
        {
            List<Auth> model = new List<Auth>();
            model = _authService.GetAll();
            return View(model);
        }

        [AppAuthorizeFilter(AuthCodeStatic.PAGE_AUTH_ADD)]
        public ActionResult Add(string IsSuccess)
        {
            ViewBag.Issuccess = IsSuccess ?? "Empty";
            var model = new AddViewModel();
            return View(model);
        }

        [HttpPost]
        [AppAuthorizeFilter(AuthCodeStatic.PAGE_AUTH_ADD)]
        public ActionResult Add(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                Auth auth = new Auth();
                auth.Code = model.Code;
                auth.Name = model.Name;
                auth.IsDeleted = false;
                _authService.Add(auth);

                return RedirectToAction("Add", "Auth", new { IsSuccess = "True" });
            }
            catch
            {
                return RedirectToAction("Add", "Auth", new { IsSuccess = "False" });
            }
        }

        [AppAuthorizeFilter(AuthCodeStatic.PAGE_AUTH_EDIT)]
        public ActionResult Edit(int id, string IsSuccess)
        {
            ViewBag.Issuccess = IsSuccess ?? "Empty";
            var model = new AddViewModel();
            Auth auth = _authService.GetById(id);
            if (auth == null)
            {
                return View("_ErrorNotExist");
            }
            model.Id = auth.Id;
            model.Name = auth.Name;
            model.Code = auth.Code;
           
            return View(model);
        }

        [AppAuthorizeFilter(AuthCodeStatic.PAGE_AUTH_EDIT)]
        [HttpPost]
        public ActionResult Edit(AddViewModel model)
        {
            try
            {
                var auth = _authService.GetById(model.Id);
                if (auth == null)
                {
                    return View("_ErrorNotExist");
                }
                auth.Code = model.Code;
                auth.Name = model.Name;
                _authService.Update(auth);
               
                return RedirectToAction("Edit", "Auth", new { Id = model.Id, IsSuccess = "True" });
            }
            catch
            {
                return RedirectToAction("Edit", "Auth", new { Id = model.Id, IsSuccess = "False" });
            }
        }

        [AppAuthorizeFilter(AuthCodeStatic.PAGE_AUTH_DELETE)]
        [HttpPost]
        public JsonResult Delete(int[] data)
        {
            try
            {
                if (data == null) return Json("2");
                foreach (var authId in data)
                {
                    _authService.Delete(authId,1);//todo session dan sonra
                }
                return Json("1");
            }
            catch { return Json("0"); }
        }

    }
}
