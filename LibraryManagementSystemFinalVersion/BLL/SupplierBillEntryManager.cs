using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class SupplierBillEntryManager
    {
        SupplierBillEntryGateway supplierBillEntryGateway = new SupplierBillEntryGateway();

        public List<Supplier> GetSupplierInfoByDropDownList()
        {
            return supplierBillEntryGateway.GetSupplierInfoByDropDownList();
        }

        public List<Press> GetAllPressInfoByDropDownList()
        {
            return supplierBillEntryGateway.GetAllPressInfoByDropDownList();
        }

        public List<Paper> GetAllPaperInfoByDropDownList()
        {
            return supplierBillEntryGateway.GetAllPaperInfoByDropDownList();
        }

        public SupplierBillEntry GetNextBillNo()
        {
            return supplierBillEntryGateway.GetNextBillNo();
        }

        public string Save(SupplierBillEntry supplierBillEntry)
        {
            if (supplierBillEntryGateway.Insert(supplierBillEntry) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save Data in Database!!";
        }

        public List<SupplierBillEntry> GetAllSupplierBillEntryList()
        {
            return supplierBillEntryGateway.GetAllSupplierBillEntryList();
        }

        public SupplierBillEntry GetSupplierBillEntities(int i)
        {
            return supplierBillEntryGateway.GetSupplierBillEntities(i);
        }

        public DataTable GetSupplierBillReportData()
        {
            return supplierBillEntryGateway.GetSupplierBillReportData();
        }
    }
}