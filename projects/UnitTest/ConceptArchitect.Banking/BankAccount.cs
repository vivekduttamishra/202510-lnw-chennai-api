namespace ConceptArchitect.Banking
{
    public class BankAccount
    {
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public double Balance { get; private set; }
        public static double InterestRate { get; set; } = 12;

        private string password;

        public BankAccount(int accountNumber, string name, string password, double balance)
        {
            AccountNumber= accountNumber;
            Name= name;
            this.password = password;
            Balance = balance;
        }

        public bool Deposit(double amount)
        {
            if(amount>0)
            {
                Balance += amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Withdraw(double amount, string password)
        {
            if (amount <= 0)
                return false;
            if (this.password != password)
                throw new InvalidCredentialsException(AccountNumber);

            if (amount > Balance)
                return false;

            return true;
        }

        public void CreditInterest()
        {
            Balance += Balance * InterestRate / 1200;
        }

        public void Show()
        {
            Console.WriteLine($"Account: {AccountNumber}\tName={Name}\tBalance={Balance}");
        }

    }
}
