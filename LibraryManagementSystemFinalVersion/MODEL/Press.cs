using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class Press
    {
        public int PressId { get; set; }
        public string PressCode { get; set; }
        public string PressName { get; set; }
        public string PressAddress { get; set; }
        public double PressOpeningBalance { get; set; }
    }
}