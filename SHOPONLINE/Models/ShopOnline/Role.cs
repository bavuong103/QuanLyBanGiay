
namespace SHOPONLINE.Models.ShopOnline
{
    using System;
    using System.Collections.Generic;
    
    public partial class Role
    {
        public Role()
        {
            this.ActionRoles = new HashSet<ActionRole>();
            this.MasterRoles = new HashSet<MasterRole>();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<ActionRole> ActionRoles { get; set; }
        public virtual ICollection<MasterRole> MasterRoles { get; set; }
    }
}
