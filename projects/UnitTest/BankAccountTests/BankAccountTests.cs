using ConceptArchitect.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountTests
{
    public  class BankAccountTests
    {
        const string password = "p@ss";
        const double balance = 20000;
        BankAccount account = new BankAccount(1, "Vivek", password, balance);

        [Fact]
        public void DepositShouldFailForNegativeAmount()
        {
            bool result = account.Deposit(-1);
            Assert.False(result);

        }

        

        [Fact]
        public void DepositShouldSucceedForPositiveAmount()
        {
            bool result = account.Deposit(1);
            Assert.True(result);
        }

        [Fact]
        public void WithdrawShouldFailForInvalidCredentials()
        {
            Assert.Throws<InvalidCredentialsException>(() => account.Withdraw(1, "wrong password"));
        }

        [Fact]
        public void WithdrawShouldFailForNegativeBalance()
        {
            bool result = account.Withdraw(-1, password);
            Assert.Equal(false, result);
        }

        [Fact]
        public void WithdrawalShouldFailForInsufficientBalance()
        {
            bool result = account.Withdraw(balance+1, password);
            Assert.Equal(false, result);
        }

        [Fact]
        public void WithdrawalShoudWorkRightBalanceAndPassword()
        {
            Assert.True(account.Withdraw(balance, password));
        }

        [Fact]
        public void CreditInterestCreditsInterest()
        {
            var expectedResult = balance + balance * BankAccount.InterestRate / 1200;
            account.CreditInterest();

            Assert.Equal(expectedResult, account.Balance, 0.01);
        }

        [Fact]
        public void ShowInfoShowsCurrentAccountInfo()
        {
            account.Show();
        }


    }
}
