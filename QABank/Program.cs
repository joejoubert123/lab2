using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }


}


