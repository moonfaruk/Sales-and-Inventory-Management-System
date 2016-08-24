using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class BookSales
    {
        public int BookSalesId { get; set; }
        public string Date { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int PartyId { get; set; }
        public string PartyCode { get; set; }
        public string MemoNo { get; set; }
        public string SalesType { get; set; }
        public double Quantity { get; set; }
        public string Year { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public double BookRate { get; set; }
        public double Commisssion { get; set; }
        public double SalesRate { get; set; }
        public double Packing { get; set; }
        public double Bonus { get; set; }
        public double PaymentAmount { get; set; }
        public double Dues { get; set; }
        public double TotalPrice { get; set; }
        public double Total { get; set; }

    }
}