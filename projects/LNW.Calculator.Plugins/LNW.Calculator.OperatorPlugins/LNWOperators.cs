namespace LNW.Calculator.OperatorPlugins
{
    public class LNWOperators
    {

        public static int Factorial(int x)
        {
            return x > 1 ? x * Factorial(x - 1) : 1;
        }

        public static int Permutation(int n,int r)
        {
            return Factorial(n) / Factorial(n - r);
        }

        public static int Combination(int n,int r)
        {
            return Permutation(n, r) / Factorial(r);
        }

    }
}
