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
    public class BookSpecimanGateway
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

        public BookSpeciman GetNextMemoNo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_bookSpeciman ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BookSpeciman bookSpeciman = new BookSpeciman();
            while (reader.Read())
            {
                bookSpeciman.BookSpecimanId = int.Parse(reader["id"].ToString());
                bookSpeciman.MemoNo = reader["memo_no"].ToString();
            }
            reader.Close();
            connection.Close();
            return bookSpeciman;
        }

        public BookInfo GetBookInfo(int i)
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

        public int Insert(BookSpeciman bookSpeciman)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_bookSpeciman VALUES('" + bookSpeciman.Date + "','" + bookSpeciman.DistrictId +
                           "','" + bookSpeciman.PartyId + "','" + bookSpeciman.MemoNo + "','" + bookSpeciman.Year +
                           "','" + bookSpeciman.GroupId + "','" + bookSpeciman.BookId + "','" + bookSpeciman.Quantity +
                           "','" + bookSpeciman.Rate + "','"+bookSpeciman.Total+"')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<BookSpeciman> GetAllBookSpecimanList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bookSpeciman";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<BookSpeciman> bookSpecimanList = new List<BookSpeciman>();
            while (reader.Read())
            {
                BookSpeciman bookSpeciman = new BookSpeciman();
                GetValueFromDatabase(bookSpeciman, reader);
                bookSpecimanList.Add(bookSpeciman);
            }
            reader.Close();
            connection.Close();
            return bookSpecimanList;
        }

        private  void GetValueFromDatabase(BookSpeciman bookSpeciman, SqlDataReader reader)
        {
            bookSpeciman.BookSpecimanId = int.Parse(reader["id"].ToString());
            bookSpeciman.Date = reader["date"].ToString();
            bookSpeciman.DistrictName = reader["district_id"].ToString();
            bookSpeciman.PartyCode = reader["party_id"].ToString();
            bookSpeciman.MemoNo = reader["memo_no"].ToString();
            bookSpeciman.Year = reader["year"].ToString();
            bookSpeciman.GroupName = reader["group_id"].ToString();
            bookSpeciman.BookId = int.Parse(reader["book_id"].ToString());
            BookInfo bookInfo = GetBookInfo(bookSpeciman.BookId);
            bookSpeciman.BookRate = bookInfo.BookRate;
            bookSpeciman.Commission = bookInfo.BookCommission;
            bookSpeciman.Quantity = Convert.ToDouble(reader["quantity"].ToString());
            bookSpeciman.Rate = Convert.ToDouble(reader["rate"].ToString());
            bookSpeciman.Total = Convert.ToDouble(reader["total"].ToString());
        }

        public BookSpeciman GetBookSpeciman(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bookSpeciman ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BookSpeciman bookSpeciman = new BookSpeciman();
            while (reader.Read())
            {
                GetValueFromDatabase(bookSpeciman, reader);
            }
            reader.Close();
            connection.Close();
            return bookSpeciman;
        }

        public BookSpeciman GetSearchInfo(string s)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bookSpeciman WHERE memo_no='" + s + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            BookSpeciman bookSpeciman = new BookSpeciman();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GetValueFromDatabase(bookSpeciman, reader);
            }
            reader.Close();
            connection.Close();
            return bookSpeciman;
        }

        public DataTable GetBookSpecimanReportData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_BookSpecimanView";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            connection.Close();
            return dt;
        }
    }
}