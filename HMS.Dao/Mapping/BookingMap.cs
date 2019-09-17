using Dao.HMS.Mapping.Base;
using Model.HMS.Entity;

namespace Dao.HMS.Mapping {


    public class BookingMap : BaseClassMap<Booking, long>
    {
        
        public BookingMap() {
			Table("Booking");
			LazyLoad();
			//Id(x => x.Id).GeneratedBy.Identity().Column("Id");
			References(x => x.Customer).Column("CustomerId");
			Map(x => x.Checkindate).Column("CheckInDate");
			Map(x => x.Checkoutdate).Column("CheckOutdate");
			Map(x => x.Noofadult).Column("NoOfAdult");
			Map(x => x.Noofchild).Column("NoOfChild");
			Map(x => x.Iscancel).Column("IsCancel");

            HasMany(x => x.Bookingdetails).KeyColumn("BookingId").Cascade.AllDeleteOrphan().Inverse();
            //HasMany(x => x.Rooms).KeyColumn("BookingId").Cascade.AllDeleteOrphan();
            HasMany(x => x.Roomhistories).KeyColumn("BookingId").Cascade.AllDeleteOrphan().Inverse();

        }
    }
}
