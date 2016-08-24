using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class WritterGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
        public int Insert(Writter writter)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_writter VALUES('" + writter.WritterCode + "','" + writter.WritterName +
                           "','" + writter.WritterAddress + "','" + writter.WritterPhone + "','" +
                           writter.WritterOpeningBalance + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public Writter GetNextCode()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_writter ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Writter writter = new Writter();
            while (reader.Read())
            {
                writter.WritterId = int.Parse(reader["id"].ToString());
                writter.WritterCode = reader["writter_code"].ToString();
            }
            reader.Close();
            connection.Close();
            return writter;
        }

        public List<Writter> GetAllWritter()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_writter";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Writter> writterList = new List<Writter>();
            while (reader.Read())
            {
                Writter writter = new Writter();
                GetDataFromDatabase(writter, reader);
                writterList.Add(writter);
            }
            reader.Close();
            connection.Close();
            return writterList;
        }

        private static void GetDataFromDatabase(Writter writter, SqlDataReader reader)
        {
            writter.WritterId = int.Parse(reader["id"].ToString());
            writter.WritterCode = reader["writter_code"].ToString();
            writter.WritterName = reader["writter_name"].ToString();
            writter.WritterAddress = reader["writter_address"].ToString();
            writter.WritterPhone = reader["writter_phone"].ToString();
            writter.WritterOpeningBalance = Convert.ToDouble(reader["writter_opening_balance"].ToString());
        }

        public Writter GetWritter(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_writter ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Writter writter = new Writter();
            while (reader.Read())
            {
                GetDataFromDatabase(writter, reader);
            }
            reader.Close();
            connection.Close();
            return writter;
        }

        public Writter GetSearchInfo(string s)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_writter WHERE writter_code='" + s + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            Writter writter = new Writter();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GetDataFromDatabase(writter, reader);
            }
            reader.Close();
            connection.Close();
            return writter;
        }
    }
}