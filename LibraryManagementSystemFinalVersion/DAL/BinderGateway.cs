using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class BinderGateway
    {
         string connectionString =
            WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
        public int Insert(Binder binder)
        {
           SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_binder VALUES('" + binder.BinderCode + "','" + binder.BinderName + "','" +
                           binder.BinderAddress + "','" + binder.BinderOpeningBalance + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<Binder> GetAllBinderList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_binder";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Binder> binderList = new List<Binder>();
            while (reader.Read())
            {
                Binder binder = new Binder();
                GetDataFromDatabase(binder, reader);
                binderList.Add(binder);
            }
            reader.Close();
            connection.Close();
            return binderList;
        }

        private static void GetDataFromDatabase(Binder binder, SqlDataReader reader)
        {
            binder.BinderId = int.Parse(reader["id"].ToString());
            binder.BinderCode = reader["binder_code"].ToString();
            binder.BinderName = reader["binder_name"].ToString();
            binder.BinderAddress = reader["binder_address"].ToString();
            binder.BinderOpeningBalance = Convert.ToDouble(reader["binder_opening_balance"].ToString());
        }

        public Binder GetNextBinderCode()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_binder ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Binder binder = new Binder();
            while (reader.Read())
            {
                binder.BinderId = int.Parse(reader["id"].ToString());
                binder.BinderCode = reader["binder_code"].ToString();
            }
            reader.Close();
            connection.Close();
            return binder;
        }

        public Binder GetBinder(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_binder ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Binder binder = new Binder();
            while (reader.Read())
            {
                GetDataFromDatabase(binder, reader);
            }
            reader.Close();
            connection.Close();
            return binder;
        }

        public Binder GetSearchInfo(string s)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_binder WHERE binder_code='" + s + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            Binder binder = new Binder();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                ReadDataFromDatabase(binder, reader);
            }
            reader.Close();
            connection.Close();
            return binder;
        }

        private void ReadDataFromDatabase(Binder binder, SqlDataReader reader)
        {
            binder.BinderId = int.Parse(reader["id"].ToString());
            binder.BinderCode = reader["binder_code"].ToString();
            binder.BinderName = reader["binder_name"].ToString();
            binder.BinderAddress = reader["binder_address"].ToString();
            binder.BinderOpeningBalance = Convert.ToDouble(reader["binder_opening_balance"].ToString());
        }
    }
}