
namespace SHOPONLINE.Models.ShopOnline
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public System.DateTime RequireDate { get; set; }
        public string Receiver { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
