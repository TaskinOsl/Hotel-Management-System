using Dao.HMS.Mapping.Base;
using Model.HMS.Entity;

namespace Dao.HMS.Mapping {


    public class CustomerMap : BaseClassMap<Customer, long>
    {
        
        public CustomerMap() {
			Table("Customer");
			LazyLoad();
			Map(x => x.Firstname).Column("FirstName");
			Map(x => x.Lastname).Column("LastName");
			Map(x => x.Address).Column("Address");
			Map(x => x.Contactnumber).Column("ContactNumber");
			Map(x => x.Nid).Column("NID");
			Map(x => x.Passport).Column("Passport");
			Map(x => x.Email).Column("Email");
			Map(x => x.Remarks).Column("Remarks");
			Map(x => x.Dob).Column("DOB");
			Map(x => x.Nationality).Column("Nationality");
			HasMany(x => x.Bookings);
        }
    }
}
