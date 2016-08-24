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
    public class BookReturnGateway
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
                party.PartyName = reader["party_name"].ToString();
                partyList.Add(party);
            }
            reader.Close();
            connection.Close();
            return partyList;
        }

        public List<Group> GetAllGroupInfoByDropDownList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_group";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Group> groupList = new List<Group>();
            while (reader.Read())
            {
                Group group = new Group();
                group.GroupId = int.Parse(reader["id"].ToString());
                group.GroupName = reader["group_name"].ToString();
                groupList.Add(group);
            }
            reader.Close();
            connection.Close();
            return groupList;
        }

        public List<BookInfo> GetAllBookInfoByDropDownList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_book_info";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<BookInfo> bookInfoList = new List<BookInfo>();
            while (reader.Read())
            {
                BookInfo bookInfo = new BookInfo();
                bookInfo.BookInfoId = int.Parse(reader["id"].ToString());
                bookInfo.BookName = reader["book_name"].ToString();
                bookInfoList.Add(bookInfo);
            }
            reader.Close();
            connection.Close();
            return bookInfoList;
        }

        public BookReturn GetNextReturnNo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_bookReturn ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BookReturn bookReturn = new BookReturn();
            while (reader.Read())
            {
                bookReturn.BookReturnId = int.Parse(reader["id"].ToString());
                bookReturn.ReturnNo = reader["return_no"].ToString();
            }
            reader.Close();
            connection.Close();
            return bookReturn;
        }

        public BookInfo GetBookReturn(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_book_info WHERE id=" + i;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BookInfo bookInfo = new BookInfo();
            while (reader.Read())
            {
                bookInfo.BookInfoId = int.Parse(reader["id"].ToString());
                bookInfo.BookRate = Convert.ToDouble(reader["book_rate"].ToString());
                bookInfo.BookCommission = Convert.ToDouble(reader["book_commission"].ToString());
                bookInfo.BookName = reader["book_name"].ToString();

            }
            reader.Close();
            connection.Close();
            return bookInfo;
        }

        public int Insert(BookReturn bookReturn)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_bookReturn VALUES('" + bookReturn.Date + "','" + bookReturn.DistrictId +
                           "','" + bookReturn.PartyId + "','" + bookReturn.ReturnNo + "','" + bookReturn.ChallanReturn +
                           "','" + bookReturn.Year + "','" + bookReturn.GroupId + "','" + bookReturn.BookId + "','" +
                           bookReturn.Quantity + "','" + bookReturn.ReturnRate + "','"+bookReturn.Total+"','" + bookReturn.TransportBill +
                           "','" + bookReturn.Less + "','"+bookReturn.NetReturn+"')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<BookReturn> GetAllBookReturnList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bookReturn";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<BookReturn> bookReturnList= new List<BookReturn>();
            while (reader.Read())
            {
                BookReturn bookReturn = new BookReturn();
                GetValueFromDatabase(bookReturn, reader);

                bookReturnList.Add(bookReturn);
            }
            reader.Close();
            connection.Close();
            return bookReturnList;
        }

        private  void GetValueFromDatabase(BookReturn bookReturn, SqlDataReader reader)
        {
            bookReturn.BookReturnId = int.Parse(reader["id"].ToString());
            bookReturn.Date = reader["date"].ToString();
            bookReturn.DistrictName = reader["district_id"].ToString();
            bookReturn.PartyName = reader["party_id"].ToString();
            bookReturn.ReturnNo = reader["return_no"].ToString();
            bookReturn.ChallanReturn = reader["challan_return"].ToString();
            bookReturn.Year = reader["year"].ToString();
            bookReturn.GroupName = reader["group_id"].ToString();
            bookReturn.BookId = int.Parse(reader["book_id"].ToString());
            BookInfo bookInfo = GetBookReturn(bookReturn.BookId);
            bookReturn.BookRate = bookInfo.BookRate;
            bookReturn.Commission = bookInfo.BookCommission;
            bookReturn.Quantity = Convert.ToDouble(reader["quantity"].ToString());
            bookReturn.ReturnRate = Convert.ToDouble(reader["return_rate"].ToString());
            bookReturn.Total = Convert.ToDouble(reader["total"].ToString());
            bookReturn.TransportBill = Convert.ToDouble(reader["transport_bill"].ToString());
            bookReturn.Less = Convert.ToDouble(reader["less"].ToString());
            bookReturn.NetReturn = Convert.ToDouble(reader["net_return"].ToString());
        }

        public BookReturn GetReturns(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bookReturn ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BookReturn bookReturn = new BookReturn();
            while (reader.Read())
            {
                GetValueFromDatabase(bookReturn, reader);
            }
            reader.Close();
            connection.Close();
            return bookReturn;
        }

        public BookReturn GetSearchInfo(string s)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bookReturn WHERE return_no='" + s + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            BookReturn bookReturn = new BookReturn();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GetValueFromDatabase(bookReturn, reader);
            }
            reader.Close();
            connection.Close();
            return bookReturn;
        }

        public DataTable GetBookReturnReportData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_BookReturnView";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            connection.Close();
            return dt;
        }
    }
}