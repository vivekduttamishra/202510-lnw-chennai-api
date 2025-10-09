using ConceptArchitect.Calculator.Extension;
using ConceptArchitect.CalculatorAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCalculator
{
    public class OperatorTests
    {

        [Fact]
        public void PlusOperatorWorksCorrectly()
        {
            Assert.Equal(5, BasicOperators.Plus(2, 3));
        }
    }
}
