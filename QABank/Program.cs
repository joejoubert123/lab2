using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QABank.Program;

namespace QABank
{
    class Program
    {
        static void Main(string[] args)
        {
        }


        public class BankAccount
        {
            // Fields
            private static int nextAccountNumber = 100000;

            // Properties
            public string CustomerName { get; set; }
            public int AccountNumber { get; private set; }
            public decimal Balance { get; private set; }

            // Constructors
            public BankAccount(string customerName, int accountNumber = 0, decimal balance = 0.0m)
            {
                CustomerName = customerName;
                AccountNumber = (accountNumber == 0) ? GenerateAccountNumber() : accountNumber;
                Balance = balance;
            }

            // Methods
            public void Deposit(decimal amount)
            {
                if (amount < 0)
                {
                    throw new ArgumentException("Deposit amount must be non-negative.");
                }

                Balance += amount;
            }

            public void Withdraw(decimal amount)
            {
                if (amount < 0)
                {
                    throw new ArgumentException("Withdrawal amount must be non-negative.");
                }

                if (amount > Balance)
                {
                    throw new InvalidOperationException("Insufficient funds for withdrawal.");
                }

                Balance -= amount;
            }

            private int GenerateAccountNumber()
            {
                int generatedAccountNumber = nextAccountNumber;
                nextAccountNumber++;
                return generatedAccountNumber;
            }
        }

     

public class CurrentAccount : BankAccount
    {
        // Properties
        public decimal OverdraftLimit { get; set; }

        // Constructors
        public CurrentAccount(string customerName, int accountNumber = 0, decimal balance = 0.0m, decimal overdraftLimit = 0.0m)
            : base(customerName, accountNumber, balance)
        {
            OverdraftLimit = overdraftLimit;
        }

        // Override Withdraw method to enforce overdraft limit
        public override void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Withdrawal amount must be non-negative.");
            }

            if (amount > (Balance + OverdraftLimit))
            {
                throw new InvalidOperationException("Exceeding overdraft limit is not allowed.");
            }

            Balance -= amount;
        }
    }

    public class SavingsAccount : BankAccount
    {
        // Properties
        public decimal InterestRate { get; set; }

        // Constructors
        public SavingsAccount(string customerName, int accountNumber = 0, decimal balance = 0.0m, decimal interestRate = 0.0m)
            : base(customerName, accountNumber, balance)
        {
            InterestRate = interestRate;
        }

        // Method to add interest
        public void AddInterest()
        {
            decimal interestAmount = Balance * (InterestRate / 100);
            Balance += interestAmount;
        }
    }



}


}


