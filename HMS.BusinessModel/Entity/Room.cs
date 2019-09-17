using System.Collections.Generic;
using Model.HMS.Entity.Base;

namespace Model.HMS.Entity {

    public class Room : BaseEntity<long>
    {
        public Room()
        {
            Roomhistories = new List<Roomhistory>();
        }
       
        public virtual string Roomno { get; set; }
        public virtual int Noofadult { get; set; }
        public virtual int Maxchild { get; set; }
        public virtual string Description { get; set; }
        public virtual Roomtype Roomtype { get; set; }
        public virtual IList<Roomhistory> Roomhistories { get; set; }
    }
}
