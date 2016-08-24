using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class OthersGroup
    {
        public int OthersGroupId { get; set; }
        public string OtherGroupCode { get; set; }
        public string OtherGroupName { get; set; }
        public string OtherGroupRemarks { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public OthersGroup(string otherGroupCode, string otherGroupName, string otherGroupRemarks, string groupName)
        {
            OtherGroupCode = otherGroupCode;
            OtherGroupName = otherGroupName;
            OtherGroupRemarks = otherGroupRemarks;
            GroupName = groupName;
        }

        public OthersGroup()
        {
            
        }
    }
}