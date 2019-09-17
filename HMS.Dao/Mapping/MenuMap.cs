using Dao.HMS.Mapping.Base;
using Model.HMS.Entity;

namespace Dao.HMS.Mapping {


    public class MenuMap : BaseClassMap<Menu, long>
    {
        
        public MenuMap() {
			Table("Menus");
			LazyLoad();
            Map(x => x.Name).Column("Name");
			Map(x => x.Controllername).Column("ControllerName");
			Map(x => x.Actionname).Column("ActionName");
			Map(x => x.Parentid).Not.Nullable().Column("ParentId");
			Map(x => x.Sortorder).Not.Nullable().Column("SortOrder");
            HasManyToMany(x => x.Profiles).Cascade.All().Inverse().Table("UserMenus");
        }
    }
}
