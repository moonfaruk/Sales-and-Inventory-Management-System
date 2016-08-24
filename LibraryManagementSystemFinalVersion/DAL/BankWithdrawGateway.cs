using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class BankWithdrawGateway
    {
         string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;

        public List<BankAccount> GetAllBankInfoByDropDownList()
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

        public BankAccount GetBank(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bankAccount WHERE id=" + i;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BankAccount bankAccount = new BankAccount();
            while (reader.Read())
            {
                bankAccount.BankAccountId = int.Parse(reader["id"].ToString());
                bankAccount.AccountNo = reader["account_no"].ToString();

            }
            reader.Close();
            connection.Close();
            return bankAccount;
        }

        public int Insert(BankWithdraw bankWithdraw)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_bankWithdraw VALUES('" + bankWithdraw.Date + "','" + bankWithdraw.BankId +
                           "','" + bankWithdraw.CheckNo + "','" + bankWithdraw.WithdrawBy + "','" + bankWithdraw.Amount +
                           "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public BankWithdraw GetLastBankWithdrawInfo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_bankWithdraw ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BankWithdraw bankWithdraw = new BankWithdraw();
            while (reader.Read())
            {
                bankWithdraw.BankWithdrawId = int.Parse(reader["id"].ToString());
                bankWithdraw.Date = reader["date"].ToString();
                bankWithdraw.BankName = reader["bank_id"].ToString();
                bankWithdraw.AccountNo = reader["bank_id"].ToString();
                bankWithdraw.CheckNo = reader["check_no"].ToString();
                bankWithdraw.WithdrawBy = reader["withdrawBy"].ToString();
                bankWithdraw.Amount = Convert.ToDouble(reader["amount"].ToString());

            }
            reader.Close();
            connection.Close();
            return bankWithdraw;
        }

        public BankAccount GetAccountNo(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bankAccount WHERE id=" + i;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BankAccount bankAccount = new BankAccount();
            while (reader.Read())
            {
                bankAccount.BankAccountId = int.Parse(reader["id"].ToString());
                bankAccount.AccountNo = reader["account_no"].ToString();

            }
            reader.Close();
            connection.Close();
            return bankAccount;
        }
    }
}