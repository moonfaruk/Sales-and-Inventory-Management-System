using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class MainBookManager
    {
        MainBookGateway mainBookGateway = new MainBookGateway();
        public string Save(MainBook mainBook)
        {
            if (mainBookGateway.Insert(mainBook) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save Data in Database!!";
        }

        public MainBook GetNextCode()
        {
            return mainBookGateway.GetNextCode();
        }

        public List<MainBook> GetAllMainBook()
        {
            return mainBookGateway.GetAllMainBook();
        }

        public MainBook GetMainBooks(int i)
        {
            return mainBookGateway.GetMainBooks(i);
        }
    }
}