
namespace SHOPONLINE.Models.ShopOnline
{
    using System;
    using System.Collections.Generic;
    
    public partial class MasterRole
    {
        public int Id { get; set; }
        public string MasterId { get; set; }
        public string RoleId { get; set; }
    
        public virtual Role Role { get; set; }
        public virtual Master Master { get; set; }
    }
}
