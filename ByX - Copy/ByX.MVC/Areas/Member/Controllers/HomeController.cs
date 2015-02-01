using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ByX.MVC.Helper;
using Ext.Net;
using Ext.Net.MVC;

namespace ByX.MVC.Areas.Member.Controllers
{

    [AuthorizeUser(RoleLevel = "Member")]
    public class HomeController : Controller
    {
        //
        // GET: /Member/Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddTab(string containerid, string viewname)
        {
            var result = new Ext.Net.MVC.PartialViewResult
            {
                ViewName = viewname,
                ContainerId = containerid,
                RenderMode = RenderMode.AddTo,
                WrapByScriptTag = false

            };


            this.GetCmp<TabPanel>(containerid).SetLastTabAsActive();

            return result;
        }

    }
}
