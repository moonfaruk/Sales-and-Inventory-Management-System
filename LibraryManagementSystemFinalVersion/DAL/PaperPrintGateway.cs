using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.DAL
{
    public class PaperPrintGateway
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

        public PaperPrint GetNextOrderNo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * FROM tbl_paperPrint ORDER BY id DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            PaperPrint paperPrint = new PaperPrint();
            while (reader.Read())
            {
                paperPrint.PaperPrintId = int.Parse(reader["id"].ToString());
                paperPrint.OrderNo = reader["order_no"].ToString();
            }
            reader.Close();
            connection.Close();
            return paperPrint;
        }

        public int Insert(PaperPrint paperPrint)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO tbl_paperPrint VALUES('" + paperPrint.Date + "','" + paperPrint.OrderNo + "','" +
                           paperPrint.PressId + "','" + paperPrint.Year + "','" + paperPrint.PrintingType + "','" +
                           paperPrint.GroupId + "','" + paperPrint.BookId + "','" + paperPrint.Plate + "','" +
                           paperPrint.Forma + "','" + paperPrint.FormaType + "','" + paperPrint.ColorType + "','" +
                           paperPrint.PaperId + "','" + paperPrint.PaperType + "','" + paperPrint.BookQuantity + "','" +
                           paperPrint.PaperQuantity + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<PaperPrint> GetAllPaperPrint()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_paperPrint";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<PaperPrint> paperPrintList = new List<PaperPrint>();
            while (reader.Read())
            {
                PaperPrint paperPrint = new PaperPrint();
                GetValueFromDatabase(paperPrint, reader);

                paperPrintList.Add(paperPrint);
            }
            reader.Close();
            connection.Close();
            return paperPrintList;
        }

        private static void GetValueFromDatabase(PaperPrint paperPrint, SqlDataReader reader)
        {
            paperPrint.PaperPrintId = int.Parse(reader["id"].ToString());
            paperPrint.Date = reader["date"].ToString();
            paperPrint.OrderNo = reader["order_no"].ToString();
            paperPrint.PressName = reader["press_id"].ToString();
            paperPrint.Year = reader["year"].ToString();
            paperPrint.PrintingType = reader["printing_type"].ToString();
            paperPrint.GroupName = reader["group_id"].ToString();
            paperPrint.BookName = reader["book_id"].ToString();
            paperPrint.Plate = Convert.ToDouble(reader["plate"].ToString());
            paperPrint.Forma = Convert.ToDouble(reader["forma"].ToString());
            paperPrint.FormaType = reader["forma_type"].ToString();
            paperPrint.ColorType = reader["color_type"].ToString();
            paperPrint.PaperName = reader["paper_id"].ToString();
            paperPrint.PaperType = reader["paper_type"].ToString();
            paperPrint.BookQuantity = Convert.ToDouble(reader["book_quantity"].ToString());
            paperPrint.PaperQuantity = Convert.ToDouble(reader["paper_quantity"].ToString());
        }

        public PaperPrint GetPaperPrint(int i)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM tbl_paperPrint ORDER BY id ASC OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            PaperPrint paperPrint = new PaperPrint();
            while (reader.Read())
            {
                GetValueFromDatabase(paperPrint, reader);
            }
            reader.Close();
            connection.Close();
            return paperPrint;
        }
    }
}