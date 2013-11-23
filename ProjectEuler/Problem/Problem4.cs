// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
//
// Find the largest palindrome made from the product of two 3-digit numbers.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ProjectEuler.Problem
{
    public class Problem4 : IProblem
    {

        public void PrintSummary()
        {
            System.Console.WriteLine("A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.");
            System.Console.WriteLine("Find the largest palindrome made from the product of two 3-digit numbers.");
        }

        public void Execute()
        {
            // Brute force palindrome solution
            Int64 largestPalindrome = 0;
            for (Int64 i = 0; i <= 999; ++i)
            {
                for (Int64 j = 0; j <= 999; ++j)
                {
                    Int64 product = i * j;
                    if (product > largestPalindrome)
                    {
                        String p1 = product.ToString();
                        char[] ap1 = p1.ToCharArray();
                        Array.Reverse(ap1);
                        String p2 = new String(ap1);
                        if (p1 == p2)
                        {
                            // Palindrome!
                            largestPalindrome = product;
                        }
                    }
                }
            }

            System.Console.WriteLine(largestPalindrome.ToString());
        }
    }
}
