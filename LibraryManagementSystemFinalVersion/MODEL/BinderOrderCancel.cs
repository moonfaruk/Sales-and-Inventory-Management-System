using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class BinderOrderCancel
    {
        public int BinderOrderCancelId { get; set; }
        public string Date { get; set; }
        public string Year { get; set; }
        public int BinderId { get; set; }
        public string BinderName { get; set; }
        public string OrderNo { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public double Quantity { get; set; }
    }
}