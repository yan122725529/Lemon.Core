
// Licensed under MIT License (MIT) (https://github.com/zzzprojects/Z.ExtensionMethods)
// Website: http://www.zzzprojects.com/
// Feedback / Feature Requests / Issues : http://zzzprojects.uservoice.com/forums/283927
// All ZZZ Projects products: Entity Framework Extensions / Bulk Operations / Extension Methods /Icon Library

using System;
using System.Globalization;

public static partial class Extensions
{
    /// <summary>
    ///     A DateTime extension method that converts this object to a rfc 1123 string.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>The given data converted to a string.</returns>
    public static string ToRFC1123String(this DateTime @this)
    {
        return @this.ToString("r", DateTimeFormatInfo.CurrentInfo);
    }

    /// <summary>
    ///     A DateTime extension method that converts this object to a rfc 1123 string.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="culture">The culture.</param>
    /// <returns>The given data converted to a string.</returns>
    public static string ToRFC1123String(this DateTime @this, string culture)
    {
        return @this.ToString("r", new CultureInfo(culture));
    }

    /// <summary>
    ///     A DateTime extension method that converts this object to a rfc 1123 string.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="culture">The culture.</param>
    /// <returns>The given data converted to a string.</returns>
    public static string ToRFC1123String(this DateTime @this, CultureInfo culture)
    {
        return @this.ToString("r", culture);
    }
}