using ConceptArchitect.Calculator.Extension;
using ConceptArchitect.CalculatorAPI;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCalculator
{
    public class CalculatorTests
    {
        Calculator calculator = new Calculator();
        int op1 = 20;
        int op2 = 10;
        string validOperatorName = "plus";
        string invalidOperatorName = "foo";
        Operator validOperator = BasicOperators.Plus;

        [Fact]
        public void CalculatorPerformsCorrectCalculationForValidOperator()
        {
            ResultFormatter formatter = (op1, operatorName, op2, result) =>
            {
                Assert.Equal(validOperator(op1,op2), result);
                return "this value doesn't matter for my test";
            };
            calculator.ResultFormatter = formatter;

            calculator.Calculate(op1, validOperatorName, op2);
        }

        [Fact(
            //Skip ="Not Yet Tested"
        )]
        public void CalculatorReturnsInvalidOperatorMessageForInvalidOperator()
        {
            bool errorPresenterCalled = false;
            Action<string>  errorPresenter = errorMessage =>
            {
                errorPresenterCalled = true;
                Assert.Equal($"Invalid Operator:'{invalidOperatorName}'", errorMessage);
            };
            calculator.ErrorPresenter = errorPresenter;
            calculator.Calculate(op1, invalidOperatorName, op2);
            
            Assert.True(errorPresenterCalled);
        }

        [Fact]
        public void ErrorPresenterIsNotCalledForValidOperator()
        {
            calculator.ErrorPresenter = errorMessage => Assert.Fail("Error Presenter shouldn't have been called");

            calculator.Calculate(op1, validOperatorName, op2);
        }

        [Fact(
         //  Skip = "Not Yet Tested"
        )]
        public void CalculatorDoesntCallFormatterForInvalidOperator() 
        {
            calculator.ResultFormatter = (op1, operatorName, op2, result) =>
            {
                Assert.Fail("Result Formatter Shouldn't have been called");
                return "Actual output not relevant to my test";
            };

            calculator.Calculate(op1, invalidOperatorName, op2);
        }
        
        
        [Fact(
          // Skip = "Not Yet Tested"
        )]
        public void CalculatorUsesTheValueReturnedByTheFormatterForPrinting()
        {
            var expected = "TestResult";
            calculator.ResultFormatter = (op1, operatorName, op2, result) => expected;

            calculator.ResultPresenter=(actual)=> Assert.Equal(actual, expected);

            calculator.Calculate(op1, validOperatorName, op2);
        }

        [Fact(
           //Skip = "Not Yet Tested"
        )]
        public void CalculatorCallsResultPresenterEveryTimeForValidCalculationsOnly()
        {
            int times = 0;

            calculator.ResultFormatter = (op1, operatorName, op2, result) =>
            {
                times++;
                return null; //I don't care
            };
            
            calculator.Calculate(op1, validOperatorName, op2); //1
            calculator.Calculate(op1, invalidOperatorName, op2); //not called
            calculator.Calculate(op1, validOperatorName, op2); //2

            //Assert total number of times formatter is called.

            Assert.Equal(2, times);

        }


        [Fact]
        public void CanHaveMultipleAliasForSameMethod()
        {
            var helpText = "Multiplies Numbers";
            calculator.AddOperator((x, y) => x * y, "multiply", helpText, new string[] { "product", "into", "times" });

            int[] results = new int[3];
            int i = 0;
            calculator.ResultFormatter = (a, b, c, result) =>
            {
                results[i] = result;
                i++;
                return "";
            };
            

            calculator.Calculate(op1, "product", op2);
            calculator.Calculate(op1, "into", op2);
            calculator.Calculate(op1, "times", op2);

            Assert.Equal(3, i);
            Assert.Equal(results[0], results[1]);
            Assert.Equal(results[0], results[2]);

            Assert.True(calculator.GetHelp("times").Contains(helpText));


        }

    }
}
