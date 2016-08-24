using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class EmployeeSalaryBillEntryManager
    {
        EmployeeSalaryBillEntryGateway employeeSalaryBillEntryGateway = new EmployeeSalaryBillEntryGateway();
        public List<Employee> GetAllEmployeeByDropDownList()
        {
            return employeeSalaryBillEntryGateway.GetAllEmployeeByDropDownList();
        }

        public string Save(EmployeeSalaryBillEntry employeeSalaryBillEntry)
        {
            if (employeeSalaryBillEntryGateway.Insert(employeeSalaryBillEntry) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save data In Database!!";
        }

        public List<EmployeeSalaryBillEntry> GetAllEmployeesBillEntryList()
        {
            return employeeSalaryBillEntryGateway.GetAllEmployeesBillEntryList();
        }

        public EmployeeSalaryBillEntry GetEmployees(int i)
        {
            return employeeSalaryBillEntryGateway.GetEmployees(i);

        }

        public DataTable GetEmployeeSalaryReportData()
        {
            return employeeSalaryBillEntryGateway.GetEmployeeSalaryReportData();
        }
    }
}