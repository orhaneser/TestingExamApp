using Core.Helper;
using Examp.Dto;
using LocationApp.Web.Mvc.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Session;

namespace WebUI.Controllers
{
    [UserAuthorize]

    public class SubjectController : Controller
    {
        readonly Service.Services.SubjectService subjectService = new Service.Services.SubjectService();

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string SubjectText)
        {
            SubjectDto subjectDto = new SubjectDto();
            subjectDto.SubjectText = SubjectText;
            var result = JsonConvert.DeserializeObject<SubjectDto>(subjectService.AddSubject(subjectDto));
            return RedirectToAction("List", "Subject");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var result = JsonConvert.DeserializeObject<SubjectDto>(subjectService.GetSubject(id.Value));
            if (result != null)
            {
                return View(result);
            }
            else
                return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(SubjectDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(subjectService.SetSubject(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<SubjectDto>>(subjectService.GetAllSubject()));
        }
    }
}