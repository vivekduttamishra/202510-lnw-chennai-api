
namespace CalculatorV1
{
    public interface IOperator
    {
        int Evaluate(int op1, int op2);
    }

    


    public class Plus : IOperator
    {
        public int Evaluate(int op1, int op2)
        {
            return op1 + op2;
        }
    }
        
    public class Minus : IOperator
    {
        public int Evaluate(int op1, int op2)
        {
            return op1 - op2;
        }
    }

    public class Multiply : IOperator
    {
        public int Evaluate(int op1, int op2)
        {
            return op1 * op2;
        }
    }



    public class CalculatorV3
    {
        public OutputFormat OutputFormat { get; set; }= OutputFormat.Infix;

        public void Calculate(int op1, string operatorName, int op2)
        {
            Dictionary<string,IOperator> operators =new Dictionary<string,IOperator> {
                { "plus", new Plus() },
                { "Minus", new Minus() },
                { "multiply", new Multiply() },

            };
            
            


            int result = 0;
            if(operators.ContainsKey(operatorName))
                result = operators[operatorName].Evaluate(op1, op2);

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