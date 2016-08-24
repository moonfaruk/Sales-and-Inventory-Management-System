using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class PersonalLoanPayment
    {
        public int PersonalLoanPaymentId { get; set; }
        public string LoanDate { get; set; }
        public string LoanType { get; set; }
        public int PartyId { get; set; }
        public string PartyName { get; set; }
        public double Amount { get; set; }
    }
}