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
    public class OthersBillPaymentGateway
    {
         string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
        public List<OthersGroup> GetAllGroupByIdDropDownList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_other_group";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<OthersGroup> othersGroupList = new List<OthersGroup>();
            while (reader.Read())
            {
                OthersGroup othersGroup = new OthersGroup();
                othersGroup.OthersGroupId = int.Parse(reader["id"].ToString());
                othersGroup.OtherGroupName = reader["other_group_name"].ToString();
                othersGroupList.Add(othersGroup);
            }
            reader.Close();
            connection.Close();
            return othersGroupList;
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

        public int Insert(OthersBillPayment othersBillPayment)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_otherBillPayment VALUES('" + othersBillPayment.Date + "','" +
                           othersBillPayment.OtherGroupId + "','" + othersBillPayment.PaymentMode + "','" +
                           othersBillPayment.BankId + "','" + othersBillPayment.CheckNo + "','" +
                           othersBillPayment.CheckDate + "','" + othersBillPayment.Amount + "','"+othersBillPayment.Remarks+"')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<OthersBillPayment> GetAllOthersBillPaymentList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_otherBillPayment";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<OthersBillPayment> othersBillPaymentList = new List<OthersBillPayment>();
            while (reader.Read())
            {
                OthersBillPayment othersBillPayment = new OthersBillPayment();
                GetValueFromDatabase(othersBillPayment, reader);

                othersBillPaymentList.Add(othersBillPayment);
            }
            reader.Close();
            connection.Close();
            return othersBillPaymentList;
        }

        private static void GetValueFromDatabase(OthersBillPayment othersBillPayment, SqlDataReader reader)
        {
            othersBillPayment.OthersBillPaymentId = int.Parse(reader["id"].ToString());
            othersBillPayment.Date = reader["date"].ToString();
            othersBillPayment.OtherGroupName = reader["other_name_id"].ToString();
            othersBillPayment.PaymentMode = reader["payment_mode"].ToString();
            othersBillPayment.BankName = reader["bank_id"].ToString();
            othersBillPayment.CheckNo = reader["check_no"].ToString();
            othersBillPayment.CheckDate = reader["check_date"].ToString();
            othersBillPayment.Amount = Convert.ToDouble(reader["amount"].ToString());
            othersBillPayment.Remarks = reader["remarks"].ToString();
        }

        public OthersBillPayment GetOthersBills(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_otherBillPayment ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            OthersBillPayment othersBillPayment = new OthersBillPayment();
            while (reader.Read())
            {
                GetValueFromDatabase(othersBillPayment, reader);
            }
            reader.Close();
            connection.Close();
            return othersBillPayment;
        }

        public DataTable GetOthersPaymentReportData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_otherBillPayment ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            connection.Close();
            return dt;
        }
    }
}