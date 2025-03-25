#region

using System;
using System.Linq.Expressions;
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.UserScope.Models;

#endregion

namespace FacilityAccessService.Business.UserScope.Specifications
{
    /// <summary>
    /// This specification is created for the general case of filtering, when parameters are not known in advance.
    /// </summary>
    public class NonDeterminedSpecification<TEntity> : Specification<TEntity> where TEntity : class
    {
        public NonDeterminedSpecification(
            int? offset = null,
            int? take = null,
            Expression<Func<TEntity, string>> matchingField = null,
            string approximateSearchValue = null
        )
        {
            if (offset is not null && take is not null)
            {
                ApplyPaging((int)offset, (int)take);
            }
            else if ((offset is null) != (take is null))
            {
                throw new ArgumentNullException(
                    $"Both arguments must be given or not at all: '{nameof(offset)}' '{nameof(take)}' ");
            }

            if (matchingField is not null && !string.IsNullOrEmpty(approximateSearchValue))
            {
                ApplyLike(matchingField, approximateSearchValue);
            }
            else if ((offset is null) != (take is null))
            {
                throw new ArgumentNullException(
                    $"Both arguments must be given or not at all: '{nameof(matchingField)}' '{nameof(approximateSearchValue)}' "
                );
            }
        }
    }
}