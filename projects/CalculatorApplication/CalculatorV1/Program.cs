namespace CalculatorV1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();

            //test default calcualtor
            TestCalculator(calc,"Test Default Calculator");

            calc.AddOperator(Operators.Multiply, "multiply");

            //calc.OutputFormat = OutputFormat.MethodStyle;
            
            calc.ResultFormatter = ResultFormatters.MethodStyle;


            TestCalculator(calc, "Method Style Output Format");

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
