using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class OthersBillPayment
    {
        public int OthersBillPaymentId { get; set; }
        public string Date { get; set; }
        public int OtherGroupId { get; set; }
        public string OtherGroupName { get; set; }
        public string PaymentMode { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string CheckNo { get; set; }
        public string CheckDate { get; set; }
        public double Amount { get; set; }
        public string Remarks { get; set; }

    }
}