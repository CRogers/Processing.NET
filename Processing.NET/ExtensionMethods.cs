using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Processing.NET
{
    public static class ExtensionMethods
    {
        public static bool AnyOf<T>(this T item, params T[] tests)
        {
            return tests.Contains(item);
        }
    }
}
