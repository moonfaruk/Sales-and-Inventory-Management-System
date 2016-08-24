using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class OtherGroupManager
    {
        OtherGroupGateway otherGroupGateway = new OtherGroupGateway();
        public string Save(OthersGroup othersGroup)
        {
            if (otherGroupGateway.Insert(othersGroup) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save data in Database!!";
        }

        public OthersGroup GetNextCode()
        {
            return otherGroupGateway.GetNextCode();
        }

        public List<OthersGroup> GetAllOthersGroup()
        {
            return otherGroupGateway.GetAllOthersGroup();
        }

        public List<Group> GetAllGroupByDropDownList()
        {
            return otherGroupGateway.GetAllGroupByDropDownList();
        }

        public OthersGroup GetLastGroup()
        {
            return otherGroupGateway.GetLastGroup();
        }

        public OthersGroup GetSearchInfo(string oGroup)
        {
            return otherGroupGateway.GetSearchInfo(oGroup);
        }
    }
}