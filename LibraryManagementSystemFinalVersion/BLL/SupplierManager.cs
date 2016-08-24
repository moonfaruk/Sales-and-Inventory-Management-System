using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class SupplierManager
    {
        SupplierGateway supplierGateway = new SupplierGateway();

        public string Save(Supplier supplier)
        {
            if (supplierGateway.Insert(supplier) > 0)
            {
                return "Saved Successfully!!";
            }
            else
            {
                return "Could Not Save Data in Database!!";
            }
        }

        public Supplier GetNextSupplierCode()
        {
            return supplierGateway.GetNextSupplierCode();
        }
    }
}