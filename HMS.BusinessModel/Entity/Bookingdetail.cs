using Model.HMS.Entity.Base;

namespace Model.HMS.Entity {

    public class Bookingdetail : BaseEntity<long>
    {
        public Bookingdetail() { }
        
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual int Noofnight { get; set; }
        public virtual string Callername { get; set; }
        public virtual string Contactno { get; set; }
        public virtual string Email { get; set; }
        public virtual int Billingtype { get; set; }
        public virtual decimal Advanceamount { get; set; }
        public virtual string Creditcardno { get; set; }
        public virtual Booking Booking { get; set; }
    }
}
