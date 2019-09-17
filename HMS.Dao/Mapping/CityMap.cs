using Dao.HMS.Mapping.Base;
using Model.HMS.Entity;

namespace Dao.HMS.Mapping {


    public class CityMap : BaseClassMap<City, long>
    {
        
        public CityMap() {
			Table("City");
			LazyLoad();
			References(x => x.Country).Column("CountryId");
			References(x => x.State).Column("StateId");
			
			Map(x => x.Shortname).Column("Shortname");
			HasMany(x => x.Hotels);
        }
    }
}
