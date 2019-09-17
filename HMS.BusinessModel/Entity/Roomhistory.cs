using System;
using Model.HMS.Entity.Base;

namespace Model.HMS.Entity
{

    public class Roomhistory : BaseEntity<long>
    {
        public Roomhistory() { }

        public virtual DateTime Arrivaldate { get; set; }
        public virtual DateTime Leavedate { get; set; }
        public virtual Booking Booking { get; set; }
        public virtual Room Room { get; set; }
        public virtual Roomregister Roomregister { get; set; }
    }
}
