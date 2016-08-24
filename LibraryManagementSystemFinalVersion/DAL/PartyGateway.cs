using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls.WebParts;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class PartyGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
        public int Insert(Party party)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_party VALUES('" + party.DivisionName + "','" + party.DistrictName + "','" +
                           party.PartyCode + "','" + party.PartyName + "','" + party.PartyPropiter + "','" +
                           party.PartyAddress + "','" + party.PartyPhone + "','" + party.PartyEmail + "','" +
                           party.PartyWeb + "','" + party.PartyOpeningBalance + "','" + party.PartyDate + "')";
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

        public List<District> GetAllDistrictByDropDownList()
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
                district.DistrictName = reader["district_name"].ToString();
                district.DivisionId = int.Parse(reader["division_id"].ToString());
                districtList.Add(district);
            }
            reader.Close();
            connection.Close();
            return districtList;
        }

        public Party GetNextPartyCode()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_party ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Party party = new Party();
            while (reader.Read())
            {
                party.PartyId = int.Parse(reader["id"].ToString());
                party.PartyCode = reader["party_code"].ToString();

            }
            reader.Close();
            connection.Close();
            return party;
        }

        public List<Party> GetAllPartyInfo()
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
                ReadDataFromDatabase(party, reader);

                partyList.Add(party);
            }
            reader.Close();
            connection.Close();
            return partyList;
        }

        public Party GetParties(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_party ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Party party = new Party();
            while (reader.Read())
            {
                ReadDataFromDatabase(party, reader);
            }
            reader.Close();
            connection.Close();
            return party;

        }

        public Party GetSearchInfo(string code)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_party WHERE party_code='"+code+"'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            Party party = new Party();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                ReadDataFromDatabase(party, reader);
            }
            reader.Close();
            connection.Close();
            return party;

        }

        private static void ReadDataFromDatabase(Party party, SqlDataReader reader)
        {
            party.PartyId = int.Parse(reader["id"].ToString());
            party.DistrictId = int.Parse(reader["district_id"].ToString());
            party.DistrictName = reader["district_id"].ToString();
            party.PartyCode = reader["party_code"].ToString();
            party.PartyName = reader["party_name"].ToString();
            party.PartyPropiter = reader["party_propitor"].ToString();
            party.PartyAddress = reader["party_address"].ToString();
            party.PartyPhone = reader["party_phone"].ToString();
            party.PartyEmail = reader["party_email"].ToString();
            party.PartyWeb = reader["party_web"].ToString();
            party.PartyOpeningBalance = Convert.ToDouble(reader["party_opening_balance"].ToString());
            party.PartyDate = reader["party_date"].ToString();
         
        }

        public DataTable GetEmpPartyBankReportData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = " SELECT * FROM tbl_emp_party_bank";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            connection.Close();
            return dt;
        }

        public Division GetDivision(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_division WHERE id=" + i;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Division division = new Division();
            while (reader.Read())
            {
                division.DivisionId = int.Parse(reader["id"].ToString());
                division.DivisionName = reader["division_name"].ToString();
                

            }
            reader.Close();
            connection.Close();
            return division;
        }

        public District GetDistrict(int districtId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT div.division_name FROM tbl_district as dis INNER JOIN tbl_division as div ON dis.division_id = div.id WHERE  dis.id=" + districtId;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            District district = new District();
            if (reader.Read())
            {
               
                district.DivisionName = reader["division_name"].ToString();
            }
            reader.Close();
            connection.Close();
            return district;
        }
    }
}