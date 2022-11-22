
namespace SHOPONLINE.Models.ShopOnline
{
    using System;
    using System.Collections.Generic;
    
    public partial class WebAction
    {
        public WebAction()
        {
            this.ActionRoles = new HashSet<ActionRole>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<ActionRole> ActionRoles { get; set; }
    }
}
