using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    public class BankingException: Exception
    {
        public int AccountNumber { get; set; }
        public BankingException(int accountNumber, string message) : base(message)
        {
            AccountNumber=accountNumber;
        }
    }

    public class InvalidCredentialsException : BankingException
    {
        public InvalidCredentialsException(int accountNumber, string message="Invalid Credentials") : base(accountNumber, message) { }
    }
}
