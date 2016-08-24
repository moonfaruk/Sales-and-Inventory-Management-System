using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class BinderOrderCancelManager
    {
        BinderOrderCancelGateway binderOrderCancelGateway = new BinderOrderCancelGateway();
        public List<Binder> GetAllBinderInfoByDropDownList()
        {
            return binderOrderCancelGateway.GetAllBinderInfoByDropDownList();
        }

        public List<Group> GetAllGroupInfoByDropDownList()
        {
            return binderOrderCancelGateway.GetAllGroupInfoByDropDownList();
        }

        public List<BookInfo> GetAllBookInfoByDropDownList()
        {
            return binderOrderCancelGateway.GetAllBookInfoByDropDownList();
        }

        public BinderOrderCancel GetNextOrderNo()
        {
            return binderOrderCancelGateway.GetNextOrderNo();
        }

        public string Save(BinderOrderCancel binderOrderCancel)
        {
            if (binderOrderCancelGateway.Insert(binderOrderCancel) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save Data in Database!!";
        }

        public List<BinderOrderCancel> GetAllBinderOrderCancel()
        {
            return binderOrderCancelGateway.GetAllBinderOrderCancel();
        }

        public BinderOrderCancel GetBinderOrderCancel(int i)
        {
            return binderOrderCancelGateway.GetBinderOrderCancel(i);
        }
    }
}