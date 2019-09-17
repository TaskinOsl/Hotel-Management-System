using Dao.HMS.Base;
using Model.HMS.Entity;

namespace Dao.HMS
{
    public interface IHotelDao : IBaseDao<Hotel, long>
    {
        
    }
    public class HotelDao:BaseDao<Hotel, long>,IHotelDao
    {
        public HotelDao()
        {
            
        }
    }
}
