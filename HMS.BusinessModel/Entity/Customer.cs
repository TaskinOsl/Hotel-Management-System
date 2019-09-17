using System.Collections.Generic;
using Model.HMS.Entity.Base;

namespace Model.HMS.Entity {

    public class Customer : BaseEntity<long>
    {
        public Customer() { }
       
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string Address { get; set; }
        public virtual string Contactnumber { get; set; }
        public virtual string Nid { get; set; }
        public virtual string Passport { get; set; }
        public virtual string Email { get; set; }
        public virtual string Remarks { get; set; }
        public virtual System.Nullable<System.DateTime> Dob { get; set; }
        public virtual string Nationality { get; set; }
        public virtual IList<Booking> Bookings { get; set; }
        public virtual IList<Roomregister> Roomregisters { get; set; } 
    }
}
