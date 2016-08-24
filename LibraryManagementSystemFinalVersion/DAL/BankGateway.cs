using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls.Expressions;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class BankGateway
    {
         string connectionString =  WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
        public int Insert(BankAccount bankAccount)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_bankAccount VALUES('" + bankAccount.BankAccountCode + "','" +
                           bankAccount.BankAccountName + "','"+bankAccount.AccountNo+"','" + bankAccount.BankAccountOpeningBalance + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public BankAccount GetNextBankCode()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_bankAccount ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BankAccount bankAccount = new BankAccount();
            while (reader.Read())
            {
                bankAccount.BankAccountId = int.Parse(reader["id"].ToString());
                bankAccount.BankAccountCode = reader["bank_code"].ToString();
            }
            reader.Close();
            connection.Close();
            return bankAccount;
        }

        public List<BankAccount> GetAllBankInfo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bankAccount";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            int serial = 1;
            List<BankAccount> bankList = new List<BankAccount>();
            while (reader.Read())
            {
                BankAccount account = new BankAccount();
                account.SerialNo = serial++;
                account.BankAccountId = int.Parse(reader["id"].ToString());
                account.BankAccountCode = reader["bank_code"].ToString();
                account.BankAccountName = reader["bank_name"].ToString();
                account.AccountNo = reader["account_no"].ToString();
                account.BankAccountOpeningBalance = Convert.ToDouble(reader["bank_opening_balance"].ToString());

                bankList.Add(account);
            }
            reader.Close();
            connection.Close();
            return bankList;
        }

        public BankAccount GetBankAccountById(int bankAccountId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bankAccount WHERE id =" + bankAccountId;
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BankAccount bankAccount = new BankAccount();
            while (reader.Read())
            {
                bankAccount.BankAccountId = int.Parse(reader["id"].ToString());
                bankAccount.BankAccountCode = reader["bank_code"].ToString();
                bankAccount.BankAccountName = reader["bank_name"].ToString();
                bankAccount.AccountNo = reader["account_no"].ToString();
                bankAccount.BankAccountOpeningBalance = Convert.ToDouble(reader["bank_opening_balance"].ToString());
                break;
            }
            reader.Close();
            connection.Close();
            return bankAccount;
        }

        public bool UpdateBankAccount(BankAccount bankAccount)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE tbl_bankAccount SET bank_code='" + bankAccount.BankAccountCode +
                           "',bank_name='" + bankAccount.BankAccountName + "',account_no='"+bankAccount.AccountNo+"',bank_opening_balance='" +
                           bankAccount.BankAccountOpeningBalance + "' WHERE id=" + bankAccount.BankAccountId;
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteBankAccount(int dId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "DELETE FROM tbl_bankAccount WHERE id=" + dId;
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}