using Model.HMS.Entity.Base;

namespace Model.HMS.Entity {

    public class Roomregisterdetail : BaseEntity<long>
    {
        public Roomregisterdetail() { }
        
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual System.Nullable<int> Noofnight { get; set; }
        public virtual string Callername { get; set; }
        public virtual string Contactno { get; set; }
        public virtual Roomregister Roomregister { get; set; }
        public virtual string Email { get; set; }
        public virtual System.Nullable<int> Billingtype { get; set; }
        public virtual System.Nullable<decimal> Advanceamount { get; set; }
        public virtual string Creditcardno { get; set; }
    }
}
