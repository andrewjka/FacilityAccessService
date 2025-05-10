using Domain.TerminalScope.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Persistence.TerminalScope.Converters;

public class TerminalTokenConverter : ValueConverter<TerminalToken, string>
{
    public TerminalTokenConverter(
    ) : base(
        ToProvider => ToProvider.GetHexFormat(),
        FromProvider => TerminalToken.GetFromHex(FromProvider)
    )
    {
    }
}