using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Model.JobLanes.Entity;


namespace Dao.Joblanes.Mapping {
    
    
    public class MenusMap : ClassMapping<Menus> {
        
        public MenusMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Id, map => map.Generator(Generators.Identity));
			Property(x => x.Name);
			Property(x => x.Controller_Name, map => map.Column("ControllerName"));
			Property(x => x.Action_Name, map => map.Column("ActionName"));
			Property(x => x.Parent_Id, map => { map.Column("ParentId"); map.NotNullable(true); });
			Property(x => x.Sort_Order, map => { map.Column("SortOrder"); map.NotNullable(true); });
        }
    }
}
