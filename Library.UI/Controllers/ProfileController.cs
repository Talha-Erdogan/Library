using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Business.Interfaces;
using Library.Data.Entity;
using Library.UI.Models.Profile;
using Microsoft.AspNetCore.Mvc;

namespace Library.UI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        public IActionResult List()
        {
            List<Profile> model = new List<Profile>();
            model = _profileService.GetAll();
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
                Profile profile = new Profile();
                profile.Code = model.Code;
                profile.Name = model.Name;
                profile.IsDeleted = false;
                _profileService.Add(profile);

                return RedirectToAction("Add", "Profile", new { IsSuccess = "True" });
            }
            catch
            {
                return RedirectToAction("Add", "Profile", new { IsSuccess = "False" });
            }
        }

        public ActionResult Edit(int id, string IsSuccess)
        {
            ViewBag.Issuccess = IsSuccess ?? "Empty";
            var model = new AddViewModel();
            Profile profile = _profileService.GetById(id);
            if (profile == null)
            {
                return View("_ErrorNotExist");
            }
            model.Id = profile.Id;
            model.Name = profile.Name;
            model.Code = profile.Code;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AddViewModel model)
        {
            try
            {
                var profile = _profileService.GetById(model.Id);
                if (profile == null)
                {
                    return View("_ErrorNotExist");
                }
                profile.Code = model.Code;
                profile.Name = model.Name;
                _profileService.Update(profile);

                return RedirectToAction("Edit", "Profile", new { Id = model.Id, IsSuccess = "True" });
            }
            catch
            {
                return RedirectToAction("Edit", "Profile", new { Id = model.Id, IsSuccess = "False" });
            }
        }

        [HttpPost]
        public JsonResult Delete(int[] data)
        {
            try
            {
                if (data == null) return Json("2");
                foreach (var profileId in data)
                {
                    _profileService.Delete(profileId, 1);//todo session dan sonra
                }
                return Json("1");
            }
            catch { return Json("0"); }
        }
    }
}
