using System.Collections.Generic;
using Model.HMS.Entity.Base;

namespace Model.HMS.Entity {

    public class Country : BaseEntity<long>
    {
        public Country() { }
        
        public virtual string Shortname { get; set; }
        public virtual string Flag { get; set; }
        public virtual string Callingcode { get; set; }
        public virtual IList<City> Cities { get; set; }
        public virtual IList<State> States { get; set; }
    }
}
