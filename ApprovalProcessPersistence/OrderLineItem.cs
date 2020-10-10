using System;
using System.Collections.Generic;
using System.Text;

namespace ApprovalProcessPersistence
{
    class OrderLineItem
    {
        public int OrderLineItemId { get; set; }
        public decimal Amount { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
