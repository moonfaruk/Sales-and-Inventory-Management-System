using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class SupplierBillEntry
    {
        public int SupplierBillEntryId { get; set; }
        public string SupplierDate { get; set; }
        public string SupplierBillDate { get; set; }
        public string BillNo { get; set; }
        public string SupplierType { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int PressId { get; set; }
        public string PressName { get; set; }
        public int PaperId { get; set; }
        public string PaperName { get; set; }
        public string PaperType { get; set; }
        public double PaperQuantity { get; set; }
        public double Prize { get; set; }
        public string Description { get; set; }
        public double BillAmount { get; set; }

    }
}