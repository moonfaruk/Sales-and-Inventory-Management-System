using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class EmployeeSalaryPaymentGateway
    {
         string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
        public List<Employee> GetAllEmployeeByDropDownList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_employee";
            SqlCommand command = new SqlCommand(query, connection);
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

        public List<BankAccount> GetAllBankInfoByIdDropDownList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bankAccount";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<BankAccount> bankAccountList = new List<BankAccount>();
            while (reader.Read())
            {
                BankAccount bankAccount = new BankAccount();
                bankAccount.BankAccountId = int.Parse(reader["id"].ToString());
                bankAccount.BankAccountName = reader["bank_name"].ToString();
                bankAccountList.Add(bankAccount);
            }
            reader.Close();
            connection.Close();
            return bankAccountList;
        }

        public int Insert(EmployeeSalaryPayment employeeSalaryPayment)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_employeeSalaryPayment VALUES('" + employeeSalaryPayment.EmployeeDate + "','" +
                           employeeSalaryPayment.EmployeeYear + "','" + employeeSalaryPayment.EmployeeMonth + "','" +
                           employeeSalaryPayment.EmployeeId + "','" + employeeSalaryPayment.PaymentMode + "','" +
                           employeeSalaryPayment.BankId + "','" + employeeSalaryPayment.CheckNo + "','" +
                           employeeSalaryPayment.CheckDate + "','" + employeeSalaryPayment.Amount + "','" +
                           employeeSalaryPayment.Remarks + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public EmployeeSalaryPayment GetLastEmployeeSalary()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_employeeSalaryPayment ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            EmployeeSalaryPayment employeeSalaryPayment = new EmployeeSalaryPayment();
            while (reader.Read())
            {
                employeeSalaryPayment.EmployeeSalaryPaymentId = int.Parse(reader["id"].ToString());
                employeeSalaryPayment.EmployeeDate = reader["date"].ToString();
                employeeSalaryPayment.EmployeeYear = Convert.ToDouble(reader["year"].ToString());
                employeeSalaryPayment.EmployeeMonth = reader["month"].ToString();
                employeeSalaryPayment.EmployeeName = reader["employee_id"].ToString();
                employeeSalaryPayment.PaymentMode = reader["payment_mode"].ToString();
                employeeSalaryPayment.BankName = reader["bank_id"].ToString();
                employeeSalaryPayment.CheckNo = reader["check_no"].ToString();
                employeeSalaryPayment.CheckDate = reader["check_date"].ToString();
                employeeSalaryPayment.Amount = Convert.ToDouble(reader["amount"].ToString());
                employeeSalaryPayment.Remarks = reader["remarks"].ToString();

            }
            reader.Close();
            connection.Close();
            return employeeSalaryPayment;
        }
    }
}