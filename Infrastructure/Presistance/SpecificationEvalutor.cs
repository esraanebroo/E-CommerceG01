using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance
{
    internal static class SpecificationEvalutor
    {
        public static IQueryable<T> GetQuery<T>(IQueryable<T> inputQuery, Specifications<T> specifications) where T : class 
        {
            var query = inputQuery;
            if (specifications.Criteria is not null)
                query=query.Where(specifications.Criteria);//where
            foreach (var item in specifications.IncludeExpressions) 
            {
                query = query.Include(item);
            }

           // query=specifications.IncludeExpressions.Aggregate(query,(currentQuery,includeExpression)=>currentQuery.Include(includeExpression));
            return query;



        }
    }
}
