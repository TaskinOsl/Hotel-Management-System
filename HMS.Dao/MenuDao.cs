using System.Collections.Generic;
using Dao.HMS.Base;
using Model.HMS.Entity;

namespace Dao.HMS
{
    public interface IMenuDao : IBaseDao<Menu, long>
    {
        IList<Menu> LoadMenus();

        Menu GetById(int menuId);
    }
    public class MenuDao : BaseDao<Menu, long>, IMenuDao
    {
        public MenuDao()
        {
            
        }

        public IList<Menu> LoadMenus()
        {
            return Session.QueryOver<Menu>().List<Menu>();
        }

        public Menu GetById(int menuId)
        {
            return Session.QueryOver<Menu>().Where(x => x.Id == menuId).SingleOrDefault<Menu>();
        }
    }
}
