using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public  class EmployeeGateway
    {
         string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;

        public int Insert(Employee employee)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_employee VALUES('" + employee.EmployeeCode + "','" + employee.EmployeeName +
                           "','" + employee.EmployeeNationalId + "','" + employee.EmployeeContactNo + "','" +
                           employee.EmployeeAddress + "','" + employee.EmployeeBasicSalary + "','" +
                           employee.EmployeeOpeningBalance + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public Employee GetNextEmployeeCode()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_employee ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Employee employee = new Employee();
            while (reader.Read())
            {
                employee.EmployeeId = int.Parse(reader["id"].ToString());
                employee.EmployeeCode = reader["employee_code"].ToString();
            }
            reader.Close();
            connection.Close();
            return employee;
        }

        public bool CheckEmpNationalIdIsExit(double employeeNationalId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_employee WHERE employee_nationalId=" + employeeNationalId;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool checkNationalId = false;
            Employee employee = new Employee();
            while (reader.Read())
            {
                employee.EmployeeNationalId = Convert.ToDouble(reader["employee_nationalId"].ToString());
                checkNationalId = true;
            }
            reader.Close();
            connection.Close();

            return checkNationalId;
        }
    }
}