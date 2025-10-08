
namespace CalculatorV1
{
   



    public class CalculatorV4
    {
        public OutputFormat OutputFormat { get; set; }= OutputFormat.Infix;

        public void Calculate(int op1, string operatorName, int op2)
        {
            Dictionary<string,Operator> operators =new Dictionary<string,Operator> 
            {
                { "plus", new Operator(Operators.Plus) },
                { "Minus", new Operator(Operators.Minus) },
                { "multiply", new Operator(Operators.Multiply) },
                {"divide", (x,y)=> x/y }
            };
            
            


            int result = 0;
            if(operators.ContainsKey(operatorName))
                result = operators[operatorName](op1, op2);

            else
            {
                Console.WriteLine($"Invalid Operator:'{operatorName}'");
                return;
            }

            string output="";
            switch (OutputFormat)
            {
                case OutputFormat.Infix:
                    output = $"{op1} {operatorName} {op2} = {result}";
                    break;
                case OutputFormat.MethodStyle:
                    output = $"{operatorName}({op1},{op2})={result}";
                    break;

            }
                
                


            Console.WriteLine(output);
        }
    }
}