
using System;

namespace CalculatorV1
{
    public class Calculator
    {
        public void Calculate(int op1, string operatorName, int op2)
        {
            if (operatorName == "plus")
            {
                Console.WriteLine($"{op1} {operatorName} {op2} = {op1 + op2}");
            }
            else if (operatorName == "minus") 
            {
                Console.WriteLine($"{op1} {operatorName} {op2} = {op1 - op2}");
            }
                
            else if (operatorName == "multiply")
            {
                Console.WriteLine($"{op1} {operatorName} {op2} = {op1 * op2}");
            }
                
            else if (operatorName == "divide")
            {
                Console.WriteLine($"{op1} {operatorName} {op2} = {op1 / op2}");
            }
                

            if (operatorName == "mod")
            {
                Console.WriteLine($"{op1} {operatorName} {op2}={op1 % op2}");

            }
            else
            {
                Console.WriteLine($"Invalid Operator:'{operatorName}'");


            }
        }
    }
}