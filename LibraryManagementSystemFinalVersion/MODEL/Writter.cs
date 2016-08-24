using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class Writter
    {
        public int WritterId { get; set; }
        public string WritterCode { get; set; }
        public string WritterName { get; set; }
        public string WritterPhone { get; set; }
        public string WritterAddress { get; set; }
        public double WritterOpeningBalance { get; set; }
    }
}