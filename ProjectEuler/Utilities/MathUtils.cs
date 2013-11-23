using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Utilities
{
    public static class MathUtils
    {
        /// <summary>
        /// Return whether the number is a multiple of another number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="multiple"></param>
        /// <returns></returns>
        public static bool IsMultiple(int number, int multiple)
        {
            return (number % multiple == 0);
        }

        /// <summary>
        /// Generate the next term in the fibonacci sequence
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int NextFibonacci(int a, int b)
        {
            return a + b;
        }

        public static Int64 Pow(Int64 a, Int64 b)
        {
            Int64 res = a;
            for (Int64 i = 1; i < b; ++i)
            {
                res *= a;
            }

            return res;
        }

        // Find the multiplicative order of a module n
        public static Int64 MultiplicativeOrder(Int64 a, Int64 n)
        {
            // Get the greatest common divisor
            Int64 order = 0;
            if (GreatestCommonDivisor(a, n) == 1)
            {
                // Find the smallest integer k such that a^k = 1 (mod n)
                for(;;)
                {
                    // Increment order
                    ++order;

                    // Find power
                    Int64 pow = MathUtils.Pow(a, order);

                    // If mod n is 1, match
                    if (pow % n == 1)
                    {
                        break;
                    }
                }
            }
            return order;
        }

        // Find the greatest common divisor of a and b
        public static Int64 GreatestCommonDivisor(Int64 a, Int64 b)
        {
            Int64 divisor = 1;

            // First, ensure that a > b
            if (a < b)
            {
                Utils.Swap<Int64>(ref a, ref b);
            }

            // Find the number of times b divides into a
            Int64 quotient = 0;
            Int64 resultant = 1;
            while (a != 0)
            {
                while (a >= b)
                {
                    a -= b;
                    ++quotient;
                }

                // Swap a and b so that the remainder is now b and a is the new base value
                if (a != 0)
                {
                    resultant = b;
                    Utils.Swap<Int64>(ref a, ref b);
                    quotient = 0;
                }
                
            }

            return divisor;
        }

        // Find the number of divisors for a given number
        public static Int64 NumDivisors(Int64 n)
        {
            Int64 divisors = 1;
            Int64 factor = 2;

            while (n > 1)
            {
                // Find the number of times we can divide our number
                Int64 divisions = 0;
                while (n % factor == 0)
                {
                    n /= factor;
                    ++divisions;
                }

                // Our number of divisors increases by divisors * (divisions + 1) iff divisions > 0
                if (divisions > 0)
                {
                    divisors *= (divisions + 1);
                }

                ++factor;
            }

            return divisors;
        }
    }
}
