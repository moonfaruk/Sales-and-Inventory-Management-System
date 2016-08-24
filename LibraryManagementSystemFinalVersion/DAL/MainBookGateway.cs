using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class MainBookGateway
    {
         string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
        public int Insert(MainBook mainBook)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_main_book VALUES('" + mainBook.MainBookCode + "','" + mainBook.MainBookName +
                           "','" + mainBook.MainBookClass + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }

        public MainBook GetNextCode()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_main_book ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            MainBook mainBook = new MainBook();
            while (reader.Read())
            {
                mainBook.MainBookId = int.Parse(reader["id"].ToString());
                mainBook.MainBookCode = reader["main_book_code"].ToString();
            }
            reader.Close();
            connection.Close();
            return mainBook;
        }

        public List<MainBook> GetAllMainBook()
        {
           SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_main_book";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<MainBook> mainBookList = new List<MainBook>();
            while (reader.Read())
            {
                MainBook mainBook = new MainBook();
                GetDataFromDatabase(mainBook, reader);
                mainBookList.Add(mainBook);
            }
            reader.Close();
            connection.Close();
            return mainBookList;
        }

        private static void GetDataFromDatabase(MainBook mainBook, SqlDataReader reader)
        {
            mainBook.MainBookId = int.Parse(reader["id"].ToString());
            mainBook.MainBookCode = reader["main_book_code"].ToString();
            mainBook.MainBookName = reader["main_book_name"].ToString();
            mainBook.MainBookClass = reader["main_book_class"].ToString();
        }

        public MainBook GetMainBooks(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_main_book ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            MainBook mainBook = new MainBook();
            while (reader.Read())
            {
                GetDataFromDatabase(mainBook, reader);
            }
            reader.Close();
            connection.Close();
            return mainBook;
        }
    }
}