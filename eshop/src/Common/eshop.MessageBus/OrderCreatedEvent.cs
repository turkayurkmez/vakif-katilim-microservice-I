using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.MessageBus
{
    public class OrderCreatedEvent 
    {
        //public Guid Id { get; set; }
        //public DateTime EventDate { get; set; }

        public  OrderCreatedCommand OrderCreatedCommand { get; set; }

    }

    public class OrderCreatedCommand
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string? CreditCardInfo { get; set; }

    }

    public class OrderItem
    {
        public int ProductId { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
    }
}

