using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class PaperTransfer
    {
        public int PaperTransferId { get; set; }
        public string Date { get; set; }
        public string TransferNo { get; set; }
        public int FromPressId { get; set; }
        public int ToPressId { get; set; }
        public int PaperId { get; set; }
        public string PaperName { get; set; }
        public string PaperType { get; set; }
        public double Quantity { get; set; }
    }
}