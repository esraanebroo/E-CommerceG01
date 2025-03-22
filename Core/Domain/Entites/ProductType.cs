using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class ProductType:BaseEntity<int>
    {
        //Id
        public string Name { get; set; }
    }
}
