using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ByX.Model;
using ByX.MVC.Helper;
using ByX.Service;

namespace ByX.MVC.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserService _userService;
    
        public AccountController(IUserService userService)
        {
            _userService = userService;

        }
        //
        // GET: /Account/

   

        public ActionResult Login()
        {
          
            return View("Login");
        }


        [HttpPost]
        public ActionResult Login(User usr)
        {
            if (_userService.IsRegisteredUser(usr))
            {
                string roleName = _userService.GetRoleByUser(usr);
                Sessions.CurrentUser = usr;
                return RedirectToAction("Index", "Home", new { area = roleName }); 
            }     
            
           ViewData["Name"]  = "wrong password or username";
            return  View("Login");
        }
    }
}
