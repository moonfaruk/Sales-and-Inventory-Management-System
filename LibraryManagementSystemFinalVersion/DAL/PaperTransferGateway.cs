using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class PaperTransferGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementApp"].ConnectionString;
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

        public PaperTransfer GetNextTransferNo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_paperTransfer ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            PaperTransfer paperTransfer = new PaperTransfer();
            while (reader.Read())
            {
                paperTransfer.PaperTransferId = int.Parse(reader["id"].ToString());
                paperTransfer.TransferNo = reader["transfer_no"].ToString();
            }
            reader.Close();
            connection.Close();
            return paperTransfer;
        }

        public int Insert(PaperTransfer paperTransfer)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_paperTransfer VALUES('" + paperTransfer.Date + "','" +
                           paperTransfer.TransferNo + "','" + paperTransfer.FromPressId + "','"+paperTransfer.ToPressId+"','" + paperTransfer.PaperId +
                           "','" + paperTransfer.PaperType + "','" + paperTransfer.Quantity + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}