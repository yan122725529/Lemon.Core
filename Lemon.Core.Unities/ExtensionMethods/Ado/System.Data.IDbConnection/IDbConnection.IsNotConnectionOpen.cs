
// Licensed under MIT License (MIT) (https://github.com/zzzprojects/Z.ExtensionMethods)
// Website: http://www.zzzprojects.com/
// Feedback / Feature Requests / Issues : http://zzzprojects.uservoice.com/forums/283927
// All ZZZ Projects products: Entity Framework Extensions / Bulk Operations / Extension Methods /Icon Library

using System.Data;
using System.Data.Common;

public static partial class Extensions
{
    /// <summary>A DbConnection extension method that queries if a not connection is open.</summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>true if a not connection is open, false if not.</returns>
    public static bool IsNotConnectionOpen(this DbConnection @this)
    {
        return @this.State != ConnectionState.Open;
    }
}