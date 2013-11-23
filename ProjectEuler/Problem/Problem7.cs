//By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
//What is the 10 001st prime number?

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using ProjectEuler.Utilities;
using ProjectEuler.Primes;

namespace ProjectEuler.Problem
{
    public class Problem7 : IProblem
    {

        public void PrintSummary()
        {
            System.Console.WriteLine("By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.");
            System.Console.WriteLine("What is the 10 001st prime number?");
        }

        public void Execute()
        {
            Int64 prime = 1;
            Int64 numPrimes = 0;

            // Create a sieve
            PrimeSieve sieve = new PrimeSieve();

            while(numPrimes != 10001)
            {
                // Increment prime value
                ++prime;
                if (sieve.IsPrime(prime))
                {
                    ++numPrimes;
                }
            }

            System.Console.WriteLine(prime.ToString());
        }
    }
}
