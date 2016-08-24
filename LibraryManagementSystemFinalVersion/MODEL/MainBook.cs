using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class MainBook
    {
        public int MainBookId { get; set; }
        public string MainBookCode { get; set; }
        public string MainBookName { get; set; }
        public string MainBookClass { get; set; }

        public MainBook(string mainBookCode, string mainBookName, string mainBookClass)
        {
            MainBookCode = mainBookCode;
            MainBookName = mainBookName;
            MainBookClass = mainBookClass;
        }

        public MainBook()
        {
            
        }
    }
}