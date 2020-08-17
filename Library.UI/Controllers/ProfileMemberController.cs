using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Business.Enums;
using Library.Business.Interfaces;
using Library.Data.Entity;
using Library.UI.Filters;
using Library.UI.Models.ProfileMember;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.UI.Controllers
{
    public class ProfileMemberController : Controller
    {
        private readonly IProfileMemberService _profileMemberService;
        private readonly IProfileService _profileService;
        public ProfileMemberController(IProfileMemberService profileMemberService, IProfileService profileService)
        {
            _profileMemberService = profileMemberService;
            _profileService = profileService;
        }

        [AppAuthorizeFilter(AuthCodeStatic.PAGE_PROFILEMEMBER_BATCHEDIT)]
        public ActionResult BatchEdit()
        {
            BatchEditViewModel model = new BatchEditViewModel();
            model.ProfileSelectList = GetProfileSelectList();
            model.MemberList = new List<MemberCheckViewModel>();
            model.MemberWhichIsNotIncludeList = new List<MemberCheckViewModel>();
            return View(model);
        }

        [AppAuthorizeFilter(AuthCodeStatic.PAGE_PROFILEMEMBER_BATCHEDIT)]
        [HttpPost]

        public ActionResult BatchEdit(BatchEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.ProfileId.HasValue)
                {
                    model.MemberList = GetAllMemberByProfileId(model.ProfileId.Value);
                    model.MemberWhichIsNotIncludeList = GetAllMemberByProfileIdWhichIsNotIncluded(model.ProfileId.Value);
                }
                else
                {
                    model.MemberList = new List<MemberCheckViewModel>();
                    model.MemberWhichIsNotIncludeList = new List<MemberCheckViewModel>();
                }
                return View(model);
            }

            if (model.SubmitType == "Add")
            {
                if (model.MemberWhichIsNotIncludeList != null && model.ProfileId.HasValue)
                {
                    ModelState.Clear();
                    List<MemberCheckViewModel> records = model.MemberWhichIsNotIncludeList.Where(x => x.Checked == true).ToList();
                    if (records != null)
                    {
                        foreach (var item in records)
                        {
                            ProfileMember profileMember = new ProfileMember();
                            profileMember.MemberId = item.ID;
                            profileMember.ProfileId = model.ProfileId.Value;
                            _profileMemberService.Add(profileMember);
                        }
                    }
                }
            }
            if (model.SubmitType == "Delete")
            {
                if (model.MemberList != null && model.ProfileId.HasValue)
                {
                    ModelState.Clear();
                    List<MemberCheckViewModel> record = model.MemberList.Where(x => x.Checked == true).ToList();
                    if (record != null)
                    {
                        foreach (var item in record)
                        {
                            var apiResponseModel = _profileMemberService.DeleteByProfileIdAndEmployeeId(model.ProfileId.Value, item.ID);
                        }
                    }
                }
            }

            model.ProfileSelectList = GetProfileSelectList();
            if (model.ProfileId.HasValue)
            {
                model.MemberList = GetAllMemberByProfileId(model.ProfileId.Value);
                model.MemberWhichIsNotIncludeList = GetAllMemberByProfileIdWhichIsNotIncluded(model.ProfileId.Value);
            }
            else
            {
                model.MemberList = new List<MemberCheckViewModel>();
                model.MemberWhichIsNotIncludeList = new List<MemberCheckViewModel>();
            }

            return View(model);
        }


        [NonAction]
        private List<MemberCheckViewModel> GetAllMemberByProfileId(int profileId)
        {
            //profile ait kullanıcı kayıtları listelenir
            List<MemberCheckViewModel> resultList = new List<MemberCheckViewModel>();
            resultList = _profileMemberService.GetAllMemberByProfileId(profileId).Select(a => new MemberCheckViewModel() { ID = a.Id, Name = a.Name, Checked = false, LastName = a.LastName }).ToList();
            return resultList;
        }

        [NonAction]
        private List<MemberCheckViewModel> GetAllMemberByProfileIdWhichIsNotIncluded(int profileId)
        {
            //profile ait olmayan yetki kayıtları listelenir
            List<MemberCheckViewModel> resultList = new List<MemberCheckViewModel>();
            resultList = _profileMemberService.GetAllMemberWhichIsNotIncludedByProfileId(profileId).Select(a => new MemberCheckViewModel() { ID = a.Id, Name = a.Name, Checked = false, LastName = a.LastName }).ToList();
            return resultList;
        }


        [NonAction]
        private List<SelectListItem> GetProfileSelectList()
        {
            // aktif profil kayıtları listelenir
            List<SelectListItem> resultList = new List<SelectListItem>();
            resultList = _profileService.GetAll().OrderBy(r => r.Name).Select(r => new SelectListItem() { Value = r.Id.ToString(), Text = r.Name }).ToList();
            return resultList;
        }
    }
}
