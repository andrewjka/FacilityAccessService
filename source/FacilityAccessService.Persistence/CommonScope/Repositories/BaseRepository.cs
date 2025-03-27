using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Execution;
using AutoMapper.Extensions.ExpressionMapping;
using FacilityAccessService.Business.CommonScope.Repositories;
using FacilityAccessService.Business.CommonScope.Specification;
using Microsoft.EntityFrameworkCore;

namespace FacilityAccessService.Persistence.CommonScope.Repositories
{
    /// <summary>
    ///     Describes a base class for all repository implementations. It operates on a business entity and its equivalent
    ///     for database representation.
    /// </summary>
    /// <typeparam name="TEntityDB">A database entity representing a business model.</typeparam>
    /// <typeparam name="TEntityBusiness">Business model.</typeparam>
    public abstract class BaseRepository<TEntityDB, TEntityBusiness> : IBaseRepository<TEntityBusiness>
        where TEntityDB : class
        where TEntityBusiness : class
    {
        protected readonly AppDatabaseContext _context;

        protected readonly IMapper _mapper;


        public BaseRepository(AppDatabaseContext context, IMapper mapper)
        {
            if (context is null) throw new ArgumentNullException(nameof(context));
            if (mapper is null) throw new ArgumentNullException(nameof(mapper));

            _context = context;
            _mapper = mapper;
        }


        public abstract Task<TEntityBusiness> FirstByAsync(
            Specification<TEntityBusiness> specification
        );

        public abstract Task<ReadOnlyCollection<TEntityBusiness>> SelectByAsync(
            Specification<TEntityBusiness> specification
        );

        public abstract Task<int> DeleteByAsync(
            Specification<TEntityBusiness> specification
        );


        public virtual Task CreateAsync(TEntityBusiness model)
        {
            _context.Add(_mapper.Map<TEntityDB>(model));

            return Task.CompletedTask;
        }

        public virtual Task UpdateAsync(TEntityBusiness model)
        {
            _context.Update(_mapper.Map<TEntityDB>(model));

            return Task.CompletedTask;
        }

        public virtual Task DeleteAsync(TEntityBusiness model)
        {
            _context.Remove(_mapper.Map<TEntityDB>(model));

            return Task.CompletedTask;
        }


        protected virtual void BuildQueryBasedSpecification(
            ref IQueryable<TEntityDB> queryable,
            Specification<TEntityBusiness> specification
        )
        {
            if (specification.Expression is not null)
            {
                var _expression =
                    _mapper.MapExpression<Expression<Func<TEntityDB, bool>>>(specification.Expression);

                queryable = queryable.Where(_expression);
            }

            if (specification.OrderBy is not null)
            {
                var _orderBy =
                    _mapper.MapExpression<Expression<Func<TEntityDB, object>>>(specification.OrderBy);

                queryable = queryable.OrderBy(_orderBy);
            }
            else if (specification.OrderByDescending is not null)
            {
                var _orderByDescending =
                    _mapper.MapExpression<Expression<Func<TEntityDB, object>>>(specification.OrderBy);

                queryable = queryable.OrderByDescending(_orderByDescending);
            }

            if (specification.IsPaginatingUsed)
            {
                queryable = queryable.Take((int)specification.Take);
                queryable = queryable.Skip((int)specification.Offset);
            }
        }
    }
}