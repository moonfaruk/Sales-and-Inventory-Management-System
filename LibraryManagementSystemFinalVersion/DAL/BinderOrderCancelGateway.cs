using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;
using Microsoft.Win32;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class BinderOrderCancelGateway
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

        public BinderOrderCancel GetNextOrderNo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_binderOrderCancel ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BinderOrderCancel binderOrderCancel = new BinderOrderCancel();
            while (reader.Read())
            {
                binderOrderCancel.BinderOrderCancelId = int.Parse(reader["id"].ToString());
                binderOrderCancel.OrderNo = reader["order_no"].ToString();
            }
            reader.Close();
            connection.Close();
            return binderOrderCancel;
        }

        public int Insert(BinderOrderCancel binderOrderCancel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_binderOrderCancel VALUES('" + binderOrderCancel.Date + "','" +
                           binderOrderCancel.Year + "','" + binderOrderCancel.BinderId + "','" +
                           binderOrderCancel.OrderNo + "','" + binderOrderCancel.GroupId + "','" +
                           binderOrderCancel.BookId + "','" + binderOrderCancel.Quantity + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<BinderOrderCancel> GetAllBinderOrderCancel()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_binderOrderCancel";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<BinderOrderCancel> binderOrderCancelList = new List<BinderOrderCancel>();
            while (reader.Read())
            {
                BinderOrderCancel binderOrderCancel = new BinderOrderCancel();
                GetValueFromDatabase(binderOrderCancel, reader);
                binderOrderCancelList.Add(binderOrderCancel);
            }
            reader.Close();
            connection.Close();
            return binderOrderCancelList;
        }

        private static void GetValueFromDatabase(BinderOrderCancel binderOrderCancel, SqlDataReader reader)
        {
            binderOrderCancel.BinderOrderCancelId = int.Parse(reader["id"].ToString());
            binderOrderCancel.Date = reader["date"].ToString();
            binderOrderCancel.Year = reader["year"].ToString();
            binderOrderCancel.BinderName = reader["binder_id"].ToString();
            binderOrderCancel.OrderNo = reader["order_no"].ToString();
            binderOrderCancel.GroupName = reader["group_id"].ToString();
            binderOrderCancel.BookName = reader["book_id"].ToString();
            binderOrderCancel.Quantity = Convert.ToDouble(reader["quantity"].ToString());
        }

        public BinderOrderCancel GetBinderOrderCancel(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_binderOrderCancel ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BinderOrderCancel binderOrderCancel = new BinderOrderCancel();
            while (reader.Read())
            {
                GetValueFromDatabase(binderOrderCancel, reader);
            }
            reader.Close();
            connection.Close();
            return binderOrderCancel;
        }
    }
}