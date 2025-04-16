﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction
{
    public interface IServiceManger
    {
        public IProductService ProductService { get; }
        public IBasketServices BasketServices { get; }
        public IAuthenticationService AuthenticationService { get; }

    }
}
