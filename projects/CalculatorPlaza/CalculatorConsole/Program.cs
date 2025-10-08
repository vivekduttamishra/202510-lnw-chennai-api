using ConceptArchitect.Calculator.Extension;
using ConceptArchitect.CalculatorAPI;

namespace CalculatorConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();
            
            TestCalculator(calc, "Test Default Calculator");

            calc.AddOperator(Operators.Multiply, "multiply");
            calc.AddOperator(Operators.Divide, "divide");
            calc.AddOperator(Operators.Mod, "mod");

            calc.ResultFormatter = ResultFormatters.MethodStyle;
            TestCalculator(calc, "Extended Calculator");
        }

        private static void TestCalculator(Calculator calc, string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("-------------------");
            calc.Calculate(20, "plus", 30);
            calc.Calculate(20, "minus", 30);
            calc.Calculate(20, "multiply", 30);
            calc.Calculate(20, "foo", 30);
            calc.Calculate(20, "mod", 3);
            Console.WriteLine("-------------------");
            Console.WriteLine("\n");
        }
    }
}
