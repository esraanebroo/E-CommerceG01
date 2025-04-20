using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.OrderModels
{
    public record OrderRequest
    {
        public int BasketId { get; init; }
        public ShippingAdressDto ShippingAdress { get; init; }
        public int DeliveryMethodId { get; init; }
    }
}
