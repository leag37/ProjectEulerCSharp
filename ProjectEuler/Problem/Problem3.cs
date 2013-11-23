// The prime factors of 13195 are 5, 7, 13 and 29.
//
// What is the largest prime factor of the number 600851475143 ?

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using ProjectEuler.Utilities;

namespace ProjectEuler.Problem
{
    public class Problem3 : IProblem
    {

        public void PrintSummary()
        {
            System.Console.WriteLine("The prime factors of 13195 are 5, 7, 13 and 29.");
            System.Console.WriteLine("What is the largest prime factor of the number 600851475143 ?");
        }

        public void Execute()
        {
            // Setup starting prime value
            Int64 prime = 600851475143;

            // Get all the factors of this prime number
            ArrayList factors = Prime.PrimeFactorize(prime);
           
            // The largst factor will be the last element in the array
            Int64 largestFactor = (Int64) factors[factors.Count - 1];

            System.Console.WriteLine(largestFactor.ToString());
        }
    }
}
