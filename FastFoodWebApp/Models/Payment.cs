using System;
using System.Collections.Generic;

namespace FastFoodWebApp.Models
{
    public partial class Payment
    {
        public string PaymentId { get; set; } = null!;
        public string? OrderId { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public string? PaymentStatus { get; set; }
        public DateTime? PaymentDate { get; set; }
        public TimeSpan? PaymentTime { get; set; }

        public virtual Order? Order { get; set; }
    }
}
