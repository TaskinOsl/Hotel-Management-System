using Dao.HMS.Mapping.Base;
using Model.HMS.Entity;

namespace Dao.HMS.Mapping {


    public class CountryMap : BaseClassMap<Country, long>
    {
        
        public CountryMap() {
			Table("Country");
			LazyLoad();
			Map(x => x.Shortname).Column("Shortname");
			Map(x => x.Flag).Column("Flag");
			Map(x => x.Callingcode).Column("CallingCode");
			HasMany(x => x.Cities);
			HasMany(x => x.States);
        }
    }
}
