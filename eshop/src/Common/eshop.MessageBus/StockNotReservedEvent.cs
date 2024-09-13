using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.MessageBus
{
    public class StockNotReservedEvent
    {
        public StockNotReservedCommand StockNotReservedCommand { get; set; }
    }

    public class StockNotReservedCommand
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
    }
}
