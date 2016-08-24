using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class GroupGateway
    {
         string connectionString =  WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
        public int Insert(Group group)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_group VALUES('" + group.GroupCode + "','" + group.GroupName + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public Group GetNextGroupCode()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_group ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Group group = new Group();
            while (reader.Read())
            {
                group.GroupId = int.Parse(reader["id"].ToString());
                group.GroupCode = reader["group_code"].ToString();
            }
            reader.Close();
            connection.Close();
            return group;
        }

        public Group GetLastGroup()
        {
           SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_group ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Group group = new Group();
            while (reader.Read())
            {
                group.GroupId = int.Parse(reader["id"].ToString());
                group.GroupCode = reader["group_code"].ToString();
                group.GroupName = reader["group_name"].ToString();
           
            }
            reader.Close();
            connection.Close();
            return group;
        }

        public Group GetSearchInfo(string s)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_group WHERE group_code='" + s + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            Group group = new Group();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                group.GroupId = int.Parse(reader["id"].ToString());
                group.GroupCode = reader["group_code"].ToString();
                group.GroupName = reader["group_name"].ToString();
            }
            reader.Close();
            connection.Close();
            return group;
        }
    }
}