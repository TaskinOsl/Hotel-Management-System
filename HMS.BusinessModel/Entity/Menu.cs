using System.Collections.Generic;
using Model.HMS.Entity.Base;

namespace Model.HMS.Entity {

    public class Menu : BaseEntity<long>
    {
        public Menu() { }
        
        public virtual string Controllername { get; set; }
        public virtual string Actionname { get; set; }
        public virtual long Parentid { get; set; }
        public virtual int Sortorder { get; set; }
        public virtual IList<UserProfile> Profiles { get; set; }
    }
}
