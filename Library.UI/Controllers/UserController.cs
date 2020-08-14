using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Library.Business.Common;
using Library.Business.Interfaces;
using Library.UI.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IProfileDetailService _profileDetailService;
        private readonly IProfileMemberService _profileMemberService;
        public UserController(IMemberService memberService, IProfileDetailService profileDetailService, IProfileMemberService profileMemberService)
        {
            _memberService = memberService;
            _profileDetailService = profileDetailService;
            _profileMemberService = profileMemberService;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            GetCaptchaImage();
            return View(model);
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            bool isValidCaptcha = CaptchaHelper.ValidateCaptchaCode(model.CaptchaCode, HttpContext);

            if (!isValidCaptcha)
            {
                ViewBag.Error = "Captcha Code Is Not Valid";
                return View(model);
            }

            SessionLoginResult result = SessionHelper.Login(model.UserName, model.Password, _memberService, _profileDetailService, _profileMemberService);
            if (result.IsSuccess)
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View(model);
            }
            else
            {
                ViewBag.Error = result.Message;
                return View(model);
            }
        }

        // oturum açmadan erişilecek
        [AllowAnonymous]
        public ActionResult Logout()
        {
            // session logout olmalı
            string _UserSessionTrace_SessionTraceGuid = "UserSessionTrace_SessionTraceGuid elde edilemedi";
            if (SessionHelper.CurrentUser != null)
            {

            }
            SessionHelper.Logout();
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult NotAuthorized()
        {
            return View();
        }

        [Route("get-captcha-image")]
        public IActionResult GetCaptchaImage()
        {
            int width = 120;
            int height = 36;
            var captchaCode = CaptchaHelper.GenerateCaptchaCode();
            var result = CaptchaHelper.GenerateCaptchaImage(width, height, captchaCode);
            HttpContext.Session.SetString("CaptchaCode", result.CaptchaCode);
            Stream s = new MemoryStream(result.CaptchaByteData);
            return new FileStreamResult(s, "image/png");
        }
    }
}
