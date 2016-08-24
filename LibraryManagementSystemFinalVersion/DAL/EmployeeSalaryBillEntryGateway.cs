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
    public class EmployeeSalaryBillEntryGateway
    {
         string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
        public List<Employee> GetAllEmployeeByDropDownList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_employee";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Employee> employeeList = new List<Employee>();
            while (reader.Read())
            {
                Employee employee = new Employee();
                employee.EmployeeId = int.Parse(reader["id"].ToString());
                employee.EmployeeName = reader["employee_name"].ToString();
                employeeList.Add(employee);
            }
            reader.Close();
            connection.Close();
            return employeeList;
        }

        public int Insert(EmployeeSalaryBillEntry employeeSalaryBillEntry)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_employee_salary_entry VALUES('" + employeeSalaryBillEntry.EmployeeDate +
                           "','" + employeeSalaryBillEntry.EmployeeYear + "','" + employeeSalaryBillEntry.EmployeeMonth +
                           "','" + employeeSalaryBillEntry.EmployeeName + "','" + employeeSalaryBillEntry.SalaryReduce +
                           "','" + employeeSalaryBillEntry.Bonus + "','" + employeeSalaryBillEntry.Salary + "','" +
                           employeeSalaryBillEntry.Remarks + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<EmployeeSalaryBillEntry> GetAllEmployeesBillEntryList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from tbl_employee_salary_entry";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<EmployeeSalaryBillEntry> employeeSalaryBillEntryList = new List<EmployeeSalaryBillEntry>();
            while (reader.Read())
            {
                
                EmployeeSalaryBillEntry employeeSalaryBillEntry = new EmployeeSalaryBillEntry();
                GetValue(employeeSalaryBillEntry, reader);
                employeeSalaryBillEntryList.Add(employeeSalaryBillEntry);
            }
            reader.Close();
            connection.Close();
            return employeeSalaryBillEntryList;
        }

        private static void GetValue(EmployeeSalaryBillEntry employeeSalaryBillEntry, SqlDataReader reader)
        {
            employeeSalaryBillEntry.EmployeeSalaryBillEntryId = int.Parse(reader["id"].ToString());
            employeeSalaryBillEntry.EmployeeDate = (reader["employee_date"].ToString()).Substring(0,10);
            employeeSalaryBillEntry.EmployeeYear = Convert.ToDouble(reader["employee_year"].ToString());
            employeeSalaryBillEntry.EmployeeMonth = reader["employee_month"].ToString();
            employeeSalaryBillEntry.EmployeeName = reader["employee_id"].ToString();
            employeeSalaryBillEntry.SalaryReduce = Convert.ToDouble(reader["salary_reduce"].ToString());
            employeeSalaryBillEntry.Bonus = Convert.ToDouble(reader["bonus"].ToString());
            employeeSalaryBillEntry.Salary = Convert.ToDouble(reader["salary"].ToString());
            employeeSalaryBillEntry.Remarks = reader["remarks"].ToString();
        }

        public EmployeeSalaryBillEntry GetEmployees(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_employee_salary_entry ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            EmployeeSalaryBillEntry employeeSalaryBillEntry = new EmployeeSalaryBillEntry();
            while (reader.Read())
            {
                GetValue(employeeSalaryBillEntry, reader);
            }
            reader.Close();
            connection.Close();
            return employeeSalaryBillEntry;
        }

        public DataTable GetEmployeeSalaryReportData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_employee_salary_entry ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            connection.Close();
            return dt;
        }
    }
}