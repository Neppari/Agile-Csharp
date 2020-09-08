using System;
using System.Collections.Generic;
using System.Text;

namespace Homework2
{
    class User
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        public int Id { get; private set; }
        public decimal Balance { get; private set; }

        public User(string name, string password, int id, decimal balance)
        {
            Name = name;
            Password = password;
            Id = id;
            Balance = balance;
        }

        public decimal WithdrawFunds(decimal amount)
        {
            decimal newBalance = Balance - amount;
            Balance = newBalance;
            return Balance;
        }

        public decimal DepositFunds(decimal amount)
        {
            decimal newBalance = Balance + amount;
            Balance = newBalance;
            return Balance;
        }
    }
}
