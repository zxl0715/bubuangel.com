using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bubuangel.com.Areas.Member.Extensions;
namespace bubuangel.com.Areas.Member.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Member/Home/
        [UserAuthorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}
