using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Calculator.Extension
{
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

        public static int Divide(int op1, int op2)
        {
            return op1 / op2;
        }

        public static int Mod(int op1, int op2)
        {
            return op1 % op2;
        }
    }
}
