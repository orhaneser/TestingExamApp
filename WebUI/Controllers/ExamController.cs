using Examp.Database;
using Examp.Dto;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Session;

namespace WebUI.Controllers
{
    [UserAuthorize]

    public class ExamController : Controller
    {
        readonly Service.Services.QuestionService questionService = new Service.Services.QuestionService();
        readonly Service.Services.LessonService lessonService = new Service.Services.LessonService();
        readonly Service.Services.SubjectService subjectService = new Service.Services.SubjectService();
        readonly Service.Services.SubjectLessonService subjectLessonService = new Service.Services.SubjectLessonService();
        [HttpGet]
        public ActionResult Create()
        {
            GetLessons();
            return View();
        }
        [HttpPost]
        public ActionResult Create(QuestionDto model)
        {
            return RedirectToAction("Create");
        }
        void GetLessons()
        {
            var list = JsonConvert.DeserializeObject<List<LessonDto>>(lessonService.GetAllLesson());
            list.Insert(0, new LessonDto { LessonID = 0, LessonText = "Seçiniz" });
            ViewBag.lesson = list;
        }
        [HttpGet]
        public JsonResult GetLesson(int LessonID)
        {
            var data = JsonConvert.DeserializeObject<List<SubjectLessonDto>>(subjectLessonService.GetAllSubjectLesson());
            var item = data.Where(x => x.LessonID == LessonID);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetSubject(int SubjectID)
        {
            var data = JsonConvert.DeserializeObject<List<SubjectDto>>(subjectService.GetAllSubject());
            var item = data.Where(x => x.SubjectID == SubjectID);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetQuestion( Question datas ,string take)
        {
            var r = new Random();
            var data = JsonConvert.DeserializeObject<List<QuestionDto>>(questionService.GetAllQuestion());
            var item = data.Where(x => x.SubjectID == datas.SubjectID);
            var dif = item.Where(x => x.Difficult == datas.Difficult);
            var randomdata = dif.OrderBy(u => r.Next()).Take(Convert.ToInt32( take));
            return Json(randomdata, JsonRequestBehavior.AllowGet);
        }

    }
}