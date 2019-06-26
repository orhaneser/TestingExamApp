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

    public class LessonController : Controller
    {
        readonly Service.Services.LessonService lessonService = new Service.Services.LessonService();

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create( string LessonText)
        {
            LessonDto lessonDto = new LessonDto();
            lessonDto.LessonText = LessonText;
            var result = JsonConvert.DeserializeObject<LessonDto>(lessonService.AddLesson(lessonDto));

            return RedirectToAction("List", "Lesson");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var result = JsonConvert.DeserializeObject<LessonDto>(lessonService.GetLesson(id.Value));
            if (result != null)
            {
                return View(result);
            }
            else
                return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(LessonDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(lessonService.SetLesson(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<LessonDto>>(lessonService.GetAllLesson()));
        }
    }
}