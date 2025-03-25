#region

using System;
using FacilityAccessService.Domain.Secure.CommonScope.Context;

#endregion

namespace FacilityAccessService.Domain.Secure.CommonScope.Abstractions
{
    public abstract class BaseUserAuthorization
    {
        protected IUserContext _userContext;


        public BaseUserAuthorization(IUserContext userContext)
        {
            if (userContext is null) throw new ArgumentNullException(nameof(userContext));

            this._userContext = userContext;
            
            EnsureUserNotNull();
            EnsureHasPermission();
        }


        protected void EnsureUserNotNull()
        {
            if (_userContext.User is null)
            {
                throw new UnauthorizedAccessException(
                    "No user is associated with the current context. This operation requires an authenticated user."
                );
            }
        }

        protected abstract void EnsureHasPermission();
    }
}