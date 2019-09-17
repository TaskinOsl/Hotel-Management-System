using Dao.HMS.Mapping.Base;
using Model.HMS.Entity;

namespace Dao.HMS.Mapping {


    public class RoomtypeMap : BaseClassMap<Roomtype, long>
    {
        
        public RoomtypeMap() {
			Table("RoomType");
			LazyLoad();
            Map(x => x.Name).Column("Name");
			Map(x => x.Description).Column("Description");
			Map(x => x.Ratepernight).Column("RatePerNight");
			HasMany(x => x.Rooms);
			HasMany(x => x.Roomfacilities);
        }
    }
}
