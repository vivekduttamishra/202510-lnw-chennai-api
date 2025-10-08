using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.CalculatorAPI
{
    public delegate string ResultFormatter(int op1, string operatorName, int op2, int result);
}
