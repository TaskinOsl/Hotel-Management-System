using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Model.HMS.Entity;
using Model.HMS.ViewModel;
using NHibernate;
using Services.HMS;
using Services.HMS.Helper;

namespace Web.HMS.Controllers
{
    [Authorize]
    public class SettingController : Controller
    {
        #region Declaration And Initialization

        private readonly IUserService _userService;
        private readonly IMenuService _menuService;
        private ISession _session;
        public SettingController()
        {
            _session = NhSessionFactory.OpenSession();
            _userService = new UserService(_session);
            _menuService = new MenuService(_session);
        }

        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region Save/Update/Delete Operation

        /// <summary>
        /// Save Menu Permission For User
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public JsonResult SaveMenuPermission(string data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            UserMenuVm userMenuList = serializer.Deserialize<UserMenuVm>(data);

            //userMenuList.UserName is UserId 
            UserProfile userProfile = _userService.GetById(Convert.ToInt64(userMenuList.UserName));
            userProfile.Menus.Clear();
            userProfile.Menus = new List<Menu>();
            foreach (var menuId in userMenuList.MenuIds)
            {
                Menu menu = _menuService.GetById(menuId);
                userProfile.Menus.Add(menu);
            }
            _menuService.Update(userProfile);

            return Json("Menus assigend successfully");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GrantPermissionTo(long id)
        {
            UserProfile user = _userService.GetById(id);
            ViewBag.UserName = user.NickName;
            ViewBag.UserId = user.Id;
            IList<Menu> allMenus = _menuService.LoadMenus();
            IList<Menu> userAssignedMenus = user.Menus;

            List<MenuViewModel> menuViewModels = CastToVM(allMenus).ToList();
            List<MenuViewModel> finaList = new List<MenuViewModel>();
            foreach (var menuViewModel in menuViewModels.Where(x => x.ParentId == 0).ToList())
            {
                var recursiveMenu = GenerateUserMenu(menuViewModels, menuViewModel);
                finaList.Add(recursiveMenu);
            }
            ViewBag.ExistingPermittedMenu = userAssignedMenus;
            return View(finaList);
        }

        #endregion

        #region List

        /// <summary>
        /// Show List Of Users
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult LoadUserProfiles()
        {
            IList<UserProfile> profiles = _userService.LoadUser();
            return View(profiles);
        }

        #endregion

        #region Private Methods

        public MenuViewModel GenerateUserMenu(List<MenuViewModel> list, MenuViewModel root)
        {
            if (list == null) throw new ArgumentNullException("User don't have any permission!");
            if (root == null) throw new InvalidOperationException("root == null");

            GenerateRecursiveMenu(root, list);
            return root;
        }

        //recursive method
        public void GenerateRecursiveMenu(MenuViewModel node, List<MenuViewModel> all)
        {
            var childs = all.Where(x => x.ParentId == node.Id).ToList();
            foreach (var item in childs)
            {
                node.Menus.Add(item);
            }

            foreach (var item in childs)
                all.Remove(item);

            foreach (var item in childs)
            {
                GenerateRecursiveMenu(item, all);
            }
        }

        private IList<MenuViewModel> CastToVM(IList<Menu> allMenus)
        {
            try
            {
                IList<MenuViewModel> menuViewModels = new List<MenuViewModel>();
                foreach (var menu in allMenus)
                {
                    var menuVm = new MenuViewModel();
                    menuVm.Id = menu.Id;
                    menuVm.ActionName = menu.Actionname;
                    menuVm.ControllerName = menu.Controllername;
                    menuVm.Name = menu.Name;
                    menuVm.ParentId = menu.Parentid;
                    menuVm.SortOrder = menu.Sortorder;
                    menuViewModels.Add(menuVm);
                }
                return menuViewModels;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}