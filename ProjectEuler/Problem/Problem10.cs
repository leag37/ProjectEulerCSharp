//The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

//Find the sum of all the primes below two million.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using ProjectEuler.Utilities;

namespace ProjectEuler.Problem
{
    public class Problem10 : IProblem
    {

        public void PrintSummary()
        {
            System.Console.WriteLine("The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.");

            System.Console.WriteLine("Find the sum of all the primes below two million.");
        }

        public void Execute()
        {
            Int64 currValue = 2;
            Int64 sumPrimes = 0;
            
            while (currValue < 2000000)
            {
                if (Prime.IsPrimeNaive(currValue))
                {
                    sumPrimes += currValue;
                }

                // Increment currValue
                ++currValue;
            }

            System.Console.WriteLine(sumPrimes.ToString());
        }
    }
}
