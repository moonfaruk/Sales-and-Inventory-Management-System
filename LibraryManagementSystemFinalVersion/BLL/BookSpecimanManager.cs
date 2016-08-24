using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class BookSpecimanManager
    {
        BookSpecimanGateway bookSpecimanGateway = new BookSpecimanGateway();
        public List<District> GetAllDistrictByDropDownList()
        {
            return bookSpecimanGateway.GetAllDistrictByDropDownList();
        }

        public List<Party> GetAllPartiesByIdDropDownList()
        {
            return bookSpecimanGateway.GetAllPartiesByIdDropDownList();
        }

        public List<Group> GetAllGroupInfoByDropDownList()
        {
            return bookSpecimanGateway.GetAllGroupInfoByDropDownList();
        }

        public List<BookInfo> GetAllBookInfoByDropDownList()
        {
            return bookSpecimanGateway.GetAllBookInfoByDropDownList();
        }

        public BookSpeciman GetNextMemoNo()
        {
            return bookSpecimanGateway.GetNextMemoNo();
        }

        public BookInfo GetBookInfo(int i)
        {
            return bookSpecimanGateway.GetBookInfo(i);
        }

        public string Save(BookSpeciman bookSpeciman)
        {
            if (bookSpecimanGateway.Insert(bookSpeciman) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save data in Database!!";
        }

        public List<BookSpeciman> GetAllBookSpecimanList()
        {
            return bookSpecimanGateway.GetAllBookSpecimanList();
        }

        public BookSpeciman GetBookSpeciman(int i)
        {
            return bookSpecimanGateway.GetBookSpeciman(i);
        }

        public BookSpeciman GetSearchInfo(string s)
        {
            return bookSpecimanGateway.GetSearchInfo(s);
        }

        public DataTable GetBookSpecimanReportData()
        {
            return bookSpecimanGateway.GetBookSpecimanReportData();
        }
    }
}