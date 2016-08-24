using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class BookInfo
    {
        public int BookInfoId { get; set; }
        public string BookCode { get; set; }
        public string BookName { get; set; }
        public string BookSize { get; set; }
        public double BookForma { get; set; }
        public double BookInar { get; set; }
        public int PressId { get; set; }
        public string PressName { get; set; }
        public int BinderId { get; set; }
        public string BinderName { get; set; }
        public double BookRate { get; set; }
        public double BookReturnRate { get; set; }
        public double BookCommission { get; set; }
        public double BookOpeningBalance { get; set; }
        public string BookStatus { get; set; }
        public int MainBookId { get; set; }
        public string MainBookCode { get; set; }

    }
}