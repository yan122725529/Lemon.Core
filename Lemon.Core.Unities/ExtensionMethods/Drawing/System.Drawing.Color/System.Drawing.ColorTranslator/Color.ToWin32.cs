// Copyright (c) 2015 ZZZ Projects. All rights reserved
// Licensed under MIT License (MIT) (https://github.com/zzzprojects/Z.ExtensionMethods)
// Website: http://www.zzzprojects.com/
// Feedback / Feature Requests / Issues : http://zzzprojects.uservoice.com/forums/283927
// All ZZZ Projects products: Entity Framework Extensions / Bulk Operations / Extension Methods /Icon Library

using System;
using System.Drawing;

public static partial class Extensions
{
    /// <summary>
    ///     Translates the specified  structure to a Windows color.
    /// </summary>
    /// <param name="c">The  structure to translate.</param>
    /// <returns>The Windows color value.</returns>
    public static Int32 ToWin32(this Color c)
    {
        return ColorTranslator.ToWin32(c);
    }
}