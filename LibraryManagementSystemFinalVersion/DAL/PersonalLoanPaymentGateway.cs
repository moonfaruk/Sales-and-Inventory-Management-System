using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class PersonalLoanPaymentGateway
    {
         string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
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
                party.PartyName = reader["party_name"].ToString();
                partyList.Add(party);
            }
            reader.Close();
            connection.Close();
            return partyList;
            
        }

        public int Insert(PersonalLoanPayment personalLoanPayment)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_personalLoanPayment VALUES('" + personalLoanPayment.LoanDate + "','" +
                           personalLoanPayment.LoanType + "','" + personalLoanPayment.PartyId + "','" +
                           personalLoanPayment.Amount + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<PersonalLoanPayment> GetAllPersonalLoanList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_personalLoanPayment";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<PersonalLoanPayment> personalLoanPaymentList = new List<PersonalLoanPayment>();
            while (reader.Read())
            {
                PersonalLoanPayment personalLoanPayment = new PersonalLoanPayment();
                GetValueFromDatabase(personalLoanPayment, reader);
                personalLoanPaymentList.Add(personalLoanPayment);
            }
            reader.Close();
            connection.Close();
            return personalLoanPaymentList;
        }

        private static void GetValueFromDatabase(PersonalLoanPayment personalLoanPayment, SqlDataReader reader)
        {
            personalLoanPayment.PersonalLoanPaymentId = int.Parse(reader["id"].ToString());
            personalLoanPayment.LoanDate = reader["date"].ToString();
            personalLoanPayment.LoanType = reader["loan_type"].ToString();
            personalLoanPayment.PartyName = reader["party_id"].ToString();
            personalLoanPayment.Amount = Convert.ToDouble(reader["amount"].ToString());
        }

        public PersonalLoanPayment GetLoanParties(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_personalLoanPayment ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            PersonalLoanPayment personalLoanPayment = new PersonalLoanPayment();
            while (reader.Read())
            {
                GetValueFromDatabase(personalLoanPayment, reader);
            }
            reader.Close();
            connection.Close();
            return personalLoanPayment;
        }
    }
}