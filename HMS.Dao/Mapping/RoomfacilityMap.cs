using Dao.HMS.Mapping.Base;
using Model.HMS.Entity;

namespace Dao.HMS.Mapping {


    public class RoomfacilityMap : BaseClassMap<Roomfacility, long>
    {
        
        public RoomfacilityMap() {
			Table("RoomFacilities");
			LazyLoad();
			References(x => x.Roomtype).Column("RoomTypeId");
			}
    }
}
