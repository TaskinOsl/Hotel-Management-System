using System.Collections.Generic;
using Dao.HMS;
using Model.HMS.Entity;
using NHibernate;
using Services.HMS.Base;

namespace Services.HMS
{
    public interface IMenuService : IBaseService
    {
        IList<Menu> LoadMenus();
        Menu GetById(int menuId);

        void Update(UserProfile userProfile);
    }
    public class MenuService : BaseService, IMenuService
    {
        private readonly IMenuDao _menuDao;
        private readonly IUserDao _userDao;
        private ISession _session;
        public MenuService(ISession session)
        {
            _session = session;
            _menuDao = new MenuDao() { Session = session };
            _userDao = new UserDao() { Session = session };
        }

        public IList<Menu> LoadMenus()
        {
            return _menuDao.LoadMenus();
        }

        public Menu GetById(int menuId)
        {
            return _menuDao.GetById(menuId);
        }

        public void Update(UserProfile userProfile)
        {
            ITransaction transaction = null;
            using (transaction = _session.BeginTransaction())
            {
                _userDao.Update(userProfile);
                transaction.Commit();
            }
        }
    }
}
