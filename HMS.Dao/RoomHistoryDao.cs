using Dao.HMS.Base;
using Model.HMS.Entity;

namespace Dao.HMS
{
    public interface IRoomHistoryDao : IBaseDao<Roomhistory, long>
    {
        
    }
    public class RoomHistoryDao:BaseDao<Roomhistory, long>,IRoomHistoryDao
    {
        public RoomHistoryDao()
        {
            
        }
    }
}
