using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class BinderManager
    {
        BinderGateway binderGateway = new BinderGateway();
        public string Save(Binder binder)
        {
            if (binderGateway.Insert(binder) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save Data in Database!!";
        }

        public List<Binder> GetAllBinderList()
        {
            return binderGateway.GetAllBinderList();
        }

        public Binder GetNextBinderCode()
        {
            return binderGateway.GetNextBinderCode();
        }

        public Binder GetBinder(int i)
        {
            return binderGateway.GetBinder(i);
        }

        public Binder GetSearchInfo(string s)
        {
            return binderGateway.GetSearchInfo(s);
        }
    }
}