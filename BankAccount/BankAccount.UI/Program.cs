using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BankAccount.BLL;

namespace BankAccount.UI
{
    class Program
    {
        static AccountManager _manager = new AccountManager();
        static Account CurrentAccount = new Account();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                WelcomeOptions welcomeOption = new WelcomeOptions();
                welcomeOption = Welcome();
                Nav(welcomeOption);
                if (welcomeOption == WelcomeOptions.Login)
                {
                    MainOptions mainOption = new MainOptions();
                    mainOption = AccountMain(CurrentAccount);
                    Nav(mainOption, CurrentAccount);
                }
                if (welcomeOption == WelcomeOptions.Invalid)
                    continue;
            }
            // Open Bank account
            // CurrentAccount = GetAccount();
            // Withdraw
            // Deposit
        }

        #region Create Methods
        public static void OpenNewAccount() // method to open new account
        {
            string name = OpenAccountNameInputVeri();
            string address = OpenAccountAddrInputVeri();
            string phonenumber = OpenAccountPhoneInputVeri();
            Account.AccountType type = OpenAccountTypeInputVeri();
            string password = OpenAccountPasswordVeri();

            CurrentAccount = _manager.OpenNewAccount(name, address, phonenumber, password, type);
            Console.WriteLine($"Your account has been opened. Your account number is {CurrentAccount.AccountNumber}");
            Console.WriteLine("Save this number, along with your password, for your records.");
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
        }
        #endregion

        #region Read Methods

            #region Open Account
            public static string OpenAccountNameInputVeri()
            {
                string inputx = "";
                string inputy = "";
                while (true)
                {
                    Console.WriteLine("What is your first name?");
                    inputx = Console.ReadLine();
                
                    if (Regex.IsMatch(inputx, @"^[\d \s]+$"))
                        Console.WriteLine("Cannot contain numbers or spaces.");
                    else
                        break;
                }
                while (true)
                {
                    Console.WriteLine("What is your last name?");
                    inputy = Console.ReadLine();
                    if (Regex.IsMatch(inputx, @"^[\d \s]+$"))
                        Console.WriteLine("Cannot contain numbers or spaces.");
                    else
                        break;
                }
                return inputx + " " + inputy;
            }

            public static string OpenAccountAddrInputVeri()
            {
                string inputa = "";
                string inputb = "";
                string inputc = "";
                string inputd = "";
                string inpute = "";
                while (true)
                {
                    Console.WriteLine("Please enter your address number.");
                    inputa = Console.ReadLine();
                    break;
                }
                while (true)
                {
                    Console.WriteLine("Please enter the address name.");
                    inputb = Console.ReadLine();
                    break;
                }
                while (true)
                {
                    Console.WriteLine("Please enter your city.");
                    inputc = Console.ReadLine();
                    break;
                }
                while (true)
                {
                    Console.WriteLine("Please enter your state.");
                    inputd = Console.ReadLine();
                    break;
                }
                while (true)
                {
                    Console.WriteLine("Please enter your zipcode.");
                    inpute = Console.ReadLine();
                    break;
                }
                return inputa + " " + inputb + ", " + inputc + " " + inputd + ", " + inpute;
            }

            public static string OpenAccountPhoneInputVeri()
            {
                while (true)
                {
                    Console.WriteLine("What is your phone number?");
                    string phonenumber = Console.ReadLine();
                    if (Regex.IsMatch(phonenumber, @"^[a-zA-Z\s]+$"))
                        Console.WriteLine("Cannot contain letters or spaces.");
                    else
                        return phonenumber;
                }
            }

            public static Account.AccountType OpenAccountTypeInputVeri()
            {
                while (true)
                {
                    Console.WriteLine("What type of account would you like? Options are: Checking, Saving, MoneyMarket, Senior.");
                    string input = Console.ReadLine();
                    if (Enum.TryParse(input, out Account.AccountType type))
                    {
                        return type;
                    }
                    else
                    {
                        Console.WriteLine("That was not a valid account type.");
                        System.Threading.Thread.Sleep(2000);
                    }
                }
            }

            public static string OpenAccountPasswordVeri()
            {
                while (true)
                {
                    Console.WriteLine("Enter a super secret password.");
                    string password = Console.ReadLine();
                    Console.WriteLine("Confirm your super secret password");
                    string confirm = Console.ReadLine();
                    if (password == confirm)
                        return password;
                    else
                        Console.WriteLine("The inputs did not match.");
                }
            }
            #endregion

        public static void DisplayBalance(Account account)
        {
            string balance = _manager.DisplayBalance(account);
            Console.WriteLine($"Your current balance is: {balance}");
            System.Threading.Thread.Sleep(2000);
        }

        public static Account GetAccount()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What is your account number?");
                string x = Console.ReadLine();
                int num = Convert.ToInt32(x);
                GetAccountRequest request = new GetAccountRequest();
                GetAccountResponse response = new GetAccountResponse();
                request.AccountNumber = num;
                Console.WriteLine("Please enter your password");
                request.Password = Console.ReadLine();
                response = _manager.AccountLogin(request);
                if (response.response == ResponseEnums.GetResponse.Success)
                {
                    return response.Account;
                }
                if (response.response == ResponseEnums.GetResponse.Fail)
                {
                    Console.WriteLine("You've entered the incorrect password.");
                    System.Threading.Thread.Sleep(2000);
                }
                if (response.response == ResponseEnums.GetResponse.Unknown)
                {
                    Console.WriteLine("That account does not exist.");
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }

        #endregion

        #region Update Methods
        public static void ChangeName(Account account)
        {
            _manager.ChangeName(account.Name);
        }

        public static void ChangeAddress(Account account)
        {
            _manager.ChangeAddress(account.Address);
        }

        public static void ChangePhoneNumber(Account account)
        {
            _manager.ChangePhoneNumber(account.Phone);
        }

        public static Account Deposit(Account account)
        {
            GetAccountResponse response = new GetAccountResponse();
            Console.WriteLine("How much would you like to deposit?");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Depositing " + amount + ", please wait.");
            System.Threading.Thread.Sleep(2000);
            response = _manager.Deposit(account, amount);
            if (response.response == ResponseEnums.GetResponse.Success)
            {
                Console.WriteLine("Deposit Successful.");
                System.Threading.Thread.Sleep(2000);
                return response.Account;
            }
            if (response.response == ResponseEnums.GetResponse.Fail)
            {
                Console.WriteLine("Deposit Failed . . .");
                Console.WriteLine("Did you try to deposit a non-positive amount?");
                System.Threading.Thread.Sleep(2000);
                return account;
            }
            else
            {
                Console.WriteLine("An unknown error has occured . . .");
                System.Threading.Thread.Sleep(2000);
                return account;
            }
        }

        public static void Withdraw(Account account)
        {
            _manager.Withdraw(1);
        }

        public static void ChangeAccountType(Account account)
        {
            _manager.ChangeAccountType(account.UserAccount);
        }
        #endregion

        #region Delete Methods
        public void CloseAccount(Account account) // method to close existing account
        {
            _manager.CloseAccount(account);
        }
        #endregion


        #region I/O Methods
        internal enum WelcomeOptions
        {
            Login,
            NewAccount,
            About,
            Exit,
            Invalid
        }

        static WelcomeOptions Welcome()
        {
            Console.WriteLine("Welcome to Console First National");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("Option \'1\': Login");
            Console.WriteLine("Option \'2\': New Account");
            Console.WriteLine("Option \'3\': About");
            Console.WriteLine("Option \'4\': Exit");
            var input = Console.ReadKey().Key;
            Console.CursorLeft = 0;
            switch (input)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    return WelcomeOptions.Login;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    return WelcomeOptions.NewAccount;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    return WelcomeOptions.About;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    return WelcomeOptions.Exit;
                default:
                    return WelcomeOptions.Invalid;
            }

        }

        static void Nav(WelcomeOptions option)
        {
            switch (option)
            {
                case WelcomeOptions.Login:
                    CurrentAccount = GetAccount();
                    break;
                case WelcomeOptions.NewAccount:
                    OpenNewAccount();
                    break;
                case WelcomeOptions.About:
                    Console.WriteLine("Not Implemented . . .");
                    System.Threading.Thread.Sleep(2000);
                    break;
                case WelcomeOptions.Exit:
                    Console.WriteLine("Thank you for visiting Console First National.");
                    Console.WriteLine("This program will now exit . . .");
                    System.Threading.Thread.Sleep(5000);
                    Environment.Exit(0);
                    break;
                case WelcomeOptions.Invalid:
                    Console.WriteLine("Invalid Input . . .");
                    System.Threading.Thread.Sleep(2000);
                    break;
                    
            }
        }

        internal enum MainOptions
        {
            DisplayBalance,
            Deposit,
            Withdraw,
            ChangeName,
            ChangeAddress,
            ChangePhoneNumber,
            ChangeAccountType,
            Exit,
            Invalid
        }

        static MainOptions AccountMain(Account account)
        {
            string name = account.Name;

            Console.WriteLine($"Welcome, {name} ");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("Option \'1\': View Balance");
            Console.WriteLine("Option \'2\': Deposit");
            Console.WriteLine("Option \'3\': Withdraw");
            Console.WriteLine("Option \'4\': Change Name");
            Console.WriteLine("Option \'5\': Change Address");
            Console.WriteLine("Option \'6\': Change Phone Number");
            Console.WriteLine("Option \'7\': Change Account Type");
            var input = Console.ReadKey().Key;
            Console.CursorLeft = 0;
            switch (input)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    return MainOptions.DisplayBalance;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    return MainOptions.Deposit;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    return MainOptions.Withdraw;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    return MainOptions.ChangeName;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    return MainOptions.ChangeAddress;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    return MainOptions.ChangePhoneNumber;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    return MainOptions.ChangeAccountType;
                case ConsoleKey.Escape:
                    return MainOptions.Exit;
                default:
                    return MainOptions.Invalid;
            }

        }

        static void Nav(MainOptions option, Account account)
        {
            switch (option)
            {
                case MainOptions.DisplayBalance:
                    DisplayBalance(account);
                    break;
                case MainOptions.Deposit:
                    OpenNewAccount();
                    break;
                case MainOptions.Withdraw:
                    Console.WriteLine("Not Implemented . . .");
                    System.Threading.Thread.Sleep(2000);
                    break;
                case MainOptions.ChangeName:
                    Console.WriteLine("Not Implemented . . .");
                    System.Threading.Thread.Sleep(2000);
                    break;
                case MainOptions.ChangeAddress:
                    Console.WriteLine("Not Implemented . . .");
                    System.Threading.Thread.Sleep(2000);
                    break;
                case MainOptions.ChangePhoneNumber:
                    Console.WriteLine("Not Implemented . . .");
                    System.Threading.Thread.Sleep(2000);
                    break;
                case MainOptions.ChangeAccountType:
                    Console.WriteLine("Not Implemented . . .");
                    System.Threading.Thread.Sleep(2000);
                    break;
                case MainOptions.Invalid:
                    Console.WriteLine("Not Implemented . . .");
                    System.Threading.Thread.Sleep(2000);
                    break;
            }
        }

        static void Loop()
        {
                
        }

        #endregion
    }
}

    

