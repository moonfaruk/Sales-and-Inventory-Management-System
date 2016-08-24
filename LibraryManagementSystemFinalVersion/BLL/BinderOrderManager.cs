using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class BinderOrderManager
    {
        BinderOrderGateway binderOrderGateway = new BinderOrderGateway();
        public List<Binder> GetAllBinderInfoByDropDownList()
        {
            return binderOrderGateway.GetAllBinderInfoByDropDownList();
        }

        public List<Group> GetAllGroupInfoByDropDownList()
        {
            return binderOrderGateway.GetAllGroupInfoByDropDownList();
        }

        public List<BookInfo> GetAllBookInfoByDropDownList()
        {
            return binderOrderGateway.GetAllBookInfoByDropDownList();
        }

        public List<Press> GetAllPressInfoByDropDownList()
        {
            return binderOrderGateway.GetAllPressInfoByDropDownList();
        }

        public BinderOrder GetNextOrderNo()
        {
            return binderOrderGateway.GetNextOrderNo();
        }

        public string Save(BinderOrder binderOrder)
        {
            if (binderOrderGateway.Insert(binderOrder) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save data in Database!!";
        }

        public List<BinderOrder> GetAllBinderOrder()
        {
            return binderOrderGateway.GetAllBinderOrder();
        }

        public BinderOrder GetBinderOrder(int i)
        {
            return binderOrderGateway.GetBinderOrder(i);
        }

        public DataTable GetBinderOrderReportData()
        {
            return binderOrderGateway.GetBinderOrderReportData();
        }
    }
}