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
    public class CoverReceivedGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
        public List<Group> GetAllGroupInofByDropDownList()
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

        public CoverReceived GetNextReceiveNo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_coverReceived ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            CoverReceived coverReceived = new CoverReceived();
            while (reader.Read())
            {
                coverReceived.CouerReceivedId = int.Parse(reader["id"].ToString());
                coverReceived.RecNo = reader["receive_no"].ToString();
            }
            reader.Close();
            connection.Close();
            return coverReceived;
        }

        public int Insert(CoverReceived coverReceived)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_coverReceived VALUES('" + coverReceived.Date + "','" + coverReceived.RecNo +
                           "','" + coverReceived.Year + "','" + coverReceived.GroupId + "','" + coverReceived.BookId +
                           "','" + coverReceived.Quantity + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }

        public List<CoverReceived> GetAllCoverReceived()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_coverReceived";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<CoverReceived> coverReceivedList = new List<CoverReceived>();
            while (reader.Read())
            {
                CoverReceived coverReceived = new CoverReceived();
                GetValueFromDatabase(coverReceived, reader);
                coverReceivedList.Add(coverReceived);
            }
            reader.Close();
            connection.Close();
            return coverReceivedList;

        }

        private static void GetValueFromDatabase(CoverReceived coverReceived, SqlDataReader reader)
        {
            coverReceived.CouerReceivedId = int.Parse(reader["id"].ToString());
            coverReceived.Date = reader["date"].ToString();
            coverReceived.RecNo = reader["receive_no"].ToString();
            coverReceived.Year = reader["year"].ToString();
            coverReceived.GroupName = reader["group_id"].ToString();
            coverReceived.BookName = reader["book_id"].ToString();
            coverReceived.Quantity = Convert.ToDouble(reader["quantity"].ToString());
        }

        public CoverReceived GetCovers(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_coverReceived ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            CoverReceived coverReceived = new CoverReceived();
            while (reader.Read())
            {
                GetValueFromDatabase(coverReceived, reader);
            }
            reader.Close();
            connection.Close();
            return coverReceived;
        }

        public CoverReceived GetSearchInfo(string s)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_coverReceived WHERE receive_no='" + s + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            CoverReceived coverReceived = new CoverReceived();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GetValueFromDatabase(coverReceived, reader);
            }
            reader.Close();
            connection.Close();
            return coverReceived;
        }

        public DataTable GetCoverReceivedReportData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_coverReceivedView";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            connection.Close();
            return dt;
        }
    }
}