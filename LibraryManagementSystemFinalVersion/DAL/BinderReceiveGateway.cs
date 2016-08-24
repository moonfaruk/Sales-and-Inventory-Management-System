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
    public class BinderReceiveGateway
    {
         string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;

        public List<Binder> GetAllBinderInfoByDropDownList()
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

        public BinderReceive GetNextReceiveNo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_binderReceive ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BinderReceive binderReceive = new BinderReceive();
            while (reader.Read())
            {
                binderReceive.BinderReceiveId = int.Parse(reader["id"].ToString());
                binderReceive.ReceiveNo = reader["receive_no"].ToString();
            }
            reader.Close();
            connection.Close();
            return binderReceive;
        }

        public int Insert(BinderReceive binderReceive)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_binderReceive VALUES('" + binderReceive.Date + "','" +
                           binderReceive.ReceiveNo + "','" + binderReceive.BinderId + "','" + binderReceive.OrderNo +
                           "','" + binderReceive.ChallanNo + "','" + binderReceive.Year + "','" + binderReceive.GroupId +
                           "','" + binderReceive.BookId + "','" + binderReceive.Quantity + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<BinderReceive> GetAllBinderReceive()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_binderReceive";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<BinderReceive> binderReceiveList = new List<BinderReceive>();
            while (reader.Read())
            {
                BinderReceive binderReceive = new BinderReceive();
                GetValueFromDatabase(binderReceive, reader);

                binderReceiveList.Add(binderReceive);
            }
            reader.Close();
            connection.Close();
            return binderReceiveList;
        }

        private static void GetValueFromDatabase(BinderReceive binderReceive, SqlDataReader reader)
        {
            binderReceive.BinderReceiveId = int.Parse(reader["id"].ToString());
            binderReceive.Date = reader["date"].ToString();
            binderReceive.ReceiveNo = reader["receive_no"].ToString();
            binderReceive.BinderName = reader["binder_id"].ToString();
            binderReceive.OrderNo = reader["order_no"].ToString();
            binderReceive.ChallanNo = reader["challan_no"].ToString();
            binderReceive.Year = reader["year"].ToString();
            binderReceive.GroupName = reader["group_id"].ToString();
            binderReceive.BookName = reader["book_id"].ToString();
            binderReceive.Quantity = Convert.ToDouble(reader["quantity"].ToString());
        }

        public BinderReceive GetBinderReceive(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_binderReceive ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BinderReceive binderReceive = new BinderReceive();
            while (reader.Read())
            {
                GetValueFromDatabase(binderReceive, reader);
            }
            reader.Close();
            connection.Close();
            return binderReceive;
        }

        public BinderReceive GetSearchInfo(string s)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_binderReceive WHERE receive_no='" + s + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            BinderReceive binderReceive = new BinderReceive();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GetValueFromDatabase(binderReceive, reader);
            }
            reader.Close();
            connection.Close();
            return binderReceive;
        }

        public DataTable GetBinderReceiveReportData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_binderReceiveView";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            connection.Close();
            return dt;
        }
    }
}