using Model.HMS.Entity.Base;

namespace Model.HMS.Entity {

    public class Globalsetting : BaseEntity<long>
    {
        public Globalsetting() { }
        public virtual System.Nullable<int> Minimumbooking { get; set; }
        public virtual System.Nullable<int> Tax { get; set; }
        public virtual System.Nullable<bool> Ispriceincludingtax { get; set; }
    }
}
