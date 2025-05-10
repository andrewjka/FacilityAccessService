using Domain.UserScope.Models;

namespace Business.Secure.CommonScope.Context;

public interface IUserContext
{
    public User User { get; }
}