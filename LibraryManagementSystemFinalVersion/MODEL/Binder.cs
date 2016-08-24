using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class Binder
    {
        public int BinderId { get; set; }
        public string BinderCode { get; set; }
        public string BinderName { get; set; }
        public string BinderAddress { get; set; }
        public double BinderOpeningBalance { get; set; }
    }
}