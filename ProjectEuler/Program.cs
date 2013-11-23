using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectEuler.Problem;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            // Project introduction
            System.Console.WriteLine("Welcome to Project Euler Solutions.");
            
            // Default command
            string cmd = "";
            while(cmd.ToLower() != "exit")
            {
                // Print out base instruction set
                System.Console.WriteLine("Please enter the problem you would like to solve.");
            
                // Read the command
                cmd = System.Console.ReadLine();

                // Parse the command to a number (if applicable)
                int iCmd = 0;
                bool isNumeric = int.TryParse(cmd, out iCmd);

                // If it's a valid numerical command
                if (isNumeric && iCmd > 0)
                {
                    // Get the type of the class name
                    Type type = Type.GetType("ProjectEuler.Problem.Problem" + iCmd.ToString());

                    if (type != null)
                    {
                        IProblem problem = Activator.CreateInstance(type) as IProblem;

                        problem.PrintSummary();

                        problem.Execute();
                    }
                }
            }
            
        }
    }
}
