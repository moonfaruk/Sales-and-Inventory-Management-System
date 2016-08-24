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
    public class CoverSupplyGateway
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

        public CoverSupply GetNextSupplyNo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_coverSupply ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            CoverSupply coverSupply = new CoverSupply();
            while (reader.Read())
            {
                coverSupply.CoverSupplyId = int.Parse(reader["id"].ToString());
                coverSupply.SupplyNo = reader["supply_no"].ToString();
            }
            reader.Close();
            connection.Close();
            return coverSupply;
        }

        public int Insert(CoverSupply coverSupply)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_coverSupply VALUES('" + coverSupply.Date + "','" + coverSupply.SupplyNo +
                           "','" + coverSupply.BinderId + "','" + coverSupply.GroupId + "','" + coverSupply.BookId +
                           "','" + coverSupply.Quantity + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<CoverSupply> GetAllCoverSupply()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_coverSupply";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<CoverSupply> coverSupplyList = new List<CoverSupply>();
            while (reader.Read())
            {
                CoverSupply coverSupply = new CoverSupply();
                GetValueFromDatabase(coverSupply, reader);

                coverSupplyList.Add(coverSupply);
            }
            reader.Close();
            connection.Close();
            return coverSupplyList;
        }

        private static void GetValueFromDatabase(CoverSupply coverSupply, SqlDataReader reader)
        {
            coverSupply.CoverSupplyId = int.Parse(reader["id"].ToString());
            coverSupply.Date = reader["date"].ToString();
            coverSupply.SupplyNo = reader["supply_no"].ToString();
            coverSupply.BinderName = reader["binder_id"].ToString();
            coverSupply.GroupName = reader["group_id"].ToString();
            coverSupply.BookName = reader["book_id"].ToString();
            coverSupply.Quantity = Convert.ToDouble(reader["quantity"].ToString());
        }

        public CoverSupply GetSupplier(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_coverSupply ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            CoverSupply coverSupply = new CoverSupply();
            while (reader.Read())
            {
                GetValueFromDatabase(coverSupply, reader);
            }
            reader.Close();
            connection.Close();
            return coverSupply;
        }

        public CoverSupply GetSearchInfo(string s)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_coverSupply WHERE supply_no='" + s + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            CoverSupply coverSupply = new CoverSupply();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GetValueFromDatabase(coverSupply, reader);
            }
            reader.Close();
            connection.Close();
            return coverSupply;
        }

        public DataTable GetCoverSupplyReportData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_coverSupplyView";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            connection.Close();
            return dt;
        }
    }
}
