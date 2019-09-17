using Dao.HMS.Mapping.Base;
using Model.HMS.Entity;

namespace Dao.HMS.Mapping {


    public class HotelMap : BaseClassMap<Hotel, long>
    {
        
        public HotelMap() {
			Table("Hotel");
			LazyLoad();
			
			References(x => x.City).Column("CityId");
			Map(x => x.Streetaddress).Column("StreetAddress");
			Map(x => x.Postcode).Column("PostCode");
			Map(x => x.Contactnumber).Column("ContactNumber");
			Map(x => x.Emailaddress).Column("EmailAddress");
        }
    }
}
