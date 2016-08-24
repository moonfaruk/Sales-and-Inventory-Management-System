using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class EmployeeSalaryBillEntry
    {
        public int EmployeeSalaryBillEntryId { get; set; }
        public string EmployeeDate { get; set; }
        public double EmployeeYear { get; set; }
        public string EmployeeMonth { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public double SalaryReduce { get; set; }
        public double Bonus { get; set; }
        public double Salary { get; set; }
        public string Remarks { get; set; }
    }
}