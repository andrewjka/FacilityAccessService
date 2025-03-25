#region

using System;
using System.Linq.Expressions;

#endregion

namespace FacilityAccessService.Business.CommonScope.Specification
{
    /// <summary>
    /// Contains a set of parameters for filtering the query.
    /// </summary>
    /// <typeparam name="TEntity">Entity for querying.</typeparam>
    public abstract class Specification<TEntity> where TEntity : class
    {
        // Basics generic expression
        public Expression<Func<TEntity, bool>> Expression { get; private set; }

        // Ordering expressions
        public Expression<Func<TEntity, object>> OrderBy { get; private set; }
        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }
        public bool IsOrderingUsed { get; private set; }

        // Paginating
        public int? Skip { get; protected set; }
        public int? Take { get; protected set; }
        public bool IsPaginatingUsed { get; private set; }

        // Like expression
        public Expression<Func<TEntity, string>> MatchingField { get; private set; }
        public string ApproximateSearchValue { get; private set; }
        public bool IsLikeUsed { get; private set; }


        /// <summary>
        /// Applies the expression for querying once.
        /// </summary>
        protected void ApplyExpression(Expression<Func<TEntity, bool>> expression)
        {
            Expression = expression;
        }

        /// <summary>
        /// Applies the expression for sorting in ascending order once.
        /// </summary>
        protected void ApplyOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
            IsOrderingUsed = true;
            OrderByDescending = null;
        }

        /// <summary>
        /// Applies the expression for sorting in descending order once.
        /// </summary>
        protected void ApplyOrderByDescending(Expression<Func<TEntity, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
            IsOrderingUsed = true;
            OrderBy = null;
        }

        /// <summary>
        /// Applies a match search per string field.
        /// </summary>
        protected void ApplyLike(Expression<Func<TEntity, string>> matchingField, string approximateSearchValue)
        {
            MatchingField = matchingField;
            ApproximateSearchValue = approximateSearchValue;
            IsLikeUsed = true;
        }

        /// <summary>
        /// Applies the pagination once.
        /// </summary>
        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPaginatingUsed = true;
        }
    }
}