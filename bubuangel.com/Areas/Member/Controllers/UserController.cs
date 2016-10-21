using bubuangel.com.Areas.Member.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zxl.BLL;
using Zxl.Common;
using Zxl.Models;

namespace bubuangel.com.Areas.Member.Controllers
{
    public class UserController : Controller
    {

        UserService userService = new UserService();
        //
        // GET: /Member/User/

        public ActionResult Index()
        {
            string verificationCode = Security.CreateVerificationText(6);
            Bitmap _img = Security.CreateVerificationImage(verificationCode, 160, 30);
            _img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            TempData["VerificationCode"] = verificationCode.ToUpper();
            return null;
        }

        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult VerificationCode()
        {
            string verificationCode = Security.CreateVerificationText(6);
            Bitmap _img = Security.CreateVerificationImage(verificationCode, 160, 30);
            _img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            TempData["VerificationCode"] = verificationCode.ToUpper();
            return null;
        }

        //
        // GET: /Member/User/Register/
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel register)
        {
            if (TempData["VerificationCode"] == null || TempData["VerificationCode"].ToString() != register.VerificationCode.ToUpper())
            {
                ModelState.AddModelError("VerificationCode", "验证码不正确");
            }
            if (ModelState.IsValid)
            {

                if (userService.Exist(register.UserName))
                {
                    ModelState.AddModelError("UserName", "用户名已存在");
                }
                else
                {
                    User _user = new User()
                    {
                        UserName = register.UserName,
                        DisplayName = register.DisplayName,
                        Password = Security.Sha256(register.Password),
                        Email = register.Email,
                        Status = 0,
                        RegisrationTime = DateTime.Now,
                        LoginTime = DateTime.Now

                    };
                    _user = userService.Add(_user);
                    if (_user.UserID > 0)
                    {
                        return Content("注册成功!");
                    }
                    else
                    {
                        ModelState.AddModelError("", "注册失败");
                    }
                }
            }
            return View(register);
        }
        //  /Member/User/Login/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var _user = userService.Find(loginViewModel.UserName);
                if (_user == null)
                {
                    ModelState.AddModelError("UserName", "用户名不存在");
                }
                else if (_user.Password == Security.Sha256(loginViewModel.Password))
                {
                    //var _identity = userService.CreateIdentity(_user, DefaultAuthenticationTypes.ApplicationCookie);
                    //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    //AuthenticationManager.SignIn( _identity);

                    HttpCookie _cookie = new HttpCookie("User");

                    _cookie.Values.Add("UserName", loginViewModel.UserName);
                    _cookie.Values.Add("Password", Security.Sha256(loginViewModel.Password));
                    Response.Cookies.Add(_cookie);
                    _user.LoginTime = DateTime.Now;
                    _user.LoginIP = Request.UserHostAddress;
                    userService.Update(_user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Password", "密码错误");
                }
            }

            return View();
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            if (Request.Cookies["User"] != null)
            {
                HttpCookie _cookie = Request.Cookies["User"];
                _cookie.Expires = DateTime.Now.AddHours(-1);
                Response.Cookies.Add(_cookie);
            }

            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Redirect(Url.Content("~/"));
        }
    }
}
