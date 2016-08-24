using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class CoverReceived
    {
        public int CouerReceivedId { get; set; }
        public string Date { get; set; }
        public string RecNo { get; set; }
        public string Year { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public double Quantity { get; set; }
    }
}