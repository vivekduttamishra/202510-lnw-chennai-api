using ConceptArchitect.Calculator.Extension;
using System.Runtime.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestCalculator
{
    public class FormatterTests
    {
        //   Calculator performs correct calculation for valid operator
        //Calculator "Invalid Operator:'foo'" if we pass invalid operator foo
        //   Calculator doesn't call formatter if operator is invalid

        //   Calculator uses the value returned by formatter for printing
        //   Calculator invokes ResultPresenter with formatted data
        //   Calculator invokes ErrorPresenter with error data


        [Fact]
        public void InfixFormatterFormatsCorrectly()
        {
            int op1 = 5;
            int op2 = 6;
            var operatorName = "plus";
            int result = op1 + op2;

            var actual = ResultFormatters.Infix(op1, operatorName, op2, result);
            var expected = $"{op1} {operatorName} {op2} = {result}";

            Assert.Equal(expected, actual);


        }



    }
}