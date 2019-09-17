using Dao.HMS.Mapping.Base;
using Model.HMS.Entity;

namespace Dao.HMS.Mapping {


    public class RoomregisterMap : BaseClassMap<Roomregister, long>
    {
        
        public RoomregisterMap() {
			Table("RoomRegister");
			LazyLoad();
			Map(x => x.Checkindate).Column("CheckInDate");
			Map(x => x.Checkoutdate).Column("CheckOutdate");
			Map(x => x.Noofadult).Column("NoOfAdult");
			Map(x => x.Noofchild).Column("NoOfChild");
            HasMany(x => x.Roomregisterdetails).Cascade.AllDeleteOrphan().Inverse();
            //HasMany(x => x.Rooms).Cascade.AllDeleteOrphan();
            HasMany(x => x.Roomhistories).Cascade.AllDeleteOrphan();

            References(x => x.Customer).Column("CustomerId");

        }
    }
}
