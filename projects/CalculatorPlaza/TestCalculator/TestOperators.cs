using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCalculator
{
    public  class OperatorSet1
    {
        public static int Zero(int a, int b) { return 0; }
        public static int One(int a, int b) { return 1; }
        
    }

    public class OperatorSet2
    {
        public static int Special1(int a , int b) { return (a + b) / (a - b); }
    }
}
