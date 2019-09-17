using System.Collections.Generic;
using Model.HMS.Entity.Base;

namespace Model.HMS.Entity {

    public class City : BaseEntity<long>
    {
        public City() { }
        public virtual string Shortname { get; set; }
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public virtual IList<Hotel> Hotels { get; set; }
    }
}
