using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public double EmployeeNationalId { get; set; }
        public string EmployeeContactNo { get; set; }
        public string EmployeeAddress { get; set; }
        public double EmployeeBasicSalary { get; set; }
        public double EmployeeOpeningBalance { get; set; }
    }
}