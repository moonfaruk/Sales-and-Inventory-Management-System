using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class BankDeposit
    {
        public int BankDepositId { get; set; }
        public string BankDate { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string Mode { get; set; }
        public string PartyBankName { get; set; }
        public string CheckNo { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int PartyId { get; set; }
        public string PartyName { get; set; }
        public double Amount { get; set; }
    }
}