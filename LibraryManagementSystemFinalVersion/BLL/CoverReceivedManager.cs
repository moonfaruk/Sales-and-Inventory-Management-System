using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class CoverReceivedManager
    {
        CoverReceivedGateway coverReceivedGateway = new CoverReceivedGateway();
        public List<Group> GetAllGroupInfoByDropDownList()
        {
            return coverReceivedGateway.GetAllGroupInofByDropDownList();
        }

        public List<BookInfo> GetAllBookInfoByDropDownList()
        {
            return coverReceivedGateway.GetAllBookInfoByDropDownList();
        }

        public CoverReceived GetNextReceiveNo()
        {
            return coverReceivedGateway.GetNextReceiveNo();
        }

        public string Save(CoverReceived coverReceived)
        {
            if (coverReceivedGateway.Insert(coverReceived) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could not Save Data in Database!!";
        }

        public List<CoverReceived> GetAllCoverReceived()
        {
            return coverReceivedGateway.GetAllCoverReceived();
        }

        public CoverReceived GetCovers(int i)
        {
            return coverReceivedGateway.GetCovers(i);
        }

        public CoverReceived GetSearchInfo(string s)
        {
            return coverReceivedGateway.GetSearchInfo(s);
        }

        public DataTable GetCoverReceivedReportData()
        {
            return coverReceivedGateway.GetCoverReceivedReportData();
        }
    }
}