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
    public class BankDepositGateway
    {
         string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
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

        public List<District> GetAllDistrictByDropDownList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_district";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<District> districtList = new List<District>();
            while (reader.Read())
            {
                District district = new District();
                district.DistrictId = int.Parse(reader["id"].ToString());
                district.DistrictName = reader["district_name"].ToString();
                districtList.Add(district);
            }
            reader.Close();
            connection.Close();
            return districtList;
        }

        public List<Party> GetAllPartyByDropDownList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_party";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Party> partyList = new List<Party>();
            while (reader.Read())
            {
                Party party = new Party();
                party.PartyId = int.Parse(reader["id"].ToString());
                party.PartyName = reader["party_name"].ToString();
                partyList.Add(party);
            }
            reader.Close();
            connection.Close();
            return partyList;
        }

        public int Insert(BankDeposit bankDeposit)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_bankDeposit VALUES('" + bankDeposit.BankDate + "','" + bankDeposit.BankId +
                           "','" + bankDeposit.Mode + "','" + bankDeposit.PartyBankName + "','" + bankDeposit.CheckNo +
                           "','" + bankDeposit.DistrictId + "','" + bankDeposit.PartyId + "','" + bankDeposit.Amount +
                           "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<BankDeposit> GetAllBankDeposit()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bankDeposit";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<BankDeposit> bankDepositList = new List<BankDeposit>();
            while (reader.Read())
            {
                BankDeposit bankDeposit = new BankDeposit();
                GetValueFromDatabase(bankDeposit, reader);
                bankDepositList.Add(bankDeposit);
            }
            reader.Close();
            connection.Close();
            return bankDepositList;
        }

        private static void GetValueFromDatabase(BankDeposit bankDeposit, SqlDataReader reader)
        {
            bankDeposit.BankDepositId = int.Parse(reader["id"].ToString());
            bankDeposit.BankDate = reader["date"].ToString();
            bankDeposit.BankName = reader["bank_id"].ToString();
            bankDeposit.Mode = reader["mode"].ToString();
            bankDeposit.PartyBankName = reader["party_bank_name"].ToString();
            bankDeposit.CheckNo = reader["check_no"].ToString();
            bankDeposit.DistrictName = reader["district_id"].ToString();
            bankDeposit.PartyName = reader["party_id"].ToString();
            bankDeposit.Amount = Convert.ToDouble(reader["amount"].ToString());
        }

        public BankDeposit GetBankDepositInfo(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bankDeposit ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BankDeposit bankDeposit = new BankDeposit();
            while (reader.Read())
            {
                GetValueFromDatabase(bankDeposit, reader);
            }
            reader.Close();
            connection.Close();
            return bankDeposit;
        }

        public DataTable GetBankDepositReportData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_bankDeposit ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            connection.Close();
            return dt;
        }
    }
}