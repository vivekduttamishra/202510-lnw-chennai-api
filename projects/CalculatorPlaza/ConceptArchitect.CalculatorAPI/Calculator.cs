using System.Numerics;
using System.Text;

namespace ConceptArchitect.CalculatorAPI
{
   public  class OperatorInfo
    {
        public string Name { get; set; }
        public Operator Operator { get; set; }
        public string Help { get; set; }
        public string[] Aliases { get; set; }
    }


    public class BasicOperators
    {
        [Operator(Name="add", HelpText ="Adds two number", Aliases ="plus,sum")]
        public static int Plus(int x, int y) 
        { 
            return x + y; 
        }

        [Operator(HelpText = "Substracts from first to second", Aliases = "sub,less")]
        public static int Minus(int x, int y)
        {
            return x - y;
        }

        [Operator(Ignore =true)]
        public static int ComplexTask(int a, int b)
        {
            return 0;
        }

    }


    public class Calculator
    {
        //public OutputFormat OutputFormat { get; set; }= OutputFormat.Infix;

        public ResultFormatter ResultFormatter { get; set; }
        Dictionary<string, OperatorInfo> operators=new Dictionary<string, OperatorInfo>() ;

        public Action<string> ResultPresenter { get; set; }
        public Action<string> ErrorPresenter { get; set; }

        public IEnumerable<string> Operators
        {
            get
            {
                return operators.Keys;
            }
        }

        public Calculator()
        {
            
            ResultFormatter = (op1, name, op2, result) => $"{op1} {name} {op2} = {result}";

            ResultPresenter = Console.WriteLine;
            ErrorPresenter = Console.WriteLine;
        
        }


        public string GetHelp(string name)
        {
            var help = new StringBuilder(name);
            var info = operators[name];
            if (info == null)
            {
                return $"Invalid Operation: {name}";
            }
            else
            {
                help.AppendLine($"About: {name} ");
                if(name!=info.Name)
                    help.AppendLine($"Primary Name: {info.Name} ");
                if(info.Aliases!=null && info.Aliases.Length > 0)
                {
                    help.Append("Aliases: ");
                    foreach (var alias in info.Aliases)
                        help.Append(alias + " ");
                    help.AppendLine();
                }
                help.AppendLine($"{info.Help}");
                return help.ToString();
            }
        }

        public void AddOperator(Operator _operator, string name = null, string help="", string[] aliases = null)
        {
            var info= new OperatorInfo
            {
                Name = name,
                Operator = _operator,
                Help = help,
                Aliases = aliases
            };

            operators[name]= info;
            if(info.Aliases!=null )
                foreach(var alias in info.Aliases )
                    operators[alias]= info;
        }


        public void Calculate(int op1, string operatorName, int op2)
        {

            int result = 0;
            if (operators.ContainsKey(operatorName))
                result = operators[operatorName].Operator(op1, op2);

            else
            {
                //Console.WriteLine($"Invalid Operator:'{operatorName}'");
                ErrorPresenter($"Invalid Operator:'{operatorName}'");
                return;
            }

         


            var output = ResultFormatter(op1, operatorName, op2, result);


            // Hard coded and non testable
            //Console.WriteLine(output);
            ResultPresenter(output);
        }
    }
}
