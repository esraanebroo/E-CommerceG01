using Domain.Contracts;
using Domain.Entites.OrderEntites;

namespace Servieces.Specifications
{
    public class OrderWithIncludesSpecifications :Specifications <Order>
    {
        public OrderWithIncludesSpecifications(Guid id) : base(o=>o.Id==id)
        {
            AddInclude(o =>o.DeliveryMethod);
            AddInclude(o => o.OrderItems);
        }
        public OrderWithIncludesSpecifications(string email):base(e=>e.UserEmail==email)
        {
            AddInclude(o => o.DeliveryMethod);
            AddInclude(o => o.OrderItems);
            SetOrderBy(o => o.OrderDate);
        }
    }
}
