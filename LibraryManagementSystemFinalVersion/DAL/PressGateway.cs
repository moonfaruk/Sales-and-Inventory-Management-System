using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class PressGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;

        public int Insert(Press press)
        {
           SqlConnection connection = new SqlConnection(connectionString);
            string quary = "INSERT INTO tbl_press VALUES('" + press.PressCode + "','" + press.PressName + "','" +
                           press.PressAddress + "','" + press.PressOpeningBalance + "')";
            SqlCommand command = new SqlCommand(quary,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public Press GetNextPressCode()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_press ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Press press = new Press();
            while (reader.Read())
            {
                press.PressId = int.Parse(reader["id"].ToString());
                press.PressCode = reader["press_code"].ToString();
            }
            reader.Close();
            connection.Close();
            return press;
        }
    }
}