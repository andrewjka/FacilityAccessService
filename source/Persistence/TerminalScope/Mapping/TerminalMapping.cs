using AutoMapper;
using Domain.TerminalScope.Models;

namespace Persistence.TerminalScope.Mapping;

public class TerminalMapping : Profile
{
    public TerminalMapping()
    {
        CreateMap<Terminal, Models.Terminal>();
        CreateMap<Models.Terminal, Terminal>()
            .ConstructUsing(from => new Terminal(
                from.Name,
                from.Token,
                from.ExpiredTokenOn)
            );
    }
}