using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public double SupplierOpeningBalance { get; set; }



        //public Supplier(string supplierCode, string supplierName, string supplierAddress, double supplierOpeningBalance)
        //{
        //    SupplierCode = supplierCode;
        //    SupplierName = supplierName;
        //    SupplierAddress = supplierAddress;
        //    SupplierOpeningBalance = supplierOpeningBalance;
        //}

        //public Supplier()
        //{
            
        //}
    }
}