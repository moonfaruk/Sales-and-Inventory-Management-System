using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class LoanGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
        public int Insert(LoanParty loanParty)
        {
           SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_loan VALUES('" + loanParty.LoanCode + "','" + loanParty.LoanName + "','" +
                           loanParty.Remarks + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }

        public LoanParty GetNextLoanCode()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_loan ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            LoanParty loanParty = new LoanParty();
            while (reader.Read())
            {
                loanParty.LoanPartyId = int.Parse(reader["id"].ToString());
                loanParty.LoanCode = Convert.ToInt32(reader["loan_code"].ToString());
            }
            reader.Close();
            connection.Close();
            return loanParty;
        }
    }
}