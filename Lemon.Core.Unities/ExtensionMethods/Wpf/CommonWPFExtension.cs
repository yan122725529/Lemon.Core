using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ZilLion.Core.Infrastructure.Extensions
{
    public static class CommonWPFExtension
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IList<T> list)
        {
            return new ObservableCollection<T>(list);
        }
    }
}