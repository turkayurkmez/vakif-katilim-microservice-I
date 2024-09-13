using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.MessageBus
{

    /*
     * Bu olay; Catalog'dan fırlatılacak ve Basket dinleyecek.
     */
    public class PriceDiscountedEvent
    {
        public DiscountPriceCommand DiscountPriceCommand { get; set; }
    }
   
    public class DiscountPriceCommand
    {
        public int ProductId { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal? NewPrice { get; set; }

    }
}
