using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.MessageBus
{
    public class StockReservedEvent 
    {
        public StockReservedCommand StockReservedCommand { get; set; }
    }

    public class StockReservedCommand
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string? CreditCardInfo { get; set; }

    }
}
