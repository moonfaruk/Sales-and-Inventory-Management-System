using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class EmployeeSalaryPayment
    {
        public int EmployeeSalaryPaymentId { get; set; }
        public string EmployeeDate { get; set; }
        public double EmployeeYear { get; set; }
        public string EmployeeMonth { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string PaymentMode { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string CheckNo { get; set; }
        public string CheckDate { get; set; }
        public double Amount { get; set; }
        public string Remarks { get; set; }
     
    }
}