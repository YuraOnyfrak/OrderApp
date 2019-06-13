using OrderApp.Entity.EntityDTO;
using System;
using System.Collections.Generic;

namespace OrderApp
{
    public partial class Payments
    {
        public int Id { get; set; }
        public string MethodName { get; set; }
        public decimal Amount { get; set; }
        public long OrderOxId { get; set; }

        public virtual Orders OrderOx { get; set; }
    }
}
