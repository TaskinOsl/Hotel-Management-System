using Dao.HMS.Mapping.Base;
using Model.HMS.Entity;

namespace Dao.HMS.Mapping {


    public class GlobalsettingMap : BaseClassMap<Globalsetting, long>
    {
        
        public GlobalsettingMap() {
			Table("GlobalSetting");
			LazyLoad();
			Map(x => x.Minimumbooking).Column("MinimumBooking");
			Map(x => x.Tax).Column("Tax");
			Map(x => x.Ispriceincludingtax).Column("IsPriceIncludingTax");
        }
    }
}
