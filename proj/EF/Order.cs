using System;
using System.Collections.Generic;

namespace proj.EF
{
    public partial class Order
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Customer { get; set; }
        public string? Performer { get; set; }
        public string? Status { get; set; }
    }
}
