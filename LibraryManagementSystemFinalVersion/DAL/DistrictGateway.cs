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
    public class DistrictGateway
    {
        string connectionString =
           WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
        public int Insert(District district)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_district VALUES('" + district.DistrictCode + "','" + district.DistrictName +
                           "','" + district.DivisionName + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<Division> GetAllDivisionByDropDownList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_division";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Division> divisionList = new List<Division>();
            while (reader.Read())
            {
                Division division = new Division();
                division.DivisionId = int.Parse(reader["id"].ToString());
                division.DivisionName = reader["division_name"].ToString();
                divisionList.Add(division);
            }
            reader.Close();
            connection.Close();
            return divisionList;
        }

        public List<District> GetAllDistrict()
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
                district.DistrictCode = reader["district_code"].ToString();
                district.DistrictName = reader["district_name"].ToString();
                district.DivisionName = reader["division_id"].ToString();
                districtList.Add(district);
            }
            reader.Close();
            connection.Close();
            return districtList;
        }

        public District GetDistrict(int rowNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_district ORDER BY id ASC OFFSET " + rowNo + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            District district = new District();
            while (reader.Read())
            {
                district.DistrictId = int.Parse(reader["id"].ToString());
                district.DistrictCode = reader["district_code"].ToString();
                district.DistrictName = reader["district_name"].ToString();
                district.DivisionName = reader["division_id"].ToString();
            }
            reader.Close();
            connection.Close();
            return district;
        }

        public District GetNextDistrictCode()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_district ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            District district = new District();
            while (reader.Read())
            {
                district.DistrictId = int.Parse(reader["id"].ToString());
                district.DistrictCode = reader["district_code"].ToString();
            }
            reader.Close();
            connection.Close();
            return district;
        }
    }
}
