using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class GroupManager
    {
        GroupGateway groupGateway = new GroupGateway();
        public string Save(Group group)
        {
            if (groupGateway.Insert(group) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save data In Database!!";
        }

        public Group GetNextGroupCode()
        {
            return groupGateway.GetNextGroupCode();
        }

        public Group GetLastGroup()
        {
            return groupGateway.GetLastGroup();
        }

        public Group GetSearchInfo(string s)
        {
            return groupGateway.GetSearchInfo(s);
        }
    }
}