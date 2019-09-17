using System.Collections.Generic;
using Model.HMS.Entity.Base;

namespace Model.HMS.Entity {

    public class Roomtype : BaseEntity<long>
    {
        public Roomtype() { }
       
        public virtual string Description { get; set; }
        public virtual System.Nullable<decimal> Ratepernight { get; set; }
        public virtual IList<Room> Rooms { get; set; }
        public virtual IList<Roomfacility> Roomfacilities { get; set; }
    }
}
