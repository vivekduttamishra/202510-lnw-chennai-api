using CalculatorV1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcWinOs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();
            calc.Calculate(20, "plus", 30);
            calc.Calculate(20, "minus", 30);
            calc.Calculate(20, "mod", 30);
        }
    }
}
