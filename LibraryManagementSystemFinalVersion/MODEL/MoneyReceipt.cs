using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class MoneyReceipt
    {
        public int MoneyReceiptId { get; set; }
        public string Date { get; set; }
        public string MrNo { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int PartyId { get; set; }
        public string PartyCode { get; set; }
        public string PartyName { get; set; }
        public string Mode { get; set; }
        public string ChequeNo { get; set; }
        public string ChequeDate { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public double Amount { get; set; }
        public string Remarks { get; set; }
    }
}