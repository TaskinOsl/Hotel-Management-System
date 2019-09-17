using Dao.HMS.Base;
using Model.HMS.Entity;

namespace Dao.HMS
{
    public interface IRoomRegisterDao : IBaseDao<Roomregister, long>
    {
        
    }

    public class RoomRegisterDao : BaseDao<Roomregister, long>, IRoomRegisterDao
    {
        public RoomRegisterDao()
        {
            
        }
    }
}
