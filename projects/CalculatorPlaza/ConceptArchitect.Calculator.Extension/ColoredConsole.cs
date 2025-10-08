using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Calculator.Extension
{
    public class ColoredConsole
    {
        public ConsoleColor Color { get; set; }

        public void Print(string result)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(result);
            Console.ResetColor();
        }

        public static Action<string> ForColor(ConsoleColor color)
        {
            var console=new ColoredConsole() { Color = color };
            return console.Print;
        }
    }
}
