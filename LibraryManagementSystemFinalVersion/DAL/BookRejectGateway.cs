using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls.WebParts;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class BookRejectGateway
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

        public BookReject GetNextRejectNo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_bookReject ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BookReject bookReject = new BookReject();
            while (reader.Read())
            {
                bookReject.BookRejectId = int.Parse(reader["id"].ToString());
                bookReject.RejectNo = reader["reject_no"].ToString();
            }
            reader.Close();
            connection.Close();
            return bookReject;
        }

        public BookInfo GetRejectBook(int i)
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

        public List<BookReject> GetAllBookRejectList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bookReject";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<BookReject> bookRejectList = new List<BookReject>();
            while (reader.Read())
            {
                BookReject bookReject = new BookReject();
                GetValueFromDatabase(bookReject, reader);

                bookRejectList.Add(bookReject);
            }
            reader.Close();
            connection.Close();
            return bookRejectList;
        }

        private void GetValueFromDatabase(BookReject bookReject, SqlDataReader reader)
        {
            bookReject.BookRejectId = int.Parse(reader["id"].ToString());
            bookReject.Date = reader["date"].ToString();
            bookReject.DistrictName = reader["district_id"].ToString();
            bookReject.PartyName = reader["party_id"].ToString();
            bookReject.RejectNo = reader["reject_no"].ToString();
            bookReject.Year = reader["year"].ToString();
            bookReject.GroupName = reader["group_id"].ToString();
            bookReject.BookId = int.Parse(reader["book_id"].ToString());
            BookInfo bookInfo = GetRejectBook(bookReject.BookId);
            bookReject.BookRate = bookInfo.BookRate;
            bookReject.Commission = bookInfo.BookCommission;
            bookReject.Quantity = Convert.ToDouble(reader["quantity"].ToString());
            bookReject.RejectRate = Convert.ToDouble(reader["reject_rate"].ToString());
            bookReject.Total = Convert.ToDouble(reader["total"].ToString());
        }

        public BookReject GetBookReject(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bookReject ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BookReject bookReject = new BookReject();
            while (reader.Read())
            {
                GetValueFromDatabase(bookReject, reader);
            }
            reader.Close();
            connection.Close();
            return bookReject;
        }

        public BookReject GetSearchInfo(string s)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bookReject WHERE reject_no='" + s + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            BookReject bookReject = new BookReject();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GetValueFromDatabase(bookReject, reader);
            }
            reader.Close();
            connection.Close();
            return bookReject;
        }

        public int Insert(BookReject bookReject)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_bookReject VALUES('" + bookReject.Date + "','" + bookReject.DistrictId +
                           "','" + bookReject.PartyId + "','" + bookReject.RejectNo + "','" + bookReject.Year + "','" +
                           bookReject.GroupId + "','" + bookReject.BookId + "','" + bookReject.Quantity + "','" +
                           bookReject.RejectRate + "','"+bookReject.Total+"')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}