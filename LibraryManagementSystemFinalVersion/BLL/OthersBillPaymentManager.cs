using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class OthersBillPaymentManager
    {
        OthersBillPaymentGateway othersBillPaymentGateway = new OthersBillPaymentGateway();
        public List<OthersGroup> GetAllGroupByIdDropDownList()
        {
            return othersBillPaymentGateway.GetAllGroupByIdDropDownList();
        }

        public List<BankAccount> GetAllBankInfoByIdDropDownList()
        {
            return othersBillPaymentGateway.GetAllBankInfoByIdDropDownList();
        }

        public string Save(OthersBillPayment othersBillPayment)
        {
            if (othersBillPaymentGateway.Insert(othersBillPayment)>0)
            {
                return "Saved Successfully!!";
            }
            return "Could not Save Data in Database!!";
        }

        public List<OthersBillPayment> GetAllOthersBillPaymentList()
        {
            return othersBillPaymentGateway.GetAllOthersBillPaymentList();
        }

        public OthersBillPayment GetOthesBills(int i)
        {
            return othersBillPaymentGateway.GetOthersBills(i);
        }

        public DataTable GetOthersPaymentReportData()
        {
            return othersBillPaymentGateway.GetOthersPaymentReportData();
        }
    }
}