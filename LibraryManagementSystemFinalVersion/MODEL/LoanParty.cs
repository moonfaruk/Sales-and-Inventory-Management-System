using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class LoanParty
    {
        public int LoanPartyId { get; set; }
        public int LoanCode { get; set; }
        public string LoanName { get; set; }
        public string Remarks { get; set; }


    }
}