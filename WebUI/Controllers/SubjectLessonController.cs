using Core.Helper;
using Examp.Dto;
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

    public class SubjectLessonController : Controller
    {
        readonly Service.Services.SubjectLessonService subjectLessonService = new Service.Services.SubjectLessonService();
        readonly Service.Services.SubjectService subjectService = new Service.Services.SubjectService();
        readonly Service.Services.LessonService lessonService = new Service.Services.LessonService();
        [HttpGet]
        public ActionResult List()
        {
            GetSubject();
            GetLesson();
            return View(JsonConvert.DeserializeObject<List<SubjectLessonDto>>(subjectLessonService.GetAllSubjectLesson()));
        }

        void GetSubject()
        {
            var list = JsonConvert.DeserializeObject<List<SubjectDto>>(subjectService.GetAllSubject());
            list.Insert(0, new SubjectDto { SubjectID = 0, SubjectText = "Seçiniz" });
            ViewBag.subject = list;
        }
        void GetLesson()
        {
            var list = JsonConvert.DeserializeObject<List<LessonDto>>(lessonService.GetAllLesson());
            list.Insert(0, new LessonDto { LessonID = 0, LessonText = "Seçiniz" });
            ViewBag.lesson = list;
        }
        [HttpPost]
        public JsonResult AddSubjectLesson(int SubjectID, int LessonID)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(subjectLessonService.AddSubjectLesson(new SubjectLessonDto { LessonID = LessonID, SubjectID = SubjectID }));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Remove(int Id)
        {
            var result = JsonConvert.DeserializeObject<ResultHelper>(subjectLessonService.DeleteSubjectLesson(Id));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}