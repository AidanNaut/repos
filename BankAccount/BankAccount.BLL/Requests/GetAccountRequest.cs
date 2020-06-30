using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.BLL
{
    public class GetAccountRequest
    {
        public int AccountNumber { get; set; }
        public string Password { get; set; }

    }
}
