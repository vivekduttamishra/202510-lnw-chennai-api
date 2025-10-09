using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.CalculatorAPI
{
    public class CalculatorBuilder
    {
        Calculator calculator;

        public CalculatorBuilder()
        {
            calculator = new Calculator();
        }

        public CalculatorBuilder Defaults()
        {
            
            return this;
        }

        public CalculatorBuilder AddOperatorInfo(OperatorInfo info)
        {
            calculator.AddOperator(info.Operator, info.Name, info.Help, info.Aliases);
            return this;
        }

        public CalculatorBuilder AddOperatorClass<T>()
        {
            return AddOperatorClass(typeof(T));
        }
        
        public CalculatorBuilder AddOperatorClass(Type type)        
        {
            foreach (var method in type.GetMethods(BindingFlags.Public|BindingFlags.Static))
            {
                var operatorInfo = GetOperatorInfo(method);
                if (operatorInfo != null)
                    AddOperatorInfo(operatorInfo);
            }

            return this;
        }

        public CalculatorBuilder AddAssembly(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                if (type.IsClass && !type.IsAbstract)
                    AddOperatorClass(type);
            }

            return this;
        }

        public CalculatorBuilder AddExecutingAssembly()
        {
            return AddAssembly(Assembly.GetExecutingAssembly());
        }


        public CalculatorBuilder AddResultPresener(Action<string> resultPresenter)
        {
            calculator.ResultPresenter = resultPresenter;
            return this;
        }

        public CalculatorBuilder AddErrorPresenter(Action<string> errorPresenter)
        {
            calculator.ErrorPresenter = errorPresenter;
            return this;
        }

        public CalculatorBuilder AddResultFormatter(ResultFormatter formatter)
        {
            calculator.ResultFormatter = formatter;
            return this;
        }


        public CalculatorBuilder AddPlugins(string basePath)
        {

            if (!Directory.Exists(basePath))
                return this;

            foreach(var file in Directory.GetFiles(basePath, "*.dll"))
            {
                var asm = Assembly.LoadFrom(file);
                AddAssembly(asm);
            }

            return this;
        }

        public CalculatorBuilder AddOperation(Operator @operator, string name, string help="", string[] alias=null )
        {
            calculator.AddOperator(@operator, name, help, alias);
            return this;
        }

        private OperatorInfo GetOperatorInfo(MethodInfo method)
        {
            if (method == null)
                return null;

            

            if(method.ReturnType!=typeof(int))
                return null;

            var parameters = method.GetParameters();
            if(parameters.Length!=2)
                return null;

            foreach (var parameter in parameters)
                if (parameter.ParameterType != typeof(int))
                    return null;

            return new OperatorInfo()
            {
                Operator = (Operator)Operator.CreateDelegate(typeof(Operator), method),
                Name= method.Name,
                Help=$"About {method.Name}"
            };


        }

        public Calculator Build()
        {
             return calculator;
        }
    }
}
