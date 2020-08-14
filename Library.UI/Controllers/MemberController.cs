using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Library.Business.Interfaces;
using Library.Data.Entity;
using Library.UI.Models.Member;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.UI.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public MemberController(IMemberService memberService, IWebHostEnvironment hostingEnvironment)
        {
            _memberService = memberService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult List()
        {
            List<Member> model = new List<Member>();
            model = _memberService.GetAll();
            return View(model);
        }

        
        public ActionResult Add(string IsSuccess)
        {
            ViewBag.Issuccess = IsSuccess ?? "Empty";
            Models.Member.AddViewModel model = new AddViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Models.Member.AddViewModel model, IFormFile imageFilePath)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Member member = new Member();
            member.Name = model.Name;
            member.LastName = model.LastName;
            member.Phone = model.Phone;
            member.TC = model.TC;
            member.Panel = false;
            member.CreatedDateTime = DateTime.Now;
            //resim kaydetme işlevi
            if (imageFilePath != null)
            {
                try
                {
                    List<string> allowedExtensions =  new List<string>() { ".png",".jpeg",".jpg",".gif" };
                    string fileExtension = Path.GetExtension(imageFilePath.FileName).ToLower();
                    bool isAllowed = allowedExtensions.Contains(fileExtension);
                    if (isAllowed)
                    {
                        if (imageFilePath.Length > 0)
                        {
                            // full path to file in temp location
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "MemberImages");

                            //mac cihazlarda -> image isminde boşluk oldugunda url olarak algılamamaktadır. bu yuzden replace ediyoruz.
                            var newImageName = Guid.NewGuid().ToString() + imageFilePath.FileName.Replace(" ", "");
                            var fileNameWithPath = string.Concat(filePath, "\\", newImageName);
                            member.ImageFilePath = newImageName;
                            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                            {
                                imageFilePath.CopyTo(stream);
                            }
                        }
                        else
                        {
                            ViewBag.Error = "Picture Format Incompatible";
                            return View(model);
                        }
                    }
                    else
                    {
                        ViewBag.Error = "Picture Format Incompatible";
                        return View(model);
                    }
                }
                catch 
                {
                    ViewBag.Error = "Image not Saved.";
                    return View(model);
                }
            }

            var result = _memberService.Add(member);
            if (result>0)
            {
                return RedirectToAction("Add", "Member", new { IsSuccess = "True" });
            }
            else
            {
                return RedirectToAction("Add", "Member", new { IsSuccess = "False" });
            }

            
        }

        public ActionResult Edit(int id, string IsSuccess)
        {
            ViewBag.Issuccess = IsSuccess ?? "Empty";
            var model = new AddViewModel();
            Member member = _memberService.GetById(id);
            if (member == null)
            {
                return View("_ErrorNotExist");
            }
            model.Id = member.Id;
            model.Name = member.Name;
            model.LastName = member.LastName;
            model.Phone = member.Phone;
            model.TC = member.TC;
            if (member.ImageFilePath ==null)
            {
                model.ImageName = "";
            }
            else
            {
                model.ImageName = member.ImageFilePath;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AddViewModel model, IFormFile imageFilePath)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var member = _memberService.GetById(model.Id);
                if (member == null)
                {
                    return View("_ErrorNotExist");
                }
                member.Name = model.Name;
                member.LastName = model.LastName;
                member.Phone = model.Phone;
                member.TC = model.TC;
                //resim kaydetme işlevi
                if (imageFilePath != null)
                {
                    try
                    {
                        List<string> allowedExtensions = new List<string>() { ".png", ".jpeg", ".jpg", ".gif" };
                        string fileExtension = Path.GetExtension(imageFilePath.FileName).ToLower();
                        bool isAllowed = allowedExtensions.Contains(fileExtension);
                        if (isAllowed)
                        {
                            if (imageFilePath.Length > 0)
                            {
                                // full path to file in temp location
                                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "MemberImages");

                                //mac cihazlarda -> image isminde boşluk oldugunda url olarak algılamamaktadır. bu yuzden replace ediyoruz.
                                var newImageName = Guid.NewGuid().ToString() + imageFilePath.FileName.Replace(" ", "");
                                var fileNameWithPath = string.Concat(filePath, "\\", newImageName);
                                member.ImageFilePath = newImageName;
                                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                                {
                                    imageFilePath.CopyTo(stream);
                                }
                            }
                            else
                            {
                                ViewBag.Error = "Picture Format Incompatible";
                                return View(model);
                            }
                        }
                        else
                        {
                            ViewBag.Error = "Picture Format Incompatible";
                            return View(model);
                        }
                    }
                    catch
                    {
                        ViewBag.Error = "Image not Saved.";
                        return View(model);
                    }
                }
                _memberService.Update(member);

                return RedirectToAction("Edit", "Member", new { Id = model.Id, IsSuccess = "True" });
            }
            catch
            {
                return RedirectToAction("Edit", "Member", new { Id = model.Id, IsSuccess = "False" });
            }
        }

    }
}
