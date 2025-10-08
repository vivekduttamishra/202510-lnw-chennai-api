using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorV1
{
    public delegate string ResultFormatter(int op1, string operatorName, int op2, int result);

    //similar to
    //Func<int,string,int,int,string>

    public class ResultFormatters
    {
        public static readonly ResultFormatter Infix =(op1,operatorName,op2,result)=> 
                                            $"{op1} {operatorName} {op2} = {result}";

        public static readonly ResultFormatter MethodStyle=(op1,operatorName,op2,result)=>
                                             $"{operatorName}({op1},{op2})={result}";

    }
}
