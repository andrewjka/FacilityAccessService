using Domain.CommonScope.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Persistence.TerminalScope.Converters;

public class TerminalTokenConverter : ValueConverter<Token512Bit, string>
{
    public TerminalTokenConverter(
    ) : base(
        ToProvider => ToProvider.GetHexFormat(),
        FromProvider => Token512Bit.GetFromHex(FromProvider)
    )
    {
    }
}