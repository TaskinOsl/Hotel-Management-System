using Model.HMS.Entity.Base;

namespace Model.HMS.Entity {

    public class Hotel : BaseEntity<long>
    {
        public Hotel() { }
        public virtual string Streetaddress { get; set; }
        public virtual string Postcode { get; set; }
        public virtual string Contactnumber { get; set; }
        public virtual string Emailaddress { get; set; }
        public virtual City City { get; set; }
    }
}
