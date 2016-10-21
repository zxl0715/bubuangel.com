using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zxl.BLL;
using Zxl.Common;

namespace bubuangel.com.Areas.Member.Extensions
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 核心【验证用户是否登陆】
        /// 操作的Action或Controller上加[UserAuthorize]就可实现验证是否已经登录
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.Cookies["User"] == null)
            {
                return false;
            }
            HttpCookie _cookie = httpContext.Request.Cookies["User"];
            string _username = _cookie["UserName"];
            string _password = _cookie["Password"];
            httpContext.Response.Write("用户名：" + _username);
            if (_username == "" || _password == "")
            {
                return false;
            }
            UserService userService = new UserService();
            var _user = userService.Find(_username);
            if (_user != null && _user.Password == _password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}