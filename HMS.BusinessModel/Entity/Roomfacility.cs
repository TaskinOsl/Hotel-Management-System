using Model.HMS.Entity.Base;

namespace Model.HMS.Entity {

    public class Roomfacility : BaseEntity<long>
    {
        public Roomfacility() { }
        
        public virtual Roomtype Roomtype { get; set; }
    }
}
