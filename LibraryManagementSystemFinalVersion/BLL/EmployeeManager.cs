using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class EmployeeManager
    {
        EmployeeGateway employeeGateway = new EmployeeGateway();

        public string Save(Employee employee)
        {
            bool isEmpNationalIdIsExit = employeeGateway.CheckEmpNationalIdIsExit(employee.EmployeeNationalId);
            if (isEmpNationalIdIsExit)
            {
                return " National Id is already Exit in database!!";
            }
            else if (employeeGateway.Insert(employee) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not save data In Database!!";

        }

        public Employee GetNextEmployeeCode()
        {
            return employeeGateway.GetNextEmployeeCode();
        }
    }
}