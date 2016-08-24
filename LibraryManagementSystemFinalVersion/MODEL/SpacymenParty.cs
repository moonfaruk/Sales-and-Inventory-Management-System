using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class SpacymenParty
    {
        public int SpacymenPartyId { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string SpacymenPartyCode { get; set; }
        public string SpacymenPartyName { get; set; }
        public string SpacymenPartyAddress { get; set; }
        public string SchoolName { get; set; }
    }
}