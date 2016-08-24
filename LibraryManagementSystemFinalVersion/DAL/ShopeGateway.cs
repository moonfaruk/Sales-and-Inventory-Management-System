using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class ShopeGateway
    {
         string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
        public int Insert(Shope shope)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_shope VALUES('" + shope.ShopeCode + "','" + shope.ShopeName + "','" +
                           shope.ShopePhone + "','" + shope.ShopeAddress + "','" + shope.MonthlyRent + "','" +
                           shope.OpeningBalance + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<Shope> GetAllShopeInfo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_shope";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Shope> shopeList = new List<Shope>();
            int serialNo = 1;
            while (reader.Read())
            {
                Shope shope = new Shope();
                shope.SerialNo = serialNo++;
                shope.ShopeId = int.Parse(reader["id"].ToString());
                shope.ShopeCode = reader["shope_code"].ToString();
                shope.ShopeName = reader["shope_name"].ToString();
                shope.ShopePhone = reader["shope_phone"].ToString();
                shope.ShopeAddress = reader["shope_address"].ToString();
                shope.MonthlyRent = Convert.ToDouble(reader["shope_monthly_rent"].ToString());
                shope.OpeningBalance = Convert.ToDouble(reader["shope_opening_balance"].ToString());
                shopeList.Add(shope);
            }
            reader.Close();
            connection.Close();
            return shopeList;
        }

        public Shope GetNextShopeCode()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_shope ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Shope shope = new Shope();
            while (reader.Read())
            {
                shope.ShopeId = int.Parse(reader["id"].ToString());
                shope.ShopeCode = reader["shope_code"].ToString();
            }
            reader.Close();
            connection.Close();
            return shope;
        }

        public Shope GetShopeById(int shId)
        {
           SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_shope WHERE id=" + shId;
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Shope shope = new Shope();
            while (reader.Read())
            {
                shope.ShopeId = int.Parse(reader["id"].ToString());
                shope.ShopeCode = reader["shope_code"].ToString();
                shope.ShopeName = reader["shope_name"].ToString();
                shope.ShopePhone = reader["shope_phone"].ToString();
                shope.ShopeAddress = reader["shope_address"].ToString();
                shope.MonthlyRent = Convert.ToDouble(reader["shope_monthly_rent"].ToString());
                shope.OpeningBalance = Convert.ToDouble(reader["shope_opening_balance"].ToString());
                break;
            }
            reader.Close();
            connection.Close();
            return shope;
        }

        public bool UpdateShope(Shope shope)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE tbl_shope SET shope_code='" + shope.ShopeCode + "',shope_name='" + shope.ShopeName +
                           "',shope_phone='" + shope.ShopePhone + "',shope_address='" + shope.ShopeAddress +
                           "',shope_monthly_rent='" + shope.MonthlyRent + "',shope_opening_balance='" +
                           shope.OpeningBalance + "' WHERE id=" + shope.ShopeId;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;


        }

        public bool DeleteShop(int shId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "DELETE FROM tbl_shope WHERE id=" + shId;
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