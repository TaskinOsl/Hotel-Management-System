using Dao.HMS.Base;
using Model.HMS.Entity;

namespace Dao.HMS
{
    public interface IUserDao : IBaseDao<UserProfile, long>
    {

        UserProfile GetByAspNetId(string aspNetId);
    }

    public class UserDao : BaseDao<UserProfile, long>, IUserDao
    {
        public UserDao()
        {
            
        }

        public UserProfile GetByAspNetId(string aspNetId)
        {
            return
                Session.QueryOver<UserProfile>().Where(x => x.AspNetUserId == aspNetId).SingleOrDefault<UserProfile>();
        }
    }
}
