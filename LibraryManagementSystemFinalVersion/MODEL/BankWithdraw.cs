using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class BankWithdraw
    {
        public int BankWithdrawId { get; set; }
        public string Date { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string CheckNo { get; set; }
        public string WithdrawBy { get; set; }
        public double Amount { get; set; }
    }
}