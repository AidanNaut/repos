using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccount.BLL;
using NUnit.Framework;

namespace BankAccount.Tests
{
    [TestFixture]
    public class Tests
    {
        
        [Test]
        public void Test1()
        {
            AccountManager manager = new AccountManager();
            Account expected = null;

            foreach (Account account in manager.GetAccounts())
            {
                if (account.AccountNumber == 123456)
                {
                    expected = account;
                }
            }
            
            GetAccountRequest request = new GetAccountRequest() { AccountNumber = 123456, Password = "pass" };
            GetAccountResponse response = manager.AccountLogin(request);

            Account actual = response.Account;
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Test2()
        {
            ResponseEnums.GetResponse expected = ResponseEnums.GetResponse.Success;

            AccountManager manager = new AccountManager();
            GetAccountRequest request = new GetAccountRequest() { AccountNumber = 123456, Password = "pass" };
            GetAccountResponse response = manager.AccountLogin(request);

            ResponseEnums.GetResponse actual = response.response;
            Assert.AreEqual(expected, actual);

        }

    }
}
