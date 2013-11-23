using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problem
{
    interface IProblem
    {
        /// <summary>
        /// Prints the summary of the problem to the console.
        /// </summary>
        void PrintSummary();

        /// <summary>
        /// Executes the solution of the problem
        /// </summary>
        void Execute(); 
    }
}
