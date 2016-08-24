using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class BookRejectManager
    {
        BookRejectGateway bookRejectGateway = new BookRejectGateway();
        public List<District> GetAllDistrictByDropDownList()
        {
            return bookRejectGateway.GetAllDistrictByDropDownList();
        }

        public List<Party> GetAllPartiesByIdDropDownList()
        {
            return bookRejectGateway.GetAllPartiesByIdDropDownList();
        }

        public List<Group> GetAllGroupInfoByDropDownList()
        {
            return bookRejectGateway.GetAllGroupInfoByDropDownList();
        }

        public List<BookInfo> GetAllBookInfoByDropDownList()
        {
            return bookRejectGateway.GetAllBookInfoByDropDownList();
        }

        public BookReject GetNextRejectNo()
        {
            return bookRejectGateway.GetNextRejectNo();
        }

        public BookInfo GetRejectBook(int i)
        {
            return bookRejectGateway.GetRejectBook(i);
        }

        public List<BookReject> GetAllBookRejectList()
        {
            return bookRejectGateway.GetAllBookRejectList();
        }

        public BookReject GetBookReject(int i)
        {
            return bookRejectGateway.GetBookReject(i);
        }

        public BookReject GetSearchInfo(string s)
        {
            return bookRejectGateway.GetSearchInfo(s);
        }

        public string Save(BookReject bookReject)
        {
            if (bookRejectGateway.Insert(bookReject) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save data in Database!!";
        }
    }
}