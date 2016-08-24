using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class BonusGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
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
                districtList.Add(district);
            }
            reader.Close();
            connection.Close();
            return districtList;
        }

        public List<Party> GetAllPartiesByIdDropDownList()
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
                party.PartyId = int.Parse(reader["id"].ToString());
                party.PartyCode = reader["party_code"].ToString();
                partyList.Add(party);
            }
            reader.Close();
            connection.Close();
            return partyList;
        }

        public Party GetPartyName(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_party WHERE id=" + i;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Party party = new Party();
            while (reader.Read())
            {
                party.PartyId = int.Parse(reader["id"].ToString());
                party.PartyName = reader["party_name"].ToString();
                party.PartyCode = reader["party_code"].ToString();
            }
            reader.Close();
            connection.Close();
            return party;
        }

        public int Insert(Bonus bonus)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_bonus VALUES('" + bonus.Date + "','" + bonus.DistrictId + "','" +
                           bonus.PartyId + "','" + bonus.Amount + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<Bonus> GetAllBonus()
        {
           SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bonus";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Bonus> bonusList = new List<Bonus>();
            while (reader.Read())
            {
                Bonus bonus = new Bonus();
                GetValueFromDatabase(bonus, reader);

                bonusList.Add(bonus);
            }
            reader.Close();
            connection.Close();
            return bonusList;
        }

        private  void GetValueFromDatabase(Bonus bonus, SqlDataReader reader)
        {
            bonus.BonusId = int.Parse(reader["id"].ToString());
            bonus.Date = reader["date"].ToString();
            bonus.DistrictName = reader["district_id"].ToString();
            bonus.PartyId = int.Parse(reader["party_id"].ToString());
            Party party = GetPartyName(bonus.PartyId);
            bonus.PartyCode = party.PartyCode;
            bonus.PartyName = party.PartyName;
            bonus.Amount = Convert.ToDouble(reader["amount"].ToString());
        }

        public Bonus GetBonus(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bonus ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Bonus bonus = new Bonus();
            while (reader.Read())
            {
                GetValueFromDatabase(bonus, reader);
            }
            reader.Close();
            connection.Close();
            return bonus;
        }

        public Bonus GetSearchInfo(string s)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bonus WHERE date='" + s + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            Bonus bonus = new Bonus();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GetValueFromDatabase(bonus, reader);
            }
            reader.Close();
            connection.Close();
            return bonus;
        }
    }
}