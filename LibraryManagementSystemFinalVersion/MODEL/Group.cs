using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }

        public Group(string groupCode, string groupName)
        {
            GroupCode = groupCode;
            GroupName = groupName;
        }

        public Group()
        {
            
        }
    }
}