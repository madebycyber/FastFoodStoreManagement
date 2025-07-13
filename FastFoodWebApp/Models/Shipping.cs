using System;
using System.Collections.Generic;

namespace FastFoodWebApp.Models
{
    public partial class Shipping
    {
        public string ShippingId { get; set; } = null!;
        public string? OrderId { get; set; }
        public string ShippingAddress { get; set; } = null!;
        public DateTime? ShippingDate { get; set; }
        public TimeSpan? ShippingTime { get; set; }
        public string? ShippingStatus { get; set; }

        public virtual Order? Order { get; set; }
    }
}
