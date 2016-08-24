using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class PPLiminationGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;

        public int Insert(PPLimination ppLimination)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_ppLimination VALUES('" + ppLimination.PPLiminationCode + "','" + ppLimination.PPLiminationName + "','"+ppLimination.PPLiminationAddress+"','"+ppLimination.PPLiminationOpeningBalance+"')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public PPLimination GetNextPPLiminationCode()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_ppLimination ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            PPLimination ppLimination = new PPLimination();
            while (reader.Read())
            {
                ppLimination.PPLiminationId = int.Parse(reader["id"].ToString());
                ppLimination.PPLiminationCode = reader["pplimination_code"].ToString();
            }
            reader.Close();
            connection.Close();
            return ppLimination;
        }

        public PPLimination GetPpLiminations(int rowNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_ppLimination ORDER BY id ASC OFFSET " + rowNo + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            PPLimination ppLimination = new PPLimination();
            while (reader.Read())
            {
                GetAllInfoFromDatabase(ppLimination, reader);
            }
            reader.Close();
            connection.Close();
            return ppLimination;
        }

        private static void GetAllInfoFromDatabase(PPLimination ppLimination, SqlDataReader reader)
        {
            ppLimination.PPLiminationId = int.Parse(reader["id"].ToString());
            ppLimination.PPLiminationCode = reader["pplimination_code"].ToString();
            ppLimination.PPLiminationName = reader["pplimination_name"].ToString();
            ppLimination.PPLiminationAddress = reader["pplimination_address"].ToString();
            ppLimination.PPLiminationOpeningBalance = Convert.ToDouble(reader["pplimination_opening_balance"].ToString());
        }

        public List<PPLimination> GetAllPpLiminationInfo()
        {
           SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_ppLimination";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<PPLimination> ppLiminationList = new List<PPLimination>();
            while (reader.Read())
            {
                PPLimination ppLimination = new PPLimination();
                GetAllInfoFromDatabase(ppLimination, reader);
                ppLiminationList.Add(ppLimination);
            }
            reader.Close();
            connection.Close();
            return ppLiminationList;
        }
    }
}