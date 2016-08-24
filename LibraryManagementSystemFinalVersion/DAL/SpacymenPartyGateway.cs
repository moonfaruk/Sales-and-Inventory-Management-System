using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class SpacymenPartyGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;

        public List<District> GetAllDistrictByDropDownList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_district";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<District> districtList = new List<District>();
            while (reader.Read())
            {
                District district = new District();
                district.DistrictId = int.Parse(reader["id"].ToString());
                district.DistrictName = reader["district_name"].ToString();
                districtList.Add(district);
            }
            reader.Close();
            connection.Close();
            return districtList;
        }

        //public Party GetSpacymenParty(int i)
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    string query = "SELECT * FROM tbl_party WHERE id=" + i;
        //    SqlCommand command = new SqlCommand(query, connection);
        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();
        //    Party p = new Party();
        //    while (reader.Read())
        //    {
        //        p.PartyId = int.Parse(reader["id"].ToString());
        //        p.PartyCode =  reader["party_code"].ToString();
        //        p.PartyName =  reader["party_name"].ToString();
        //        p.PartyAddress = reader["party_address"].ToString();
                
        //    }
        //    reader.Close();
        //    connection.Close();
        //    return p;
        //}

        public int Insert(SpacymenParty spacymenParty)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_spacymenParty VALUES('" + spacymenParty.DistrictName + "','" +
                           spacymenParty.SpacymenPartyCode + "','" + spacymenParty.SpacymenPartyName + "','" +
                           spacymenParty.SpacymenPartyAddress + "','" + spacymenParty.SchoolName + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public SpacymenParty GetNextCode()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_spacymenParty ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            SpacymenParty sp = new SpacymenParty();
            while (reader.Read())
            {
                sp.SpacymenPartyId = int.Parse(reader["id"].ToString());
                sp.SpacymenPartyCode = reader["spacymenParty_code"].ToString();
            }
            reader.Close();
            connection.Close();
            return sp;
        }

        public List<SpacymenParty> GetAllSpacymenPartyList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_spacymenParty";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<SpacymenParty> spacymenPartyList = new List<SpacymenParty>();
            while (reader.Read())
            {
                SpacymenParty spacymenParty = new SpacymenParty();
                GetAllDataFromDatabase(spacymenParty, reader);
                spacymenPartyList.Add(spacymenParty);
            }
            reader.Close();
            connection.Close();
            return spacymenPartyList;
        }

        private static void GetAllDataFromDatabase(SpacymenParty spacymenParty, SqlDataReader reader)
        {
            spacymenParty.SpacymenPartyId = int.Parse(reader["id"].ToString());
            spacymenParty.DistrictName = reader["district_id"].ToString();
            spacymenParty.SpacymenPartyCode = reader["spacymenParty_code"].ToString();
            spacymenParty.SpacymenPartyName = reader["spacymenParty_name"].ToString();
            spacymenParty.SpacymenPartyAddress = reader["spacymenParty_address"].ToString();
            spacymenParty.SchoolName = reader["school_name"].ToString();
        }

        public SpacymenParty GetAllSpacymenParties(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_spacymenParty ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command =new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            SpacymenParty spacymenParty = new SpacymenParty();
            while (reader.Read())
            {
                GetAllDataFromDatabase(spacymenParty, reader);
            }
            reader.Close();
            connection.Close();
            return spacymenParty;
        }
    }
}