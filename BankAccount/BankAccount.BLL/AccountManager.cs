using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccount.BLL;

namespace BankAccount.BLL
{
    public class AccountManager
    {
        #region Create Methods
        public static List<Account> Accounts = ReadFromFile();
        #endregion

        #region Read Methods
        public static List<Account> ReadFromFile()
        {
            string path = @"C:\Users\William\source\repos\BankAccount\BankAccount.BLL\bin\Debug\Accounts.txt";

            if (File.Exists(path)) { }
            else
                throw new Exception($"Could not find file at {path}");

            string[] rows = File.ReadAllLines(path);

            List<Account> accounts = new List<Account>();

            for (int i = 0; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(';');
                Account account = new Account
                {
                    Name = columns[0],
                    Address = columns[1],
                    Phone = columns[2],
                    Password = columns[3],
                    UserAccount = (Account.AccountType)Enum.Parse(typeof(Account.AccountType), columns[4], true),
                    AccountNumber = Convert.ToInt32(columns[5])
                };
                accounts.Add(account);
            }
            return accounts;
        }

        public List<Account> GetAccounts()
        {
            return Accounts;
        }

        public string DisplayBalance(Account account)
        {
            decimal a = account.Balance;
            string b = a.ToString();
            return b;
        }

        /*
        public GetAccountResponse AccountLogin(GetAccountRequest request)
        {
            GetAccountResponse response = new GetAccountResponse();
            foreach (Account account in Accounts)
            {
                if (account.AccountNumber == request.AccountNumber)
                {
                    if (request.Password == account.Password)
                    {
                        response.response = ResponseEnums.GetResponse.Success;
                        response.Account = account;
                        return response;
                    }
                    else
                    {
                        response.response = ResponseEnums.GetResponse.Fail;
                        return response;
                    }
                } 
            }
            response.response = ResponseEnums.GetResponse.Unknown;
            return response;
        }
        */

        public GetAccountResponse AccountLogin(GetAccountRequest request)
        {
            GetAccountResponse response = new GetAccountResponse();
            Account a = Accounts.FirstOrDefault(account => account.AccountNumber == request.AccountNumber);
            
            if (request.Password == a.Password)
            {
                response.response = ResponseEnums.GetResponse.Success;
                response.Account = a;
                return response;
            }
            if (request.Password != a.Password)
            {
                response.response = ResponseEnums.GetResponse.Fail;
                return response;
            }
                
            response.response = ResponseEnums.GetResponse.Unknown;
            return response;
        }

        //public GetLogoutResponse AccountLogout(GetLogoutRequest request)

        #endregion

        #region Update Methods
        public Account OpenNewAccount(string name, string address, string phonenumber, string password, Account.AccountType type) // method to open new account
        {
            Account newAccount = new Account
                (
                 name,
                 address,
                 phonenumber,
                 password,
                 type
                );

            WriteToFile(newAccount);
            Accounts.Add(newAccount);

            return newAccount;
        }

        public void WriteToFile(Account input)
        {
            
            GetAccountResponse response = new GetAccountResponse();
            foreach (Account account in Accounts)
            {
                if (account == input)
                {
                    throw new Exception("Can't add data that's already there, dummy!");
                }
            }

            string path = @"C:\Users\William\source\repos\BankAccount\BankAccount.BLL\bin\Debug\Accounts.txt";

            if (File.Exists(path)) { }
            else
                throw new Exception($"Could not find file at {path}");
            string output = "";

            string[] columns = new string[6];
            columns[0] = input.Name;
            columns[1] = input.Address;
            columns[2] = input.Phone;
            columns[3] = input.Password;
            columns[4] = input.UserAccount.ToString();
            columns[5] = input.AccountNumber.ToString();

            for (int i = 0; i < columns.Length; i++)
            {
                if (i == 0)
                    output = columns[0];
                else
                    output += @";" + columns[i];
            }

            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine();
                writer.Write(output);
            }
        }

        public string ChangeName(string name)
        {
            return name;
        }

        public string ChangeAddress(string address)
        {
            return address;
        }

        public string ChangePhoneNumber(string number)
        {
            return number;
        }

        public GetAccountResponse Deposit(Account account, decimal x)
        {
            GetAccountResponse response = new GetAccountResponse();
            response.Account = account;
            if (x <= 0)
            {
                response.response = ResponseEnums.GetResponse.Fail;
                return response;
            }
            if (x > 0)
            {
                response.Account.Balance += x;
                response.response = ResponseEnums.GetResponse.Success;
                return response;
            }
            else
            {
                response.response = ResponseEnums.GetResponse.Unknown;
                return response;
            }
        }

        public decimal Withdraw(decimal x)
        {
            return x;
        }

        public Account.AccountType ChangeAccountType(Account.AccountType accountType)
        {
            return accountType;
        }
        #endregion

        #region Delete Methods
        public bool CloseAccount(Account account) // method to close existing account
        {
            Account oldAccount = account;
            return true;
        }
        #endregion
    }
}
