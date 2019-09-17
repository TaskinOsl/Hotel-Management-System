using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Model.HMS.Entity;
using Services.HMS;
using Services.HMS.Helper;

namespace Web.HMS
{
    public class CustomMenuFilter : ActionFilterAttribute
    {
        private readonly IUserService _userService = new UserService(NhSessionFactory.OpenSession());
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //check if user is logged in or not 
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                // Get permitted Menu
                if (HttpContext.Current.Session["userMenus"] == null)
                {
                    UserProfile userProfile = _userService.GetByAspNetId(HttpContext.Current.User.Identity.GetUserId());
                    if (userProfile == null || HttpContext.Current.Session["userMenus"] == null)
                        filterContext.Controller.ViewBag.userMenuList = new List<Menu>() { new Menu() { Name = "Demo" } };
                    if (userProfile != null)
                    {
                        HttpContext.Current.Session["userMenus"] = userProfile.Menus.ToList();
                        filterContext.Controller.ViewBag.userMenuList = userProfile.Menus.ToList();
                    }
                }
            }
            else
            {
                HttpContext.Current.Session["userMenus"] = null;
                filterContext.Controller.ViewBag.userMenuList = null;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}