using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class SupplierLedger
    {
        public int SupplierLedgerId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }

        //public SupplierLedger(string fromDate, string toDate)
        //{
        //    FromDate = fromDate;
        //    ToDate = toDate;
        //}
    }
}