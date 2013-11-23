// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
//
// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ProjectEuler.Problem
{
    public class Problem5 : IProblem
    {

        public void PrintSummary()
        {
            System.Console.WriteLine("2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.");
            System.Console.WriteLine("What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?");
        }

        public void Execute()
        {
            // Brute force palindrome solution
            Int64 smallestDivisible = 0;
            
            // Condition met
            bool foundValue = false;
            while (foundValue == false)
            {
                // Increment (by 20 since 20 is the largest multiple)
                smallestDivisible += 20;

                // Try to divide by each value with 1 being given (assume we will find a value)
                foundValue = true;
                for (Int64 i = 2; i <= 20; ++i)
                {
                    if (smallestDivisible % i != 0)
                    {
                        foundValue = false;
                        break;
                    }
                }
            }

            System.Console.WriteLine(smallestDivisible.ToString());
        }
    }
}
