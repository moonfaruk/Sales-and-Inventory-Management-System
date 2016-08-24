using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class Shope
    {
        public int ShopeId { get; set; }
        public int SerialNo { get; set; }
        public string ShopeCode { get; set; }
        public string ShopeName { get; set; }
        public string ShopePhone { get; set; }
        public string ShopeAddress { get; set; }
        public double MonthlyRent { get; set; }
        public double OpeningBalance { get; set; }

    }
}