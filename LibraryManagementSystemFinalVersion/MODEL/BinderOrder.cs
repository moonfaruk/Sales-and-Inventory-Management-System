using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class BinderOrder
    {
        public int BinderOrderId { get; set; }
        public string Date { get; set; }
        public string Year { get; set; }
        public string OrderNo { get; set; }
        public int BinderId { get; set; }
        public string BinderName { get; set; }
        public int GroupId { get; set; }
        public string GroupCode { get; set; }
        public int BookId { get; set; }
        public string BookCode { get; set; }
        public double Quantity { get; set; }
        public double FormaQuantity { get; set; }
        public int PressId { get; set; }
        public string PressName { get; set; }
        public double Forma { get; set; }
    }
}