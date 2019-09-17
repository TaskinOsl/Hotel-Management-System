using Dao.HMS.Base;
using Model.HMS.Entity;

namespace Dao.HMS
{
    public interface IRoomFacilityDao : IBaseDao<Roomfacility, long>
    {
        
    }
    public class RoomFacilityDao : BaseDao<Roomfacility, long>, IRoomFacilityDao
    {
        public RoomFacilityDao()
        {
            
        }
    }
}
