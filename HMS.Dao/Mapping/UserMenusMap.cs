using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Model.JobLanes.Entity;


namespace Dao.Joblanes.Mapping {
    
    
    public class UserMenusMap : ClassMapping<User_Menus> {
        
        public UserMenusMap() {
			Table("UserMenus");
			Schema("dbo");
			Lazy(true);
			Id(x => x.Id, map => map.Generator(Generators.Identity));
			Property(x => x.User_Id, map => map.Column("UserId"));
			Property(x => x.Menu_Id, map => { map.Column("MenuId"); map.NotNullable(true); });
        }
    }
}
