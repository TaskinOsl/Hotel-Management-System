using System;
using System.Collections.Generic;
using Model.HMS.Entity.Base;

namespace Model.HMS.Entity {

    public class Booking : BaseEntity<long>
    {
        public Booking()
        {
            Bookingdetails = new List<Bookingdetail>();
            Roomhistories = new List<Roomhistory>();
            Rooms = new List<Room>();
        }
        public virtual DateTime Checkindate { get; set; }
        public virtual DateTime Checkoutdate { get; set; }
        public virtual int Noofadult { get; set; }
        public virtual int Noofchild { get; set; }
        public virtual bool Iscancel { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual IList<Bookingdetail> Bookingdetails { get; set; }
        public virtual IList<Room> Rooms { get; set; }
        public virtual IList<Roomhistory> Roomhistories { get; set; } 

    }
}
