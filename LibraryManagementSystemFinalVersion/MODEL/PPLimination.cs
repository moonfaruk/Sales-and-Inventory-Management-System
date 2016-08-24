using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class PPLimination
    {
        public int PPLiminationId { get; set; }
        public string PPLiminationCode { get; set; }
        public string PPLiminationName { get; set; }
        public string PPLiminationAddress { get; set; }
        public double PPLiminationOpeningBalance { get; set; }
    }
}