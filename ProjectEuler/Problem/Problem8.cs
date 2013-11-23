﻿//Find the greatest product of five consecutive digits in the 1000-digit number.

//73167176531330624919225119674426574742355349194934
//96983520312774506326239578318016984801869478851843
//85861560789112949495459501737958331952853208805511
//12540698747158523863050715693290963295227443043557
//66896648950445244523161731856403098711121722383113
//62229893423380308135336276614282806444486645238749
//30358907296290491560440772390713810515859307960866
//70172427121883998797908792274921901699720888093776
//65727333001053367881220235421809751254540594752243
//52584907711670556013604839586446706324415722155397
//53697817977846174064955149290862569321978468622482
//83972241375657056057490261407972968652414535100474
//82166370484403199890008895243450658541227588666881
//16427171479924442928230863465674813919123162824586
//17866458359124566529476545682848912883142607690042
//24219022671055626321111109370544217506941658960408
//07198403850962455444362981230987879927244284909188
//84580156166097919133875499200524063689912560717606
//05886116467109405077541002256983155200055935729725
//71636269561882670428252483600823257530420752963450

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using ProjectEuler.Utilities;
using ProjectEuler.Primes;

namespace ProjectEuler.Problem
{
    public class Problem8 : IProblem
    {

        public void PrintSummary()
        {
            System.Console.WriteLine("Find the greatest product of five consecutive digits in the 1000-digit number.");
            System.Console.WriteLine("73167176531330624919225119674426574742355349194934");
            System.Console.WriteLine("96983520312774506326239578318016984801869478851843");
            System.Console.WriteLine("85861560789112949495459501737958331952853208805511");
            System.Console.WriteLine("12540698747158523863050715693290963295227443043557");
            System.Console.WriteLine("66896648950445244523161731856403098711121722383113");
            System.Console.WriteLine("62229893423380308135336276614282806444486645238749");
            System.Console.WriteLine("30358907296290491560440772390713810515859307960866");
            System.Console.WriteLine("70172427121883998797908792274921901699720888093776");
            System.Console.WriteLine("65727333001053367881220235421809751254540594752243");
            System.Console.WriteLine("52584907711670556013604839586446706324415722155397");
            System.Console.WriteLine("53697817977846174064955149290862569321978468622482");
            System.Console.WriteLine("83972241375657056057490261407972968652414535100474");
            System.Console.WriteLine("82166370484403199890008895243450658541227588666881");
            System.Console.WriteLine("16427171479924442928230863465674813919123162824586");
            System.Console.WriteLine("17866458359124566529476545682848912883142607690042");
            System.Console.WriteLine("24219022671055626321111109370544217506941658960408");
            System.Console.WriteLine("07198403850962455444362981230987879927244284909188");
            System.Console.WriteLine("84580156166097919133875499200524063689912560717606");
            System.Console.WriteLine("05886116467109405077541002256983155200055935729725");
            System.Console.WriteLine("71636269561882670428252483600823257530420752963450");
        }

        public void Execute()
        {
            // Setup
            int numDigits = 1000;
            int maxProduct = 0;
            String number = "73167176531330624919225119674426574742355349194934" +
                            "96983520312774506326239578318016984801869478851843" +
                            "85861560789112949495459501737958331952853208805511" +
                            "12540698747158523863050715693290963295227443043557" +
                            "66896648950445244523161731856403098711121722383113" +
                            "62229893423380308135336276614282806444486645238749" +
                            "30358907296290491560440772390713810515859307960866" +
                            "70172427121883998797908792274921901699720888093776" +
                            "65727333001053367881220235421809751254540594752243" +
                            "52584907711670556013604839586446706324415722155397" +
                            "53697817977846174064955149290862569321978468622482" +
                            "83972241375657056057490261407972968652414535100474" +
                            "82166370484403199890008895243450658541227588666881" +
                            "16427171479924442928230863465674813919123162824586" +
                            "17866458359124566529476545682848912883142607690042" +
                            "24219022671055626321111109370544217506941658960408" +
                            "07198403850962455444362981230987879927244284909188" +
                            "84580156166097919133875499200524063689912560717606" +
                            "05886116467109405077541002256983155200055935729725" +
                            "71636269561882670428252483600823257530420752963450";
            int[] digits = new int[numDigits];
            int i = 0;
            foreach(char c in number)
            {
                digits[i++] = (int)Char.GetNumericValue(c);
            }

            for (i = 0; i < 996; ++i)
            {
                // Get 5 values
                int a = digits[i];
                int b = digits[i + 1];
                int c = digits[i + 2];
                int d = digits[i + 3];
                int e = digits[i + 4];
                int product = a * b * c * d * e;
                if (product > maxProduct)
                {
                    maxProduct = product;
                }
            }

            System.Console.WriteLine(maxProduct.ToString());
        }
    }
}
