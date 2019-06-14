using Core.Helper;
using Examp.Database;
using Examp.Dto;
using LocationApp.Web.Mvc.Helpers;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Session;

namespace WebUI.Controllers
{
    [UserAuthorize]
    public class QuestionController : Controller
    {
        readonly Service.Services.OptionService optionService = new Service.Services.OptionService();
        readonly Service.Services.QuestionService questionService = new Service.Services.QuestionService();
        readonly Service.Services.UserQuestionService userQuestionService = new Service.Services.UserQuestionService();
        readonly Service.Services.LessonService lessonService = new Service.Services.LessonService();
        readonly Service.Services.SubjectService subjectService = new Service.Services.SubjectService();
        readonly Service.Services.SubjectLessonService subjectLessonService = new Service.Services.SubjectLessonService();
        void GetLessons()
        {
            var list = JsonConvert.DeserializeObject<List<LessonDto>>(lessonService.GetAllLesson());
            list.Insert(0, new LessonDto { LessonID = 0, LessonText = "Seçiniz" });
            ViewBag.lesson = list;
        }
        [HttpGet]
        public ActionResult Create()
        {
            GetLessons();
            var a = Session["Session"];
            return View();
        }
        [HttpPost]
        public ActionResult Create(QuestionDto model)
        {
            return RedirectToAction("Create");

        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var result = JsonConvert.DeserializeObject<QuestionDto>(questionService.GetQuestion(id.Value));
            if (result != null)
            {
                return View(result);
            }
            else
                return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(QuestionDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(questionService.SetQuestion(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpPost]
        public ActionResult EditQuestion(int subjectID, int UserQuestionID, int optionID, string OptionA, string OptionB, string OptionC, string OptionD, string OptionE, string Text, string SubText, string radio, string difficult)
        {
            OptionDto Option = new OptionDto();
            Option.OptionID = optionID; Option.OptionA = OptionA; Option.OptionB = OptionB; Option.OptionC = OptionC; Option.OptionD = OptionD; Option.OptionE = OptionE;
            ResultHelper option = JsonConvert.DeserializeObject<ResultHelper>(optionService.SetOption(Option));
            QuestionDto model = new QuestionDto();
            model.Difficult = difficult; model.QuestionText = Text; model.AnswerKey = radio; model.SubText = SubText;model.QuestionID = UserQuestionID;model.OptionID = optionID;model.SubjectID = subjectID;
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(questionService.SetQuestion(model));


            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult List(int page = 1, int pageSize = 4)
        {
            var UserID = Session["Session"];
            var data = JsonConvert.DeserializeObject<List<UserQuestionDto>>(userQuestionService.GetAllUserQuestion());
            var filter = data.Where(x => x.UserID == (int)UserID);
            filter.OrderBy(x => x.UserID).ToPagedList(page, pageSize);
            PagedList<UserQuestionDto> model = new PagedList<UserQuestionDto>(filter, page, pageSize);
            return View(model);
        }
        [HttpPost]
        public ActionResult QuestionList(int UserQuestionID)
        {
            var data = JsonConvert.DeserializeObject<List<UserQuestionDto>>(userQuestionService.GetAllUserQuestion());
            var item = data.Where(x => x.QuestionID == UserQuestionID);
            return Json(item, JsonRequestBehavior.AllowGet);
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
        public JsonResult AddQuestion(int subject, int lesson, string radio, string difficult, string Text, string SubText, int OptionID)
        {
            ResultHelper question = JsonConvert.DeserializeObject<ResultHelper>(questionService.AddQuestion(new QuestionDto { QuestionText = Text, SubText = SubText, Difficult = difficult, SubjectID = subject, AnswerKey = radio, OptionID = OptionID }));
            return Json(question, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddOption(string OptionA, string OptionB, string OptionC, string OptionD, string OptionE)
        {
            ResultHelper question = JsonConvert.DeserializeObject<ResultHelper>(optionService.AddOption(new OptionDto { OptionA = OptionA, OptionB = OptionB, OptionC = OptionC, OptionD = OptionD, OptionE = OptionE }));

            return Json(question, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddUserQuestion(int QuestionID)
        {
            var userID = Session["Session"];
            ResultHelper UserQuestion = JsonConvert.DeserializeObject<ResultHelper>(userQuestionService.AddUserQuestion(new UserQuestionDto { UserID = (int)userID, QuestionID = QuestionID }));
            return Json(UserQuestion, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult UserQuestionCount()
        {
            var data = JsonConvert.DeserializeObject<List<UserQuestionDto>>(userQuestionService.GetAllUserQuestion());
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetUserQuestionID(int Id)
        {
            var data = JsonConvert.DeserializeObject<List<UserQuestionDto>>(userQuestionService.GetAllUserQuestion());
            var item = data.Where(x => x.QuestionID == Id);
            return Json(item, JsonRequestBehavior.AllowGet);

            //return Json(JsonConvert.DeserializeObject<ResultHelper>(questionService.DeleteQuestion(Id)), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(int DeletequestionID,int DeleteUserQuestion)
        {
           var item= JsonConvert.DeserializeObject<ResultHelper>(userQuestionService.DeleteUserQuestion(DeleteUserQuestion));
            return Json(JsonConvert.DeserializeObject<ResultHelper>(questionService.DeleteQuestion(DeletequestionID)), JsonRequestBehavior.AllowGet);
        }
    }
}