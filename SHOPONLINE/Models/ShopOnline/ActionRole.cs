
namespace SHOPONLINE.Models.ShopOnline
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActionRole
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public int WebActionId { get; set; }
    
        public virtual WebAction WebAction { get; set; }
        public virtual Role Role { get; set; }
    }
}
