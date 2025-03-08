using System;

namespace FacilityAccessService.Business.CommonScope.PersistenceContext
{
    public interface IPersistenceContext : ITransaction, IUnitWork
    {
    }
}