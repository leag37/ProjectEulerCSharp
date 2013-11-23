// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
//
// Find the sum of all the multiples of 3 or 5 below 1000.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectEuler.Utilities;

namespace ProjectEuler.Problem
{
    public class Problem1 : IProblem
    {

        /// <summary>
        /// Initializes the Problem1 class
        /// </summary>
        public Problem1()
        {

        }

        public void Execute()
        {
            // Sum of multiples
            int sum = 0;

            // Iterate through 1 -> 1000
            for (int i = 0; i < 1000; ++i)
            {
                if (MathUtils.IsMultiple(i, 3) || MathUtils.IsMultiple(i, 5))
                {
                    sum += i;
                }
            }

            System.Console.WriteLine(sum.ToString());
        }

        public void PrintSummary()
        {
            System.Console.WriteLine("If we list all the natural numbers below 10 that are multiples " +
                "of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23. Find the sum of all " +
                "the multiples of 3 or 5 below 1000.");
        }
    }
}
