using ConceptArchitect.Banking;

namespace BankAccountConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double balance = 20000;
            string password = "p@ss";
            var a1 = new BankAccount(1, "Vivek", password, balance);


            //TestDeposit(a1, 1, true, "Can Deposit Postive Amount");
            TestDeposit(a1, -1, false, "Can't Deposit Negative Amount");
            TestWithdraw(a1, -1, password, false, "Can't Withdraw Negative Amount");
            TestWithdraw(a1, balance + 1, password, false, "Can't withdraw more than balance");
            TestWithdraw(a1, 1, "wrong_password", false, "Can't withdraw with wrong password");
            TestWithdraw(a1, 1, password, true, "Can withdraw with valid password");

            TestWithdraw(a1, balance - 1, password, true, "Can withdraw upto balance");
            TestWithdraw(a1, balance * 2, "wrong_password",false, "Can't withraw with wrong password");


        }

        static void TestDeposit(BankAccount a, double amount, bool expectedResult, string testMessage)
        {
            var actaulResult = a.Deposit(amount);
            if (actaulResult == expectedResult)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"PASSED:\t{testMessage}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Failed:\t{testMessage}\n\texpected={expectedResult}\tActual={actaulResult}");
            }

            Console.ResetColor();

        }

        static void TestWithdraw(BankAccount a, double amount,string password, bool expectedResult, string testMessage)
        {
            var actaulResult = a.Withdraw(amount, password);
            if (actaulResult == expectedResult)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"PASSED:\t{testMessage}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Failed:\t{testMessage}\n\texpected={expectedResult}\tActual={actaulResult}");
            }

            Console.ResetColor();

        }
    }
}
