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
    public class BookSalesGateway
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

        public BookSales GetNextMemoNo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_bookSales ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BookSales bookSales = new BookSales();
            while (reader.Read())
            {
                bookSales.BookSalesId = int.Parse(reader["id"].ToString());
                bookSales.MemoNo = reader["memo_no"].ToString();
            }
            reader.Close();
            connection.Close();
            return bookSales;
        }

        public int Insert(BookSales bookSales)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_bookSales VALUES('" + bookSales.Date + "','" + bookSales.DistrictId + "','" +
                           bookSales.PartyId + "','" + bookSales.MemoNo + "','" + bookSales.SalesType + "','" +
                           bookSales.Year + "','" + bookSales.GroupId + "','" + bookSales.BookId + "','" +
                           bookSales.Quantity + "','" + bookSales.SalesRate + "','"+bookSales.Total+"','" + bookSales.Packing + "','" +
                           bookSales.Bonus + "','"+bookSales.TotalPrice+"','" + bookSales.PaymentAmount + "','"+bookSales.Dues+"')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<BookSales> GetAllBookSalesList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bookSales";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<BookSales> bookSalesList = new List<BookSales>();
            while (reader.Read())
            {
                BookSales bookSales = new BookSales();
                GetValueFromDatabase(bookSales, reader);
                bookSalesList.Add(bookSales);
            }
            reader.Close();
            connection.Close();
            return bookSalesList;
        }

        private  void GetValueFromDatabase(BookSales bookSales, SqlDataReader reader)
        {
            bookSales.Date = reader["date"].ToString();
            bookSales.DistrictName = reader["district_id"].ToString();
            bookSales.PartyCode = reader["party_id"].ToString();
            bookSales.MemoNo = reader["memo_no"].ToString();
            bookSales.SalesType = reader["sales_type"].ToString();
            bookSales.Year = reader["year"].ToString();
            bookSales.GroupName = reader["group_id"].ToString();
            bookSales.BookId = int.Parse(reader["book_id"].ToString());
            BookInfo bookInfo = GetBookInfo(bookSales.BookId);
            bookSales.BookRate = bookInfo.BookRate;
            bookSales.Commisssion = bookInfo.BookCommission;
            bookSales.Quantity = Convert.ToDouble(reader["quantity"].ToString());
            bookSales.SalesRate = Convert.ToDouble(reader["sales_rate"].ToString());
            bookSales.Total = Convert.ToDouble(reader["total"].ToString());
            bookSales.Packing = Convert.ToDouble(reader["packing"].ToString());
            bookSales.Bonus = Convert.ToDouble(reader["bonus"].ToString());
            bookSales.TotalPrice = Convert.ToDouble(reader["total_price"].ToString());
            bookSales.PaymentAmount = Convert.ToDouble(reader["payment_amount"].ToString());
            bookSales.Dues = Convert.ToDouble(reader["dues"].ToString());
        }

        public BookSales GetBookSales(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bookSales ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BookSales bookSales = new BookSales();
            while (reader.Read())
            {
                GetValueFromDatabase(bookSales, reader);
            }
            reader.Close();
            connection.Close();
            return bookSales;
        }

        public BookSales GetSearchInfo(string s)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bookSales WHERE memo_no='" + s + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            BookSales bookSales = new BookSales();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GetValueFromDatabase(bookSales, reader);
            }
            reader.Close();
            connection.Close();
            return bookSales;
        }

        public DataTable GetBookSalesReportData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_bookSalesView";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            connection.Close();
            return dt;
        }
    }
}