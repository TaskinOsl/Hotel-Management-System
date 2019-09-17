using Dao.HMS.Base;
using Model.HMS.Entity;

namespace Dao.HMS
{
    public interface IBookingDetailDao : IBaseDao<Bookingdetail, long>
    {
        
    }
    public class BookingDetailDao:BaseDao<Bookingdetail, long>,IBookingDetailDao
    {
        public BookingDetailDao()
        {
            
        }
    }
}
