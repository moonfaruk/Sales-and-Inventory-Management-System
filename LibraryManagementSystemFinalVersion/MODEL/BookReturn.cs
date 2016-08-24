using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class BookReturn
    {
        public int BookReturnId { get; set; }
        public string Date { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int PartyId { get; set; }
        public string PartyName { get; set; }
        public string ReturnNo { get; set; }
        public string ChallanReturn { get; set; }
        public double Quantity { get; set; }
        public string Year { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public double BookRate { get; set; }
        public double Commission { get; set; }
        public double ReturnRate { get; set; }
        public double TransportBill { get; set; }
        public double Less { get; set; }
        public double Total { get; set; }
        public double NetReturn { get; set; }

    }
}