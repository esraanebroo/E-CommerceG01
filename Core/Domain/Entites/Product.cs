using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Product:BaseEntity<int>
    {
        //Id
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        //Navigtional property one[Brand] to many[product]
        public ProductBrand productBrand { get; set; }
        public int BrandId { get; set; }              //FK
        //Navigtional property one[Type] to many[product]
        public ProductType ProductType { get; set; }
        public int TypeId { get; set; }               //FK
    }
}
