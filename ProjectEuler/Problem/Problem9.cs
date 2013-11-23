//A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
//a2 + b2 = c2

//For example, 32 + 42 = 9 + 16 = 25 = 52.

//There exists exactly one Pythagorean triplet for which a + b + c = 1000.
//Find the product abc.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using ProjectEuler.Utilities;
using ProjectEuler.Primes;

namespace ProjectEuler.Problem
{
    public class Problem9 : IProblem
    {

        public void PrintSummary()
        {
            System.Console.WriteLine("A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,");
            System.Console.WriteLine("a2 + b2 = c2");

            System.Console.WriteLine("For example, 32 + 42 = 9 + 16 = 25 = 52.");

            System.Console.WriteLine("There exists exactly one Pythagorean triplet for which a + b + c = 1000.");
            System.Console.WriteLine("Find the product abc.");

        }

        public void Execute()
        {
            // Setup
            int triplet1 = 0;
            int triplet2 = 0;
            int triplet3 = 0;

            for (int i = 0; i < 1000; ++i)
            {
                for (int j = i + 1; j < 1000; ++j)
                {
                    for (int k = j + 1; k < 1000; ++k)
                    {
                        // Check that this value is a triplet
                        if (i * i + j * j == k * k)
                        {
                            // Check that the sum is 1000
                            if (i + j + k == 1000)
                            {
                                // We found our triplet
                                triplet1 = i;
                                triplet2 = j;
                                triplet3 = k;
                            }
                        }
                    }
                }
            }

            int tripProd = triplet1 * triplet2 * triplet3;

            System.Console.WriteLine("a: " + triplet1.ToString() + " b: " + triplet2.ToString() + " c: " + triplet3.ToString());
            System.Console.WriteLine("Product: " + tripProd.ToString());
        }
    }
}
