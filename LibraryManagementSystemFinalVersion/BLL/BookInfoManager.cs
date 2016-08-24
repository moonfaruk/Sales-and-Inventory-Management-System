using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class BookInfoManager
    {
        BookInfoGateway bookInfoGateway = new BookInfoGateway();
        public List<Press> GetAllPressListByDropDownList()
        {
            return bookInfoGateway.GetAllPressListByDropDownList();
        }

        public List<Binder> GetAllBinderByDropDownList()
        {
            return bookInfoGateway.GetAllBinderByDropDownList();
        }

        public string Save(BookInfo bookInfo)
        {
            if (bookInfoGateway.Insert(bookInfo) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save data in Database!!";
        }

        public BookInfo GetNextBookCode()
        {
            return bookInfoGateway.GetNextBookCode();
        }

        public List<BookInfo> GetAllBookInfo()
        {
            return bookInfoGateway.GetAllBookInfo();
        }

        public BookInfo GetBooks(int i)
        {
            return bookInfoGateway.GetBooks(i);
        }

        public BookInfo GetSearchInfo(string book)
        {
            return bookInfoGateway.GetSearchInfo(book);
        }

        public List<MainBook> GetAllMainBookByDropDownList()
        {
            return bookInfoGateway.GetAllMainBookByDropDownList();
        }
    }
}