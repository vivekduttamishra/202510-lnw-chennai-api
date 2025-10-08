using System.Numerics;

namespace ConceptArchitect.CalculatorAPI
{
    public class Calculator
    {
        //public OutputFormat OutputFormat { get; set; }= OutputFormat.Infix;

        public ResultFormatter ResultFormatter { get; set; }
        Dictionary<string, Operator> operators=new Dictionary<string, Operator>() ;

        public Action<string> ResultPresenter { get; set; }
        public Action<string> ErrorPresenter { get; set; }


        public Calculator()
        {
            AddOperator((x, y) => x + y, "plus");
            AddOperator((x, y) => x - y, "minus");
            ResultFormatter = (op1, name, op2, result) => $"{op1} {name} {op2} = {result}";

            ResultPresenter = Console.WriteLine;
            ErrorPresenter = Console.WriteLine;
        
        }




        public void AddOperator(Operator _operator, string name = null)
        {
            operators[name] = _operator;
        }


        public void Calculate(int op1, string operatorName, int op2)
        {

            int result = 0;
            if (operators.ContainsKey(operatorName))
                result = operators[operatorName](op1, op2);

            else
            {
                //Console.WriteLine($"Invalid Operator:'{operatorName}'");
                ErrorPresenter($"Invalid Operator:'{operatorName}");
                return;
            }

         


            var output = ResultFormatter(op1, operatorName, op2, result);


            // Hard coded and non testable
            //Console.WriteLine(output);
            ResultPresenter(output);
        }
    }
}
