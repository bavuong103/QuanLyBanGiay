namespace SHOPONLINE.Models.ShopOnline
{
    using System;
    using System.Collections.Generic;
    
    public partial class Master
    {
        public Master()
        {
            this.MasterRoles = new HashSet<MasterRole>();
        }
    
        public string Id { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    
        public virtual ICollection<MasterRole> MasterRoles { get; set; }
    }
}
