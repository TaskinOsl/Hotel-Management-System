using System.Collections.Generic;
using Model.HMS.Entity.Base;

namespace Model.HMS.Entity {

    public class State : BaseEntity<long>
    {
        public State() { }
        
        public virtual string Shortname { get; set; }
        public virtual Country Country { get; set; }
        public virtual IList<City> Cities { get; set; }
    }
}
