
namespace CalculatorV1
{
   
    
    public class CalculatorV2
    {
        public OutputFormat OutputFormat { get; set; }= OutputFormat.Infix;

        public void Calculate(int op1, string operatorName, int op2)
        {
            int result = 0;
            if (operatorName == "plus")
                result = op1 + op2;
            else if (operatorName == "minus") 
                result = op1 - op2;                
            else if (operatorName == "multiply")
                result = op1 % op2;
            else if (operatorName == "divide")
                result = op1 % op2;
            else if (operatorName == "mod")
                result = op1 % op2;
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