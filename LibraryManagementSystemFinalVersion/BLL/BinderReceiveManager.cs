using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class BinderReceiveManager
    {
        BinderReceiveGateway binderReceiveGateway = new BinderReceiveGateway();
        public List<Binder> GetAllBinderInfoByDropDownList()
        {
            return binderReceiveGateway.GetAllBinderInfoByDropDownList();
        }

        public List<Group> GetAllGroupInfoByDropDownList()
        {
            return binderReceiveGateway.GetAllGroupInfoByDropDownList();
        }

        public List<BookInfo> GetAllBookInfoByDropDownList()
        {
            return binderReceiveGateway.GetAllBookInfoByDropDownList();
        }

        public BinderReceive GetNextReceiveNo()
        {
            return binderReceiveGateway.GetNextReceiveNo();
        }

        public string Save(BinderReceive binderReceive)
        {
            if (binderReceiveGateway.Insert(binderReceive) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save Data in Database!!";
        }

        public List<BinderReceive> GetAllBinderReceive()
        {
            return binderReceiveGateway.GetAllBinderReceive();
        }

        public BinderReceive GetBinderReceive(int i)
        {
            return binderReceiveGateway.GetBinderReceive(i);
        }

        public BinderReceive GetSearchInfo(string s)
        {
            return binderReceiveGateway.GetSearchInfo(s);
        }

        public DataTable GetBinderReceiveReportData()
        {
            return binderReceiveGateway.GetBinderReceiveReportData();
        }
    }
}