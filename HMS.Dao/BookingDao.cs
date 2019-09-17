using System.Collections.Generic;
using Dao.HMS.Base;
using Model.HMS.Entity;

namespace Dao.HMS
{
    public interface IBookingDao : IBaseDao<Booking, long>
    {

        IList<Booking> LoadActiveBooking();
    }
    public class BookingDao : BaseDao<Booking, long>, IBookingDao
    {
        public BookingDao()
        {
            
        }

        public IList<Booking> LoadActiveBooking()
        {
            return Session.QueryOver<Booking>().Where(x => x.Iscancel == false).List<Booking>();
        }
    }
}
