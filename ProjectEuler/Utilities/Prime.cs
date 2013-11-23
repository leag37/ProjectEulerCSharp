using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ProjectEuler.Utilities
{
    public static class Prime
    {
        /// <summary>
        /// Use the AKS Primality Test for determining whether a number is prime or not
        /// Input: integer n > 1.
        /// If n = a^b for integers a > 1 and b > 1, output composite.
        /// Find the smallest r such that or(n) > (log n)^2.
        /// If 1 < gcd(a,n) < n for some a ≤ r, output composite.
        /// If n ≤ r, output prime.
        /// For a = 1 to \scriptstyle\lfloor \scriptstyle{\sqrt{\varphi(r)}\log(n)} \scriptstyle\rfloor do
        /// if (X+a)n≠ Xn+a (mod Xr − 1,n), output composite;
        /// Output prime.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPrime(Int64 n)
        {
            // Is the integer > 1
            if (n <= 1)
            {
                return false;
            }

            // Test if n = a^b for some a,b > 1
            if (TestPowers(n) == true)
            {
                return false;
            }

            // Test multiplicative order
            Int64 order = TestMultiplicativeOrder(n);

            // Test for gcd
            if (TestGCD(n, order) == true)
            {
                return false;
            }

            // If n <= r, prime
            if (n <= order)
            {
                return true;
            }

            if (TestTotient(n, order) == true)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Test conditionn = a^b for integers a>1 and b>1.
        /// </summary>
        /// <param name="n"></param>
        /// <returns>True if the test fails to find a valid a, b</returns>
        private static bool TestPowers(Int64 n)
        {
            Int64 a = 2;
            Int64 b = 2;

            bool canTest = true;
            while (canTest == true)
            {
                // Get the value of a, b
                Int64 pow = MathUtils.Pow(a, b);
                
                // Pow = n, test fails, return true
                if (pow == n)
                {
                    return false;
                }
                // Pow > n, reset a and b
                else if (pow > n)
                {
                    // If b is already 2, fail test
                    if (b == 2)
                    {
                        return false;
                    }

                    ++a;
                    b = 2;
                }
                else
                {
                    ++b;
                }
            }

            // Test passed, return true
            return true;
        }

        // Test multiplicative order
        private static Int64 TestMultiplicativeOrder(Int64 n)
        {
            // Find log(n)^2 (convert n to double)
            double dN = Convert.ToDouble(n);
            double log = Math.Log(dN, 2);
            log *= log;
            Int64 iLog = Convert.ToInt64(log);

            // Find the multiplicative order such that or(n) > log (must be at least 2, since anything mod1 is always 0
            Int64 r = 2;
            for(;;)
            {
                // Get the order
                Int64 order = MathUtils.MultiplicativeOrder(n, r);
                if (order > log)
                {
                    return r;
                }
                ++r;
            }

            return 0;
        }

        // Test for If 1 < gcd(a,n) < n for some a ≤ r, output composite.
        private static bool TestGCD(Int64 n, Int64 r)
        {
            // Find GCD for all a in 2 -> r
            for (Int64 i = 2; i <= r; ++i)
            {
                // Get the gcd
                Int64 gcd = MathUtils.GreatestCommonDivisor(i, n);
                if (1 < gcd && gcd < n)
                {
                    return true;
                }
            }
            return false;
        }

        // Test Euler's totient function
        // For a = 1 to floor(sqrt(phi(r))log(n)) do
        // if (X+a)^n≠ X^n+a (mod X^r − 1,n), output composite;
        private static bool TestTotient(Int64 n, Int64 r)
        {
            // First, prime factorize. Then, go through each prime factor and perform the following equation:
            // (1 - 1/p0)(1 - 1/p1)(1 - 1/p2)... * n
            ArrayList factorsR = PrimeFactorize(r);
            Double totient = 1;
            foreach (Int64 i in factorsR)
            {
                totient *= (1.0 - 1.0 / Convert.ToDouble(i));
            }
            totient *= r;
            Int64 iTotient = Convert.ToInt64(totient);
            totient = Convert.ToDouble(iTotient);

            // Sqrt of the totient
            Double sqrtTotient = Math.Sqrt(totient);
            Double logn = Math.Log(n, 2);
            Int64 limit = Convert.ToInt64(Math.Floor(logn * sqrtTotient));
            for (Int64 i = 1; i <= limit; ++i)
            {
                // Find 
            }

            return true;
        }

        // Returns the prime factors of a number
        public static ArrayList PrimeFactorize(Int64 n)
        {
            ArrayList factors = new ArrayList();

            // Ceiling starts as n
            Int64 ceil = n;
            for (Int64 i = 2; i <= ceil; ++i)
            {
                if (ceil % i == 0)
                {
                    // Add to array list
                    factors.Add(i);

                    // Divide until we can't divide anymore
                    while (ceil % i == 0)
                    {
                        ceil /= i;
                    }
                }
            }
            return factors;
        }

        /** Naive test for primality */
        public static bool IsPrimeNaive(Int64 n)
        {
            for (Int64 i = 2; i < n; ++i)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
