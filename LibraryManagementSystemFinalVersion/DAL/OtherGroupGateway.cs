using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class OtherGroupGateway
    {
         string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
        public int Insert(OthersGroup othersGroup)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_other_group VALUES('" + othersGroup.OtherGroupCode + "','" + othersGroup.OtherGroupName +
                           "','" + othersGroup.OtherGroupRemarks + "','" + othersGroup.GroupName + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public OthersGroup GetNextCode()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_other_group ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            OthersGroup othersGroup = new OthersGroup();
            while (reader.Read())
            {
                othersGroup.OthersGroupId = int.Parse(reader["id"].ToString());
                othersGroup.OtherGroupCode = reader["other_group_code"].ToString();
            }
            reader.Close();
            connection.Close();
            return othersGroup;
        }

        public List<OthersGroup> GetAllOthersGroup()
        {
           SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_other_group";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<OthersGroup> otherGroupList = new List<OthersGroup>();
            while (reader.Read())
            {
                OthersGroup othersGroup = new OthersGroup();
                GetDataFromDatabase(othersGroup, reader);
                otherGroupList.Add(othersGroup);
            }
            reader.Close();
            connection.Close();
            return otherGroupList;
        }

        private static void GetDataFromDatabase(OthersGroup othersGroup, SqlDataReader reader)
        {
            othersGroup.OthersGroupId = int.Parse(reader["id"].ToString());
            othersGroup.OtherGroupCode = reader["other_group_code"].ToString();
            othersGroup.OtherGroupName = reader["other_group_name"].ToString();
            othersGroup.OtherGroupRemarks = reader["other_group_remarks"].ToString();
            othersGroup.GroupName = reader["group_id"].ToString();
        }

        public List<Group> GetAllGroupByDropDownList()
        {
           SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_group";
            SqlCommand command = new SqlCommand(query,connection);
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

        public OthersGroup GetLastGroup()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_other_group ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            OthersGroup othersGroup = new OthersGroup();
            while (reader.Read())
            {
                GetDataFromDatabase(othersGroup, reader);

            }
            reader.Close();
            connection.Close();
            return othersGroup;
        }

        public OthersGroup GetSearchInfo(string oGroup)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_other_group WHERE other_group_code='" + oGroup + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            OthersGroup othersGroup = new OthersGroup();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GetDataFromDatabase(othersGroup, reader);
            }
            reader.Close();
            connection.Close();
            return othersGroup;
        }
    }
}