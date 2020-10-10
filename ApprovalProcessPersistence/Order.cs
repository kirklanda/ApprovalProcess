using System;
using System.Collections.Generic;
using System.Text;

namespace ApprovalProcessPersistence
{
    class Order
    {
        public int OrderId { get; set; }

        public ICollection<OrderLineItem> OrderLineItems { get; set; } = new List<OrderLineItem>();
    }
}
