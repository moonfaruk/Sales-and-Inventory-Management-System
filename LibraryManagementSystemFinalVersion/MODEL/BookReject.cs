using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class BookReject
    {
        public int BookRejectId { get; set; }
        public string Date { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int PartyId { get; set; }
        public string PartyName { get; set; }
        public string RejectNo { get; set; }
        public double Quantity { get; set; }
        public string Year { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public double BookRate { get; set; }
        public double Commission { get; set; }
        public double RejectRate { get; set; }
        public double Total { get; set; }

    }
}