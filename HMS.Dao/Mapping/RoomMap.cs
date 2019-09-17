using Dao.HMS.Mapping.Base;
using Model.HMS.Entity;

namespace Dao.HMS.Mapping {


    public class RoomMap : BaseClassMap<Room, long>
    {
        
        public RoomMap() {
			Table("Room");
			LazyLoad();
			References(x => x.Roomtype).Column("RoomTypeId");
			Map(x => x.Roomno).Column("RoomNo");
			Map(x => x.Noofadult).Column("NoOfAdult");
			Map(x => x.Maxchild).Column("MaxChild");
			Map(x => x.Description).Column("Description");
			//HasMany(x => x.Roomhistories).Cascade.AllDeleteOrphan().Inverse();
        }
    }
}
