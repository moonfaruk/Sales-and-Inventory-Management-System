using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class Bonus
    {
        public int BonusId { get; set; }
        public string Date { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int PartyId { get; set; }
        public string PartyCode { get; set; }
        public string PartyName { get; set; }
        public double Amount { get; set; }
    }
}