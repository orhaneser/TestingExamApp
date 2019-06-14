using Core.Helper;
using Examp.Dto;
using LocationApp.Web.Mvc.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        readonly Service.Services.UserService userService = new Service.Services.UserService();

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult User()

        {
            var data = JsonConvert.DeserializeObject<List<UserDto>>(userService.GetAllUser());
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Create(string Email, string Password)
        {
            UserDto userDto = new UserDto();
            userDto.Mail = Email;
            userDto.Password = Password;
            userDto.Role = false;
            var result = JsonConvert.DeserializeObject<UserDto>(userService.AddUser(userDto));

            return RedirectToAction("Login","Login");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var result = JsonConvert.DeserializeObject<UserDto>(userService.GetUser(id.Value));
            if (result != null)
            {
                return View(result);
            }
            else
                return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(UserDto model)
        {
            ResultHelper result = JsonConvert.DeserializeObject<ResultHelper>(userService.SetUser(model));
            ViewBag.Message = Helper.GetResultMessage(result.Result, result.ResultDescription);
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            return View(JsonConvert.DeserializeObject<List<UserDto>>(userService.GetAllUser()));
        }
    }
}