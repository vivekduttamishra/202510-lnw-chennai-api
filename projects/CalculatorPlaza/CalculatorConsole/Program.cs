using ConceptArchitect.Calculator.Extension;
using ConceptArchitect.CalculatorAPI;
using LNW.Calculator.OperatorPlugins;

namespace CalculatorConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator()
            {
                ResultPresenter = ColoredConsole.ForColor(ConsoleColor.Yellow),
                ErrorPresenter = ColoredConsole.ForColor(ConsoleColor.Red)
            };
            
            TestCalculator(calc, "Test Default Calculator");

            calc.AddOperator(AdvancedOperators.Multiply, "multiply");
            calc.AddOperator(AdvancedOperators.Divide, "divide");
            calc.AddOperator(AdvancedOperators.Mod, "mod");

            calc.AddOperator(LNWOperators.Permutation, "p");
            calc.AddOperator(LNWOperators.Combination, "c");

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
            calc.Calculate(5, "p", 3);
            Console.WriteLine("-------------------");
            Console.WriteLine("\n");
        }
    }
}
