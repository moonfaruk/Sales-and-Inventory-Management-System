using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class Party
    {
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int PartyId { get; set; }
        public string PartyCode { get; set; }
        public string PartyName { get; set; }
        public string PartyPropiter { get; set; }
        public string PartyAddress { get; set; }
        public string PartyPhone { get; set; }
        public string PartyEmail { get; set; }
        public string PartyWeb { get; set; }
        public double PartyOpeningBalance { get; set; }
        public string PartyDate { get; set; }
    }
}