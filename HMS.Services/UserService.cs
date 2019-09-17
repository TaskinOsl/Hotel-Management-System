using System;
using System.Collections.Generic;
using Dao.HMS;
using Model.HMS.Entity;
using NHibernate;
using Services.HMS.Base;

namespace Services.HMS
{
    public interface IUserService:IBaseService
    {
        bool Save(UserProfile userProfile);

        System.Collections.Generic.IList<UserProfile> LoadUser();
        UserProfile GetById(long id);

        UserProfile GetByAspNetId(string aspNetId);
    }

    public class UserService : BaseService, IUserService
    {
        private readonly IUserDao _userDao;
        public UserService(ISession session)
        {
            _userDao = new UserDao() { Session = session };
        }
        public bool Save(UserProfile userProfile)
        {
            try
            {
               _userDao.Save(userProfile);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<UserProfile> LoadUser()
        {
            try
            {
                return _userDao.LoadAll();
            }
            catch (Exception)
            {
               throw;
            }
        }

        public UserProfile GetById(long id)
        {
            return _userDao.LoadById(id);
        }

        public UserProfile GetByAspNetId(string aspNetId)
        {
            return _userDao.GetByAspNetId(aspNetId);
        }
    }
}
