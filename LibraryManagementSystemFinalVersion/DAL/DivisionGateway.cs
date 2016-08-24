using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.BLL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class DivisionGateway
    {
         string connectionString =
            WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;

        public int Insert(Division division)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_division VALUES('" + division.DivisionCode + "','" + division.DivisionName +
                           "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        //public Division GetFirstDivision()
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    connection.Open();
        //    string query = "SELECT TOP 1 * FROM tbl_division ORDER BY id ASC";
        //    SqlCommand command = new SqlCommand(query, connection);
        //    SqlDataReader reader = command.ExecuteReader();
        //    Division divisionFirst = new Division();
        //    while (reader.Read())
        //    {
        //        divisionFirst.DivisionId = int.Parse(reader["id"].ToString());
        //        divisionFirst.DivisionCode = reader["division_code"].ToString();
        //        divisionFirst.DivisionName = reader["division_name"].ToString();

        //    }
        //    reader.Close();
        //    connection.Close();
        //    return divisionFirst;
        //}


        public List<Division> GetAllDivisions()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from tbl_division";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Division> divisionList = new List<Division>();
            while (reader.Read())
            {
                Division division = new Division();
                division.DivisionId = int.Parse(reader["id"].ToString());
                division.DivisionCode = reader["division_code"].ToString();
                division.DivisionName = reader["division_name"].ToString();
                divisionList.Add(division);
            }
            reader.Close();
            connection.Close();
            return divisionList;

        }

        public Division GetDivision(int row_no)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_division ORDER BY id ASC OFFSET " + row_no + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Division division = new Division();
            while (reader.Read())
            {
                division.DivisionId = int.Parse(reader["id"].ToString());
                division.DivisionCode = reader["division_code"].ToString();
                division.DivisionName = reader["division_name"].ToString();
            }
            reader.Close();
            connection.Close();
            return division;

        }

        public Division GetNextDivisionCode()
        {
           SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_division ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Division division = new Division();
            while (reader.Read())
            {
                division.DivisionId = int.Parse(reader["id"].ToString());
                division.DivisionCode = reader["division_code"].ToString();
            }
            reader.Close();
            connection.Close();
            return division;
        }
    }
}