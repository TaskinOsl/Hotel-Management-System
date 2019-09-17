using Dao.HMS.Mapping.Base;
using Model.HMS.Entity;

namespace Dao.HMS.Mapping {


    public class BookingdetailMap : BaseClassMap<Bookingdetail, long>
    {
        
        public BookingdetailMap() {
			Table("BookingDetail");
			LazyLoad();
			//Id(x => x.Id).GeneratedBy.Identity().Column("Id");
			References(x => x.Booking).Column("BookingId");
			Map(x => x.Firstname).Column("FirstName");
			Map(x => x.Lastname).Column("LastName");
			Map(x => x.Noofnight).Column("NoOfNight");
			Map(x => x.Callername).Column("CallerName");
			Map(x => x.Contactno).Column("ContactNo");
			Map(x => x.Email).Column("Email");
			Map(x => x.Billingtype).Column("BillingType");
			Map(x => x.Advanceamount).Column("AdvanceAmount");
			Map(x => x.Creditcardno).Column("CreditCardNo");
        }
    }
}
