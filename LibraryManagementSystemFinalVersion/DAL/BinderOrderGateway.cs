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
    public class BinderOrderGateway
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
                group.GroupCode = reader["group_code"].ToString();
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
                bookInfo.BookCode = reader["book_code"].ToString();
                bookInfoList.Add(bookInfo);
            }
            reader.Close();
            connection.Close();
            return bookInfoList;
        }

        public List<Press> GetAllPressInfoByDropDownList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_press";
            SqlCommand command = new SqlCommand(query, connection);
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

        public BinderOrder GetNextOrderNo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_binderOrder ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BinderOrder binderOrder = new BinderOrder();
            while (reader.Read())
            {
                binderOrder.BinderOrderId = int.Parse(reader["id"].ToString());
                binderOrder.OrderNo = reader["order_no"].ToString();
            }
            reader.Close();
            connection.Close();
            return binderOrder;
        }

        public int Insert(BinderOrder binderOrder)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_binderOrder VALUES('" + binderOrder.Date + "','" + binderOrder.Year + "','"+binderOrder.OrderNo+"','" +
                           binderOrder.BinderId + "','" + binderOrder.GroupId + "','" + binderOrder.BookId + "','" +
                           binderOrder.Quantity + "','" + binderOrder.FormaQuantity + "','" + binderOrder.PressId +
                           "','" + binderOrder.Forma + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<BinderOrder> GetAllBinderOrder()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_binderOrder";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<BinderOrder> binderOrderList = new List<BinderOrder>();
            while (reader.Read())
            {
                BinderOrder binderOrder = new BinderOrder();
                GetValueFromDatabase(binderOrder, reader);
                binderOrderList.Add(binderOrder);
            }
            reader.Close();
            connection.Close();
            return binderOrderList;
        }

        private static void GetValueFromDatabase(BinderOrder binderOrder, SqlDataReader reader)
        {
            binderOrder.BinderOrderId = int.Parse(reader["id"].ToString());
            binderOrder.Date = reader["date"].ToString();
            binderOrder.Year = reader["year"].ToString();
            binderOrder.OrderNo = reader["order_no"].ToString();
            binderOrder.BinderName = reader["binder_id"].ToString();
            binderOrder.GroupCode = reader["group_id"].ToString();
            binderOrder.BookCode = reader["book_id"].ToString();
            binderOrder.Quantity = Convert.ToDouble(reader["quantity"].ToString());
            binderOrder.FormaQuantity = Convert.ToDouble(reader["forma_quantity"].ToString());
            binderOrder.PressName = reader["press_id"].ToString();
            binderOrder.Forma = Convert.ToDouble(reader["forma"].ToString());
        }

        public BinderOrder GetBinderOrder(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_binderOrder ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            BinderOrder binderOrder = new BinderOrder();
            while (reader.Read())
            {
                GetValueFromDatabase(binderOrder, reader);
            }
            reader.Close();
            connection.Close();
            return binderOrder;
        }

        public DataTable GetBinderOrderReportData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_BinderOrderView";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            connection.Close();
            return dt;
        }
    }
}