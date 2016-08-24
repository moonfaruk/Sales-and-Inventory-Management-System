using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class PaperPrint
    {
        public int PaperPrintId { get; set; }
        public string Date { get; set; }
        public string OrderNo { get; set; }
        public int PressId { get; set; }
        public string PressName { get; set; }
        public string Year { get; set; }
        public string PrintingType { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public double Plate { get; set; }
        public double Forma { get; set; }
        public string FormaType { get; set; }
        public string ColorType { get; set; }
        public int PaperId { get; set; }
        public string PaperName { get; set; }
        public string PaperType { get; set; }
        public double BookQuantity { get; set; }
        public double PaperQuantity { get; set; }
    }
}