using System;

namespace MRV.Lead.Infra.Core.Maps;

public static class CharEnumExtensions
{
    private static byte ToByte<T>(this T @enum) where T : struct
    {
        return Convert.ToByte(@enum);
    }

    public static string Value<T>(this T @enum) where T : struct
    {
        return Convert.ToChar(@enum.ToByte()).ToString();
    }
}