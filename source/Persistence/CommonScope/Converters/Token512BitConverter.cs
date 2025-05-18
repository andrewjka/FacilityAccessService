using Domain.CommonScope.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Persistence.CommonScope.Converters;

public class Token512BitConverter : ValueConverter<Token512Bit, string>
{
    public Token512BitConverter(
    ) : base(
        ToProvider => ToProvider.GetHexFormat(),
        FromProvider => Token512Bit.GetFromHex(FromProvider)
    )
    {
    }
}