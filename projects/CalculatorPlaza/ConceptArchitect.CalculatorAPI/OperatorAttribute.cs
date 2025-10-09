using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.CalculatorAPI
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
    public class OperatorAttribute: Attribute
    {
        public bool Ignore { get; set; } //if true, current selection will be ignored
        public string Name { get; set; }
        public string HelpText { get; set; }
        public string Aliases { get; set;}

        public static OperatorAttribute For(MethodInfo method)
        {
            var ignore=new OperatorAttribute() { Ignore = true };

            var classAttrb = method.DeclaringType.GetCustomAttribute<OperatorAttribute>();
            if (classAttrb != null && classAttrb.Ignore)
                return ignore;

            var methodAttrb = method.GetCustomAttribute<OperatorAttribute>();
            if (methodAttrb == null)
            {
                methodAttrb = new OperatorAttribute()
                {
                    Name = method.Name,
                    Aliases = "",
                    HelpText = ""
                };
            }

            return methodAttrb;
            

        }
    }
}
