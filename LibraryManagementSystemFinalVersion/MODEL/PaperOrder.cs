using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class PaperOrder
    {
        public int PaperOrderId { get; set; }
        public string Date { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SlipNo { get; set; }
        public int PressId { get; set; }
        public string PressCode { get; set; }
        public int PaperId { get; set; }
        public string PaperName { get; set; }
        public string PaperType { get; set; }
        public double Quantity { get; set; }
    }
}