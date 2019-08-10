using LocationApp.Core.Core;
using LocationApp.Core.Helper;
using LocationApp.Data.Dto;
using LocationApp.Service.Services;
using LocationApp.Web.Mvc.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LocationApp.Core.Helper;
namespace LocationApp.Web.Controllers
{
    public class LoginController : Controller
    {
        #region Services
        LocationApp.Service.Services.UserService userService = new Service.Services.UserService();
        LocationApp.Service.Services.UserLoginService userLoginService = new UserLoginService();
        #endregion
        [HttpGet]
        public ActionResult SendMail(string email,string password)
        {
            Postman mailer = new Postman();
            mailer.ToEmail = email;
            mailer.Subject = "Parola öğrenme talebi";
            mailer.Body = password;
            mailer.IsHtml = true;
            mailer.Send();
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Auth");
        }
        [HttpGet]
        public ActionResult Auth()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Auth(string email, string password)
        {
            UserDto item = JsonConvert.DeserializeObject<UserDto>(userService.isLogin(email, password));
            if (item != null)
            {
                string fullName = item.Name + " " + item.SurName;
                FormsAuthentication.SetAuthCookie(fullName.ToUpper(), true);
                Session.Add("User", fullName.ToUpper());
                Session.Timeout = 300000;
                var result = JsonConvert.DeserializeObject<ResultHelper>(userLoginService.AddUserLogin(new UserLoginDto
                {
                    CreationDate = DateTime.Now,
                    IpAdress = NetWork.GetLocalIPAddress(),
                    Password = password,
                    UserID = item.UserID,
                    UserLoginID = 0
                }));
                return RedirectToAction("List","Campus");
            }

            else
                ViewBag.Message =
                    Helper.GetResultMessage(false, "Kullanıcı adı veya parola hatalı.");
            return View();
        }
        [HttpPost]
        public ActionResult MailCheck(string Email)
        {
            var result = JsonConvert.DeserializeObject<UserLoginDto>(userLoginService.SendMail(Email));

            if (result != null)
            {
                SendMail(Email, result.Password);
                ViewBag.Message = Helper.GetResultMessage(true, "Parolanız e-posta adresinize gönderilmiştir.");
                return View();
            }
            else
            {
                ViewBag.Message = Helper.GetResultMessage(false, "Böyle bir e-posta adresi bulunamadı. Yönetici ile iletişime geçin.");
                return View();
            }
        }
        [HttpGet]
        public ActionResult HomePage()
        {
            return View();
        }
    }
}