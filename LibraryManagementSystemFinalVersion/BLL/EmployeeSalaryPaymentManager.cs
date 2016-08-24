using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class EmployeeSalaryPaymentManager
    {
        EmployeeSalaryPaymentGateway employeeSalaryPaymentGateway = new EmployeeSalaryPaymentGateway();
        public List<Employee> GetAllEmployeeByDropDownList()
        {
            return employeeSalaryPaymentGateway.GetAllEmployeeByDropDownList();
        }

        public List<BankAccount> GetAllBankInfoByIdDropDownList()
        {
            return employeeSalaryPaymentGateway.GetAllBankInfoByIdDropDownList();
        }

        public string Save(EmployeeSalaryPayment employeeSalaryPayment)
        {
            if (employeeSalaryPaymentGateway.Insert(employeeSalaryPayment) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save Data in Database!!";
        }

        public EmployeeSalaryPayment GetLastEmployeeSalary()
        {
            return employeeSalaryPaymentGateway.GetLastEmployeeSalary();
        }
    }
}