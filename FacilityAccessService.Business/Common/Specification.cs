using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FacilityAccessService.Business.Common.Specification
{
    public abstract class Specification<T> where T : class
    {
        public Expression<Func<T, bool>> Expression { get; private set; }
        public List<Expression<Func<T, object>>> Includes { get; private set; }
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        public int Skip { get; protected set; }
        public int Take { get; protected set; }

        
        protected void ApplyExpression(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
            OrderByDescending = null;
        }

        protected void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
            OrderBy = null;
        }
        
        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
    }
}