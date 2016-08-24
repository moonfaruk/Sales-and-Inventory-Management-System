using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class SupplierBillPaymentManager
    {
        SupplierBillPaymentGateway supplierBillPaymentGateway = new SupplierBillPaymentGateway();
        public List<Supplier> GetSupplierInfoByDropDownList()
        {
            return supplierBillPaymentGateway.GetSupplierInfoByDropDownList();
        }

        public List<BankAccount> GetBankInfoByDropDownList()
        {
            return supplierBillPaymentGateway.GetBankInfoByDropDownList();
        }

        public SupplierBillPayment GetNextBillNo()
        {
            return supplierBillPaymentGateway.GetNextBillNo();
        }

        public string Save(SupplierBillPayment supplierBillPayment)
        {
            if (supplierBillPaymentGateway.Insert(supplierBillPayment) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save data in Database!!";
        }

        public DataTable GetSupplierBillPaymentReportData()
        {
            return supplierBillPaymentGateway.GetSupplierBillPaymentReportData();
        }

        public List<SupplierBillPayment> GetAllSupplierBillPaymentList()
        {
            return supplierBillPaymentGateway.GetAllSupplierBillPaymentList();
        }

        public SupplierBillPayment GetSupplierBillPayment(int i)
        {
            return supplierBillPaymentGateway.GetSupplierBillPayment(i);
        }

        public DataTable GetSupplierReportDateWise(DateTime fromDate, DateTime toDate)
        {
            return supplierBillPaymentGateway.GetSupplierReportDateWise(fromDate, toDate);
        }
    }
}