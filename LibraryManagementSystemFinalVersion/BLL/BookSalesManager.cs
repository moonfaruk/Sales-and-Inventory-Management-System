using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class BookSalesManager
    {
        BookSalesGateway bookSalesGateway = new BookSalesGateway();
        public List<District> GetAllDistrictByDropDownList()
        {
            return bookSalesGateway.GetAllDistrictByDropDownList();
        }

        public List<Party> GetAllPartiesByIdDropDownList()
        {
            return bookSalesGateway.GetAllPartiesByIdDropDownList();
        }

        public List<Group> GetAllGroupInfoByDropDownList()
        {
            return bookSalesGateway.GetAllGroupInfoByDropDownList();
        }

        public List<BookInfo> GetAllBookInfoByDropDownList()
        {
            return bookSalesGateway.GetAllBookInfoByDropDownList();
        }

        public BookInfo GetBookInfo(int i)
        {
            return bookSalesGateway.GetBookInfo(i);
        }

        public BookSales GetNextMemoNo()
        {
            return bookSalesGateway.GetNextMemoNo();
        }

        public string Save(BookSales bookSales)
        {
            if (bookSalesGateway.Insert(bookSales) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save data in Database!!";
        }

        public List<BookSales> GetAllBookSalesList()
        {
            return bookSalesGateway.GetAllBookSalesList();
        }

        public BookSales GetBookSales(int i)
        {
            return bookSalesGateway.GetBookSales(i);
        }

        public BookSales GetSearchInfo(string s)
        {
            return bookSalesGateway.GetSearchInfo(s);
        }

        public DataTable GetBookSalesReportData()
        {
            return bookSalesGateway.GetBookSalesReportData();
        }
    }
}