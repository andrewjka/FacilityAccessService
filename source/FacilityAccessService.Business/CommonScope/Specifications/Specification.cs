using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FacilityAccessService.Business.CommonScope.Specification
{
    /// <summary>
    /// Contains a set of parameters for filtering the query.
    /// </summary>
    /// <typeparam name="T">Entity for querying.</typeparam>
    public abstract class Specification<T> where T : class
    {
        public Expression<Func<T, bool>> Expression { get; private set; }
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        public int? Skip { get; protected set; }
        public int? Take { get; protected set; }

        /// <summary>
        /// Applies the expression for querying once.
        /// </summary>
        protected void ApplyExpression(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }
        
        /// <summary>
        /// Applies the expression for sorting in ascending order once.
        /// </summary>
        protected void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
            OrderByDescending = null;
        }
        
        /// <summary>
        /// Applies the expression for sorting in descending order once.
        /// </summary>
        protected void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
            OrderBy = null;
        }
        
        /// <summary>
        /// Applies the pagination once.
        /// </summary>
        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
    }
}