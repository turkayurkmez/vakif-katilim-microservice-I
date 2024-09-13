using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.MessageBus
{
    public class PaymentFailedEvent
    {
        public PaymentFailedCommand PaymentFailedCommand { get; set; }
    }

    public class PaymentFailedCommand
    {
        public int OrderId { get; set; }
        public string Reason { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
