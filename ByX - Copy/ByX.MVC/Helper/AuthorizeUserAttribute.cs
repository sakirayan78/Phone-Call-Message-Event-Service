using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ByX.Model;
using  ByX.Service;
namespace ByX.MVC.Helper
{
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        // Custom property
        public string RoleLevel { get; set; }
        
        public IUserService _userService { get; set; }

       

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
         
            if (httpContext.Session["current_user"] == null)
            {
                //User is not logged-in so redirect to login page
                return false;
            }

            var usr = httpContext.Session["current_user"] as User;

            string roleLevels = string.Join("", _userService.GetRoleByUser(usr)); // Call another method to get rights of the user from DB

            return String.Equals(roleLevels, RoleLevel, StringComparison.CurrentCultureIgnoreCase);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Account",
                                action = "Login",
                                area=""
                            })
                        );
        }
    }
}