using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class BookReturnManager
    {
        BookReturnGateway bookReturnGateway = new BookReturnGateway();
        public List<District> GetAllDistrictByDropDownList()
        {
            return bookReturnGateway.GetAllDistrictByDropDownList();
        }

        public List<Party> GetAllPartiesByIdDropDownList()
        {
            return bookReturnGateway.GetAllPartiesByIdDropDownList();
        }

        public List<Group> GetAllGroupInfoByDropDownList()
        {
            return bookReturnGateway.GetAllGroupInfoByDropDownList();
        }

        public List<BookInfo> GetAllBookInfoByDropDownList()
        {
            return bookReturnGateway.GetAllBookInfoByDropDownList();
        }

        public BookReturn GetNextReturnNo()
        {
            return bookReturnGateway.GetNextReturnNo();
        }

        public BookInfo GetBookReturn(int i)
        {
            return bookReturnGateway.GetBookReturn(i);
        }

        public string Save(BookReturn bookReturn)
        {
            if (bookReturnGateway.Insert(bookReturn) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save data in Database!!";
        }

        public List<BookReturn> GetAllBookReturnList()
        {
            return bookReturnGateway.GetAllBookReturnList();
        }

        public BookReturn GetReturns(int i)
        {
            return bookReturnGateway.GetReturns(i);
        }

        public BookReturn GetSearchInfo(string s)
        {
            return bookReturnGateway.GetSearchInfo(s);
        }

        public DataTable GetBookReturnReportData()
        {
            return bookReturnGateway.GetBookReturnReportData();
        }
    }
}