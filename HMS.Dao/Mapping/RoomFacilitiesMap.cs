using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Model.JobLanes.Entity;


namespace Dao.Joblanes.Mapping {
    
    
    public class RoomFacilitiesMap : ClassMapping<Room_Facilities> {
        
        public RoomFacilitiesMap() {
			Table("RoomFacilities");
			Schema("dbo");
			Lazy(true);
			Id(x => x.Id, map => map.Generator(Generators.Identity));
			Property(x => x.Version_Number, map => { map.Column("VersionNumber"); map.NotNullable(true); });
			Property(x => x.Business_Id, map => map.Column("BusinessId"));
			Property(x => x.Creation_Date, map => map.Column("CreationDate"));
			Property(x => x.Modification_Date, map => map.Column("ModificationDate"));
			Property(x => x.Status);
			Property(x => x.Create_By, map => map.Column("CreateBy"));
			Property(x => x.Modify_By, map => map.Column("ModifyBy"));
			Property(x => x.Name);
			ManyToOne(x => x.Room_Type, map => 
			{
				map.Column("RoomTypeId");
				map.NotNullable(true);
				map.Cascade(Cascade.None);
			});

        }
    }
}
