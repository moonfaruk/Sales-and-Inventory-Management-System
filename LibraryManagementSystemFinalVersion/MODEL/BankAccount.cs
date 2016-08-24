using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }
        public int SerialNo { get; set; }
        public string BankAccountCode { get; set; }
        public string BankAccountName { get; set; }
        public string AccountNo { get; set; }
        public double BankAccountOpeningBalance { get; set; }


        //public BankAccount(string code, string name, double openingBalance)
        //{
        //    BankAccountCode = code;
        //    BankAccountName = name;
        //    BankAccountOpeningBalance = openingBalance;
        //}

        //public BankAccount()
        //{
            
        //}
        
    }
}