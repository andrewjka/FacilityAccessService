using AutoMapper;
using Domain.AuthScope.Models;

namespace Persistence.AuthScope.Mapping;

public class RefreshTokenMapping : Profile
{
    public RefreshTokenMapping()
    {
        CreateMap<RefreshToken, Models.RefreshToken>()
            .ForMember(dest => dest.User, opt =>
                opt.Ignore());;

        CreateMap<Models.RefreshToken, RefreshToken>()
            .ConstructUsing(from => new RefreshToken(from.UserId, from.Token));
    }
}