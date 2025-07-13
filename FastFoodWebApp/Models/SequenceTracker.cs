using System;
using System.Collections.Generic;

namespace FastFoodWebApp.Models
{
    public partial class SequenceTracker
    {
        public string TableName { get; set; } = null!;
        public int NextValue { get; set; }
    }
}
