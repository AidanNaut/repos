using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.BLL
{
    public class Account
    {
        Random r = new Random();

        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }

        public enum AccountType
        {
            Checking,
            Savings,
            MoneyMarket,
            Senior
        }

        public AccountType UserAccount { get; set; }

        

        

        public Account(string name, string address, string phone, string password, AccountType account, int accountNumber)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Password = password;
            UserAccount = account;
            AccountNumber = accountNumber;
        }
        public Account(string name, string address, string phone, string password, AccountType account)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Password = password;
            UserAccount = account;
            AccountNumber = r.Next(999999);
        }
        public Account()
        {

        }
    }
}
