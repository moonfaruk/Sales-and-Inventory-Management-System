using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class SupplierBillPaymentGateway
    {
         string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
        public List<Supplier> GetSupplierInfoByDropDownList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_supplier";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Supplier> supplierList = new List<Supplier>();
            while (reader.Read())
            {
                Supplier supplier = new Supplier();
                supplier.SupplierId = int.Parse(reader["id"].ToString());
                supplier.SupplierName = reader["supplier_name"].ToString();
                supplierList.Add(supplier);
            }
            reader.Close();
            connection.Close();
            return supplierList;
        }

        public List<BankAccount> GetBankInfoByDropDownList()
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

        public SupplierBillPayment GetNextBillNo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_supplierBillPayment ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            SupplierBillPayment supplierBillPayment = new SupplierBillPayment();
            while (reader.Read())
            {
                supplierBillPayment.SupplierBillPaymentId = int.Parse(reader["id"].ToString());
                supplierBillPayment.BillNo = reader["bill_no"].ToString();
            }
            reader.Close();
            connection.Close();
            return supplierBillPayment;
        }

        public int Insert(SupplierBillPayment supplierBillPayment)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_supplierBillPayment VALUES('" + supplierBillPayment.SupplierDate + "','" +
                           supplierBillPayment.BillNo + "','"+supplierBillPayment.SupId+"','" +
                           supplierBillPayment.PaymentMode + "','"+supplierBillPayment.BankId+"','" + supplierBillPayment.CheckNo + "','" +
                           supplierBillPayment.CheckDate + "','" + supplierBillPayment.Amount + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public DataTable GetSupplierBillPaymentReportData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_supplierBillPayment ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            connection.Close();
            return dt;
        }

        public List<SupplierBillPayment> GetAllSupplierBillPaymentList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_supplierBillPayment";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<SupplierBillPayment> supplierBillPaymentList = new List<SupplierBillPayment>();
            while (reader.Read())
            {
                SupplierBillPayment supplierBillPayment = new SupplierBillPayment();
                GetValueFromDatabase(supplierBillPayment, reader);

                supplierBillPaymentList.Add(supplierBillPayment);
            }
            reader.Close();
            connection.Close();
            return supplierBillPaymentList;
        }

        private static void GetValueFromDatabase(SupplierBillPayment supplierBillPayment, SqlDataReader reader)
        {
            supplierBillPayment.SupplierBillPaymentId = int.Parse(reader["id"].ToString());
            supplierBillPayment.SupplierDate = reader["date"].ToString();
            supplierBillPayment.BillNo = reader["bill_no"].ToString();
            supplierBillPayment.SupplierName = reader["supplier_id"].ToString();
            supplierBillPayment.PaymentMode = reader["payment_mode"].ToString();
            supplierBillPayment.BankAccountName = reader["bank_id"].ToString();
            supplierBillPayment.CheckNo = reader["check_no"].ToString();
            supplierBillPayment.CheckDate = reader["check_date"].ToString();
            supplierBillPayment.Amount = Convert.ToDouble(reader["amount"].ToString());
        }

        public SupplierBillPayment GetSupplierBillPayment(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_supplierBillPayment ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            SupplierBillPayment supplierBillPayment = new SupplierBillPayment();
            while (reader.Read())
            {
                GetValueFromDatabase(supplierBillPayment, reader);
            }
            reader.Close();
            connection.Close();
            return supplierBillPayment;
        }

        public DataTable GetSupplierReportDateWise(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("tbl_supplierLedger", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@From",fromDate.Date));
            command.Parameters.Add(new SqlParameter("@To", toDate.Date));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            connection.Close();
            return dt;
        }
    }
}