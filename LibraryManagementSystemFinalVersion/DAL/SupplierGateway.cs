using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.WebSockets;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class SupplierGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
        public int Insert(Supplier supplier)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_supplier VALUES('" + supplier.SupplierCode + "','" + supplier.SupplierName +
                           "','" + supplier.SupplierAddress + "','" + supplier.SupplierOpeningBalance + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public Supplier GetNextSupplierCode()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_supplier ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Supplier supplier = new Supplier();
            while (reader.Read())
            {
                supplier.SupplierId = int.Parse(reader["id"].ToString());
                supplier.SupplierCode = reader["supplier_code"].ToString();
            }
            reader.Close();
            connection.Close();
            return supplier;
        }
    }
}