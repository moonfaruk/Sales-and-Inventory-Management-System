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
    public class SupplierBillEntryGateway
    {
         string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;

        public List<Supplier> GetSupplierInfoByDropDownList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_supplier";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Supplier> supplierList = new List<Supplier>();
            while (reader.Read())
            {
                Supplier supplier = new Supplier();
                supplier.SupplierId = int.Parse(reader["id"].ToString());
                supplier.SupplierName = reader["supplier_name"].ToString();
                supplierList.Add(supplier);
            }
            reader.Close();
            connection.Close();
            return supplierList;
        }

        public List<Press> GetAllPressInfoByDropDownList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_press";
            SqlCommand command = new SqlCommand(query, connection);
            List<Press> pressList = new List<Press>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
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

        public List<Paper> GetAllPaperInfoByDropDownList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_paper";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            List<Paper> paperList = new List<Paper>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Paper paper = new Paper();
                paper.PaperId = int.Parse(reader["id"].ToString());
                paper.PaperName = reader["paper_name"].ToString();
                paperList.Add(paper);
            }
            reader.Close();
            connection.Close();
            return paperList;
        }

        public SupplierBillEntry GetNextBillNo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_supplier_bill_entry ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            SupplierBillEntry supplierBillEntry = new SupplierBillEntry();
            while (reader.Read())
            {
                supplierBillEntry.SupplierBillEntryId = int.Parse(reader["id"].ToString());
                supplierBillEntry.BillNo = reader["bill_no"].ToString();
            }
            reader.Close();
            connection.Close();
            return supplierBillEntry;
        }

        public int Insert(SupplierBillEntry supplierBillEntry)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_supplier_bill_entry VALUES('" + supplierBillEntry.SupplierDate + "','" +
                           supplierBillEntry.SupplierBillDate + "','" + supplierBillEntry.BillNo + "','" +
                           supplierBillEntry.SupplierType + "','" + supplierBillEntry.SupplierId + "','" +
                           supplierBillEntry.PressId + "','" + supplierBillEntry.PaperId + "','" +
                           supplierBillEntry.PaperType + "','" + supplierBillEntry.PaperQuantity + "','" +
                           supplierBillEntry.Prize + "','" + supplierBillEntry.Description + "','" +
                           supplierBillEntry.BillAmount + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }

        public List<SupplierBillEntry> GetAllSupplierBillEntryList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from tbl_supplier_bill_entry";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<SupplierBillEntry> supplierBillEntryList = new List<SupplierBillEntry>();
            while (reader.Read())
            {
                SupplierBillEntry supplierBillEntry = new SupplierBillEntry();
                GetValueFromDatabase(supplierBillEntry, reader);

                supplierBillEntryList.Add(supplierBillEntry);
            }
            reader.Close();
            connection.Close();
            return supplierBillEntryList;
        }

        private static void GetValueFromDatabase(SupplierBillEntry supplierBillEntry, SqlDataReader reader)
        {
            supplierBillEntry.SupplierBillEntryId = int.Parse(reader["id"].ToString());
            supplierBillEntry.SupplierDate = reader["supplier_date"].ToString();
            supplierBillEntry.SupplierBillDate = reader["bill_date"].ToString();
            supplierBillEntry.BillNo = reader["bill_no"].ToString();
            supplierBillEntry.SupplierType = reader["supplier_type"].ToString();
            supplierBillEntry.SupplierId = int.Parse(reader["supplier_id"].ToString());
            supplierBillEntry.PressId = int.Parse(reader["press_id"].ToString());
            supplierBillEntry.PaperId = int.Parse(reader["paper_id"].ToString());
            supplierBillEntry.PaperType = reader["paper_type"].ToString();
            supplierBillEntry.PaperQuantity = Convert.ToDouble(reader["paper_quantity"].ToString());
            supplierBillEntry.Prize = Convert.ToDouble(reader["prize"].ToString());
            supplierBillEntry.Description = reader["description"].ToString();
            supplierBillEntry.BillAmount = Convert.ToDouble(reader["bill_amount"].ToString());
        }

        public SupplierBillEntry GetSupplierBillEntities(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_supplier_bill_entry ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            SupplierBillEntry supplierBillEntry = new SupplierBillEntry();
            while (reader.Read())
            {
                GetValueFromDatabase(supplierBillEntry, reader);
            }
            reader.Close();
            connection.Close();
            return supplierBillEntry;

        }

        public DataTable GetSupplierBillReportData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_supplier_bill_entry ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            connection.Close();
            return dt;
        }

        
    }
}