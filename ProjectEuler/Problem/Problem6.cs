//The sum of the squares of the first ten natural numbers is,
//12 + 22 + ... + 102 = 385
//The square of the sum of the first ten natural numbers is,
//(1 + 2 + ... + 10)2 = 552 = 3025
//Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
//Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ProjectEuler.Problem
{
    public class Problem6 : IProblem
    {

        public void PrintSummary()
        {
            System.Console.WriteLine("The sum of the squares of the first ten natural numbers is,");
            System.Console.WriteLine("12 + 22 + ... + 102 = 385");
            System.Console.WriteLine("The square of the sum of the first ten natural numbers is,");
            System.Console.WriteLine("(1 + 2 + ... + 10)2 = 552 = 3025");
            System.Console.WriteLine("Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.");
            System.Console.WriteLine("Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.");
        }

        public void Execute()
        {
            Int64 difference = 0;

            Int64 sumOfSquares = 0;
            Int64 squareOfSums = 0;

            for (Int64 i = 1; i <= 100; ++i)
            {
                // Sum of squares
                sumOfSquares += i * i;

                // Square of sums
                squareOfSums += i;
            }

            // Square square of sums
            squareOfSums *= squareOfSums;

            // Find difference
            difference = squareOfSums - sumOfSquares;

            System.Console.WriteLine(difference.ToString());
        }
    }
}
