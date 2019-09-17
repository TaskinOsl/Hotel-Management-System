using Dao.HMS.Mapping.Base;
using Model.HMS.Entity;

namespace Dao.HMS.Mapping
{


    public class RoomhistoryMap : BaseClassMap<Roomhistory, long>
    {

        public RoomhistoryMap()
        {
            Table("RoomHistory");
            LazyLoad();
            References(x => x.Room).Column("RoomId");
            Map(x => x.Arrivaldate).Column("ArrivalDate");
            Map(x => x.Leavedate).Column("LeaveDate");
            References(x => x.Booking).Column("BookingId");
            References(x => x.Roomregister).Column("RoomRegisterId");
        }
    }
}
