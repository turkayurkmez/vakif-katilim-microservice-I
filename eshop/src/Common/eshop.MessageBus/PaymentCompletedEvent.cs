using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.MessageBus
{
    public class PaymentCompletedEvent
    {
        public PaymentCompletedCommand PaymentCompletedCommand { get; set; }
    }

    public class PaymentCompletedCommand
    {
        public int OrderId { get; set; }
    }
}
