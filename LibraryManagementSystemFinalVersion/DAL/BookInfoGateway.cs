using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class BookInfoGateway
    {
         string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
        public List<Press> GetAllPressListByDropDownList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_press";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Press> pressList = new List<Press>();
            while (reader.Read())
            {
                Press press = new Press();
                press.PressId = int.Parse(reader["id"].ToString());
                press.PressName = reader["press_name"].ToString();
                pressList.Add(press);
            }
            reader.Close();
            connection.Close();
            return pressList;
        }

        public List<Binder> GetAllBinderByDropDownList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_binder";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Binder> binderList = new List<Binder>();
            while (reader.Read())
            {
                Binder binder = new Binder();
                binder.BinderId = int.Parse(reader["id"].ToString());
                binder.BinderName = reader["binder_name"].ToString();
                binderList.Add(binder);
            }
            reader.Close();
            connection.Close();
            return binderList;
        }

        public int Insert(BookInfo bookInfo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_book_info VALUES('" + bookInfo.BookCode + "','" + bookInfo.BookName + "','" +
                           bookInfo.BookSize + "','" + bookInfo.BookForma + "','" + bookInfo.BookInar + "','" +
                           bookInfo.PressName + "','" + bookInfo.BinderName + "','"+bookInfo.MainBookCode+"','" + bookInfo.BookRate + "','" +
                           bookInfo.BookReturnRate + "','" + bookInfo.BookCommission + "','" +
                           bookInfo.BookOpeningBalance + "','" + bookInfo.BookStatus + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public BookInfo GetNextBookCode()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_book_info ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BookInfo bookInfo = new BookInfo();
            while (reader.Read())
            {
                bookInfo.BookInfoId = int.Parse(reader["id"].ToString());
                bookInfo.BookCode = reader["book_code"].ToString();
            }
            reader.Close();
            connection.Close();
            return bookInfo;
        }

        public List<BookInfo> GetAllBookInfo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_book_info";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<BookInfo> bookInfoList = new List<BookInfo>();
            while (reader.Read())
            {
                BookInfo bookInfo = new BookInfo();
                GetDataFromDatabase(bookInfo, reader);
                bookInfoList.Add(bookInfo);
            }
            reader.Close();
            connection.Close();
            return bookInfoList;
        }

        private static void GetDataFromDatabase(BookInfo bookInfo, SqlDataReader reader)
        {
            bookInfo.BookInfoId = int.Parse(reader["id"].ToString());
            bookInfo.BookCode = reader["book_code"].ToString();
            bookInfo.BookName = reader["book_name"].ToString();
            bookInfo.BookSize = reader["book_size"].ToString();
            bookInfo.BookForma = Convert.ToDouble(reader["book_forma"].ToString());
            bookInfo.BookInar = Convert.ToDouble(reader["book_inar"].ToString());
            bookInfo.PressName = reader["press_id"].ToString();
            bookInfo.BinderName = reader["binder_id"].ToString();
            bookInfo.MainBookCode = reader["main_book_id"].ToString();
            bookInfo.BookRate = Convert.ToDouble(reader["book_rate"].ToString());
            bookInfo.BookReturnRate = Convert.ToDouble(reader["book_return_rate"].ToString());
            bookInfo.BookCommission = Convert.ToDouble(reader["book_commission"].ToString());
            bookInfo.BookOpeningBalance = Convert.ToDouble(reader["book_opening_balance"].ToString());
            bookInfo.BookStatus = reader["book_status"].ToString();
        }

        public BookInfo GetBooks(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_book_info ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BookInfo bookInfo = new BookInfo();
            while (reader.Read())
            {
                GetDataFromDatabase(bookInfo, reader);
            }
            reader.Close();
            connection.Close();
            return bookInfo;
        }

        public BookInfo GetSearchInfo(string book)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_book_info WHERE book_code='" + book + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            BookInfo bookInfo = new BookInfo();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GetDataFromDatabase(bookInfo, reader);
                
            }
            reader.Close();
            connection.Close();
            return bookInfo;
        }

        public List<MainBook> GetAllMainBookByDropDownList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_main_book";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<MainBook> mainBookList = new List<MainBook>();
            while (reader.Read())
            {
                MainBook mainBook = new MainBook();
                mainBook.MainBookId = int.Parse(reader["id"].ToString());
                mainBook.MainBookCode = reader["main_book_code"].ToString();
                mainBookList.Add(mainBook);
            }
            reader.Close();
            connection.Close();
            return mainBookList;
        }
    }
}