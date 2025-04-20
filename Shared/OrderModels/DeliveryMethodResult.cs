using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.OrderModels
{
    public record DeliveryMethodResult
    {
        public int Id { get; init; }
        public string ShortName { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }//Within a day 
        public string DeliveryTime { get; init; }


    }
}
