using Examp.Database;
using Examp.Dto;
using LocationApp.Web.Mvc.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        readonly Service.Services.UserService userService = new Service.Services.UserService();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Email, string Password )
        {
            
            var data = JsonConvert.DeserializeObject<List<UserDto>>(userService.GetAllUser());
            if (data.Any(x => x.Mail == Email && x.Password == Password))
            {
                UserDto loginUser = data.Where(x => x.Mail == Email && x.Password == Password &&x.Role==false).FirstOrDefault();
                Session["Session"] = loginUser.UserID;
                return RedirectToAction("Create", "Question");

            }
            else
            {
                ViewBag.Message = ("Kullanıcı Bulunamadı");
                return View();
            }
        }
    }
}