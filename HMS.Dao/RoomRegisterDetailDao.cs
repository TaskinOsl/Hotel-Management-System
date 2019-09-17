using Dao.HMS.Base;
using Model.HMS.Entity;

namespace Dao.HMS
{
    public interface IRoomRegisterDetailDao : IBaseDao<Roomregisterdetail, long>
    {
        
    }
    public class RoomRegisterDetailDao : BaseDao<Roomregisterdetail, long>, IRoomRegisterDetailDao
    {
        public RoomRegisterDetailDao()
        {
            
        }
    }
}
