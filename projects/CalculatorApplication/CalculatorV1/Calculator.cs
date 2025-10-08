
namespace CalculatorV1
{
   

    public class Calculator
    {
        //public OutputFormat OutputFormat { get; set; }= OutputFormat.Infix;

        public ResultFormatter ResultFormatter { get; set; } = ResultFormatters.Infix;

        Dictionary<string, Operator> operators = new Dictionary<string, Operator>
        {
            { "plus", new Operator(Operators.Plus) },
            { "minus", new Operator(Operators.Minus) },           
        };
        public void AddOperator(Operator _operator, string name = null)
        {
            operators[name] = _operator;
        }


        public void Calculate(int op1, string operatorName, int op2)
        {
            
            
            


            int result = 0;
            if(operators.ContainsKey(operatorName))
                result = operators[operatorName](op1, op2);

            else
            {
                Console.WriteLine($"Invalid Operator:'{operatorName}'");
                return;
            }

            //string output="";
            //switch (OutputFormat)
            //{
            //    case OutputFormat.Infix:
            //        output = $"{op1} {operatorName} {op2} = {result}";
            //        break;
            //    case OutputFormat.MethodStyle:
            //        output = $"{operatorName}({op1},{op2})={result}";
            //        break;

            //}


            var output = ResultFormatter(op1, operatorName, op2, result);   
                


            Console.WriteLine(output);
        }
    }
}