using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorV1
{
    public delegate int Operator(int op1, int op2);
    public class Operators
    {
        public static int Plus(int op1, int op2)
        {
            return op1 + op2;
        }
        public static int Minus(int op1, int op2)
        {
            return op1 - op2;
        }

        public static int Multiply(int op1, int op2)
        {
            return op1 * op2;
        }
    }
}
