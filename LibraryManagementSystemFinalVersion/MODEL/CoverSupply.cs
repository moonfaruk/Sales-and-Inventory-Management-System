using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class CoverSupply
    {
        public int CoverSupplyId { get; set; }
        public string Date { get; set; }
        public string SupplyNo { get; set; }
        public int BinderId { get; set; }
        public string BinderName { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public double Quantity { get; set; }
    }
}