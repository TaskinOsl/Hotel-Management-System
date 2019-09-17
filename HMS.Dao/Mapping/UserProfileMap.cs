using Dao.HMS.Mapping.Base;
using Model.HMS.Entity;

namespace Dao.HMS.Mapping
{
    public partial class UserProfileMap : BaseClassMap<UserProfile, long>
    {
        public UserProfileMap()
        {
            Table("UserProfile");
            LazyLoad();
            Map(x => x.Name).Column("Name");
            Map(x => x.NickName).Column("NickName");
            Map(x => x.AspNetUserId).Column("AspNetUserId");
            HasManyToMany(x => x.Menus).Cascade.All().Table("UserMenus");
            

        }
    }
}
