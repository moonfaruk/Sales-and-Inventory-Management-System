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
    public class PaperOrderGateway
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
                press.PressCode = reader["press_code"].ToString();
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
            SqlDataReader reader = command.ExecuteReader();
            List<Paper> paeprList = new List<Paper>();
            while (reader.Read())
            {
                Paper paper = new Paper();
                paper.PaperId = int.Parse(reader["id"].ToString());
                paper.PaperName = reader["paper_name"].ToString();
                paeprList.Add(paper);
            }
            reader.Close();
            connection.Close();
            return paeprList;
        }

        public PaperOrder GetNextSlipNo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_paperOrder ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            PaperOrder paperOrder = new PaperOrder();
            while (reader.Read())
            {
                paperOrder.PaperOrderId = int.Parse(reader["id"].ToString());
                paperOrder.SlipNo = reader["slip_no"].ToString();

            }
            reader.Close();
            connection.Close();
            return paperOrder;
        }

        public int Insert(PaperOrder paperOrder)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_paperOrder  VALUES('" + paperOrder.Date + "','" + paperOrder.SupplierId +
                           "','" + paperOrder.SlipNo + "','" + paperOrder.PressId + "','" + paperOrder.PaperId + "','" +
                           paperOrder.PaperType + "','" + paperOrder.Quantity + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<PaperOrder> GetAllPaperOrder()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_paperOrder";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<PaperOrder> paperOrderList = new List<PaperOrder>();
            while (reader.Read())
            {
                PaperOrder paperOrder = new PaperOrder();
                GetValueFromDatabase(paperOrder, reader);

                paperOrderList.Add(paperOrder);
            }
            reader.Close();
            connection.Close();
            return paperOrderList;
        }

        private static void GetValueFromDatabase(PaperOrder paperOrder, SqlDataReader reader)
        {
            paperOrder.PaperOrderId = int.Parse(reader["id"].ToString());
            paperOrder.Date = reader["date"].ToString();
            paperOrder.SupplierName = reader["supplier_id"].ToString();
            paperOrder.SlipNo = reader["slip_no"].ToString();
            paperOrder.PressCode = reader["press_id"].ToString();
            paperOrder.PaperName = reader["paper_id"].ToString();
            paperOrder.PaperType = reader["paper_type"].ToString();
            paperOrder.Quantity = Convert.ToDouble(reader["quantity"].ToString());
        }

        public PaperOrder GetPaperOrder(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_paperOrder ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            PaperOrder paperOrder = new PaperOrder();
            while (reader.Read())
            {
                GetValueFromDatabase(paperOrder, reader);
            }
            reader.Close();
            connection.Close();
            return paperOrder;
        }

        public DataTable GetPaperOrderReportData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_paperOrderView";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);
            connection.Close();
            return dt;
        }
    }
}