using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class PaperGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
        public int Insert(Paper paper)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_paper VALUES('" + paper.PaperCode + "','" + paper.PaperName + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public Paper GetNextPaperCode()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_paper ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Paper paper = new Paper();
            while (reader.Read())
            {
                paper.PaperId = int.Parse(reader["id"].ToString());
                paper.PaperCode = reader["paper_code"].ToString();
            }
            reader.Close();
            connection.Close();
            return paper;
        }
    }
}