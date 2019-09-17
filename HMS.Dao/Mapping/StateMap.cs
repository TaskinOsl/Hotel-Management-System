using Dao.HMS.Mapping.Base;
using Model.HMS.Entity;

namespace Dao.HMS.Mapping {


    public class StateMap : BaseClassMap<State, long>
    {
        
        public StateMap() {
			Table("State");
			LazyLoad();
			References(x => x.Country).Column("CountryId");
			Map(x => x.Shortname).Column("Shortname");
			HasMany(x => x.Cities);
        }
    }
}
