using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class BasketNotFoundExceptions:NotFoundExceptions
    {
        public BasketNotFoundExceptions(string id ):base($"The Basket with id {id} is not found") { }
       

    }
}
