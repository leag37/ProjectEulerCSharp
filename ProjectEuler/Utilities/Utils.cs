using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Utilities
{
    public static class Utils
    {
        // Swap
        internal static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
}
