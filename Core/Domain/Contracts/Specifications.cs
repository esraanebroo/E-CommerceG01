using System.Linq.Expressions;

namespace Domain.Contracts
{
    public abstract class Specifications <T> where T : class
    {
        //Where/Expretion
        public Expression<Func<T,bool>> ? Criteria { get;} //where
        public List<Expression<Func<T, object>>> IncludeExpressions { get; } = new();//Navegtional prop
        //sort
        public Expression<Func<T,object>> OrderBy { get; private set; } 
        public Expression<Func<T,object>> OrderByDescending { get; private set; }
        //Pagination
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPaginated { get; private set; }


        protected Specifications(Expression<Func<T, bool>> ? criteria)
        {
            Criteria = criteria;
        }

        protected void AddInclude(Expression<Func<T, object>> expression)
            => IncludeExpressions.Add(expression);
        
        protected void SetOrderBy(Expression<Func<T,object>> expression)
            =>OrderBy = expression;
        protected void SetOrderByDescending(Expression<Func<T,object>> expression)
            =>OrderByDescending = expression;

        protected void ApplyPagination(int pageIndex, int PageSize) 
        {  
            IsPaginated = true;
            Take=PageSize;
            Skip=(pageIndex-1)*PageSize;
        }

    }
}
