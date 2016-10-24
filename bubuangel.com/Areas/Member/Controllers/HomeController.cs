using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bubuangel.com.Areas.Member.Extensions;
using Zxl.Models;
using Zxl.BLL;
namespace bubuangel.com.Areas.Member.Controllers
{ 
    public class HomeController : Controller
    {


        public ModuleService BaseModuleBll = new ModuleService();
        //
        // GET: /Member/Home/
        [UserAuthorize]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 手风琴-欢迎首页
        /// </summary>
        /// <returns></returns>
        public ActionResult AccordionPage()
        {
            return View();
        }

        /// <summary>
        /// 加载手风琴菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult LoadAccordionMenu()
        {
            //List<Module> list = BaseModuleBll.GetList().FindAll(t => t.Enabled == 1);
            //return Content(list.ToJson().Replace("&nbsp;", ""));
            return View();
        }
    }
}
