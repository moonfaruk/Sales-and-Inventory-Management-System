using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class SupplierBillPayment
    {
        public int SupplierBillPaymentId { get; set; }
        public string SupplierDate { get; set; }
        public string BillNo { get; set; }
        public int SupId { get; set; }
        public string SupplierName { get; set; }
        public string PaymentMode { get; set; }
        public int BankId { get; set; }
        public string BankAccountName { get; set; }
        public string CheckNo { get; set; }
        public string CheckDate { get; set; }
        public double Amount { get; set; }

    }
}