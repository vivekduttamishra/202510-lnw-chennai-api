using ConceptArchitect.Calculator.Extension;
using ConceptArchitect.CalculatorAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestCalculator
{
    public  class CalculatorBuilderTests
    {
        [Fact]
        public void CreateDefaultCalculator()
        {
            var calculator = new CalculatorBuilder()
                                   .Defaults()
                                   .Build();

            Assert.NotNull(calculator);
            Assert.Equal(2, calculator.Operators.ToArray().Length);
        }

        [Fact]
        public void CalculatorBuilderCanAddIndividualOperator()
        {
            var calculator = new CalculatorBuilder()
                                    .Defaults()
                                    .AddOperation(AdvancedOperators.Mod,"mod")
                                    .Build();


            Assert.True(calculator.Operators.ToArray().Contains("mod"));
            
        }

        [Fact]
        public void CalculatorBuilderCanAddAllOperatorsFromAClass()
        {
            var calculator = new CalculatorBuilder()
                                .Defaults()
                                .AddOperatorClass<AdvancedOperators>()
                                .Build();

            Assert.Equal(7, calculator.Operators.ToArray().Length);

        }

        [Fact]
        public void CalculatorBuilderCanAddAllOperationPresentCurrentAssembly()
        {

            var assembly = Assembly.GetExecutingAssembly();
            var calculator = new CalculatorBuilder()
                                    .Defaults()
                                    .AddAssembly(assembly)
                                    .Build();

            Assert.Equal(5, calculator.Operators.ToArray().Length);
            var operators= calculator.Operators;
            Assert.True(operators.Contains("Zero"));
            Assert.True(operators.Contains("One"));
            Assert.True(operators.Contains("Special1"));

        }
    
    }
}
