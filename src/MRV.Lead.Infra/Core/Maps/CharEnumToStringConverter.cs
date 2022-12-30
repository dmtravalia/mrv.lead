using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;
using System;

namespace MRV.Lead.Infra.Core.Maps;

public class CharEnumToStringConverter<TEnum> : ValueConverter<TEnum, string> where TEnum : struct
{
    public CharEnumToStringConverter()
        : base((Expression<Func<TEnum, string>>)((TEnum x) => ToProvider(x)), (Expression<Func<string, TEnum>>)((string x) => FromProvider(x)), (ConverterMappingHints)null)
    {
    }

    private static string ToProvider(TEnum @enum)
    {
        return @enum.Value();
    }

    private static TEnum FromProvider(string value)
    {
        return Enum.Parse<TEnum>(Convert.ToByte(Convert.ToChar(value)).ToString());
    }
}