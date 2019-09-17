using System.Collections.Generic;
using Model.HMS.Entity.Base;

namespace Model.HMS.Entity
{
    public class UserProfile : BaseEntity<long>
    {
        public UserProfile()
        {
        }

        public virtual string NickName { get; set; }
        public virtual byte[] Image { get; set; }
        public virtual string AspNetUserId { get; set; }
        public virtual IList<Menu> Menus { get; set; }
    }
}
