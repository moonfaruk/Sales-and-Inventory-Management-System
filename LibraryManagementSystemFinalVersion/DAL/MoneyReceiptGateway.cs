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
    public class MoneyReceiptGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
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

        public List<Party> GetAllPartiesByIdDropDownList()
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
                party.PartyCode = reader["party_code"].ToString();
                partyList.Add(party);
            }
            reader.Close();
            connection.Close();
            return partyList;
        }

        public Party GetPartyName(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_party WHERE id=" + i;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Party party = new Party();
            while (reader.Read())
            {
                party.PartyId = int.Parse(reader["id"].ToString());
                party.PartyName = reader["party_name"].ToString();
                party.PartyCode = reader["party_code"].ToString();

            }
            reader.Close();
            connection.Close();
            return party;
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

        public MoneyReceipt GetNextMrNo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_moneyReceipt ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            MoneyReceipt moneyReceipt = new MoneyReceipt();
            while (reader.Read())
            {
                moneyReceipt.MoneyReceiptId = int.Parse(reader["id"].ToString());
                moneyReceipt.MrNo = reader["mr_no"].ToString();
            }
            reader.Close();
            connection.Close();
            return moneyReceipt;
        }

        public MoneyReceipt GetNextChequeNo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_moneyReceipt ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            MoneyReceipt moneyReceipt = new MoneyReceipt();
            while (reader.Read())
            {
                moneyReceipt.MoneyReceiptId = int.Parse(reader["id"].ToString());
                moneyReceipt.ChequeNo = reader["cheque_no"].ToString();
            }
            reader.Close();
            connection.Close();
            return moneyReceipt;
        }

        public int Insert(MoneyReceipt moneyReceipt)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_moneyReceipt VALUES('" + moneyReceipt.Date + "','" + moneyReceipt.MrNo +
                           "','" + moneyReceipt.DistrictId + "','" + moneyReceipt.PartyId + "','" + moneyReceipt.Mode +
                           "','" + moneyReceipt.ChequeNo + "','" + moneyReceipt.ChequeDate + "','" + moneyReceipt.BankId +
                           "','" + moneyReceipt.BranchName + "','" + moneyReceipt.Amount + "','" + moneyReceipt.Remarks +
                           "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<MoneyReceipt> GetAllMoneyReceipt()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_moneyReceipt";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<MoneyReceipt> moneyReceiptList = new List<MoneyReceipt>();
            while (reader.Read())
            {
                MoneyReceipt moneyReceipt = new MoneyReceipt();
                GetValueFromDatabase(moneyReceipt, reader);

                moneyReceiptList.Add(moneyReceipt);

            }
            reader.Close();
            connection.Close();
            return moneyReceiptList;
        }

        private  void GetValueFromDatabase(MoneyReceipt moneyReceipt, SqlDataReader reader)
        {
            moneyReceipt.MoneyReceiptId = int.Parse(reader["id"].ToString());
            moneyReceipt.Date = reader["date"].ToString();
            moneyReceipt.MrNo = reader["mr_no"].ToString();
            moneyReceipt.DistrictName = reader["district_id"].ToString();
            moneyReceipt.PartyId = int.Parse(reader["party_id"].ToString());
            Party party = GetPartyName(moneyReceipt.PartyId);
            moneyReceipt.PartyCode = party.PartyCode;
            moneyReceipt.PartyName = party.PartyName;
            moneyReceipt.Mode = reader["mode"].ToString();
            moneyReceipt.ChequeNo = reader["cheque_no"].ToString();
            moneyReceipt.ChequeDate = reader["cheque_date"].ToString();
            moneyReceipt.BankName = reader["bank_id"].ToString();
            moneyReceipt.BranchName = reader["branch_name"].ToString();
            moneyReceipt.Amount = Convert.ToDouble(reader["amount"].ToString());
            moneyReceipt.Remarks = reader["remarks"].ToString();
        }

        public MoneyReceipt GetMoneyReceipt(int i)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_moneyReceipt ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            MoneyReceipt moneyReceipt = new MoneyReceipt();
            while (reader.Read())
            {
                GetValueFromDatabase(moneyReceipt, reader);
            }
            reader.Close();
            connection.Close();
            return moneyReceipt;
        }

        public MoneyReceipt GetSearchInfo(string mrNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_moneyReceipt WHERE mr_no='" + mrNo + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            MoneyReceipt moneyReceipt = new MoneyReceipt();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                GetValueFromDatabase(moneyReceipt, reader);
            }
            reader.Close();
            connection.Close();
            return moneyReceipt;
        }

        public DataTable GetMoneyReceiptData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_moneyReceiptView";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            connection.Close();
            return dt;
        }
    }
}