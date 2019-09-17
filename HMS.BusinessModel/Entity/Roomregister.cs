using System;
using System.Collections.Generic;
using Model.HMS.Entity.Base;

namespace Model.HMS.Entity
{

    public class Roomregister : BaseEntity<long>
    {
        public Roomregister()
        {
            Roomregisterdetails = new List<Roomregisterdetail>();
            Rooms = new List<Room>();
            Roomhistories = new List<Roomhistory>();
        }

        public virtual DateTime Checkindate { get; set; }
        public virtual DateTime Checkoutdate { get; set; }
        public virtual int Noofadult { get; set; }
        public virtual int Noofchild { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual IList<Room> Rooms { get; set; }
        public virtual IList<Roomregisterdetail> Roomregisterdetails { get; set; }
        public virtual IList<Roomhistory> Roomhistories { get; set; } 
    }
}
